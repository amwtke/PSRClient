using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ExportToWord;
using System.IO;

namespace APP
{
    public partial class Tab1_AddAffectForm : Form
    {
        Record _record = null;
        int _height ;
        int _width;
        List<String> listfact;
        int flagAddOrEdit = 0; //0为添加，1为编辑
        bool blHasApproved = false;//是否审批
        bool blView = false;//是否查看
        bool blApproveEdit = false;//是否审批操作
        String _recordno=null;

        string _inputPrompt = "_填写";

        int _affectRichTextBoxCount = 1;

        private ArrayList arrParentNodes = new ArrayList();//专题、要素、电厂节点

        private string strInRecordNO = "";//传入的记录编号
        static RootNode _UserRootLeftTree = null;



        #region 位置相关 事实 723
        static int _detalUpdateHight = 0;

         List<Panel> _panelContainer = new List<Panel>();
         List<Label> _lableContainer = new List<Label>();
         List<RichTextBox> _rtContainer = new List<RichTextBox>();
         List<Button> _btContainer = new List<Button>();
         List<Button> _btPiccontainer = new List<Button>();
         List<Button> _btOpenFolderContainer = new List<Button>();

        static int _tapIndex = 0;
        static int _panelWidth = 592;
        static int _panelHeight = 152;
        static int _rtWidth = 560;
        static int _rtHeight = 48;
        static int _btWidth = 85;
        static int _btHeight = 23;

        static int _penalX = 3;
        static int _penalY = 3;
        static int _rtX = 9;
        static int _rtY = 29;

        static int _btX = 486;
        static int _btY = 1;

        static int _labelX = 7;
        static int _labelY = 8;

        static int _detalAddHeight = 10;
        static int _SelectedRT = -1;

        public string TransferFromBig = "";
        void AddControl()
        {
            Panel _lastPanel;
            Button _lastButton;
            Button _lastPicButton;
            Button _lastOpenFolder;
            Label _lastLable;
            RichTextBox _lastRT;

            if (_panelContainer.Count == 0)
                _lastPanel = this.panel2;
            else
                _lastPanel = _panelContainer[_panelContainer.Count - 1];

            if (_btContainer.Count == 0)
                _lastButton = this.bt_Delete;
            else
                _lastButton = _btContainer[_btContainer.Count - 1];

            if (_btPiccontainer.Count == 0)
            {
                _lastPicButton = bt_picinput;
            }
            else
            {
                _lastPicButton = _btPiccontainer[_btPiccontainer.Count - 1];
            }

            if (_btOpenFolderContainer.Count == 0)
            {
                _lastOpenFolder = bt_openPicFolder;
            }
            else
            {
                _lastOpenFolder = _btOpenFolderContainer[_btOpenFolderContainer.Count - 1];
            }


            if (_lableContainer.Count == 0)
                _lastLable = this.label9;
            else
                _lastLable = _lableContainer[_lableContainer.Count - 1];

            if (_rtContainer.Count == 0)
                _lastRT = this.richTextBox1;
            else
                _lastRT = _rtContainer[_rtContainer.Count - 1];


            int _controlCounter = _panelContainer.Count;
            Panel _tempPanel = new Panel();
            RichTextBox _tempRt = new RichTextBox();
            Button _tempButton = new Button();
            Button _picButton = new Button();
            Button _openFolder = new Button();
            Label _tempLabel = new Label();

            _tempPanel.Anchor = panel2.Anchor;
            _tempPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            _tempPanel.Controls.Add(_tempRt);
            _tempPanel.Controls.Add(_tempButton);
            _tempPanel.Controls.Add(_picButton);
            _tempPanel.Controls.Add(_openFolder);
            _tempPanel.Controls.Add(_tempLabel);
            _tempPanel.Name = "panela" + (_controlCounter).ToString();
            _tempPanel.Size = panel2.Size;//new System.Drawing.Size(_panelWidth, _panelHeight);
            _tempPanel.Tag = _panelContainer.Count;

            if (_panelContainer.Count != 0)//richTextbox1隐藏
                _tempPanel.Location = new System.Drawing.Point(_lastPanel.Location.X, _lastPanel.Location.Y + _lastPanel.Height + _detalAddHeight);
            else
                _tempPanel.Location = new System.Drawing.Point(_penalX, _penalY);//panel2.Location.X, panel2.Location.Y);
            this.panel1.Controls.Add(_tempPanel);

            _tempRt.Anchor = richTextBox1.Anchor;
            _tempRt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            _tempRt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            _tempRt.Location = new System.Drawing.Point(_rtX, _rtY);
            _tempRt.Name = "richTextBox1" + (_controlCounter).ToString();
            _tempRt.Size = richTextBox1.Size;//new System.Drawing.Size(_rtWidth, _rtHeight);
            _tempRt.Tag = _panelContainer.Count;
            _tempRt.ContextMenuStrip = contextMenu_RT;
            _tempRt.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            _tempRt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbClob_KeyDown);
            _tempRt.MouseDown += new MouseEventHandler(richTextBox1_MouseClick);
            _tempRt.MouseEnter += new EventHandler(richTextBox1_Enter);
            _tempRt.MouseWheel += new MouseEventHandler(Panel_MouseWheel);
           // _tempRt.SizeChanged += new EventHandler(richTextBox1_TextChanged);

            _tempButton.Anchor = _lastButton.Anchor;
            _tempButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            _tempButton.ForeColor = System.Drawing.Color.Red;
            _tempButton.Location = new System.Drawing.Point(_lastButton.Location.X, _lastButton.Location.Y);
            _tempButton.Name = "button3" + (_controlCounter).ToString();
            _tempButton.Size = new System.Drawing.Size(_btWidth, _btHeight);
            _tempButton.TabIndex = ++_tapIndex;
            _tempButton.Text = "删除";
            _tempButton.Tag = _panelContainer.Count;
            _tempButton.UseVisualStyleBackColor = false;
            _tempButton.Click += new System.EventHandler(this.bt_Delete_Click);


            _picButton.Anchor = bt_picinput.Anchor;
            _picButton.BackColor = bt_picinput.BackColor;
            _picButton.ForeColor = bt_picinput.ForeColor;
            _picButton.Location = new System.Drawing.Point(_lastPicButton.Location.X, _lastPicButton.Location.Y);
            _picButton.Name = "picbutton" + (_controlCounter).ToString();
            _picButton.Size = bt_picinput.Size;
            _picButton.Text = bt_picinput.Text;
            _picButton.Tag = _panelContainer.Count;
            _picButton.UseVisualStyleBackColor = false;
            _picButton.Click += new EventHandler(bt_picinput_Click);

            _openFolder.Anchor = bt_openPicFolder.Anchor;
            _openFolder.BackColor = bt_picinput.BackColor;
            _openFolder.ForeColor = bt_picinput.ForeColor;
            _openFolder.Location = new System.Drawing.Point(_lastOpenFolder.Location.X, _lastOpenFolder.Location.Y);
            _openFolder.Name = "OpenBT" + (_controlCounter).ToString();
            _openFolder.Size = bt_openPicFolder.Size;
            _openFolder.Text = bt_openPicFolder.Text;
            _openFolder.Tag = _panelContainer.Count;
            _openFolder.UseVisualStyleBackColor = false;
            _openFolder.Click += new EventHandler(bt_openPicFolder_Click);


