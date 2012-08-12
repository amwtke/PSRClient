using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExportToWord;
using System.IO;
using System.Reflection;
using System.Collections;

namespace APP
{
    public partial class CheckRecord : Form
    {
        static RootNode _UserRootLeftTree = null;
        public CheckRecord()
        {
            InitializeComponent();
            this.dgvRecord.DataError += delegate(object sender, DataGridViewDataErrorEventArgs e) { };
        }
        bool isShown = false;
        #region ComboBox绑定相关
        List<string> _facilityList = new List<string>();
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
        private void CheckRecord_Load(object sender, EventArgs e)
        {
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

            Range range = new Range();
            range.BindCombobox(cmbFactory, GetFacilityFromRootLeftTree());//电厂
            //range.BindCombobox(cmbElement, YaoSu.dictElement);//要素
            //range.BindCombobox(cmbSubject, ZhuanTi.dictSubject);//专题
            range.SetRange(this, cmbFactory, cmbElement, cmbSubject);//设置范围为当前所选树节点所属范围
            range.dgvBindCombobox(dgvRecord.Columns["FactoryNO"], FacilityName.dictFactory);//电厂
            range.dgvBindCombobox(dgvRecord.Columns["ElementNO"], YaoSuManager.dictElement);//要素
            range.dgvBindCombobox(dgvRecord.Columns["SubjectNO"], ZhuanTiManager.dictSubject);//专题
            this.SetCmbStatusItems();//设置状态下拉框内容
            btnQuery.PerformClick();
            isShown = true;
            cmbStatus.SelectedIndex = 2;//默认已提交
            label_checkusername.Text = "当前检查记录属于：" + RecordHelper.RecordBelongsTo;
        }
        /// <summary>
        /// 反射RecordStatus类获取各状态
        /// </summary>
        /// <returns></returns>
        private ArrayList GetRecordStatus()
        {
            ArrayList arrRecordStatus = new ArrayList();
            Type t = typeof(RecordStatus);
            FieldInfo[] fields = t.GetFields(BindingFlags.Public|BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                object objValue = field.GetValue(field);
                if (objValue != null )
                {
                    arrRecordStatus.Add(objValue);
                }
            }
            return arrRecordStatus;
        }
        /// <summary>
        /// 设置状态下拉框下拉列表
        /// </summary>
        private void SetCmbStatusItems()
        {
            ArrayList arrRecordStatus = this.GetRecordStatus();
            cmbStatus.Items.Add("");
            for (int i = 0; i < arrRecordStatus.Count; i++)
            {
                cmbStatus.Items.Add(arrRecordStatus[i]);
            }
        }
        /// <summary>
        /// 设置DataTable列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="arrColName"></param>
        public void SetDataTableColumn(DataTable dt, string[] arrColName)
        {
            foreach (string strColName in arrColName)
            {
                dt.Columns.Add(strColName);
            }
        }
        private void SetDtRecordColumn(DataTable dt)
        {
            string[] arrColName = new string[] { "RECORDNO", "RECORDNAME", "SUBMITER", "SUBMITTIME", "CHECKER", "COMMENT", "APPROVETIME", "FACTORYNO", "ELEMENTNO", "SUBJECTNO", "STATUS" };
            this.SetDataTableColumn(dt, arrColName);
        }

