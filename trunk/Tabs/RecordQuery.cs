using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
using System.Collections;
using System.Windows.Input;

namespace APP
{
    public partial class RecordQuery : Form
    {
        static RootNode _UserRootLeftTree = null;

        private string strFactoryNO = "";//电厂编号
        private string strElementNO = "";//要素编号
        private string strSubjectNO = "";//专题编号
        private DataTable dtRecordInRange = new DataTable();//当前范围内的记录
        private Fact[] arrFact = null;
        private Record[] arrRecord = null;//当前范围的记录
        private RecordResult[] arrResult = null;//所有记录结论
        private bool isShown = false;
        private Range rangeUser = new Range(true);
        public RecordQuery()
        {
            InitializeComponent();
            Dictionary<string, string> dict = new Dictionary<string, string>();
        }
        
        /// <summary>
        /// 获取当前范围内的记录
        /// </summary>
        /// <param name="strFactoryNO">电厂编号</param>
        /// <param name="strElementNO">要素编号</param>
        /// <param name="strSubjectNO">专题编号</param>
        /// <returns>Record类数组</returns>
        public Record[] GetRecord(string strFactoryNO, string strElementNO, string strSubjectNO)
        {
            RetrieveRecordPredicate _p = new RetrieveRecordPredicate(strFactoryNO,strElementNO,strSubjectNO,tb_against.Text,tb_factDescription.Text);
            IObjectContainer _db = RecordHelper.DBRecord;//DBHelper.InitDB4O(typeof(Record));

            IObjectSet ret = _db.Query(_p);
            List<Record> retArray = null;
            if (ret != null && ret.Count > 0)
            {
                retArray = new List<Record>();
                for (int i = 0; i < ret.Count; i++)
                {
                    Record r = (Record)ret[i];
                    if (MainForm.IsMyDB == false)
                    {
                        if(FelterRecord(r))
                            retArray.Add(r);
                    }
                    else
                    {
                        retArray.Add(r);
                    }
                }
            }

            if (retArray != null)
                return retArray.ToArray();
            return null;
        }
        /// <summary>
        /// 设置DataTable列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="arrColName"></param>
        public void SetDataTableColumn(DataTable dt,string[] arrColName)
        {
            foreach (string strColName in arrColName)
            {
                dt.Columns.Add(strColName);
            }
        }
        private void SetDtRecordColumn()
        {
            string[] arrColName = new string[] { "RECORDNO", "RECORDNAME", "STATUS","SUBMITER" ,"APPROVER","SUBMITTIME" };
            this.SetDataTableColumn(this.dtRecordInRange, arrColName);
        }
        public void GetRecordInRange(string strFactoryNO, string strElementNO, string strSubjectNO)
        {
            dtRecordInRange.Rows.Clear();
            arrRecord = this.GetRecord(strFactoryNO, strElementNO, strSubjectNO);
            if (arrRecord == null)
            {
                return;
            }
            foreach (Record record in arrRecord)
            {
                DataRow dr = dtRecordInRange.NewRow();
                dr["RECORDNO"] = record.ID;
                dr["RECORDNAME"] = record.Topic;
                dr["STATUS"] = record.Status;
                dr["SUBMITER"] = record.InputUser;
                dr["APPROVER"] = record.ApproveBy;
                dr["SUBMITTIME"] = record.InputTime;
                dtRecordInRange.Rows.Add(dr);
            }
        }

        
        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            this.strFactoryNO = FacilityName.GetFacilityNO(cmbFactory.Text);
            this.strElementNO = YaoSuManager.GetYaoSuBianHao(cmbElement.Text);
            this.strSubjectNO = ZhuanTiManager.GetSubjectNO(cmbSubject.Text);
            this.GetRecordInRange(strFactoryNO, strElementNO, strSubjectNO);
            arrFact = FactHelper.GetAll();
            arrResult = ResultHelper.GetAll();
        }
        /// <summary>
        /// 判断某个记录编号是否在查询范围内
        /// </summary>
        /// <param name="strRecordNo">待验证的记录编号</param>
        /// <returns>true表示在查询范围内，false则不在</returns>
        private bool RecordInRange(string strRecordNo)
        {
            if (arrRecord != null && arrRecord.Length > 0)
            {
                foreach (Record record in arrRecord)
                {
                    if (record.ID == strRecordNo)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        /// <summary>
        /// 获取符合项、偏差项总数
        /// </summary>
        /// <returns></returns>
        private int[] GetFitAndErrorCount()
        {
            int[] arrFitAndNot = new int[2]{0,0};
            int intCountFit = 0;//符合项总数
            int intCountError = 0;//不符合项总数
            if (arrFact == null)
            {
                return arrFitAndNot;
            }
            foreach (Fact result in arrFact)
            {
                if(!this.RecordInRange(result.RecordNo))
                {
                    continue;//记录号不在查询范围内则继续下一条
                }
                if (result.IsFH)
                {
                    intCountFit++;
                }
                else if (result.IsPC)
                {
                    intCountError++;
                }
            }
            arrFitAndNot[0] = intCountFit;
            arrFitAndNot[1] = intCountError;
            return arrFitAndNot;
        }
        /// <summary>
        /// 获取不同状态下的记录总数
        /// </summary>
        /// <param name="strStatus"></param>
        /// <returns></returns>
        private object GetRecordCountInStatus(string strStatus)
        {
            return dtRecordInRange.Compute("count(RECORDNO)", "STATUS='" + strStatus+"'");
        }
        /// <summary>
        /// 设置汇总标签值
        /// </summary>
        private void SetLabSumText()
        {
            this.labSumEdit.Text = this.GetRecordCountInStatus(RecordStatus.Inputed).ToString();
            this.labSumSubmit.Text = this.GetRecordCountInStatus(RecordStatus.HoldForApprove).ToString();
            this.labSumOK.Text = this.GetRecordCountInStatus(RecordStatus.Approved).ToString();
            this.labSumReturn.Text = this.GetRecordCountInStatus(RecordStatus.ReturnBack).ToString();
            this.labSumDeleted.Text = this.GetRecordCountInStatus(RecordStatus.Deleted).ToString();
            this.labSumRecord.Text = dtRecordInRange.Rows.Count.ToString();
            int[] arrFitAndError = this.GetFitAndErrorCount();
            this.labSumFit.Text = arrFitAndError[0].ToString();
            this.labSumError.Text = arrFitAndError[1].ToString();
        }
        private void BindData(DataGridView dgv,TabPage tp)
        {
            //DataRow[] arrRows = null;
            DataView dv = new DataView(dtRecordInRange);
            dv.Sort = "SUBMITTIME DESC";//按记录编号升序
            string strStatus = "";
            switch (tp.Name.ToUpper())
            {
                case "TPEDIT":
                    //arrRows = this.FilterDtRecord(RecordStatus.Inputed);
                    strStatus = RecordStatus.Inputed;
                    break;
                case "TPSUBMIT":
                    //arrRows = this.FilterDtRecord(RecordStatus.HoldForApprove);
                    strStatus = RecordStatus.HoldForApprove;
                    break;
                case "TPOK":
                    //arrRows = this.FilterDtRecord(RecordStatus.Approved);
                    strStatus = RecordStatus.Approved;
                    break;
                case "TPRETURN":
                    //arrRows = this.FilterDtRecord(RecordStatus.ReturnBack);
                    strStatus = RecordStatus.ReturnBack;
                    break;
                case "TPDELETED":
                    strStatus = RecordStatus.Deleted;
                    break;
                case "TPQUERY":
                    //dgv.DataSource = dtRecordInRange;
                    dgv.DataSource = dv;
                    return;
                default:
                    return;
            }
            dv.RowFilter = "status='" + strStatus + "'";
            dgv.DataSource = dv;
            //dgv.DataSource = arrRows;
        }
        private DataRow[] FilterDtRecord(string strStatus)
        {
            string strFilterExpress = "STATUS='" + strStatus + "'";
            string strSort = "RECORDNO";
            return dtRecordInRange.Select(strFilterExpress, strSort);
        }
        private void tabRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabRecord.SelectedTab.Name != tpSum.Name)
            {
                tabRecord.SelectedTab.Controls.Add(dgvRecord);
                this.BindData(dgvRecord, tabRecord.SelectedTab);
            }
        }

        private void RecordQuery_Load(object sender, EventArgs e)
        {
            comboBox_fhpc.SelectedIndex = 0;
            Range range = new Range();
            range.BindCombobox(cmbFactory, FacilityName.dictFactory);
            //range.BindCombobox(cmbElement, YaoSuManager.dictElement);
            //range.BindCombobox(cmbSubject, ZhuanTiManager.dictSubject);
            range.SetRange(this,cmbFactory, cmbElement, cmbSubject);
            this.SetDtRecordColumn();

            isShown = true;

            if (_UserRootLeftTree == null)
            {
                try
                {
                    _UserRootLeftTree = TreeNodeHelper.GetRootNodeByUserName(UserSession.LoginUser.Name);
                    GetFacilityFromRootLeftTree();
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
            btnQuery.PerformClick();
        }



        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
            this.SetLabSumText();
            this.BindData(dgvRecord, tabRecord.SelectedTab);
        }

        private void dgvRecord_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SolidBrush v_SolidBrush = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            int v_LineNo = 0;
            v_LineNo = e.RowIndex + 1;
            string v_Line = v_LineNo.ToString();
            e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 8, e.RowBounds.Location.Y + 5);
        }

