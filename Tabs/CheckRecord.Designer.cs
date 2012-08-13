namespace APP
{
    partial class CheckRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbElement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFactory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintBySubject = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.dgvRecord = new System.Windows.Forms.DataGridView();
            this.RecordNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Submiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactoryNO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ElementNO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubjectNO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApproveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintByElement = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.toolTip_zhuanti = new System.Windows.Forms.ToolTip(this.components);
            this.label_checkusername = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.labStatus);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cmbSubject);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbElement);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFactory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "范围";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(685, 19);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(158, 20);
            this.cmbStatus.TabIndex = 21;
            this.cmbStatus.SelectedValueChanged += new System.EventHandler(this.cmbStatus_SelectedValueChanged);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(644, 22);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(35, 12);
            this.labStatus.TabIndex = 20;
            this.labStatus.Text = "状态:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(880, 17);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 19;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cmbSubject
            // 
            this.cmbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(475, 20);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(158, 22);
            this.cmbSubject.TabIndex = 18;
            this.cmbSubject.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbSubject_DrawItem);
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
            this.cmbSubject.DropDownClosed += new System.EventHandler(this.cmbSubject_DropDownClosed);
            this.cmbSubject.MouseEnter += new System.EventHandler(this.cmbSubject_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "专题:";
            // 
            // cmbElement
            // 
            this.cmbElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbElement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbElement.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbElement.FormattingEnabled = true;
            this.cmbElement.Location = new System.Drawing.Point(264, 19);
            this.cmbElement.Name = "cmbElement";
            this.cmbElement.Size = new System.Drawing.Size(158, 22);
            this.cmbElement.TabIndex = 16;
            this.cmbElement.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbElement_DrawItem);
            this.cmbElement.SelectedIndexChanged += new System.EventHandler(this.cmbElement_SelectedIndexChanged);
            this.cmbElement.DropDownClosed += new System.EventHandler(this.cmbElement_DropDownClosed);
            this.cmbElement.SelectedValueChanged += new System.EventHandler(this.cmbElement_SelectedValueChanged);
            this.cmbElement.MouseEnter += new System.EventHandler(this.cmbElement_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "要素:";
            // 
            // cmbFactory
            // 
            this.cmbFactory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFactory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFactory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFactory.FormattingEnabled = true;
            this.cmbFactory.Location = new System.Drawing.Point(49, 20);
            this.cmbFactory.Name = "cmbFactory";
            this.cmbFactory.Size = new System.Drawing.Size(158, 22);
            this.cmbFactory.TabIndex = 14;
            this.cmbFactory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbFactory_DrawItem);
            this.cmbFactory.DropDownClosed += new System.EventHandler(this.cmbFactory_DropDownClosed);
            this.cmbFactory.SelectedValueChanged += new System.EventHandler(this.cmbFactory_SelectedValueChanged);
            this.cmbFactory.MouseEnter += new System.EventHandler(this.cmbFactory_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "电厂:";
            // 
            // btnPrintBySubject
            // 
            this.btnPrintBySubject.Location = new System.Drawing.Point(563, 83);
            this.btnPrintBySubject.Name = "btnPrintBySubject";
            this.btnPrintBySubject.Size = new System.Drawing.Size(75, 23);
            this.btnPrintBySubject.TabIndex = 2;
            this.btnPrintBySubject.Text = "按专题打印";
            this.btnPrintBySubject.UseVisualStyleBackColor = true;
            this.btnPrintBySubject.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(485, 83);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(213, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPass
            // 
            this.btnPass.Location = new System.Drawing.Point(724, 83);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(57, 23);
            this.btnPass.TabIndex = 6;
            this.btnPass.Text = "批准";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Visible = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(644, 83);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(57, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(806, 83);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(57, 23);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "退回";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // dgvRecord
            // 
            this.dgvRecord.AllowUserToAddRows = false;
            this.dgvRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordNO,
            this.RecordName,
            this.Submiter,
            this.FactoryNO,
            this.ElementNO,
            this.SubjectNO,
            this.Status,
            this.SubmitTime,
            this.Checker,
            this.Comment,
            this.ApproveTime,
            this.Sort});
            this.dgvRecord.Location = new System.Drawing.Point(12, 121);
            this.dgvRecord.Name = "dgvRecord";
            this.dgvRecord.ReadOnly = true;
            this.dgvRecord.RowTemplate.Height = 23;
            this.dgvRecord.Size = new System.Drawing.Size(961, 398);
            this.dgvRecord.TabIndex = 8;
            this.dgvRecord.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecord_CellDoubleClick);
            this.dgvRecord.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRecord_RowPostPaint);
            // 
            // RecordNO
            // 
            this.RecordNO.DataPropertyName = "RecordNO";
            this.RecordNO.HeaderText = "记录编号";
            this.RecordNO.Name = "RecordNO";
            this.RecordNO.ReadOnly = true;
            // 
            // RecordName
            // 
            this.RecordName.DataPropertyName = "RecordName";
            this.RecordName.HeaderText = "审查对象";
            this.RecordName.Name = "RecordName";
            this.RecordName.ReadOnly = true;
            this.RecordName.Width = 150;
            // 
            // Submiter
            // 
            this.Submiter.DataPropertyName = "Submiter";
            this.Submiter.HeaderText = "提交人";
            this.Submiter.Name = "Submiter";
            this.Submiter.ReadOnly = true;
            // 
            // FactoryNO
            // 
            this.FactoryNO.DataPropertyName = "FACTORYNO";
            this.FactoryNO.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.FactoryNO.HeaderText = "所属电厂";
            this.FactoryNO.Name = "FactoryNO";
            this.FactoryNO.ReadOnly = true;
            this.FactoryNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FactoryNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ElementNO
            // 
            this.ElementNO.DataPropertyName = "ELEMENTNO";
            this.ElementNO.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ElementNO.HeaderText = "要素";
            this.ElementNO.Name = "ElementNO";
            this.ElementNO.ReadOnly = true;
            this.ElementNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ElementNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SubjectNO
            // 
            this.SubjectNO.DataPropertyName = "SUBJECTNO";
            this.SubjectNO.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SubjectNO.HeaderText = "专题";
            this.SubjectNO.Name = "SubjectNO";
            this.SubjectNO.ReadOnly = true;
            this.SubjectNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubjectNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // SubmitTime
            // 
            this.SubmitTime.DataPropertyName = "SubmitTime";
            this.SubmitTime.HeaderText = "提交时间";
            this.SubmitTime.Name = "SubmitTime";
            this.SubmitTime.ReadOnly = true;
            this.SubmitTime.Width = 150;
            // 
            // Checker
            // 
            this.Checker.DataPropertyName = "Checker";
            this.Checker.HeaderText = "审查员";
            this.Checker.Name = "Checker";
            this.Checker.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "删除原因";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.Width = 150;
            // 
            // ApproveTime
            // 
            this.ApproveTime.DataPropertyName = "ApproveTime";
            this.ApproveTime.HeaderText = "审批时间";
            this.ApproveTime.Name = "ApproveTime";
            this.ApproveTime.ReadOnly = true;
            this.ApproveTime.Width = 150;
            // 
            // Sort
            // 
            this.Sort.HeaderText = "序号";
            this.Sort.Name = "Sort";
            this.Sort.ReadOnly = true;
            this.Sort.Visible = false;
            // 
            // btnPrintByElement
            // 
            this.btnPrintByElement.Location = new System.Drawing.Point(12, 83);
            this.btnPrintByElement.Name = "btnPrintByElement";
            this.btnPrintByElement.Size = new System.Drawing.Size(75, 23);
            this.btnPrintByElement.TabIndex = 9;
            this.btnPrintByElement.Text = "导出word";
            this.btnPrintByElement.UseVisualStyleBackColor = true;
            this.btnPrintByElement.Click += new System.EventHandler(this.btnPrintByElement_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(114, 83);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportToExcel.TabIndex = 10;
            this.btnExportToExcel.Text = "导出Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // label_checkusername
            // 
            this.label_checkusername.AutoSize = true;
            this.label_checkusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_checkusername.Location = new System.Drawing.Point(276, 88);
            this.label_checkusername.Name = "label_checkusername";
            this.label_checkusername.Size = new System.Drawing.Size(137, 12);
            this.label_checkusername.TabIndex = 11;
            this.label_checkusername.Text = "请选择审查的用户文件。";
            // 
            // CheckRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 531);
            this.Controls.Add(this.label_checkusername);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnPrintByElement);
            this.Controls.Add(this.dgvRecord);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPrintBySubject);
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckRecord";
            this.Text = "审查记录";
            this.Load += new System.EventHandler(this.CheckRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrintBySubject;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.DataGridView dgvRecord;
        private System.Windows.Forms.Button btnPrintByElement;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbElement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFactory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.ToolTip toolTip_zhuanti;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Submiter;
        private System.Windows.Forms.DataGridViewComboBoxColumn FactoryNO;
        private System.Windows.Forms.DataGridViewComboBoxColumn ElementNO;
        private System.Windows.Forms.DataGridViewComboBoxColumn SubjectNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubmitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Checker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sort;
        private System.Windows.Forms.Label label_checkusername;
    }
}