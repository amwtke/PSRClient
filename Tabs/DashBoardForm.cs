using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace APP
{
    
    public partial class DashBoard : Form
    {
        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是 file:// 的长度
            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }
            return _FolderPath;
        }

        Record _record;
        public DashBoard()
        {
            InitializeComponent();
        }

        public DashBoard(Record record)
        {
            InitializeComponent();
            _record = record;
            LoadRecord();
        }

        public DashBoard(string recordNo)
        {
            InitializeComponent();
            _record = RecordHelper.GetByRecordId(recordNo);
            LoadRecord();
        }

        void LoadRecord()
        {
            CheckAuthorization();
            if (_record != null && _record.ID != string.Empty)
            {
                label_recordNo.Text = _record.ID;
                label_facility.Text = FacilityName.GetFacilityNameByNO(_record.Facility);
                label_yaosu.Text = YaoSuManager.GetElementNameByNO(_record.YaoSuBianHao);
                label_zhuangti.Text = ZhuanTiManager.GetSubjectNameByNO(_record.ZhuangTiBianHao);

                textBox_agasint.Text = _record.Topic;
                label_inputer.Text = _record.InputUser;
                label_danwei.Text = _record.DanWei;
                label_inputtime.Text = _record.InputTime.ToString();
                label_recordStatus.Text = _record.Status;

                string fenlei="";
                if (_record.IsActivityInspection)
                    fenlei += ",活动观察";
                if (_record.IsWalkDown)
                    fenlei += ",现场巡视";
                if (_record.IsDocumentRevision)
                    fenlei += ",文档审查";
                if (_record.IsCommunication)
                    fenlei += ",访谈";
                if (_record.IsCompliance)
                    fenlei += ",标准对比";
                if (fenlei!=string.Empty&&fenlei[0] == ',')
                    fenlei = fenlei.Substring(1);
                label_catalogues.Text = fenlei;

                rt_description.Text = _record.RecordDesciption;
                richTextBox1_equipmet.Text = _record.Equipment;

                //加载事实
                StringBuilder _sbFact = new StringBuilder();
                _sbFact.AppendLine("<html>");
                _sbFact.AppendLine("<head>");
                _sbFact.AppendLine("<link rel=stylesheet href=\"" + Application.StartupPath + "\\CSS\\factshow.css\" type=\"text/css\">");
                _sbFact.AppendLine("<link rel=stylesheet href=\"" + Application.StartupPath + "\\CSS\\resultshow.css\" type=\"text/css\">");
                _sbFact.AppendLine("</head>");

                _sbFact.AppendLine("<body>");
                _sbFact.AppendLine("<h1 ><font color=\"#000000\"><B>");
                _sbFact.Append("共：" + _record.Facts.Count + "个事件");
                _sbFact.Append("</B></font></h1>");
                //table
                _sbFact.AppendLine("<table id=\"customers\">");
                //header
                _sbFact.AppendLine("<th>编号</th>");
                _sbFact.AppendLine("<th>事件内容</th>");
                
                if (_record.Facts != null && _record.Facts.Count > 0)
                {
                    for (int i = 0; i < _record.Facts.Count; i++)
                    {
                        if(i%2==0)
                            _sbFact.AppendLine("<tr class=\"alt\">");
                        else
                            _sbFact.AppendLine("<tr>");

                        string no = (i + 1).ToString();
                        _sbFact.AppendLine("<td>");
                        _sbFact.Append("编号:" + no);
                        _sbFact.Append("</td>");

                        _sbFact.AppendLine("<td>");
                        _sbFact.AppendLine(Kongge(Br(_record.Facts[i].Content)));
                        _sbFact.AppendLine("</td>");
                        _sbFact.AppendLine("</tr>");
                    }
                    _sbFact.AppendLine("</table>");
                }

                //加载结论
                _sbFact.AppendLine("<br>");
                _sbFact.AppendLine("<br>");
                _sbFact.AppendLine("<h1><font color=\"#000000\"><B>");
                _sbFact.Append("共：" + _record.Results.Count + "个结论");
                _sbFact.Append("</B></font></h1>");
                //table
                _sbFact.AppendLine("<table id=\"result\">");
                //header
                _sbFact.AppendLine("<th>编号</th>");
                _sbFact.AppendLine("<th>结论内容</th>");
                _sbFact.AppendLine("<th>结论针对事实</th>");
                _sbFact.AppendLine("<th>偏差项/符合项</th>");
                if (_record.Results != null && _record.Results.Count > 0)
                {
                    for (int i = 0; i < _record.Results.Count; i++)
                    {
                        if (i % 2 == 0)
                            _sbFact.AppendLine("<tr class=\"alt\">");
                        else
                            _sbFact.AppendLine("<tr>");

                        string no = (i + 1).ToString();
                        _sbFact.AppendLine("<td>");
                        _sbFact.Append("编号:" + no);
                        _sbFact.Append("</td>");

                        _sbFact.AppendLine("<td>");
                        _sbFact.AppendLine(Kongge(Br(_record.Results[i].Content)));
                        _sbFact.AppendLine("</td>");

                        _sbFact.AppendLine("<td>");
                        _sbFact.AppendLine(Kongge(Br(_record.Results[i].AgainstFacts)));
                        _sbFact.AppendLine("</td>");

                        _sbFact.AppendLine("<td>");
                        if(_record.Results[i].IsFH)
                            _sbFact.AppendLine("符合项");
                        else
                            _sbFact.AppendLine("偏差项");
                        _sbFact.AppendLine("</td>");

                        _sbFact.AppendLine("</tr>");
                    }
                    _sbFact.AppendLine("</table>");
                    _sbFact.AppendLine("</body>");
                    _sbFact.AppendLine("</html>");
                }
                webBrowser1.DocumentText = _sbFact.ToString();
            }
        }


        string Br(string content)
        {
            string newOne = "";
            if (!string.IsNullOrEmpty(content))
            {
                newOne = content.Replace("\n", "<br>");
            }
            return newOne;
        }
        string Kongge(string content)
        {
            string newOne = "";
            if (!string.IsNullOrEmpty(content))
            {
                newOne = content.Replace(" ", "&nbsp;");
            }
            return newOne;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退回？", "退回记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                KickBackForm _kickform = new KickBackForm(_record);
                if (_kickform.ShowDialog() == DialogResult.OK)
                {
                    _record.Status = RecordStatus.ReturnBack;
                    Record[] recordes = new Record[1] { _record };
                    RecordHelper.UpdateRecords(recordes);
                    this.Close();
                }
            }
        }

        private void button_approve_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否批准？", "批准记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _record.Status = RecordStatus.Approved;
                _record.ApproveBy = UserSession.LoginUser.PingYing;
                _record.ApproveTime = DateTime.Now;
                Record[] recordes=new Record[1]{_record};
                RecordHelper.UpdateRecords(recordes);
                this.Close();
            }
        }

        void CheckAuthorization()
        {
            button_approve.Enabled = Authorization.IsControlVisiable(button_approve.Parent, button_approve, "审查记录", null);
            button_back.Enabled = Authorization.IsControlVisiable(button_back.Parent, button_back, "退回", null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommonHelper.WordOutPut(_record);
        }

        private void bt_openFolder_Click(object sender, EventArgs e)
        {
            string realPath = "";
            string picfoldername = _record.InputUser + "- 图片" + @"\" + _record.ID;
            if (UserSession.LoginUser.Role == Roles.RoleFactorTeamManager)
            {
                string[] temp =RecordHelper.RecordDBPath.Split(new char[] { '\\' });
                string filename = temp[temp.Length-1];
                realPath = RecordHelper.RecordDBPath.Replace(filename, "");
            }
            else
            {
                string[] temp = MainForm.currentDBPath.Split(new char[] { '\\' });
                string filename = temp[temp.Length - 1];
                realPath = MainForm.currentDBPath.Replace(filename, "");
            }
            string recordFolder = System.IO.Path.Combine(realPath, picfoldername);
            if (System.IO.Directory.Exists(recordFolder))
            {
                string[] directorys = System.IO.Directory.GetDirectories(recordFolder);
                if (directorys != null && directorys.Length > 0)
                    CommonHelper.OpenInExplorer(recordFolder);
                else
                    MessageBox.Show("当前记录没有图片！");
            }
            else
                MessageBox.Show("当前记录没有图片！");
        }
    }
}
