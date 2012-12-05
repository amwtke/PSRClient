using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Db4objects.Db4o;

namespace APP
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            #region 左菜单
            TreeNodeHelper.RefreshTreeView<RootNode, Node>(treeView1,ref saver_left, "admin");
            treeView1.ContextMenuStrip = contextMenuStrip1;
            #endregion

            #region auth
            TreeNodeHelper.RefreshTreeView<AuthorizationTree, AuthorizationNode>(treeView3, ref saver_auth, "admin");
            treeView3.ContextMenuStrip = contextMenuStrip2;
            #endregion 

            #region UI
            TreeNodeHelper.RefreshTreeView<TreeOfForms, FormNode>(treeView2, ref saver, "admin");
            //PaintTreeView<TreeOfForms, FormNode> p = new PaintTreeView<TreeOfForms, FormNode>(treeView2);
            //_rootForm = p.ShowTreeView("admin");
            //if (_rootForm == null)
            //    _rootForm = new TreeOfForms();
            //_rootForm.RootValue = "admin";
            //saver = new GenViewToDB<TreeOfForms, FormNode>(_rootForm);
            #endregion
            treeView1.ExpandAll(); treeView3.ExpandAll(); treeView3.CheckBoxes = false;
        }

        GenViewToDB<TreeOfForms, FormNode> saver;
        GenViewToDB<RootNode, Node> saver_left;
        GenViewToDB<AuthorizationTree, AuthorizationNode> saver_auth;

         TreeOfForms _rootForm;
         
         void RefreshUIAuthorization()
         {
             ProcessControl p = new ProcessControl(addnode);

             //获取Form
             Form[] forms = CommonHelper.GenTypesObjectFromAssembly<Form>("Form");

             _rootForm = new TreeOfForms();
             _rootForm.CheckBox = true;
             _rootForm.RootValue = "admin";
             saver = new GenViewToDB<TreeOfForms, FormNode>(_rootForm);

             //录入Form
             foreach (Form f in forms)
             {
                 CommonHelper.ControlRecusive(f, p);
             }
             saver.SaveToDb();
         }
         private void button1_Click(object sender, EventArgs e)
         {
             ProcessControl p = new ProcessControl(addnode);

             //获取Form
             Form[] forms = CommonHelper.GenTypesObjectFromAssembly<Form>("Form");

             _rootForm = new TreeOfForms();
             _rootForm.CheckBox = true;
             _rootForm.RootValue = "admin";
             saver = new GenViewToDB<TreeOfForms, FormNode>(_rootForm);

             //录入Form
             foreach (Form f in forms)
             {
                 CommonHelper.ControlRecusive(f, p);
             }
             saver.SaveToDb();
         }

        void addnode(Control c)
        {
            if (c.Parent != null)
            {
                FormNode Node = new FormNode();
                Node.Checked = true;
                Node.BackColor = Color.White;
                Node.ControlType = "";
                Node.NodeName = c.Name;
                saver.AddNode(c.Parent.Name, Node);
            }
            else
            {
                FormNode Node = new FormNode();
                Node.Checked = false;
                Node.BackColor = Color.Red;
                Node.ControlType = "";
                Node.NodeName = c.Name;
                saver.AddNode(null, Node);
            }
        }

        #region treeview1

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RootNode _root = new RootNode();
            _root.RootValue = "admin";
            GenViewToDB<RootNode, Node> _saver = new GenViewToDB<RootNode, Node>(_root);
            int facilityNo = 1;
            int yaosuNo = 1;
            int zhuantiNo = 1;
            foreach (KeyValuePair<string,string> pair in FacilityName.FacilityAndDescription)
            {
                Node node = new Node();
                node.NodeName = facilityNo.ToString() + "." + FacilityName.GetFacilityNO(pair.Value);
                _saver.AddNode(null, node);
                yaosuNo = 1;
                foreach (string yaosu in YaoSuManager.YaoSus)
                {
                    Node child = new Node();
                    child.NodeName = facilityNo.ToString()+"."+yaosuNo.ToString()+"."+YaoSuManager.GetYaoSuBianHao(yaosu);
                    child.ControlType = "APP.RecordQueryTab";
                    _saver.AddNode(node.NodeName, child);
                    yaosuNo++;

                    if (ZhuanTiManager.ZhuanTis.ContainsKey(yaosu))
                    {
                        zhuantiNo = 1;
                        foreach (string zhuanti in ZhuanTiManager.ZhuanTis[yaosu])
                        {
                            Node zhuantiNode = new Node();
                            zhuantiNode.NodeName = facilityNo.ToString() + "." + yaosuNo.ToString() + "." + zhuantiNo.ToString() + "." + ZhuanTiManager.GetSubjectNO(zhuanti);
                            zhuantiNode.ControlType = "APP.RecordQueryTab";
                            _saver.AddNode(child.NodeName, zhuantiNode);
                            zhuantiNo++;
                        }
                    }
                }
                facilityNo++;
            }
            _saver.SaveToDb();

            treeView1.Nodes.Clear();
            //TreeNodeHelper.RefreshTreeView<RootNode,Node>(treeView1,ref _saver,"admin");
            TreeNodeHelper.RefreshTreeView<RootNode, Node>(treeView1, ref saver_left, "admin");
        }

        private void 同级添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNodeForm addNodeForm ;
            if (treeView1.SelNode == null || treeView1.SelNode.Level == 0)
            {
                addNodeForm = new AddNodeForm(this, 0, true);
                if (addNodeForm.ShowDialog() != DialogResult.Cancel)
                    TreeNodeHelper.AddNodeSameLevel<RootNode, Node>(treeView1, this.innerNode, saver_left);
            }
            else if (treeView1.SelNode.Level < 3)
            {
                addNodeForm = new AddNodeForm(this, treeView1.SelNode.Level, true);
                if (addNodeForm.ShowDialog() != DialogResult.Cancel)
                    TreeNodeHelper.AddNodeSameLevel<RootNode, Node>(treeView1, this.innerNode, saver_left);
            }
        }

        private void 下级添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNodeForm addNodeForm;
            if (treeView1.SelNode == null || treeView1.SelNode.Level == 0)
            {
                addNodeForm = new AddNodeForm(this, 0, false);
                if(addNodeForm.ShowDialog()!=DialogResult.Cancel)
                    TreeNodeHelper.AddNodeNextLevel<RootNode, Node>(treeView1, this.innerNode, saver_left);
            }
            else if(treeView1.SelNode.Level<2)
            {
                addNodeForm = new AddNodeForm(this, treeView1.SelNode.Level, false);
                if (addNodeForm.ShowDialog() != DialogResult.Cancel)
                    TreeNodeHelper.AddNodeNextLevel<RootNode, Node>(treeView1, this.innerNode, saver_left);
            }
            else if (treeView1.SelNode.Level == 2)
            {
                MessageBox.Show("不能添加第四级目录！");
            }
            
        }

        private void 删除选中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定？", "删除", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TreeNodeHelper.DeleteSelectedNode<RootNode, Node>(treeView1, saver_left);
            }
        }

        public string ImportedToUser;
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectUserForm _select = new SelectUserForm(this);
            if (_select.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(ImportedToUser))
                {
                    saver_left.root.RootValue = ImportedToUser;//textBox_user.Text.Trim();
                    saver_left.SaveToDb(treeView1);

                    treeView1.Nodes.Clear();
                    TreeNodeHelper.RefreshTreeView<RootNode, Node>(treeView1, ref saver_left, ImportedToUser);
                    textBox_user.Text = ImportedToUser;
                }
                else
                    MessageBox.Show("没有输入要导入的用户！");
            }
            
        }

        private void 修改当前节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelNode != null)
            {
                string oldName;
                Node node;
                if (treeView1.SelNode.Level == 0)
                {
                    node = saver_left.GetNodeByParentAddingTimeOnly(null, treeView1.SelNode.Text);
                   
                }
                else
                {
                    node = saver_left.GetNodeByParentAddingTimeOnly(treeView1.SelNode.Parent.Text, treeView1.SelNode.Text);
                }
                oldName = node.NodeName;
                AddNodeForm addForm = new AddNodeForm(node, this,treeView1.SelNode.Level);
                addForm.ShowDialog();
                TreeNodeHelper.UpdateNodeDictionaryKeyName(saver_left.ParentAndMe, oldName, node.NodeName);

                treeView1.SelNode.Text = node.NodeName;
                treeView1.SelNode.BackColor = node.BackColor;

            }
            treeView1.ExpandAll();
        }
        public Node innerNode;

        #endregion

        #region treeview3
        public AuthorizationNode innerAuthNode;


        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CommonHelper.SetChildNodeChecked(e.Node, e.Node.Checked);

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
                treeView1.ContextMenuStrip.Show();
        }

        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CommonHelper.SetChildNodeChecked(e.Node, e.Node.Checked);
        }

        private void 同级加入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAuthorizationTree addNodeForm = new AddAuthorizationTree(this);
            addNodeForm.ShowDialog();
            TreeNodeHelper.AddNodeSameLevel<AuthorizationTree, AuthorizationNode>(treeView3, this.innerAuthNode, saver_auth);
        }

        private void 下级加入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAuthorizationTree addNodeForm = new AddAuthorizationTree(this);
            addNodeForm.ShowDialog();

            TreeNodeHelper.AddNodeNextLevel<AuthorizationTree, AuthorizationNode>(treeView3, this.innerAuthNode, saver_auth);
        }

        private void 修改节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView3.SelectedNode != null)
            {
                string oldNodeName;
                AuthorizationNode node;
                if (treeView3.SelectedNode.Level == 0)
                {
                    node = saver_auth.GetNodeByParentAddingTimeOnly(null, treeView3.SelectedNode.Text);
                    
                }
                else
                {
                    node = saver_auth.GetNodeByParentAddingTimeOnly(treeView3.SelectedNode.Parent.Text, treeView3.SelectedNode.Text);
                }

                oldNodeName = node.NodeName;
                AddAuthorizationTree addNodeForm = new AddAuthorizationTree(node, this);
                addNodeForm.ShowDialog();

                TreeNodeHelper.UpdateNodeDictionaryKeyName(saver_auth.ParentAndMe, oldNodeName, node.NodeName);

                treeView3.SelectedNode.Text = node.NodeName;
                treeView3.SelectedNode.BackColor = node.BackColor;
            }
            treeView3.ExpandAll();
        }

        private void 删除节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定？", "删除", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TreeNodeHelper.DeleteSelectedNode<AuthorizationTree, AuthorizationNode>(treeView3, saver_auth);
            }
        }

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saver_auth.SaveToDb(treeView3);
            MessageBox.Show("保存成功！");
        }

        private void treeView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                treeView3.ContextMenuStrip.Show();
        }

        private void treeView3_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CommonHelper.SetChildNodeChecked(e.Node, e.Node.Checked);
        }

        private void 删除全表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        #endregion

        #region treeview2
        private void button2_Click(object sender, EventArgs e)
        {
            saver.SaveToDb(treeView2);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView2.Nodes.Clear();
            RefreshUIAuthorization();
            PaintTreeView<TreeOfForms, FormNode> _p = new PaintTreeView<TreeOfForms, FormNode>(treeView2);
            _rootForm = _p.ShowTreeView("admin");
            if (_rootForm == null) _rootForm = new TreeOfForms();
            _rootForm.RootValue = "admin";
            //刷新saver
            saver = new GenViewToDB<TreeOfForms, FormNode>(_rootForm);
        }

        private void 保存ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //if (_rootForm != null && _rootForm.ChildNodes.Length > 0)
            
                saver.SaveToDb(treeView2);
            
        }

        private void 加入特殊人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode != null)
            {
                if (treeView2.SelectedNode.Level == 0)
                {
                    FormNode n = saver.GetNodeByParentAddingTimeOnly(null, treeView2.SelectedNode.Text);
                    AddUIInform form = new AddUIInform(n, this);
                    form.ShowDialog();
                }
                else
                {
                    FormNode n = saver.GetNodeByParentAddingTimeOnly(treeView2.SelectedNode.Parent.Text, treeView2.SelectedNode.Text);
                    AddUIInform form = new AddUIInform(n, this);
                    form.ShowDialog();
                }

                //treeView2.ExpandAll();
            }
        }
        public FormNode innerFormNode;
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button_adduser_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();
            user.ShowDialog();
        }

        public string RecordStatus;
        public string ImportUserName;
        private void button_importData_Click(object sender, EventArgs e)
        {
            ImportUserAndStatusForm _select = new ImportUserAndStatusForm(this);
            //if (_select.ShowDialog() == DialogResult.OK)
            //{
            //    openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        DBHelper.TransferData(ImportUserName, RecordStatus, openFileDialog1.FileName);
            //    }
            //}

            //直接弹出选择数据文件对话框，导入全部状态下的数据
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strImportYapFile=openFileDialog1.FileName;
                DBHelper.TransferData(strImportYapFile);
            }
        }

        private void textBox_user_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textBox_user.Text))
                {
                    treeView1.Nodes.Clear();
                    TreeNodeHelper.RefreshTreeView<RootNode, Node>(treeView1, ref saver_left, textBox_user.Text);
                }
            }

        }

        private void bt_refreshBaseTable_Click(object sender, EventArgs e)
        {
            try
            {
                TreeInforAttribute[] _atts = DBHelper.GetTreeInfoAttribute(typeof(RootNode));
                string _dbname = "";
                if (_atts != null && _atts.Length >= 0)
                {
                    _dbname = _atts[0].DBName;
                    IObjectContainer _db = DBHelper.InitDB4O(_dbname, typeof(RootNode));
                    RootNode _r = new RootNode();
                    RootNode[] roots = DBHelper.FindByExample<RootNode>(_db, _r);
                    _db.Close();
                    if (roots != null && roots.Length > 0)
                    {
                        foreach (RootNode r in roots)
                        {
                            //GenViewToDB<RootNode, Node> saver = new GenViewToDB<RootNode, Node>(r);
                            if (r != null && r.ChildNodes != null && r.ChildNodes.Length > 0)
                            {
                                foreach (Node child in r.ChildNodes)
                                {
                                    processNode2(child);
                                }
                                //saver.SaveToDb();
                                _db = DBHelper.InitDB4O(_dbname, typeof(RootNode));
                                DBHelper.UpdateFromDB(_db, r);
                                _db.Close();
                            }
                        }
                        MessageBox.Show("更新完毕！");
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private void processNode(Node node, GenViewToDB<RootNode, Node> __saver)
        {
            if (node.NodeName.Contains("秦山地区一厂"))
                __saver.DeleteNode(null, node.NodeName);
            if (node.NodeName.Contains("秦山地区二厂"))
                __saver.DeleteNode(null, node.NodeName);

            if (node.NodeName.Contains("方家山"))
            {
                string oldName = node.NodeName;
                node.NodeName = "秦山核电厂扩建项目（方家山核电工程）";
                TreeNodeHelper.UpdateNodeDictionaryKeyName(__saver.ParentAndMe, oldName, "秦山核电厂扩建项目（方家山核电工程）");
            }

            if (node.NodeName.Contains("1、2"))
            {
                string oldName = node.NodeName;
                node.NodeName = "秦山第二核电厂1、2号机组";
                TreeNodeHelper.UpdateNodeDictionaryKeyName(__saver.ParentAndMe, oldName, "秦山第二核电厂1、2号机组");
            }

            if (node.NodeName.Contains("3、4"))
            {
                string oldName = node.NodeName;
                node.NodeName = "秦山第二核电厂3、4号机组";
                TreeNodeHelper.UpdateNodeDictionaryKeyName(__saver.ParentAndMe, oldName, "秦山第二核电厂3、4号机组");
            }

            if (node.NodeName.Contains("秦山地区三厂"))
            {
                string oldName = node.NodeName;
                TreeNodeHelper.UpdateNodeDictionaryKeyName(__saver.ParentAndMe, oldName, "秦山第三核电厂");
                node.NodeName = "秦山第三核电厂";
            }

            if (node.NodeName.Contains("MW"))
            {
                string oldName = node.NodeName;
                node.NodeName = "秦山核电厂320MWe";
                TreeNodeHelper.UpdateNodeDictionaryKeyName(__saver.ParentAndMe, oldName, "秦山核电厂320MWe");
            }

            if (node.NodeName.Contains("所有"))
            {
                string oldName = node.NodeName;
                node.NodeName = "秦山各核电厂";
                TreeNodeHelper.UpdateNodeDictionaryKeyName(__saver.ParentAndMe, oldName, "秦山各核电厂");
            }
        }

        private void processNode2(Node node)
        {
            if (node != null && node.ChildNodes != null && node.ChildNodes.Length > 0)
            {
                foreach (Node n in node.ChildNodes)
                {
                    processNode2(n);
                }
            }
            string realNodeName = GetRidOfIndexPrefix(node.NodeName);
            ChangeNodeName(node, realNodeName);
        }

        void ChangeNodeName(Node node, string realNodeName)
        {
            string facilityNo = FacilityName.GetFacilityNO(realNodeName);
            string zhuantiNo = ZhuanTiManager.GetSubjectNO(realNodeName);
            string yaosuNo = YaoSuManager.GetYaoSuBianHao(realNodeName);
            string str = "";
            if (facilityNo != "")
            {
                str = facilityNo;
            }
            if (zhuantiNo != "")
                str = zhuantiNo;
            if (yaosuNo != "")
                str = yaosuNo;

            if (str != "")
            {
                string oldName = node.NodeName;
                node.NodeName = node.NodeName.Replace(realNodeName, str);
            }
        }

        private void bt_baseData_Click(object sender, EventArgs e)
        {
            BaseDataForm _b = new BaseDataForm();
            _b.WindowState = FormWindowState.Maximized;
            _b.ShowDialog();
        }

        public static string GetRidOfIndexPrefix(string nodename)
        {
            int index = nodename.LastIndexOf('.');
            if (index != -1)
                return nodename.Remove(0, index + 1);
            return nodename;
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            string nodeName = e.Node.Text;
            string realName = CommonHelper.GetRealName(CommonHelper.GetRidOfIndexPrefix(nodeName), treeView1.SelNode.Level + 1);

            toolTip1.Show(realName, treeView1);
        }

        private void bt_attachLeftTree_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime _dtNow = DateTime.Now;
                DateTime _appLastWriteTime = _dtNow;//_temp.CreationTime;
                TreeNodeHelper.RefreshTreeView<RootNode, Node>(treeView1, ref saver_left, "admin");
                TreeNodeHelper.RefreshTreeView<AuthorizationTree, AuthorizationNode>(treeView3, ref saver_auth, "admin");

                ((AuthorizationTree)saver_auth.root).AppLastWriteTime = _appLastWriteTime;
                ((RootNode)saver_left.root).AppLastWriteTime = _appLastWriteTime;
                saver_auth.SaveToDb();
                saver_left.SaveToDb();

                //拷贝到新地方
                string Apppath = Application.ExecutablePath;
                FileInfo _originOne = new FileInfo(Apppath);
                string _destFileName = CommonHelper.GetAssemblyPath() + @"app" + _dtNow.Year.ToString()+_dtNow.Month.ToString()+_dtNow.Day.ToString() +"-"+_dtNow.Hour.ToString() +_dtNow.Minute.ToString()+".exe";
                _originOne.CopyTo(_destFileName,true);
                FileInfo _destOne = new FileInfo(_destFileName);
                _destOne.LastWriteTime = _dtNow;
                //

                MessageBox.Show(this, "完成绑定，时间戳为：" + ((RootNode)saver_left.root).AppLastWriteTime.ToString()+"\n 新的App文件名为：\n"+_destOne.FullName, "设置成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((Button)this.Parent.Parent.Controls["MainForm_flowLayoutPanel"].Controls["BT_SysConfig"]).PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "绑定失败！信息为\n"+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