            _tempLabel.AutoSize = true;
            _tempLabel.Location = new System.Drawing.Point(_labelX, _labelY);
            _tempLabel.Name = "label9" + (_controlCounter).ToString();
            _tempLabel.Size = new System.Drawing.Size(23, 12);
            if (_controlCounter >= 0 && (_controlCounter + 1) < 10)
                _tempLabel.Text = "00" + (_controlCounter + 1).ToString();
            else
                _tempLabel.Text = "0" + (_controlCounter + 1).ToString();

            if (!_unAgainstFactNo.ContainsKey(_panelContainer.Count + 1) && flagAddOrEdit==0)
                _unAgainstFactNo.Add(_panelContainer.Count + 1, "");


            _panelContainer.Add(_tempPanel);
            _lableContainer.Add(_tempLabel);
            _rtContainer.Add(_tempRt);
            _btContainer.Add(_tempButton);
            _btPiccontainer.Add(_picButton);
            _btOpenFolderContainer.Add(_openFolder);

            
        }

        void DeleteControl(object tag, int delta)
        {
            if (tag == null)
                return;
            int index = (int)tag + 1;

            for (; index < _panelContainer.Count; index++)
            {
                _panelContainer[index].Location = new System.Drawing.Point(_panelContainer[index].Location.X, _panelContainer[index].Location.Y - delta);

                _panelContainer[index].Tag = index - 1;
                _btContainer[index].Tag = index - 1;
                _btPiccontainer[index].Tag = index - 1;
                _rtContainer[index].Tag = index - 1;
                _btOpenFolderContainer[index].Tag = index - 1;

                int _controlCounter = index;
                if (_controlCounter >= 0 && _controlCounter < 10)
                    _lableContainer[index].Text = "00" + _controlCounter.ToString();
                else
                    _lableContainer[index].Text = "0" + _controlCounter.ToString();
            }

            _panelContainer.RemoveAt((int)tag);
            _rtContainer.RemoveAt((int)tag);
            _lableContainer.RemoveAt((int)tag);
            _btContainer.RemoveAt((int)tag);
            _btOpenFolderContainer.RemoveAt((int)tag);
            _btPiccontainer.RemoveAt((int)tag);

            UpdateFactAfterDeleteFact((int)tag + 1);
        }
        void AdjustPosition(object tag, int delta)
        {
            if (delta == 0)
                return;
            if (tag == null)//执行不到
            {
                for (int i = 0; i < _panelContainer.Count; i++)
                {
                    _panelContainer[i].Location = new System.Drawing.Point(_panelContainer[i].Location.X, _panelContainer[i].Location.Y + delta);
                }
            }
            else
            {
                int index = (int)tag + 1;//从下一个开始
                for (; index < _panelContainer.Count; index++)
                {
                    _panelContainer[index].Location = new System.Drawing.Point(_panelContainer[index].Location.X, _panelContainer[index].Location.Y + delta);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            ((RichTextBox)(sender)).BackColor = Color.White;
            int originalHight = ((RichTextBox)(sender)).Height;
            Font tempFont = ((RichTextBox)(sender)).Font;

            int textLength = ((RichTextBox)(sender)).Text.Length;

            int textLines = ((RichTextBox)(sender)).GetLineFromCharIndex(textLength) + 1;

            int Margin = ((RichTextBox)(sender)).Bounds.Height - ((RichTextBox)(sender)).ClientSize.Height;
            if (textLines <= 2)
            {
                ((RichTextBox)(sender)).Height = _rtHeight;
            }
            if (textLines >= 3)
            {
                ((RichTextBox)(sender)).Height = (TextRenderer.MeasureText(" ", tempFont).Height * textLines) + Margin + textLines * 5;

                if (textLines > 4 && textLines <= 30)
                {
                    ((RichTextBox)(sender)).Height = ((RichTextBox)(sender)).Height - (int)(textLines * 0.75);
                }
                if (textLines > 30 && textLines <= 80)
                {
                    ((RichTextBox)(sender)).Height = ((RichTextBox)(sender)).Height - (int)(textLines * 0.90);
                }
                if (textLines > 80)
                {
                    ((RichTextBox)(sender)).Height = ((RichTextBox)(sender)).Height - (textLines);
                }
            }

            _detalUpdateHight = ((RichTextBox)(sender)).Height - originalHight;
            if (_detalUpdateHight != 0)
            {
                ((RichTextBox)(sender)).Parent.Height = ((RichTextBox)(sender)).Parent.Height + _detalUpdateHight;
                AdjustPosition(((RichTextBox)(sender)).Tag, _detalUpdateHight);
            }

        }
        //抽出文字
        void tbClob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                IDataObject dataObj = Clipboard.GetDataObject();
                if (dataObj.GetDataPresent(DataFormats.StringFormat))
                {
                    e.Handled = true; //去掉格式文本的格式 
                    int selectionStart = ((RichTextBox)sender).SelectionStart;
                    string txt = (string)Clipboard.GetData(DataFormats.StringFormat);
                    int copytailpos = selectionStart + txt.Length;
                    ((RichTextBox)sender).Text = ((RichTextBox)sender).Text.Insert(selectionStart, txt);
                    ((RichTextBox)sender).Select(copytailpos, 0);
                }
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除事件？如果删除，此事件的图片附件也会被删除！", "删除事件", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int index = (int)((Button)(sender)).Tag;
                object tagPanel = _panelContainer[index].Tag;
                int delta = _panelContainer[index].Height + _detalAddHeight;
                panel1.Controls.Remove(_panelContainer[index]);
                DeleteControl(tagPanel, delta);

                if (!string.IsNullOrEmpty(_record.ID))
                {
                    string no = (((int)((Button)sender).Tag) + 1).ToString();
                    string recodeDesPath = CommonHelper.GetRecordPath(_record.ID, no);
                    if (System.IO.Directory.Exists(recodeDesPath))
                    {
                        CommonHelper.DeleteFolder(recodeDesPath);
                    }
                }

                groupBox4.Text = "事实共：" + (_panelContainer.Count).ToString() + "个";
            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu_RT.Show();
            }

            RichTextBox _this = (RichTextBox)sender;

            int index = (int)_this.Tag + 1;
            if (_SelectedRT != index)
            {
                _this.Select(_this.SelectionStart, 0);
                _SelectedRT = index;
            }


            groupBox4.Text = "事实共：" + (_panelContainer.Count).ToString() + "个。" + "当前是第：" + _SelectedRT + "个。";
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.panel1.Focus();
        }
        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (panel1.VerticalScroll.Value + 10 <= panel1.VerticalScroll.Maximum)
            {
                _SelectedRT = -1;
                this.panel1.Focus();
                panel1.VerticalScroll.Value += 10;
                panel1.Refresh();
                panel1.Invalidate();
                panel1.Update();
            }
        }
        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            //RichTextBox _this = (RichTextBox)sender;
            ////_this.Focus();
            //if ((_this.Tag == null))
            //{
            //    //tt_facts.Show("第1个事实", _this);
            //}
            //else
            //{
            //    int factNo = (int)_this.Tag + 1;
            //    tt_facts.Show("第"+factNo+"个事实", _this);
            //}
        }

        private void _tempRt_Click(object sender, EventArgs e)
        {
            
        }
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox _this;
            _this = _rtContainer[_SelectedRT - 1];
            _this.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox _this;
            _this = _rtContainer[_SelectedRT - 1];
            IDataObject dataObj = Clipboard.GetDataObject();
            if (dataObj.GetDataPresent(DataFormats.StringFormat))
            {
                //e.Handled = true; //去掉格式文本的格式 
                int selectionStart = _this.SelectionStart;
                string txt = (string)Clipboard.GetData(DataFormats.StringFormat);
                int copytailpos = selectionStart + txt.Length;
                _this.Text = _this.Text.Insert(selectionStart, txt);
                _this.Select(copytailpos, 0);
            }
        }

        private void 大窗口编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox _this;
            _this = _rtContainer[_SelectedRT - 1];
            BigFactInputForm _form = new BigFactInputForm(_SelectedRT.ToString(), _this.Text, this);
            if (_form.ShowDialog() == DialogResult.OK)
            {
                _this.Text = TransferFromBig;
            }
        }
        #endregion

        
        #region 位置 结论

        static int _selectedResultPanel = -1;
        static int PanelResultHeight = 165;
        static int _addIncreament = PanelResultHeight + 10;
        static int _panelResultX=3;
        static int _panelResultY=3;
        
         List<TextBox> _tbResultContainer = new List<TextBox>();
         List<RichTextBox> _rtResultContainer = new List<RichTextBox>();
         List<Button> _btResultContainer = new List<Button>();
         List<CheckBox> _ckFHContainer = new List<CheckBox>();
         List<CheckBox> _ckPCContainer = new List<CheckBox>();
         List<Label> _lbResultContainer = new List<Label>();
         List<Panel> _panelResultContainer = new List<Panel>();

        private void AddResult()
        {
            Panel _newPanel = new Panel();
            Label _newResultNo = new Label();
            Label _newDes = new Label();
            TextBox _newtb = new TextBox();
            RichTextBox _newRt = new RichTextBox();
            CheckBox _newFH = new CheckBox();
            CheckBox _newPC = new CheckBox();
            Button _newDeleteBt = new Button();

            Panel _lastOne = new Panel();
            if (_panelResultContainer.Count == 0)
                _lastOne = panel_result;
            else
                _lastOne = _panelResultContainer[_panelResultContainer.Count - 1];

            //Panel
            _newPanel.Anchor = panel_result.Anchor;
            _newPanel.BackColor = System.Drawing.Color.DarkTurquoise;
            _newPanel.Controls.Add(_newResultNo);
            _newPanel.Controls.Add(_newDes);
            _newPanel.Controls.Add(_newtb);
            _newPanel.Controls.Add(_newRt);
            _newPanel.Controls.Add(_newFH);
            _newPanel.Controls.Add(_newPC);
            _newPanel.Controls.Add(_newDeleteBt);

            if(_panelResultContainer.Count!=0)
                _newPanel.Location = new System.Drawing.Point(_lastOne.Location.X, _lastOne.Location.Y + _addIncreament);
            else
                _newPanel.Location = new System.Drawing.Point(_panelResultX, _panelResultY);

            _newPanel.Name = "panel_resulta" + _panelResultContainer.Count.ToString();
            _newPanel.Size = new System.Drawing.Size(panel_result.Width, panel_result.Height);
            _newPanel.Tag = _panelResultContainer.Count;
            panel3.Controls.Add(_newPanel);

            //lable1
            _newResultNo.AutoSize = true;
            _newResultNo.Location = new System.Drawing.Point(label_result.Location.X, label_result.Location.Y);
            _newResultNo.Name = "label_resultb" + (_lbResultContainer.Count + 1).ToString();
            _newResultNo.Size = label_result.Size;//new System.Drawing.Size(35, 12);
            _newResultNo.Text = "结论"+(_lbResultContainer.Count+1).ToString();
            _newResultNo.Tag = _lbResultContainer.Count;

            //label2
            _newDes.AutoSize = true;
            _newDes.Location = new System.Drawing.Point(label_factNo.Location.X, label_factNo.Location.Y);
            _newDes.Name = "label_factNo" + (_lbResultContainer.Count + 1).ToString();
            _newDes.Size = label_factNo.Size;
            _newDes.Text = "针对事实编号:";

            //textbox
            _newtb.Anchor = textBox_results.Anchor;
            _newtb.Location = new System.Drawing.Point(textBox_results.Location.X, textBox_results.Location.Y);
            _newtb.Name = "textBox_results" + (_tbResultContainer.Count + 1).ToString(); ;
            _newtb.Size = this.textBox_results.Size;//new System.Drawing.Size(264, 21);
            _newtb.Tag = _tbResultContainer.Count;
            _newtb.TextChanged += new EventHandler(_newRt_TextChange);
            _newtb.DoubleClick += new EventHandler(textBox_results_DoubleClick);
            _newtb.ReadOnly = true;

            //rich
            _newRt.Anchor = richTextBox_result.Anchor;
            _newRt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            _newRt.Location = new System.Drawing.Point(richTextBox_result.Location.X, richTextBox_result.Location.Y);
            _newRt.Name = "richTextBox_resultb"+(_rtResultContainer.Count+1).ToString();
            _newRt.Size = richTextBox_result.Size;
            _newRt.Text = "";
            _newRt.ContextMenuStrip = contextMenuStrip_result;
            _newRt.Tag = _rtResultContainer.Count;
            _newRt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbClob_KeyDown);
            _newRt.MouseDown +=new MouseEventHandler(_newRt_MouseDown);  
            _newRt.MouseWheel +=new MouseEventHandler(_newRt_MouseWheel);
            _newRt.TextChanged += new System.EventHandler(_newRt_TextChange);

            //delete button
            _newDeleteBt.Anchor = bt_delete_result.Anchor;
            _newDeleteBt.BackColor = System.Drawing.Color.Turquoise;
            _newDeleteBt.ForeColor = System.Drawing.Color.Red;
            _newDeleteBt.Location = new System.Drawing.Point(this.bt_delete_result.Location.X, this.bt_delete_result.Location.Y);
            _newDeleteBt.Name = "bt_delete_result"+(_btResultContainer.Count+1).ToString();
            _newDeleteBt.Size = this.bt_delete_result.Size;//new System.Drawing.Size(75, 23);
            _newDeleteBt.Text = "删除";
            _newDeleteBt.UseVisualStyleBackColor = false;
            _newDeleteBt.Click += new System.EventHandler(this.bt_delete_result_Click);
            _newDeleteBt.Tag = _btResultContainer.Count;

            // checkBox_fh
            _newFH.AutoSize = true;
            _newFH.Location = new System.Drawing.Point(this.checkBox_fh.Location.X, this.checkBox_fh.Location.Y);
            _newFH.Name = "checkBox_fh" + (_ckFHContainer.Count + 1).ToString();
            _newFH.Size = this.checkBox_fh.Size;
            _newFH.Text = "符合项";
            _newFH.UseVisualStyleBackColor = true;
            _newFH.Click += new System.EventHandler(this.checkBox_fh_Click);
            _newFH.Tag = _ckFHContainer.Count;

            // checkBox_pc
            _newPC.AutoSize = true;
            _newPC.Location = new System.Drawing.Point(this.checkBox_pc.Location.X, this.checkBox_pc.Location.Y);
            _newPC.Name = "checkBox_pc" + (_ckPCContainer.Count + 1).ToString();
            _newPC.Size = this.checkBox_pc.Size;
            _newPC.Text = "偏差项";
            _newPC.UseVisualStyleBackColor = true;
            _newPC.Click += new System.EventHandler(this.checkBox_pc_Click);
            _newPC.Tag = _ckPCContainer.Count;

            //加入集合
            _panelResultContainer.Add(_newPanel);
            _tbResultContainer.Add(_newtb);
            _lbResultContainer.Add(_newResultNo);
            _rtResultContainer.Add(_newRt);
            _btResultContainer.Add(_newDeleteBt);
            _ckFHContainer.Add(_newFH);
            _ckPCContainer.Add(_newPC);
        }

        private void DeleteResult(object tag)
        {
            int index = (int)tag+1;
            for (; index < _panelResultContainer.Count; index++)
            {
                _panelResultContainer[index].Location = new System.Drawing.Point(_panelResultContainer[index].Location.X, _panelResultContainer[index].Location.Y - _panelResultContainer[index - 1].Height - 10);

                //更新Tag值
                _panelResultContainer[index].Tag = index-1;
                _rtResultContainer[index].Tag = index-1;
                _lbResultContainer[index].Tag = index - 1;
                _tbResultContainer[index].Tag = index - 1;
                _btResultContainer[index].Tag = index - 1;
                _ckPCContainer[index].Tag = index - 1;
                _ckFHContainer[index].Tag = index - 1;

                _lbResultContainer[index].Text = "结论"+(index).ToString();
            }

            UpdateResultsAfterDeleteResult((int)tag + 1);

            _panelResultContainer.RemoveAt((int)tag);
            _rtResultContainer.RemoveAt((int)tag);
            _lbResultContainer.RemoveAt((int)tag);
            _tbResultContainer.RemoveAt((int)tag);
            _btResultContainer.RemoveAt((int)tag);
            _ckFHContainer.RemoveAt((int)tag);
            _ckPCContainer.RemoveAt((int)tag);


        }

        void _newRt_TextChange(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }

        private void bt_addResult_Click(object sender, EventArgs e)
        {
            AddResult();
            panel3.VerticalScroll.Value = panel3.VerticalScroll.Maximum;
            groupBox3.Text = "结论共：" + (_panelResultContainer.Count).ToString() + "个";
        }

        private void bt_delete_result_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除此结论？", "删除结论", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Panel _this = (Panel)((Button)sender).Parent;
                panel3.Controls.Remove(_this);
                DeleteResult(_this.Tag);
                groupBox3.Text = "结论共：" + (_panelResultContainer.Count).ToString() + "个";
            }
        }

        private void checkBox_pc_Click(object sender, EventArgs e)
        {
            CheckBox _this = (CheckBox)sender;
            _this.Checked = true;

            if (_this.Tag == null)
                checkBox_fh.Checked = false;
            else
                _ckFHContainer[(int)_this.Tag].Checked = false;
            this.BackColor = Color.White;
            _ckFHContainer[(int)_this.Tag].BackColor = Color.White; 

        }

        private void checkBox_fh_Click(object sender, EventArgs e)
        {
            CheckBox _this = (CheckBox)sender;
            _this.Checked = true;

            if (_this.Tag == null)
                checkBox_pc.Checked = false;
            else
                _ckPCContainer[(int)_this.Tag].Checked = false;

            _ckPCContainer[(int)_this.Tag].BackColor = Color.White;
            _this.BackColor = Color.White;
        }

        private void _newRt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip_result.Show();
            }

            RichTextBox _this = (RichTextBox)sender;

            int index = (int)_this.Tag + 1;
            if (_selectedResultPanel != index)
            {
                _this.Select(_this.SelectionStart, 0);
                _selectedResultPanel = index;
            }
            groupBox3.Text = "结论共：" + (_panelResultContainer.Count).ToString() + "个。" + "当前是第：" + _selectedResultPanel + "个。";
        }

        private void _newRt_MouseWheel(object sender, MouseEventArgs e)
        {
            if (panel3.VerticalScroll.Value + 10 <= panel3.VerticalScroll.Maximum)
            {
                _selectedResultPanel = -1;
                this.panel3.Focus();
                panel3.VerticalScroll.Value += 10;
                panel3.Refresh();
                panel3.Invalidate();
                panel3.Update();
            }
        }
        private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox _this;
            _this = _rtResultContainer[_selectedResultPanel - 1];
            _this.Copy();
        }

        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox _this;
            _this = _rtResultContainer[_selectedResultPanel - 1];
            IDataObject dataObj = Clipboard.GetDataObject();
            if (dataObj.GetDataPresent(DataFormats.StringFormat))
            {
                //e.Handled = true; //去掉格式文本的格式 
                int selectionStart = _this.SelectionStart;
                string txt = (string)Clipboard.GetData(DataFormats.StringFormat);
                int copytailpos = selectionStart + txt.Length;
                _this.Text = _this.Text.Insert(selectionStart, txt);
                _this.Select(copytailpos, 0);
            }
        }

        private void 在大窗口打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox _this;
            _this = _rtResultContainer[_selectedResultPanel - 1];
            BigFactInputForm _form = new BigFactInputForm(_selectedResultPanel.ToString(), _this.Text, this, false);
            if (_form.ShowDialog() == DialogResult.OK)
            {
                _this.Text = TransferFromBig;
            }
        }

        #endregion

        public Tab1_AddAffectForm()
        {
            Init();
            label8.Text = "审查方式、文档审查、访谈等";
            richTextBox_description.LostFocus+=new EventHandler(lostFocus);
            textBox_recordName.LostFocus += new EventHandler(lostFocus);
            richTextBox1.LostFocus += new EventHandler(lostFocus);
            this.MouseWheel+=new MouseEventHandler(panel1_MouseWheel);
            tb_spector.Text = UserSession.LoginUser.PingYing;
        }

        /// </summary>
        /// <param name="recordno"></param>
        /// <param name="blHasApproved">是否已审批</param>
        /// <param name="blView">是否查看</param>
        /// <param name="blApproveEdit">是否为审批操作</param>
        public Tab1_AddAffectForm(String recordno, bool blHasApproved, bool blView, bool blApproveEdit)
        {
            Init();

            if (recordno == "")
            {
                flagAddOrEdit = 0; //add
            }
            else
            {
                flagAddOrEdit = 1;//edit
                _recordno = recordno;//记录编号
            }
            this.blHasApproved = blHasApproved;
            this.blView = blView;
            this.blApproveEdit = blApproveEdit;
            this.strInRecordNO = recordno;
            richTextBox_description.LostFocus += new EventHandler(lostFocus);
            textBox_recordName.LostFocus += new EventHandler(lostFocus);
            richTextBox1.LostFocus += new EventHandler(lostFocus);
            label8.Text = "审查方式、文档审查、访谈等";
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);

            tb_spector.Text = UserSession.LoginUser.PingYing;
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            //获取光标位置
            Point mousePoint = new Point(e.X, e.Y);
            //换算成相对本窗体的位置
            mousePoint.Offset(this.Location.X, this.Location.Y);
            //判断是否在panel内             
            if (panel1.RectangleToScreen(panel1.DisplayRectangle).Contains(mousePoint))
            {
                //滚动
                panel1.AutoScrollPosition = new Point(0, panel1.VerticalScroll.Value - e.Delta);
            }
        }

        private void Init()
        {
            InitializeComponent();

            _height = richTextBox1.Size.Height;
            _width = richTextBox1.Size.Width;

            label9.Text = genFactNo(_affectRichTextBoxCount.ToString());

            listfact =new List<String>();
            listfact.Add("1");

            _record = new Record();
            flagAddOrEdit = 0;
        }

        //鉴权
        void CheckAuthorization()
        {
            bt_addAffect.Enabled = Authorization.IsControlVisiable(bt_addAffect.Parent, bt_addAffect, "提交", null);
            Bt_comfirmRecord.Enabled = Authorization.IsControlVisiable(Bt_comfirmRecord.Parent, Bt_comfirmRecord, "提交", null);
            BT_SubmitRecord.Enabled = Authorization.IsControlVisiable(BT_SubmitRecord.Parent, BT_SubmitRecord, "提交", null);

            if (_record.Status == RecordStatus.Approved ||
               _record.Status == RecordStatus.HoldForApprove)//审批 提交状态，双击进来只能查看
            {
                comboBox_facility.Enabled = false;
                comboBox_yaoshu.Enabled = false;
                comboBox_zhuanti.Enabled = false;

                textBox_recordName.ReadOnly = true;
                richTextBox_description.ReadOnly = true;

                bt_addAffect.Enabled = false;
                Bt_comfirmRecord.Enabled = false;//保存按钮
                BT_SubmitRecord.Enabled = false; //提交按钮
            }

            if(Bt_comfirmRecord.Enabled==true ||BT_SubmitRecord.Enabled==true||bt_addAffect.Enabled==true)
            {
                if (!(_record.InputUserSuoXie == UserSession.LoginUser.SuoXie))
                {
                    Bt_comfirmRecord.Enabled = false;
                    BT_SubmitRecord.Enabled = false;
                    bt_addAffect.Enabled = false;
                }
            }

            
        }

        #region ComboBox绑定相关
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
                            _retDic.Add(No, facility);
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
                        if ( facilityReal== facility)
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
                        _retDic.Add(YaoSuManager.GetYaoSuBianHao(realyaosu),realyaosu);
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
                if (_facility != null && _facility.ChildNodes!=null && _facility.ChildNodes.Length>0)
                {
                    foreach (Node yaosu in _facility.ChildNodes)
                    {
                        string realyaosu = YaoSuManager.GetElementNameByNO(TreeNodeHelper.GetRidOfIndexPrefix(yaosu.NodeName));
                        if ( realyaosu == yaosuName)
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
        private void Tab1_AddAffect_Load(object sender, EventArgs e)
        {
            openpicturedailog.Filter = "All   Image   Formats   (*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif)| " +
"*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif|Bitmaps   (*.bmp)|*.bmp| " +
"GIFs   (*.gif)|*.gif|JPEGs   (*.jpg)|*.jpg;*.jpeg|PNGs   (*.png)|*.png|TIFs   (*.tif)|*.tif|All   Files   (*.*)|*.* ";

            this.splitContainer1.SplitterDistance = 220;//固定基本信息面板高度
            this.panel1.MouseClick += new MouseEventHandler(panel1_MouseClick);
            richTextBox1.TextChanged+=new EventHandler(richTextBox1_TextChanged);
            richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbClob_KeyDown);
            richTextBox1.MouseWheel += new MouseEventHandler(Panel_MouseWheel);
            richTextBox1.ContextMenuStrip = contextMenu_RT;
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);

            groupBox4.Text = "事实：" + _panelContainer.Count + "个";
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
            range.BindCombobox(comboBox_facility, GetFacilityFromRootLeftTree()); //FacilityName.dictFactory);
            if (flagAddOrEdit == 1)
            {
                range.BindCombobox(comboBox_yaoshu, YaoSuManager.dictElement);
                range.BindCombobox(comboBox_zhuanti, ZhuanTiManager.dictSubject);
            }
            range.SetRange(this, comboBox_facility, comboBox_yaoshu, comboBox_zhuanti);

            LoadData();

            if (!string.IsNullOrEmpty(_record.Status))
            {
                tb_status.Text = _record.Status;
            }
            else
                tb_status.Text = RecordStatus.Inputed;

            CheckAuthorization();
            if (flagAddOrEdit == 0)
            {
                bt_addAffect.PerformClick();
                bt_addResult.PerformClick();
            }

        }

        public void LoadData() //加载数据
        {
            Bt_printRecord.Enabled = true;//打印
            
            //编辑状态，需要加载数据
            if (1 == flagAddOrEdit)
            {
                this.Text = "编辑记录";
                Bt_printRecord.Enabled = true;

                _record = RecordHelper.GetByRecordId(_recordno);


                FillUnAgainstFact(_record);

                textBox_equipment.Text = _record.Equipment;
                if (null == _record)
                {
                    return;
                }

                if (_record.Status == RecordStatus.ReturnBack)
                {
                    labelback.Visible = true;
                    richTextBox_back.Visible = true;
                    richTextBox_back.Text = _record.SendBackReason;
                }

                comboBox_zhuanti.Text = ZhuanTiManager.GetSubjectNameByNO(_record.ZhuangTiBianHao); //专题
                comboBox_facility.Text = FacilityName.GetFacilityNameByNO(_record.Facility);//电厂
                comboBox_yaoshu.Text = YaoSuManager.GetElementNameByNO(_record.YaoSuBianHao);  //要素
                

                comboBox_facility.Enabled = false;
                comboBox_yaoshu.Enabled = false;
                comboBox_zhuanti.Enabled = false;

                tb_recordNo.Text = _record.ID;      //记录编号 
                tb_spector.Text = _record.InputUser;//UserSession.LoginUser.PingYing;//观察者
                //状态
                textBox_recordName.Text = _record.Topic;
                richTextBox_description.Text = _record.RecordDesciption;

                //加载事件与结论
                if (_record.Facts != null && _record.Facts.Count>0)
                {
                    int count = _record.Facts.Count;
                    for (int i = 0; i < count; i++)
                    {
                        AddControl();
                        _rtContainer[i].Text = _record.Facts[i].Content;
                    }
                }
                if (_record.Results != null && _record.Results.Count > 0)
                {
                    int countR = _record.Results.Count;
                    for (int i = 0; i < countR; i++)
                    {
                        AddResult();
                        _rtResultContainer[i].Text = _record.Results[i].Content;
                        _tbResultContainer[i].Text = _record.Results[i].AgainstFacts;
                        _ckFHContainer[i].Checked = _record.Results[i].IsFH;
                        _ckPCContainer[i].Checked = _record.Results[i].IsPC;
                    }
                }

                //加载分类
                checkBox_document.Checked = _record.IsDocumentRevision;
                checkBox_activity.Checked = _record.IsActivityInspection;
                checkBox_compliance.Checked = _record.IsCompliance;
                checkBox_communication.Checked = _record.IsCommunication;
                checkBox_walkdown.Checked = _record.IsWalkDown;
            }
            else
            {
                this.Text = "添加记录";
                Bt_printRecord.Enabled = false; //添加不能打印
                _record.InputUserSuoXie = UserSession.LoginUser.SuoXie;
                genRecordno();
            }
        }

        private void genRecordno()
        {
            if (flagAddOrEdit == 0) //添加状态才计算id
            {
                if (comboBox_facility.SelectedIndex > 0 &&
                    comboBox_yaoshu.SelectedIndex > 0)
                {
                    _record.Facility = FacilityName.GetFacilityNO(comboBox_facility.Text);
                    _record.YaoSuBianHao = YaoSuManager.GetYaoSuBianHao(comboBox_yaoshu.Text);
                    _record.ZhuangTiBianHao = ZhuanTiManager.GetSubjectNO(comboBox_zhuanti.Text);
                    _record.InputUserSuoXie = UserSession.LoginUser.SuoXie;

                    _record.GenId();//生成编号
                    tb_recordNo.Text = _record.ID;
                }
            }
        }

        //事件编号
        private String genFactNo(String no)
        {
            if (no.Length == 1)
                return "00" + no;
            else if (no.Length ==2)
                return "0" + no;
            else
                return no;
        }

        private void Bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存
        private void Bt_comfirmRecord_Click(object sender, EventArgs e)
        {
            Save(RecordStatus.Inputed, sender);
        }

        //提交
        private void BT_SubmitRecord_Click(object sender, EventArgs e)
        {
            Save(RecordStatus.HoldForApprove, sender);
        }

        //符合项列表
        List<int> _fuhe = new List<int>();
        private void Save(String status, object sender)
        {
            Button _buttonClicked = (Button)sender;
            bool close = true;

            if (tb_recordNo.Text.Length <= 0)
            {
                MessageBox.Show("记录号为空，不能保存");
                comboBox_facility.BackColor = Color.Red;
                comboBox_yaoshu.BackColor = Color.Red;
                return;
            }
            try
            {
                ((Button)sender).Enabled = false;

                if (!string.IsNullOrEmpty(comboBox_facility.Text))//电厂
                {
                    _record.Facility = FacilityName.GetFacilityNO(comboBox_facility.Text.Trim());
                }
                else
                {
                    comboBox_facility.BackColor = Color.Red;
                    close = false;
                }

                if (!string.IsNullOrEmpty(comboBox_yaoshu.Text))  //要素
                {

                    _record.YaoSuBianHao = YaoSuManager.GetYaoSuBianHao(comboBox_yaoshu.Text.Trim());
                }
                else
                {
                    comboBox_yaoshu.BackColor = Color.Red;
                    close = false;
                }

                if (comboBox_zhuanti.SelectedIndex >= 0)//专题!string.IsNullOrEmpty(comboBox_zhuanti.Text)
                {
                    _record.ZhuangTiBianHao = ZhuanTiManager.GetSubjectNO(comboBox_zhuanti.Text.Trim());
                }

                _record.InputUser = tb_spector.Text;//观察人
                _record.InputUserSuoXie = UserSession.LoginUser.SuoXie;//缩写
                _record.DanWei = UserSession.LoginUser.DanWei;
                _record.Equipment = textBox_equipment.Text;
                /*
                    * 审查记录编号规则：

                    电厂（2位）+审查次数（1位）+要素编号（两位）+专题编号（2位）+单                 位（两位）+  人（3位）+流水，如无专题编号为0。

                    事实编号：审查记录编号+流水号（3位）
                 */
                _record.ID = tb_recordNo.Text;

                _record.Status = status;//状态

                _record.InputTime = DateTime.Now;
                if (!string.IsNullOrEmpty(textBox_recordName.Text) || status == RecordStatus.Inputed)//记录名称
                {
                    _record.Topic = textBox_recordName.Text;
                    textBox_recordName.BackColor = Color.White;
                }
                else
                {
                    close = false;
                    textBox_recordName.BackColor = Color.Red;
                }

                if (!string.IsNullOrEmpty(richTextBox_description.Text) || status == RecordStatus.Inputed)//记录概述
                {
                    _record.RecordDesciption = richTextBox_description.Text;
                    richTextBox_description.BackColor = Color.White;
                }
                else
                {
                    close = false;
                    richTextBox_description.BackColor = Color.Red;
                }
                //检查分类
                if (!checkBox_activity.Checked && !checkBox_communication.Checked
                    && !checkBox_compliance.Checked && !checkBox_document.Checked && !checkBox_walkdown.Checked
                    && status==RecordStatus.HoldForApprove)
                {
                    checkBox_activity.BackColor = Color.Red;
                    checkBox_communication.BackColor = Color.Red;
                    checkBox_compliance.BackColor = Color.Red;
                    checkBox_document.BackColor = Color.Red;
                    checkBox_walkdown.BackColor = Color.Red;
                    MessageBox.Show("请选择记录分类！");
                    return;
                }
                else
                {
                    _record.IsActivityInspection = checkBox_activity.Checked;
                    _record.IsCommunication = checkBox_communication.Checked;
                    _record.IsCompliance = checkBox_compliance.Checked;
                    _record.IsWalkDown = checkBox_walkdown.Checked;
                    _record.IsDocumentRevision = checkBox_document.Checked;
                }

                //检查事件与结论
                //提交进行全面检查
                if (status == RecordStatus.HoldForApprove)
                {
                    if (_rtContainer.Count == 0 || _rtResultContainer.Count == 0)
                    {
                        MessageBox.Show("提交记录必须包含一个事件与结论！");
                        return;
                    }
                    else
                    {
                        //是否都填写了结论
                        if (_unAgainstFactNo.Keys.Count > 0)
                        {
                            string temp = "";
                            foreach (int s in _unAgainstFactNo.Keys)
                            {
                                temp += s.ToString() + ",";
                            }
                            MessageBox.Show("还有这些事实（编号）：" + temp.Remove(temp.Length - 1, 1) + " 没有填写结论！");
                            return;
                        }

                        for (int i = 0; i < _rtContainer.Count; i++)
                        {
                            if (_rtContainer[i].Text == "")
                            {
                                _rtContainer[i].BackColor = Color.Red;
                                MessageBox.Show("事件必须有内容！请检查！");
                                return;
                            }
                        }

                        for (int i = 0; i < _rtResultContainer.Count;i++ )
                        {
                            if (_rtResultContainer[i].Text == "")
                            {
                                _rtResultContainer[i].BackColor = Color.Red;
                                MessageBox.Show("结论必须有内容！请检查！");
                                return;
                            }

                            if (_tbResultContainer[i].Text == "")
                            {
                                _tbResultContainer[i].BackColor = Color.Red;
                                MessageBox.Show("结论所针对的事件必须填！请检查！");
                                return;
                            }

                            if (!_ckFHContainer[i].Checked && !_ckPCContainer[i].Checked)
                            {
                                _ckFHContainer[i].BackColor = Color.Red;
                                _ckPCContainer[i].BackColor = Color.Red;
                                MessageBox.Show("结论必须填是符合项或者偏差项！请检查！");
                                return;
                            }
                        }
                    }

                    //结论与事实关联
                    for (int i = 0; i < _panelResultContainer.Count; i++)
                    {
                        if (_ckFHContainer[i].Checked)
                        {
                            string[] temp = _tbResultContainer[i].Text.Trim().Split(new char[] { ',' });
                            foreach (string s in temp)
                            {
                                _fuhe.Add(int.Parse(s));
                            }
                        }
                    }
                }
                //保存记录
                _record.Facts = new List<Fact>();
                for (int i = 0; i < _rtContainer.Count; i++)
                {
                    Fact _fact = new Fact();
                    _fact.Content = _rtContainer[i].Text;
                    _fact.ID = genFactNo(i.ToString());
                    _fact.TimeStamp = DateTime.Now;
                    _fact.RecordNo = _record.ID;

                    if (_fuhe.Contains(i+1))
                    {
                        _fact.IsFH = true;
                        _fact.IsPC = false;
                    }
                    else
                    {
                        _fact.IsPC = true;
                        _fact.IsFH = false;
                    }

                    _record.Facts.Add(_fact);

                }
                //保存结论
                _record.Results = new List<RecordResult>();
                for (int i = 0; i < _rtResultContainer.Count; i++)
                {
                    RecordResult _result = new RecordResult();
                    _result.AgainstFacts = _tbResultContainer[i].Text;
                    _result.Content = _rtResultContainer[i].Text;
                    _result.IsFH = _ckFHContainer[i].Checked;
                    _result.IsPC = _ckPCContainer[i].Checked;
                    _result.RecordNo = _record.ID;
                    _result.ID = _result.ID + "result" + i.ToString();
                    _record.Results.Add(_result);
                }

                if (close)
                {
                    if (flagAddOrEdit == 0)
                    {
                        //添加记录
                        if (!RecordHelper.AddRecord(_record))
                        {
                            Record[] r = new Record[1];
                            r[0] = _record;
                            RecordHelper.UpdateRecords(r);
                        }
                    }
                    else
                    {
                        Record[] r = new Record[1];
                        r[0] = _record;
                        RecordHelper.UpdateRecords(r);//更新
                    }
                    if (status == RecordStatus.Inputed)
                        MessageBox.Show("保存成功");
                    else
                        MessageBox.Show("提交成功");

                    if (((Button)sender).Name.Equals("BT_SubmitRecord"))
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("红色高亮显示的字段未必填！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败");
            }
            finally
            {

                ((Button)sender).Enabled = true;
            }
        }

        private void bt_addAffect_Click_1(object sender, EventArgs e)
        {
            AddControl();
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            groupBox4.Text = "事实共：" + (_panelContainer.Count).ToString() + "个";
        }

        private void comboBox_facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_yaoshu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_zhuanti_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Bt_printRecord_Click(object sender, EventArgs e)//打印
        {
            CommonHelper.WordOutPut(_record);
        }


        private void comboBox_facility_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(this.comboBox_facility.GetItemText(comboBox_facility.Items[e.Index]), e.Font, System.Drawing.Brushes.Black, e.Bounds);
                //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    toolTip_zhuanti.Show(this.comboBox_facility.GetItemText(comboBox_facility.Items[e.Index]), comboBox_facility, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
                e.DrawFocusRectangle();
            }
            
        }

        private void comboBox_facility_DropDownClosed(object sender, EventArgs e)
        {
            toolTip_zhuanti.Hide(comboBox_facility);
        }

        private void comboBox_facility_MouseEnter(object sender, EventArgs e)
        {
            toolTip_zhuanti.Show(comboBox_facility.Text, comboBox_facility);
        }

        private void comboBox_yaoshu_MouseEnter(object sender, EventArgs e)
        {
            toolTip_zhuanti.Show(comboBox_yaoshu.Text, comboBox_yaoshu);
        }

        private void comboBox_yaoshu_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(this.comboBox_yaoshu.GetItemText(comboBox_yaoshu.Items[e.Index]), e.Font, System.Drawing.Brushes.Black, e.Bounds);
                //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    toolTip_zhuanti.Show(this.comboBox_yaoshu.GetItemText(comboBox_yaoshu.Items[e.Index]), comboBox_yaoshu, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
                e.DrawFocusRectangle();
            }
        }

        private void comboBox_yaoshu_DropDownClosed(object sender, EventArgs e)
        {
            toolTip_zhuanti.Hide(comboBox_yaoshu);
        }

        private void comboBox_zhuanti_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(this.comboBox_zhuanti.GetItemText(comboBox_zhuanti.Items[e.Index]), e.Font, System.Drawing.Brushes.Black, e.Bounds);
                //将高亮的列表项目的文字传递到toolTip1(之前建立ToolTip的一个实例)
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    toolTip_zhuanti.Show(this.comboBox_zhuanti.GetItemText(comboBox_zhuanti.Items[e.Index]), comboBox_zhuanti, e.Bounds.X + e.Bounds.Width - 200, e.Bounds.Y + e.Bounds.Height, 1000);
                e.DrawFocusRectangle();
            }
            
        }

        private void comboBox_zhuanti_DropDownClosed(object sender, EventArgs e)
        {
            toolTip_zhuanti.Hide(comboBox_zhuanti);
            textBox_recordName.Focus();
        }

        private void comboBox_zhuanti_MouseEnter(object sender, EventArgs e)
        {
            toolTip_zhuanti.Show(comboBox_zhuanti.Text, comboBox_zhuanti);
        }

        private void RecordTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            Control _this = (Control)sender;
            if (_this.Text.StartsWith(_inputPrompt))
            {
                _this.Text = string.Empty;
            }
        }

        private void lostFocus(object sender, EventArgs e)
        {
            //Control _this = (Control)sender;
            //if (_this.Text == string.Empty)
            //{
            //    _this.Text = _inputPrompt+"内容...";
            //    _this.BackColor = Color.White;
            //}
        }

        private void Tab1_AddAffectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_record.Status == RecordStatus.Inputed)
            {
                if (MessageBox.Show("是否退出？", "关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
        }

        private void comboBox_yaoshu_DropDown(object sender, EventArgs e)
        {
            if (comboBox_facility.Text != string.Empty)
            {
                Range range = new Range();
                range.BindCombobox(comboBox_yaoshu, GetYaoSuFromRootLeftTree(comboBox_facility.Text));
            }
        }

        private void comboBox_zhuanti_DropDown(object sender, EventArgs e)
        {
            if (comboBox_facility.Text != string.Empty && comboBox_yaoshu.Text!=string.Empty)
            {
                Range range = new Range();
                range.BindCombobox(comboBox_zhuanti, GetZhuanTisFromRootLeftTree(comboBox_facility.Text, comboBox_yaoshu.Text));
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
        }

        private void checkBox_activity_Click(object sender, EventArgs e)
        {
            checkBox_activity.BackColor = Color.White;
            checkBox_communication.BackColor = Color.White;
            checkBox_compliance.BackColor = Color.White;
            checkBox_walkdown.BackColor = Color.White;
            checkBox_document.BackColor = Color.White;
        }

        private void richTextBox_back_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            KickBackForm _kickForm = new KickBackForm(_record,false);
            _kickForm.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_facility_SelectedValueChanged(object sender, EventArgs e)
        {
            genRecordno();
            Control _this = (Control)sender;
            _this.BackColor = Color.White;
            if (flagAddOrEdit != 1)
            {
                //this.comboBox_yaoshu.Text = "";
                //this.comboBox_zhuanti.Text = "";
                comboBox_yaoshu.DataSource = null;
                comboBox_zhuanti.DataSource = null;
            }
        }

        private void comboBox_yaoshu_SelectedValueChanged(object sender, EventArgs e)
        {
            genRecordno();
            Control _this = (Control)sender;
            _this.BackColor = Color.White;
            if (flagAddOrEdit != 1)
            {
                //this.comboBox_zhuanti.Text = "";
                comboBox_zhuanti.DataSource = null;
            }
        }

        private void comboBox_zhuanti_SelectedValueChanged(object sender, EventArgs e)
        {
            genRecordno();
            Control _this = (Control)sender;
            _this.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox_description.Top += 20;
            //richTextBox_description.Height -= 20;
        }

        private void bt_picinput_Click(object sender, EventArgs e)
        {
            if (openpicturedailog.ShowDialog() == DialogResult.OK)
            {
                if (_record.ID != null && _record.ID!="")
                {
                    string no = (((int)((Button)sender).Tag) + 1).ToString();
                    string recodeDesPath = CommonHelper.GetRecordPath(_record.ID, no);
                    if (!System.IO.Directory.Exists(recodeDesPath))
                    {
                        System.IO.Directory.CreateDirectory(recodeDesPath);
                    }

                    for (int i = 0; i < openpicturedailog.FileNames.Length; i++)
                    {
                        string fileName = recodeDesPath + @"\" + openpicturedailog.SafeFileNames[i];
                        System.IO.File.Copy(openpicturedailog.FileNames[i], fileName,true);
                    }
                    MessageBox.Show("共导入：" + openpicturedailog.FileNames.Length.ToString() + "张图片！");
                }
                else
                {
                    Bt_comfirmRecord.PerformClick();
                }
            }
        }

        private void bt_openPicFolder_Click(object sender, EventArgs e)
        {
            if (_record.ID != null && _record.ID != "")
            {
                string no = (((int)((Button)sender).Tag) + 1).ToString();
                string recodeDesPath = CommonHelper.GetRecordPath(_record.ID, no);
                if (System.IO.Directory.Exists(recodeDesPath))
                    CommonHelper.OpenInExplorer(recodeDesPath);
                else
                    MessageBox.Show("当前事实没有图片！");
            }
            else
            {
                Bt_comfirmRecord.PerformClick();
            }
        }

        //实际的索引值
        public SortedList<int,string> _unAgainstFactNo = new SortedList<int,string>();

        public string AgainstStr = "";
        private void textBox_results_DoubleClick(object sender, EventArgs e)
        {
            TextBox _this = (TextBox)(sender);
            if (SelectAgainstFactsForm.OpenCount == 0)
            {
                SelectAgainstFactsForm _form = new SelectAgainstFactsForm(this,_this);
                _form.Show();
            }
        }

        /// <summary>
        /// 实际索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetTextOfPanelByIndex(int index)
        {
            if (_panelContainer.Count >= index)
            {
                return _rtContainer[index - 1].Text;
            }
            return "";
        }

        //逗号分隔
        public string FormSelectFactString(List<int> selected)
        {
            string retStr = "";
            if (selected != null && selected.Count > 0)
            {
                foreach (int s in selected)
                {
                    retStr = retStr + s.ToString()+",";
                }
            }
            if (!string.IsNullOrEmpty(retStr))
            {
                retStr = retStr.Remove(retStr.Length - 1, 1);
            }
            return retStr;
        }

        /// <summary>
        /// index实际索引
        /// </summary>
        /// <param name="index"></param>
        private void UpdateResultsAfterDeleteResult(int index)
        {
            //吧选中的回收
            if (_tbResultContainer.Count >= index)
            {
                string against = _tbResultContainer[index - 1].Text;
                if (against != null && against.Length > 0)
                {
                    string[] facts = against.Split(new char[] { ',' });
                    if (facts != null && facts.Length > 0)
                    {
                        foreach (string s in facts)
                        {
                            if (!_unAgainstFactNo.ContainsKey(int.Parse(s)))
                                _unAgainstFactNo.Add(int.Parse(s), "");
                        }
                    }
                }
            }
        }
       /// <summary>
       /// 实际的索引值
       /// </summary>
       /// <param name="index"></param>
        private void UpdateFactAfterDeleteFact(int index)
        {
            if (_unAgainstFactNo.ContainsKey(index))
            {
                _unAgainstFactNo.Remove(index);
            }

            if (_tbResultContainer.Count >= 0)
            {
                foreach (TextBox tb in _tbResultContainer)
                {
                    string against = tb.Text;
                    if (against != null && against.Length > 0)
                    {
                        string[] facts = against.Split(new char[] { ',' });
                        if (facts != null && facts.Length > 0)
                        {
                            List<int> _tempList = new List<int>();
                            foreach (string s in facts)
                            {
                                int curent = int.Parse(s);
                                if (index != curent)
                                {
                                    if (curent > index)
                                        _tempList.Add(curent - 1);
                                    else
                                        _tempList.Add(curent);
                                }
                            }
                            tb.Text = FormSelectFactString(_tempList);
                        }
                    }
                }
            }
        }

        private void FillUnAgainstFact(Record record)
        {
            if (flagAddOrEdit == 1 && record != null)
            {
                _unAgainstFactNo.Clear();
                int i = 1;
                foreach (Fact f in record.Facts)
                {
                    _unAgainstFactNo.Add(i, "");
                    i++;
                }

                foreach (RecordResult r in record.Results)
                {
                    if (r.AgainstFacts != "")
                    {
                        string[] temp = r.AgainstFacts.Split(new char[] { ',' });
                        if (temp != null && temp.Length > 0)
                        {
                            foreach (string s in temp)
                            {
                                int no = int.Parse(s);
                                if (_unAgainstFactNo.ContainsKey(no))
                                {
                                    _unAgainstFactNo.Remove(no);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