        /// <summary>
        /// 获取当前范围内的记录(跟左树权限一致)
        /// </summary>
        /// <param name="strFactoryNO">电厂编号</param>
        /// <param name="strElementNO">要素编号</param>
        /// <param name="strSubjectNO">专题编号</param>
        /// <returns>Record类数组</returns>
        public Record[] GetRecord(string strFactoryNO, string strElementNO, string strSubjectNO,string strSatus)
        {
            Record recordRange = new Record();
            if (strFactoryNO != "")
            {
                recordRange.Facility = strFactoryNO;
            }
            if (strElementNO != "")
            {
                recordRange.YaoSuBianHao = strElementNO;
            }
            if (strSubjectNO != ""&&strSubjectNO!="00")
            {
                recordRange.ZhuangTiBianHao = strSubjectNO;
            }
            if (strSatus != "")
            {
                recordRange.Status = strSatus;
            }

            System.Collections.Generic.List<Record> _retRecords = new System.Collections.Generic.List<Record>();
            Record[] _records = RecordHelper.GetByExampleArray(recordRange);
            if (_records != null && _records.Length > 0)
            {
                foreach (Record r in _records)
                {
                    if (FelterRecord(r))
                        _retRecords.Add(r);
                }
            }
            return _retRecords.ToArray();
        }

