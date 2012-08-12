using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace APP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ptv = new PaintTreeView<RootNode, Node>(treeView1);
            ptv.ShowTreeView(UserSession.LoginUser.Name);
            treeView1.ExpandAll();
            this.WindowState = FormWindowState.Maximized;

            _innerPanel = panel_form;
            _MainForm = this;
            _formTitle = this.Text;
            treeView1.CheckBoxes = false;

            //label4.Text = UserSession.LoginUser.Name;
            //label5.Text = UserSession.LoginUser.DanWei;
            LoadFormCheck();
            
        }
        PaintTreeView<RootNode, Node> ptv;
        static Panel _innerPanel;
        static Form _MainForm;
        static string _formTitle;

        public static void AddForm(Control c)
        {
            if (c != null)
            {
                _innerPanel.Controls.Clear();
 
                if (c is Form)
                {
                    Form temp = (Form)c;
                    temp.WindowState = FormWindowState.Maximized;
                }
                _innerPanel.Controls.Add(c);
                //_MainForm.Controls.Add(c);
                //c.Location = _innerPanel.Location;
                c.Show();
            }
            else
            {
                _innerPanel.Controls.Clear();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ITreeNodeAction treenode = (ITreeNodeAction)e.Node.Tag;
            if (treenode != null)
            {
                treenode.ShowForm();
                btnQuery.BackColor = Color.CadetBlue;
                btnAddRecord.BackColor = Color.White;
                BT_ReviewRecord.BackColor = Color.White;
            }
            else
            {
                panel_form.Controls.Clear();
            }
        }

        private void MainForm_MaximumSizeChanged(object sender, EventArgs e)
        {
            label9.Text += label9.Text;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            CommonHelper.SetChildNodeChecked(e.Node,e.Node.Checked);

        }

        private void BT_SysConfig_Click(object sender, EventArgs e)
        {
            ShowTabInPanel<AdminForm>();
            this.SetBtnColor(sender);
            //treeView1.Nodes.Clear();

        }



        #region 功能性
        public static void ShowMessage(string info,object o)
        {
            _formTitle = "PSR" + "——" + info+" "+o.GetType().ToString();
        }

        void ShowTabInPanel<T>() where T : Form, new()
        {
            T form = new T();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panel_form.Controls.Clear();
            panel_form.Controls.Add(form);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        #endregion


        void LoadFormCheck()
        {
            #region 系统按钮
            //BT_SysConfig.Enabled = UserHelper.IsUserHaveAuth("系统", null, UserSession.LoginUser.Roles[0]);
            //if (!BT_SysConfig.Enabled)
            //{
            //    BT_SysConfig.Enabled = UserHelper.DoesUserGotSpecialAuth(this.Name, BT_SysConfig.Name);
            //}
            BT_SysConfig.Enabled = Authorization.IsControlVisiable(BT_SysConfig.Parent, BT_SysConfig, "系统", null);
            #endregion

            #region 审查记录按钮
            BT_ReviewRecord.Enabled = Authorization.IsControlVisiable(BT_ReviewRecord.Parent, BT_ReviewRecord, "审查记录", null);
            //BT_ReviewRecord.Enabled = UserHelper.IsUserHaveAuth("审查记录", null, UserSession.LoginUser.Roles[0]);
            //if (!BT_ReviewRecord.Enabled)
            //{
            //    BT_ReviewRecord.Enabled = UserHelper.DoesUserGotSpecialAuth(this.Name, BT_SysConfig.Name);
            //}

            #endregion

            #region 查询记录按钮
            btnQuery.Enabled = Authorization.IsControlVisiable(btnQuery.Parent, btnQuery, "查询", null);
            //BT_ReviewRecord.Enabled = UserHelper.IsUserHaveAuth("审查记录", null, UserSession.LoginUser.Roles[0]);
            //if (!BT_ReviewRecord.Enabled)
            //{
            //    BT_ReviewRecord.Enabled = UserHelper.DoesUserGotSpecialAuth(this.Name, BT_SysConfig.Name);
            //}

            #endregion

            #region 添加记录按钮
            btnAddRecord.Enabled = Authorization.IsControlVisiable(btnAddRecord.Parent, btnQuery, "填写", null);
            //BT_ReviewRecord.Enabled = UserHelper.IsUserHaveAuth("审查记录", null, UserSession.LoginUser.Roles[0]);
            //if (!BT_ReviewRecord.Enabled)
            //{
            //    BT_ReviewRecord.Enabled = UserHelper.DoesUserGotSpecialAuth(this.Name, BT_SysConfig.Name);
            //}
            添加记录ToolStripMenuItem.Enabled = Authorization.IsControlVisiable(btnAddRecord.Parent, btnQuery, "填写", null);
            #endregion

            if(Authorization.IsControlVisiable(treeView1.Parent, treeView1, "查询", null))
                this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.ShowTabInPanel<RecordQuery>();
            this.SetBtnColor(sender);
        }

        private void BT_ReviewRecord_Click(object sender, EventArgs e)
        {
            this.SetBtnColor(sender);
            //ImportUserAndStatusForm _select = new ImportUserAndStatusForm(this);
            //if (_select.ShowDialog() == DialogResult.OK)
            //{
            //    openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Title = "选择要审查的数据文件，数据文件以登录人的缩写命名，如\"录入员\"用户的数据文件为lry.yap";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                RecordHelper.RefreshDBOfRecord(openFileDialog1.FileName);
                //DBHelper.TransferData(ImportUserName, RecordStatus, openFileDialog1.FileName);
                //btnQuery.PerformClick();
            }
            this.ShowTabInPanel<CheckRecord>();//审查记录
            this.SetBtnColor(sender);
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            this.ShowTabInPanel<Tab1_AddAffectForm>();//添加记录
            this.SetBtnColor(sender);
        }

        private void 添加记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowTabInPanel<Tab1_AddAffectForm>();//添加记录
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void BT_Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出？", "退出", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                DBHelper.CloseDB();
            }
        }
        /// <summary>
        /// 设置点击菜单按钮颜色
        /// </summary>
        /// <param name="strBtnName"></param>
        /// <param name="panelBtn"></param>
        private void SetBtnColor(object sender)
        {
            Button btn = (Button)sender;
            string strBtnName = btn.Name;
            Color colorClick = Color.CadetBlue;
            Panel panelBtn = this.MainForm_flowLayoutPanel;
            foreach (Control ctl in panelBtn.Controls)
            {
                if (ctl.Name == strBtnName)
                {
                    ctl.BackColor = colorClick;
                }
                else
                {
                    ctl.BackColor = panelBtn.BackColor;
                }
            }
        }

        private void BT_FundationInfo_Click(object sender, EventArgs e)
        {
            this.SetBtnColor(sender);
        }

        public string RecordStatus;
        public string ImportUserName;
        private void BT_Help_Click(object sender, EventArgs e)
        {
            this.SetBtnColor(sender);
            //ImportUserAndStatusForm _select = new ImportUserAndStatusForm(this);
            //if (_select.ShowDialog() == DialogResult.OK)
            //{
            //    openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                RecordHelper.RefreshDBOfRecord(openFileDialog1.FileName);
                //DBHelper.TransferData(ImportUserName, RecordStatus, openFileDialog1.FileName);
                btnQuery.PerformClick();
            }
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string strLoginRole= UserSession.LoginUser.Role;
            string strLoginName=UserSession.LoginUser.PingYing;
            string strCompany=UserSession.LoginUser.DanWei;
            this.labLoginInfo.Text = strLoginRole + "：" + strLoginName + "   单位：" + strCompany;
            btnQuery.PerformClick();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            panel_form.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string strHelpFilePath = Path.Combine(Application.StartupPath, "help.pdf");//帮助文件路径
            if (!File.Exists(strHelpFilePath))
            {
                MessageBox.Show("帮助文件 "+strHelpFilePath+" 丢失！");
                return;
            }
            System.Diagnostics.Process.Start(strHelpFilePath);
        }

    }
}
