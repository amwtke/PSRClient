using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace APP
{
    class Range
    {
        private ArrayList arrParentNodes = new ArrayList();//专题、要素、电厂节点
        private RootNode _UserRootLeftTree=null;
        /// <summary>
        /// 需要获取用户左边树节点对电厂、要素、专题下拉框进行下拉联动时才用此构造方法
        /// </summary>
        /// <param name="blGetUserTreeNode"></param>
        public Range(bool blGetUserTreeNode)
        {
            if (!blGetUserTreeNode)
            {
                return;
            }
            if (_UserRootLeftTree == null)
            {
                try
                {
                    _UserRootLeftTree = TreeNodeHelper.GetRootNodeByUserName(UserSession.LoginUser.Name);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                
                if (_UserRootLeftTree == null)
                {
                    throw new Exception("无用户左树！");
                }
            }
        }
        public Range()
        {
        }
        /// <summary>
        /// 获取当前节点及其所有父节点
        /// </summary>
        public void GetSelectedNode(Form form)
        {
            Control ctl = form.Parent;
            if (!(ctl is Panel))
            {
                return;
            }
            ctl = ctl.Parent;
            if (!(ctl is SplitterPanel))
            {
                return;
            }
            ctl = ctl.Parent;
            if (!(ctl is SplitContainer))
            {
                return;
            }
            SplitContainer sc = (SplitContainer)ctl;
            Control[] arrCtl = sc.Panel1.Controls.Find("treeView1", false);
            if (arrCtl.Length > 0)
            {
                TreeView trv = (TreeView)arrCtl[0];
                TreeNode tn = trv.SelectedNode;
                if (tn == null)
                {
                    return;
                }
                this.arrParentNodes.Add(tn);
                this.GetParentNode(tn);
            }
        }

        /// <summary>
        /// 遍历获取所有父节点
        /// </summary>
        /// <param name="tnChild"></param>
        public void GetParentNode(TreeNode tnChild)
        {
            if (tnChild == null)
            {
                return;
            }
            TreeNode tnParent = tnChild.Parent;
            if (tnParent != null)
            {
                this.arrParentNodes.Add(tnParent);
                tnChild = tnParent;
                this.GetParentNode(tnChild);
            }
        }
        /// <summary>
        /// 设置范围(从左边菜单内容填写Conbox)
        /// </summary>
        public  void SetRange(Form form,ComboBox cmbFactory,ComboBox cmbElement,ComboBox cmbSubject)
        {
            this.GetSelectedNode(form);
            string strFactory = "";
            string strElement = "";
            string strSubject = "";
            if (arrParentNodes.Count == 3)
            {
                strFactory = ((TreeNode)arrParentNodes[2]).Text;
                strElement = ((TreeNode)arrParentNodes[1]).Text;
                strSubject = ((TreeNode)arrParentNodes[0]).Text;
            }
            else if (arrParentNodes.Count == 2)
            {
                strFactory = ((TreeNode)arrParentNodes[1]).Text;
                strElement = ((TreeNode)arrParentNodes[0]).Text;
            }
            else if (arrParentNodes.Count == 1)
            {
                strFactory = ((TreeNode)arrParentNodes[0]).Text;
            }
            cmbFactory.Text = strFactory;
            cmbElement.Text = strElement;
            cmbSubject.Text = strSubject;
        }

        /// <summary>
        /// DataGridView下拉框绑定Dictionary
        /// </summary>
        /// <param name="Column">绑定列:dataGridView1.Columns["列名"]</param>
        /// <param name="DisplayValue">实际和显示值</param>
        public void dgvBindCombobox(DataGridViewColumn Column, Dictionary<string, string> DisplayValue)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            foreach (KeyValuePair<string, string> item in DisplayValue)
            {
                DataRow drNewKY1 = dt.NewRow();
                drNewKY1["Display"] = item.Value.ToString();
                drNewKY1["Value"] = item.Key.ToString();
                dt.Rows.Add(drNewKY1);
            }
            DataGridViewComboBoxColumn com = (DataGridViewComboBoxColumn)Column;
            com.DisplayMember = "Display";
            com.ValueMember = "Value";
            com.DataSource = dt;
        }
        /// <summary>
        /// DataGridView下拉框绑定DataTable
        /// </summary>
        /// <param name="dgvc"></param>
        /// <param name="dtDrop"></param>
        public void dgvBindCombobox(DataGridViewColumn dgvc, DataTable dtDrop)
        {
            DataGridViewComboBoxColumn dgvcbc = (DataGridViewComboBoxColumn)dgvc;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("NAME", typeof(string));
            //DataTable dtDrop = this.QueryTable(sqlConn, SqlDrop);
            for (int i = 0; i < dtDrop.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = dtDrop.Rows[i][0];
                dr["NAME"] = dtDrop.Rows[i][1];
                dt.Rows.Add(dr);
            }
            dgvcbc.DataSource = dt;
            dgvcbc.ValueMember = "ID";
            dgvcbc.DisplayMember = "NAME";
        }

        /// <summary>
        /// ComboBox 绑定
        /// </summary>
        /// <param name="com">需要绑定的ComboBox</param>
        /// <param name="DV">显示值和实践值</param>
        public void BindCombobox(ComboBox com, Dictionary<string, string> DV)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            //加入空白行，为不选
            DataRow drBlank = dt.NewRow();
            drBlank["Display"] = "全部";//item.Value.ToString();
            drBlank["Value"] = "";//item.Key.ToString();
            dt.Rows.Add(drBlank);
            if (DV != null)
            {
                foreach (KeyValuePair<string, string> item in DV)
                {
                    DataRow drNewKY1 = dt.NewRow();
                    if (item.Value.ToString() == string.Empty)
                        continue;
                    drNewKY1["Display"] = item.Value.ToString();
                    drNewKY1["Value"] = item.Key.ToString();
                    dt.Rows.Add(drNewKY1);
                }
            }
            com.DisplayMember = "Display";
            com.ValueMember = "Value";
            com.DataSource = dt;

        }
        public Node GetFacilityNode(string facility)
        {
            if (_UserRootLeftTree != null)
            {
                if (_UserRootLeftTree.ChildNodes != null && _UserRootLeftTree.ChildNodes.Length > 0)
                {
                    foreach (Node node in _UserRootLeftTree.ChildNodes)
                    {
                        string facilityReal = FacilityName.GetFacilityNameByNO(TreeNodeHelper.GetRidOfIndexPrefix(node.NodeName));
                        if (facilityReal == facility)
                            return node;
                    }
                }

            }
            return null;
        }

        public Node GetYaoSuByFacility(string facility, string yaosuName)
        {
            if (_UserRootLeftTree != null)
            {
                Node _facility = GetFacilityNode(facility);
                if (_facility != null && _facility.ChildNodes != null && _facility.ChildNodes.Length > 0)
                {
                    foreach (Node yaosu in _facility.ChildNodes)
                    {
                        string realyaosu = YaoSuManager.GetElementNameByNO(TreeNodeHelper.GetRidOfIndexPrefix(yaosu.NodeName));
                        if (realyaosu == yaosuName)
                        {
                            return yaosu;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据电厂名称获取要素
        /// </summary>
        /// <param name="facility"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetYaoSuFromRootLeftTree(string facility)
        {
            Dictionary<string, string> _retDic = new Dictionary<string, string>();
            Node _facility = GetFacilityNode(facility);
            if (_facility != null && _facility.ChildNodes != null && _facility.ChildNodes.Length > 0)
            {
                foreach (Node _yaosu in _facility.ChildNodes)
                {
                    string realyaosu = YaoSuManager.GetElementNameByNO(TreeNodeHelper.GetRidOfIndexPrefix(_yaosu.NodeName));
                    if (!_retDic.ContainsKey(YaoSuManager.GetYaoSuBianHao(realyaosu)))
                        _retDic.Add(YaoSuManager.GetYaoSuBianHao(realyaosu), realyaosu);
                }
                return _retDic;
            }
            return null;
        }

        /// <summary>
        /// 根据电厂名称、专题名称获取专题
        /// </summary>
        /// <param name="facility"></param>
        /// <param name="yaosu"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetZhuanTisFromRootLeftTree(string facility, string yaosu)
        {
            Dictionary<string, string> _retDic = new Dictionary<string, string>();
            Node _yaosu = GetYaoSuByFacility(facility, yaosu);
            if (_yaosu != null)
            {
                if (_yaosu.ChildNodes != null && _yaosu.ChildNodes.Length > 0)
                {
                    foreach (Node _zhuanti in _yaosu.ChildNodes)
                    {
                        string realzhuanti = ZhuanTiManager.GetSubjectNameByNO(TreeNodeHelper.GetRidOfIndexPrefix(_zhuanti.NodeName));
                        if (!_retDic.ContainsKey(ZhuanTiManager.GetSubjectNO(realzhuanti)))
                            _retDic.Add(ZhuanTiManager.GetSubjectNO(realzhuanti), realzhuanti);
                    }
                    return _retDic;
                }
            }
            return null;
        }

    }
}