        private void dgvRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strRecordNO = this.dgvRecord.CurrentRow.Cells["RECORDNO"].Value.ToString();//记录编号
            string strSubmiter = this.dgvRecord.CurrentRow.Cells["SUBMITER"].Value.ToString();//提交人
            string strStatus = this.dgvRecord.CurrentRow.Cells["STATUS"].Value.ToString();//状态
            bool blView = false;//是否查看
            bool blApprove = false;//是否已审批
            bool blApproveEdit = false;//是否审批操作
            if (strSubmiter != UserSession.LoginUser.Name||strStatus==RecordStatus.HoldForApprove)
            {
                blApprove = true;
                blView = true;
            }
            if (UserSession.LoginUser.Role==Roles.RoleFactorTeamManager || UserSession.LoginUser.Role==Roles.Admin || MainForm.IsMyDB==false)
            {
                DashBoard _board = new DashBoard(strRecordNO);
                _board.WindowState = FormWindowState.Maximized;
                _board.ShowDialog(this);
            }
            else
            {
                if (strStatus == RecordStatus.Inputed || strStatus == RecordStatus.ReturnBack)
                {
                    APP.Tab1_AddAffectForm formAddAffect = new Tab1_AddAffectForm(strRecordNO, blApprove, blView, blApproveEdit);
                    formAddAffect.WindowState = FormWindowState.Maximized;
                    formAddAffect.ShowDialog(this);
                }
                else
                {
                    DashBoard _board = new DashBoard(strRecordNO);
                    _board.WindowState = FormWindowState.Maximized;
                    _board.ShowDialog(this);
                }
            }
            this.btnQuery_Click(sender, e);
        }

        private void cmbFactory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isShown)
            {
                //Range range = new Range(true);
                Dictionary<string, string> dictElement = rangeUser.GetYaoSuFromRootLeftTree(cmbFactory.Text);
                rangeUser.BindCombobox(cmbElement, dictElement);//下拉联动要素
                this.Query();
                this.SetLabSumText();
                this.BindData(dgvRecord, tabRecord.SelectedTab);
            }
        }

        private void cmbElement_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isShown)
            {
                //Range range = new Range(true);
                Dictionary<string, string> dictSubject = rangeUser.GetZhuanTisFromRootLeftTree(cmbFactory.Text, cmbElement.Text);
                rangeUser.BindCombobox(cmbSubject, dictSubject);//下拉联动专题
                this.Query();
                this.SetLabSumText();
                this.BindData(dgvRecord, tabRecord.SelectedTab);
            }
        }

        private void cmbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.isShown)
            {
                this.Query();
                this.SetLabSumText();
                this.BindData(dgvRecord, tabRecord.SelectedTab);
            }
        }

        private void cmbSubject_MouseEnter(object sender, EventArgs e)
        {
            toolTip_zhuanti.Show(cmbSubject.Text, cmbSubject);
        }

        private void cmbSubject_Enter(object sender, EventArgs e)
        {
            
        }

        private void cmbSubject_DrawItem(object sender, DrawItemEventArgs e)
        {
            //string text = this.cmbSubject.GetItemText(cmbSubject.Items[e.Index]);
            e.DrawBackground();
            e.Graphics.DrawString(this.cmbSubject.GetItemText(cmbSubject.Items[e.Index]), e.Font, System.Drawing.Brushes.Black, e.Bounds);
            //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                toolTip_zhuanti.Show(this.cmbSubject.GetItemText(cmbSubject.Items[e.Index]), cmbSubject, e.Bounds.X + e.Bounds.Width-200, e.Bounds.Y + e.Bounds.Height);
            e.DrawFocusRectangle();
        }

        private void cmbSubject_DropDownClosed(object sender, EventArgs e)
        {
            toolTip_zhuanti.Hide(cmbSubject);
        }

        private void cmbFactory_DrawItem(object sender, DrawItemEventArgs e)
        {
            //string text = this.cmbSubject.GetItemText(cmbSubject.Items[e.Index]);
            e.DrawBackground();
            e.Graphics.DrawString(this.cmbFactory.GetItemText(cmbFactory.Items[e.Index]), e.Font, System.Drawing.Brushes.Black, e.Bounds);
            //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                toolTip_zhuanti.Show(this.cmbFactory.GetItemText(cmbFactory.Items[e.Index]), cmbFactory, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
            e.DrawFocusRectangle();
        }

        private void cmbFactory_DropDownClosed(object sender, EventArgs e)
        {
            toolTip_zhuanti.Hide(cmbFactory);
        }

        private void cmbFactory_MouseEnter(object sender, EventArgs e)
        {
            toolTip_zhuanti.Show(cmbFactory.Text, cmbFactory);
        }

        private void cmbElement_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(this.cmbElement.GetItemText(cmbElement.Items[e.Index]), e.Font, System.Drawing.Brushes.Black, e.Bounds);
            //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                toolTip_zhuanti.Show(this.cmbElement.GetItemText(cmbElement.Items[e.Index]), cmbElement, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
            e.DrawFocusRectangle();
        }

        private void cmbElement_DropDownClosed(object sender, EventArgs e)
        {
            toolTip_zhuanti.Hide(cmbElement);
        }

        private void cmbElement_MouseEnter(object sender, EventArgs e)
        {
            toolTip_zhuanti.Show(cmbElement.Text, cmbElement);
        }

        private void tb_factDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.isShown)
                {
                    this.Query();
                    this.SetLabSumText();
                    this.BindData(dgvRecord, tabRecord.SelectedTab);
                }
            }
        }

        private void tb_against_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.isShown)
                {
                    this.Query();
                    this.SetLabSumText();
                    this.BindData(dgvRecord, tabRecord.SelectedTab);
                }
            }
        }

        //过滤左树
        bool FelterRecord(Record record)
        {
            if (record == null && string.IsNullOrEmpty(record.ID))
                return false;

            string id = record.ID;
            string facility = FacilityName.GetFacilityNameByNO(record.Facility);
            string yaosu = YaoSuManager.GetElementNameByNO(record.YaoSuBianHao);
            string zhuanti = ZhuanTiManager.GetSubjectNameByNO(record.ZhuangTiBianHao);
            if (_facilityList.Contains(facility))
            {
                Node node = GetYaoSuByFacility(facility, yaosu);
                if (node == null)
                    return false;
                else
                {
                    if (zhuanti == "")
                        return true;
                    else
                    {
                        if (node.ChildNodes != null && node.ChildNodes.Length > 0)
                        {
                            foreach (Node n in node.ChildNodes)
                            {
                                if (n.NodeName.Contains(ZhuanTiManager.GetSubjectNO(zhuanti)))
                                    return true;
                            }
                        }
                        return false;
                    }
                }
            }
            else
                return false;
        }

        #region ComboBox绑定相关
        static List<string> _facilityList = new List<string>();
        private Dictionary<string, string> GetFacilityFromRootLeftTree()
        {
            Dictionary<string, string> _retDic = new Dictionary<string, string>();
            if (_UserRootLeftTree.ChildNodes != null && _UserRootLeftTree.ChildNodes.Length > 0)
            {
                foreach (Node node in _UserRootLeftTree.ChildNodes)
                {
                    if (node.NodeName != "")
                    {
                        string No = TreeNodeHelper.GetRidOfIndexPrefix(node.NodeName);
                        string facility = FacilityName.GetFacilityNameByNO(No);
                        if (!_retDic.ContainsKey(No))
                        {
                            _retDic.Add(No, facility);
                            _facilityList.Add(facility);
                        }
                    }
                }
                return _retDic;
            }
            return null;
        }

        private Node GetFacilityNode(string facility)
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

        private Dictionary<string, string> GetYaoSuFromRootLeftTree(string facility)
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

        private Node GetYaoSuByFacility(string facility, string yaosuName)
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

        private Dictionary<string, string> GetZhuanTisFromRootLeftTree(string facility, string yaosu)
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

        #endregion

    }

    public class RetrieveRecordPredicate : Predicate
    {
        string _facility, _yaosu, _zhuanti, _topic, _fcontent;
        bool flag = true;
        public RetrieveRecordPredicate(string faciliy, string yaosu, string zhuanti, string topic, string factContent)
        {
            _facility = faciliy;
            _yaosu = yaosu;
            _zhuanti = zhuanti;
            _topic = topic;
            _fcontent = factContent;
        }
        public bool Match(Record record)
        {
            flag = true;
            if (record.IsDelete == true)
                return false;
            if (!string.IsNullOrEmpty(_facility))
            {
                flag = _facility.Equals(record.Facility);
                if (flag)
                {
                    if (!string.IsNullOrEmpty(_yaosu))
                    {
                        flag = record.YaoSuBianHao.Equals(_yaosu);
                        if (flag)
                        {
                            if (!string.IsNullOrEmpty(_zhuanti))
                            {
                                flag = record.ZhuangTiBianHao.Equals(_zhuanti);
                            }
                        }
                    }
                }
            }

            if (flag)
            {
                if (!string.IsNullOrEmpty(_topic))
                {
                    flag = record.Topic.Contains(_topic);
                }
            }

            if (flag)
            {
                if (!string.IsNullOrEmpty(_fcontent))
                {
                    foreach (Fact s in record.Facts)
                    {
                        if (s.Content.Contains(_fcontent))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }

            return flag;
        }
    }
}