        bool FelterRecord(Record record)
        {
            if (record == null && string.IsNullOrEmpty(record.ID))
                return false;

            string id = record.ID;
            string facility = FacilityName.GetFacilityNameByNO(record.Facility);
            string yaosu = YaoSuManager.GetElementNameByNO(record.YaoSuBianHao);
            string zhuanti = ZhuanTiManager.GetSubjectNameByNO(record.ZhuangTiBianHao);
            if(_facilityList.Contains(facility))
            {
                Node node = GetYaoSuByFacility(facility,yaosu);
                if(node==null)
                    return false;
                else
                {
                    if(zhuanti=="")
                        return true;
                    else
                    {
                       if(node.ChildNodes!=null && node.ChildNodes.Length>0)
                       {
                           foreach(Node n in node.ChildNodes)
                           {
                               if(n.NodeName.Contains(ZhuanTiManager.GetSubjectNO(zhuanti)))
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

        public DataTable GetRecordInRange(string strFactoryNO, string strElementNO, string strSubjectNO,string strStatus)
        {
            DataTable dt = new DataTable();
            this.SetDtRecordColumn(dt);
            Record[] arrRecord = this.GetRecord(strFactoryNO, strElementNO, strSubjectNO,strStatus);
            if (arrRecord == null)
            {
                return dt;
            }
            foreach (Record record in arrRecord)
            {
                DataRow dr = dt.NewRow();
                dr["CHECKER"] = record.ApproveBy;
                dr["COMMENT"] = record.Comments;//审批意见
                dr["ApproveTime"] = record.ApproveTime;//审批时间
                dr["FACTORYNO"] = record.Facility;
                dr["ELEMENTNO"] = record.YaoSuBianHao;
                dr["SUBJECTNO"] = record.ZhuangTiBianHao;
                dr["RECORDNO"] = record.ID;
                dr["RECORDNAME"] = record.Topic;
                //dr["STATUS"] = this.GetApproveStatus(record.ID, record.Status);
                dr["STATUS"] = record.Status;
                dr["SUBMITER"] = record.InputUser;//提交人
                dr["SUBMITTIME"] = record.InputTime;//提交时间
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 获取审批状态（事实全部审批才算审批，事实有一个退回就算退回）
        /// </summary>
        /// <param name="strRecordNO">记录编号</param>
        /// <param name="strRecordStatus">记录状态</param>
        /// <returns></returns>
        private string GetApproveStatus(string strRecordNO,string strRecordStatus)
        {
            bool blHasUnApproved = false;//是否有未审批的事实
            bool blHasReturned = false;//是否有已退回的事实
            string strApproveStatus = strRecordStatus;
            Fact fact = new Fact();
            fact.RecordNo = strRecordNO;
            Fact[] facts = FactHelper.GetByExampleArray(fact);
            foreach (Fact f in facts)
            {
                string strFactStatus = f.FactStatus;
                if (strFactStatus == RecordStatus.ReturnBack)
                {
                    blHasReturned = true;
                    strApproveStatus = RecordStatus.ReturnBack;
                    return strApproveStatus;
                }
                if (strFactStatus != RecordStatus.Approved)//含未审批的事实
                {
                    blHasUnApproved = true;
                }
            }
            if (!blHasUnApproved)
            {
                strApproveStatus = RecordStatus.Approved;
            }
            return strApproveStatus;
        }

        private void BindData(DataGridView dgv)
        {
            string strFactoryNO = FacilityName.GetFacilityNO(cmbFactory.Text);
            string strElementNO = YaoSuManager.GetYaoSuBianHao(cmbElement.Text);
            string strSubjectNO = ZhuanTiManager.GetSubjectNO(cmbSubject.Text);
            string strStatus = this.cmbStatus.Text.Trim();
            DataTable dt = this.GetRecordInRange(strFactoryNO, strElementNO, strSubjectNO,strStatus);
            dt.DefaultView.Sort = "SUBMITTIME DESC";
            dgv.DataSource = dt;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.BindData(dgvRecord);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            APP.Tab1_AddAffectForm formAddAffect = new Tab1_AddAffectForm();
            formAddAffect.ShowDialog(this);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {            
            this.Update(RecordStatus.Deleted, true, btnDelete.Text);
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Update(RecordStatus.HoldForApprove, false, btnSubmit.Text);
        }
        /// <summary>
        /// 批准
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            this.Update(RecordStatus.Approved, false, btnPass.Text);
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="strUpdateStatus">更新的status状态</param>
        /// <param name="blIsDelete">是否删除</param>
        /// <param name="strEditName">操作名称</param>
        private void Update(string strUpdateStatus, bool blIsDelete, string strEditName)
        {
            bool blCancelEdit = false;//是否取消当前操作
            string strComment = "";//审批意见
            if (dgvRecord.CurrentRow == null)
            {
                MessageBox.Show("请选择要"+strEditName+"的行！");
                return;
            }
            string strStatus = dgvRecord.CurrentRow.Cells["STATUS"].Value.ToString();//状态
            if (strStatus == RecordStatus.Approved)
            {
                MessageBox.Show("该记录已审批，不能" + strEditName + "！");
                return;
            }
            strComment = this.GetComment(ref blCancelEdit);
            if (blCancelEdit)
            {
                return;
            }
            Record[] arrRecord = new Record[1];
            Record recordUpdate = new Record();
            recordUpdate.ID = dgvRecord.CurrentRow.Cells["RecordNO"].Value.ToString();
            recordUpdate = RecordHelper.GetByRecordId(recordUpdate.ID);
            recordUpdate.IsDelete = blIsDelete;
            recordUpdate.Status = strUpdateStatus;
            recordUpdate.ApproveBy = UserSession.LoginUser.Name;
            recordUpdate.ApproveTime = DateTime.Now;
            recordUpdate.Comments = strComment;
            arrRecord[0] = recordUpdate;
            RecordHelper.UpdateRecords(arrRecord);
            MessageBox.Show(strEditName+"成功！");
            dgvRecord.CurrentRow.Cells["checker"].Value = recordUpdate.ApproveBy;//审查人
            dgvRecord.CurrentRow.Cells["COMMENT"].Value = strComment;
            dgvRecord.CurrentRow.Cells["APPROVETIME"].Value = recordUpdate.ApproveTime;
            dgvRecord.CurrentRow.Cells["status"].Value = strUpdateStatus;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Update(RecordStatus.ReturnBack, false, btnModify.Text);
        }
        /// <summary>
        /// 获取审批意见
        /// </summary>
        /// <param name="blCancelEdit"></param>
        /// <returns></returns>
        private string GetComment(ref bool blCancelEdit)
        {
            Comment comment = new Comment();
            comment.StartPosition = FormStartPosition.CenterParent;
            comment.ShowDialog(this);
            blCancelEdit = comment.CancelEdit;
            return comment.CommentContent;
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

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelClass Excel = new ExcelClass();
            DialogResult dlgResult = MessageBox.Show("是否仅导出当前所选记录？是：仅导出当前所选，否：导出全部", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgResult == DialogResult.Yes)
            {
                Excel.ExportToExcel(dgvRecord, this.Text, true);
                GC.Collect();
            }
            else if (dlgResult == DialogResult.No)
            {
                Excel.ExportToExcel(dgvRecord, this.Text, false);
                GC.Collect();
            }
            else
            {
                return;
            }
        }

        private void dgvRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //bool blApprove = false;//是否审批
            //bool blView = false;//是否查看
            //bool blApproveEdit = true;//是否审批操作
            //string strStatus = this.dgvRecord.CurrentRow.Cells["STATUS"].Value.ToString();//状态
            //if (strStatus == RecordStatus.HoldForApprove)
            //{
            //    blApprove = true;
            //    blView = true;
            //}
            string recordNo = this.dgvRecord.CurrentRow.Cells["RECORDNO"].Value.ToString();
            //Tab1_AddAffectForm formAddAffect = new Tab1_AddAffectForm(this.dgvRecord.CurrentRow.Cells["RECORDNO"].Value.ToString(), blApprove,blView,blApproveEdit);
            //formAddAffect.WindowState = FormWindowState.Maximized;
            //formAddAffect.ShowDialog(this);
            DashBoard _board = new DashBoard(recordNo);
            _board.WindowState = FormWindowState.Maximized;
            _board.ShowDialog(this);
            this.btnQuery_Click(sender,e);
        }

        private void btnPrintByElement_Click(object sender, EventArgs e)
        {
            if (dgvRecord.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要导出的行！");
                return;
            }
            foreach (DataGridViewRow row in dgvRecord.SelectedRows)
            {
                CommonHelper.WordOutPut(row);
            }

        }

        private void cmbFactory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isShown)
                btnQuery.PerformClick();
            if (cmbFactory.Text != "")
            {
                Range range = new Range();
                range.BindCombobox(cmbElement, GetYaoSuFromRootLeftTree(cmbFactory.Text.Trim()));//要素
                //cmbSubject.Items.Clear();
            }
            else
            {
                if (cmbElement.Items.Count > 0)
                    cmbElement.DataSource = null;
                if (cmbSubject.Items.Count > 0)
                    cmbSubject.DataSource = null;
                cmbElement.Text = "";
                cmbSubject.Text = "";
            }
            
        }

        private void cmbElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isShown)
                btnQuery.PerformClick();
            if (cmbFactory.Text != "" && cmbElement.Text != "")
            {
                Range range = new Range();
                range.BindCombobox(cmbSubject, GetZhuanTisFromRootLeftTree(cmbFactory.Text.Trim(), cmbElement.Text.Trim()));
            }
            else
            {
                if (cmbSubject.Items.Count > 0)
                    cmbSubject.DataSource = null;
                cmbSubject.Text = "";
            }
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isShown)
                btnQuery.PerformClick();
        }

        private void cmbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isShown)
                btnQuery.PerformClick();
        }

        private void cmbFactory_DrawItem(object sender, DrawItemEventArgs e)
        {
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

        private void cmbSubject_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(this.cmbSubject.GetItemText(cmbSubject.Items[e.Index]), e.Font, System.Drawing.Brushes.Black, e.Bounds);
            //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                toolTip_zhuanti.Show(this.cmbSubject.GetItemText(cmbSubject.Items[e.Index]), cmbSubject, e.Bounds.X + e.Bounds.Width - 200, e.Bounds.Y + e.Bounds.Height);
            e.DrawFocusRectangle();
        }

        private void cmbSubject_DropDownClosed(object sender, EventArgs e)
        {
            toolTip_zhuanti.Hide(cmbSubject);
        }

        private void cmbSubject_MouseEnter(object sender, EventArgs e)
        {
            toolTip_zhuanti.Show(cmbSubject.Text, cmbSubject);
        }

        private void cmbElement_SelectedValueChanged(object sender, EventArgs e)
        {

        }

    }
}
