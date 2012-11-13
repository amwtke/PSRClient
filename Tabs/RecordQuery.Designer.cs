namespace APP
{
    partial class RecordQuery
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
            this.comboBox_fhpc = new System.Windows.Forms.ComboBox();
            this.bt_export = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_against = new System.Windows.Forms.TextBox();
            this.tb_factDescription = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbElement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFactory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.dgvRecord = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBMITER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APPROVER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBMITTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LookintoRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.删除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpReturn = new System.Windows.Forms.TabPage();
            this.tpOK = new System.Windows.Forms.TabPage();
            this.tpSubmit = new System.Windows.Forms.TabPage();
            this.tpEdit = new System.Windows.Forms.TabPage();
            this.tpSum = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labSumError = new System.Windows.Forms.Label();
            this.labError = new System.Windows.Forms.Label();
            this.grpFit = new System.Windows.Forms.GroupBox();
            this.labSumFit = new System.Windows.Forms.Label();
            this.labFit = new System.Windows.Forms.Label();
            this.grpRecord = new System.Windows.Forms.GroupBox();
            this.labSumDeleted = new System.Windows.Forms.Label();
            this.labDeleted = new System.Windows.Forms.Label();
            this.labSumRecord = new System.Windows.Forms.Label();
            this.labRecord = new System.Windows.Forms.Label();
            this.labSumReturn = new System.Windows.Forms.Label();
            this.labReturn = new System.Windows.Forms.Label();
            this.labSumOK = new System.Windows.Forms.Label();
            this.labOK = new System.Windows.Forms.Label();
            this.labSumSubmit = new System.Windows.Forms.Label();
            this.labSubmit = new System.Windows.Forms.Label();
            this.labSumEdit = new System.Windows.Forms.Label();
            this.labEdit = new System.Windows.Forms.Label();
            this.tabRecord = new System.Windows.Forms.TabControl();
            this.tpDeleted = new System.Windows.Forms.TabPage();
            this.toolTip_zhuanti = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.彻底删除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.彻底删除记录ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tpQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tpSum.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpFit.SuspendLayout();
            this.grpRecord.SuspendLayout();
            this.tabRecord.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox_fhpc);
            this.groupBox1.Controls.Add(this.bt_export);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_against);
            this.groupBox1.Controls.Add(this.tb_factDescription);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cmbSubject);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbElement);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFactory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "范围";
            // 
            // comboBox_fhpc
            // 
            this.comboBox_fhpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fhpc.FormattingEnabled = true;
            this.comboBox_fhpc.Items.AddRange(new object[] {
            "全部",
            "符合项",
            "偏差项"});
            this.comboBox_fhpc.Location = new System.Drawing.Point(514, 52);
            this.comboBox_fhpc.Name = "comboBox_fhpc";
            this.comboBox_fhpc.Size = new System.Drawing.Size(121, 20);
            this.comboBox_fhpc.TabIndex = 20;
            this.comboBox_fhpc.Visible = false;
            // 
            // bt_export
            // 
            this.bt_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_export.Location = new System.Drawing.Point(641, 52);
            this.bt_export.Name = "bt_export";
            this.bt_export.Size = new System.Drawing.Size(75, 23);
            this.bt_export.TabIndex = 19;
            this.bt_export.Text = "导出";
            this.bt_export.UseVisualStyleBackColor = true;
            this.bt_export.Click += new System.EventHandler(this.bt_export_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "审查对象:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "事实描述:";
            // 
            // tb_against
            // 
            this.tb_against.Location = new System.Drawing.Point(314, 53);
            this.tb_against.Name = "tb_against";
            this.tb_against.Size = new System.Drawing.Size(188, 21);
            this.tb_against.TabIndex = 14;
            this.tb_against.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_against_KeyUp);
            // 
            // tb_factDescription
            // 
            this.tb_factDescription.Location = new System.Drawing.Point(72, 54);
            this.tb_factDescription.Name = "tb_factDescription";
            this.tb_factDescription.Size = new System.Drawing.Size(172, 21);
            this.tb_factDescription.TabIndex = 13;
            this.tb_factDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_factDescription_KeyUp);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(641, 19);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cmbSubject
            // 
            this.cmbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(477, 20);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(158, 22);
            this.cmbSubject.TabIndex = 11;
            this.cmbSubject.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbSubject_DrawItem);
            this.cmbSubject.DropDownClosed += new System.EventHandler(this.cmbSubject_DropDownClosed);
            this.cmbSubject.SelectedValueChanged += new System.EventHandler(this.cmbSubject_SelectedValueChanged);
            this.cmbSubject.Enter += new System.EventHandler(this.cmbSubject_Enter);
            this.cmbSubject.MouseEnter += new System.EventHandler(this.cmbSubject_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "专题:";
            // 
            // cmbElement
            // 
            this.cmbElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbElement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbElement.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbElement.FormattingEnabled = true;
            this.cmbElement.Location = new System.Drawing.Point(266, 19);
            this.cmbElement.Name = "cmbElement";
            this.cmbElement.Size = new System.Drawing.Size(158, 22);
            this.cmbElement.TabIndex = 9;
            this.cmbElement.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbElement_DrawItem);
            this.cmbElement.DropDownClosed += new System.EventHandler(this.cmbElement_DropDownClosed);
            this.cmbElement.SelectedValueChanged += new System.EventHandler(this.cmbElement_SelectedValueChanged);
            this.cmbElement.MouseEnter += new System.EventHandler(this.cmbElement_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "要素:";
            // 
            // cmbFactory
            // 
            this.cmbFactory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFactory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFactory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFactory.FormattingEnabled = true;
            this.cmbFactory.Location = new System.Drawing.Point(51, 20);
            this.cmbFactory.Name = "cmbFactory";
            this.cmbFactory.Size = new System.Drawing.Size(158, 22);
            this.cmbFactory.TabIndex = 7;
            this.cmbFactory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbFactory_DrawItem);
            this.cmbFactory.DropDownClosed += new System.EventHandler(this.cmbFactory_DropDownClosed);
            this.cmbFactory.SelectedValueChanged += new System.EventHandler(this.cmbFactory_SelectedValueChanged);
            this.cmbFactory.MouseEnter += new System.EventHandler(this.cmbFactory_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "电厂:";
            // 
            // tpQuery
            // 
            this.tpQuery.Controls.Add(this.dgvRecord);
            this.tpQuery.Location = new System.Drawing.Point(4, 22);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Size = new System.Drawing.Size(728, 292);
            this.tpQuery.TabIndex = 5;
            this.tpQuery.Text = "记录查询";
            this.tpQuery.UseVisualStyleBackColor = true;
            // 
            // dgvRecord
            // 
            this.dgvRecord.AllowUserToAddRows = false;
            this.dgvRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Sort,
            this.RecordNO,
            this.RecordName,
            this.Status,
            this.SUBMITER,
            this.APPROVER,
            this.SUBMITTIME});
            this.dgvRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecord.Location = new System.Drawing.Point(0, 0);
            this.dgvRecord.Name = "dgvRecord";
            this.dgvRecord.ReadOnly = true;
            this.dgvRecord.RowTemplate.Height = 23;
            this.dgvRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecord.Size = new System.Drawing.Size(728, 292);
            this.dgvRecord.TabIndex = 1;
            this.dgvRecord.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecord_CellDoubleClick);
            this.dgvRecord.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRecord_CellMouseClick);
            this.dgvRecord.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRecord_DataBindingComplete);
            this.dgvRecord.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRecord_RowPostPaint);
            // 
            // Select
            // 
            this.Select.HeaderText = "选择";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Visible = false;
            // 
            // Sort
            // 
            this.Sort.HeaderText = "序号";
            this.Sort.Name = "Sort";
            this.Sort.ReadOnly = true;
            this.Sort.Visible = false;
            // 
            // RecordNO
            // 
            this.RecordNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RecordNO.DataPropertyName = "RecordNO";
            this.RecordNO.HeaderText = "记录编号";
            this.RecordNO.Name = "RecordNO";
            this.RecordNO.ReadOnly = true;
            this.RecordNO.Width = 78;
            // 
            // RecordName
            // 
            this.RecordName.DataPropertyName = "RecordName";
            this.RecordName.HeaderText = "审查对象";
            this.RecordName.Name = "RecordName";
            this.RecordName.ReadOnly = true;
            this.RecordName.Width = 300;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // SUBMITER
            // 
            this.SUBMITER.DataPropertyName = "SUBMITER";
            this.SUBMITER.HeaderText = "提交人";
            this.SUBMITER.Name = "SUBMITER";
            this.SUBMITER.ReadOnly = true;
            // 
            // APPROVER
            // 
            this.APPROVER.DataPropertyName = "APPROVER";
            this.APPROVER.HeaderText = "审批人";
            this.APPROVER.Name = "APPROVER";
            this.APPROVER.ReadOnly = true;
            // 
            // SUBMITTIME
            // 
            this.SUBMITTIME.DataPropertyName = "SUBMITTIME";
            this.SUBMITTIME.HeaderText = "提交时间";
            this.SUBMITTIME.Name = "SUBMITTIME";
            this.SUBMITTIME.ReadOnly = true;
            this.SUBMITTIME.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LookintoRecord,
            this.删除记录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // LookintoRecord
            // 
            this.LookintoRecord.Name = "LookintoRecord";
            this.LookintoRecord.Size = new System.Drawing.Size(124, 22);
            this.LookintoRecord.Text = "查看记录";
            this.LookintoRecord.Click += new System.EventHandler(this.彻底删除ToolStripMenuItem_Click);
            // 
            // 删除记录ToolStripMenuItem
            // 
            this.删除记录ToolStripMenuItem.Name = "删除记录ToolStripMenuItem";
            this.删除记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除记录ToolStripMenuItem.Text = "删除记录";
            this.删除记录ToolStripMenuItem.Click += new System.EventHandler(this.删除记录ToolStripMenuItem_Click);
            // 
            // tpReturn
            // 
            this.tpReturn.Location = new System.Drawing.Point(4, 22);
            this.tpReturn.Name = "tpReturn";
            this.tpReturn.Size = new System.Drawing.Size(728, 292);
            this.tpReturn.TabIndex = 4;
            this.tpReturn.Text = "退回记录";
            this.tpReturn.UseVisualStyleBackColor = true;
            // 
            // tpOK
            // 
            this.tpOK.Location = new System.Drawing.Point(4, 22);
            this.tpOK.Name = "tpOK";
            this.tpOK.Size = new System.Drawing.Size(728, 292);
            this.tpOK.TabIndex = 3;
            this.tpOK.Text = "已审批记录";
            this.tpOK.UseVisualStyleBackColor = true;
            // 
            // tpSubmit
            // 
            this.tpSubmit.Location = new System.Drawing.Point(4, 22);
            this.tpSubmit.Name = "tpSubmit";
            this.tpSubmit.Size = new System.Drawing.Size(728, 292);
            this.tpSubmit.TabIndex = 2;
            this.tpSubmit.Text = "已提交记录";
            this.tpSubmit.UseVisualStyleBackColor = true;
            // 
            // tpEdit
            // 
            this.tpEdit.Location = new System.Drawing.Point(4, 22);
            this.tpEdit.Name = "tpEdit";
            this.tpEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpEdit.Size = new System.Drawing.Size(728, 292);
            this.tpEdit.TabIndex = 1;
            this.tpEdit.Text = "在编辑记录";
            this.tpEdit.UseVisualStyleBackColor = true;
            // 
            // tpSum
            // 
            this.tpSum.Controls.Add(this.groupBox2);
            this.tpSum.Controls.Add(this.grpFit);
            this.tpSum.Controls.Add(this.grpRecord);
            this.tpSum.Location = new System.Drawing.Point(4, 22);
            this.tpSum.Name = "tpSum";
            this.tpSum.Padding = new System.Windows.Forms.Padding(3);
            this.tpSum.Size = new System.Drawing.Size(728, 292);
            this.tpSum.TabIndex = 0;
            this.tpSum.Text = "成果统计";
            this.tpSum.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labSumError);
            this.groupBox2.Controls.Add(this.labError);
            this.groupBox2.Location = new System.Drawing.Point(8, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "偏差项统计（以确认的记录做统计）";
            // 
            // labSumError
            // 
            this.labSumError.AutoSize = true;
            this.labSumError.Location = new System.Drawing.Point(108, 29);
            this.labSumError.Name = "labSumError";
            this.labSumError.Size = new System.Drawing.Size(11, 12);
            this.labSumError.TabIndex = 9;
            this.labSumError.Text = "0";
            // 
            // labError
            // 
            this.labError.AutoSize = true;
            this.labError.Location = new System.Drawing.Point(37, 29);
            this.labError.Name = "labError";
            this.labError.Size = new System.Drawing.Size(65, 12);
            this.labError.TabIndex = 8;
            this.labError.Text = "偏差项数：";
            // 
            // grpFit
            // 
            this.grpFit.Controls.Add(this.labSumFit);
            this.grpFit.Controls.Add(this.labFit);
            this.grpFit.Location = new System.Drawing.Point(8, 103);
            this.grpFit.Name = "grpFit";
            this.grpFit.Size = new System.Drawing.Size(714, 64);
            this.grpFit.TabIndex = 1;
            this.grpFit.TabStop = false;
            this.grpFit.Text = "符合项统计（以确认的记录做统计）";
            // 
            // labSumFit
            // 
            this.labSumFit.AutoSize = true;
            this.labSumFit.Location = new System.Drawing.Point(108, 29);
            this.labSumFit.Name = "labSumFit";
            this.labSumFit.Size = new System.Drawing.Size(11, 12);
            this.labSumFit.TabIndex = 9;
            this.labSumFit.Text = "0";
            // 
            // labFit
            // 
            this.labFit.AutoSize = true;
            this.labFit.Location = new System.Drawing.Point(25, 29);
            this.labFit.Name = "labFit";
            this.labFit.Size = new System.Drawing.Size(65, 12);
            this.labFit.TabIndex = 8;
            this.labFit.Text = "符合项数：";
            // 
            // grpRecord
            // 
            this.grpRecord.Controls.Add(this.labSumDeleted);
            this.grpRecord.Controls.Add(this.labDeleted);
            this.grpRecord.Controls.Add(this.labSumRecord);
            this.grpRecord.Controls.Add(this.labRecord);
            this.grpRecord.Controls.Add(this.labSumReturn);
            this.grpRecord.Controls.Add(this.labReturn);
            this.grpRecord.Controls.Add(this.labSumOK);
            this.grpRecord.Controls.Add(this.labOK);
            this.grpRecord.Controls.Add(this.labSumSubmit);
            this.grpRecord.Controls.Add(this.labSubmit);
            this.grpRecord.Controls.Add(this.labSumEdit);
            this.grpRecord.Controls.Add(this.labEdit);
            this.grpRecord.Location = new System.Drawing.Point(8, 6);
            this.grpRecord.Name = "grpRecord";
            this.grpRecord.Size = new System.Drawing.Size(714, 82);
            this.grpRecord.TabIndex = 0;
            this.grpRecord.TabStop = false;
            this.grpRecord.Text = "记录统计";
            // 
            // labSumDeleted
            // 
            this.labSumDeleted.AutoSize = true;
            this.labSumDeleted.Location = new System.Drawing.Point(108, 57);
            this.labSumDeleted.Name = "labSumDeleted";
            this.labSumDeleted.Size = new System.Drawing.Size(11, 12);
            this.labSumDeleted.TabIndex = 11;
            this.labSumDeleted.Text = "0";
            // 
            // labDeleted
            // 
            this.labDeleted.AutoSize = true;
            this.labDeleted.Location = new System.Drawing.Point(13, 57);
            this.labDeleted.Name = "labDeleted";
            this.labDeleted.Size = new System.Drawing.Size(89, 12);
            this.labDeleted.TabIndex = 10;
            this.labDeleted.Text = "已删除记录数：";
            // 
            // labSumRecord
            // 
            this.labSumRecord.AutoSize = true;
            this.labSumRecord.Location = new System.Drawing.Point(272, 57);
            this.labSumRecord.Name = "labSumRecord";
            this.labSumRecord.Size = new System.Drawing.Size(11, 12);
            this.labSumRecord.TabIndex = 9;
            this.labSumRecord.Text = "0";
            // 
            // labRecord
            // 
            this.labRecord.AutoSize = true;
            this.labRecord.Location = new System.Drawing.Point(201, 57);
            this.labRecord.Name = "labRecord";
            this.labRecord.Size = new System.Drawing.Size(65, 12);
            this.labRecord.TabIndex = 8;
            this.labRecord.Text = "记录总数：";
            // 
            // labSumReturn
            // 
            this.labSumReturn.AutoSize = true;
            this.labSumReturn.Location = new System.Drawing.Point(618, 23);
            this.labSumReturn.Name = "labSumReturn";
            this.labSumReturn.Size = new System.Drawing.Size(11, 12);
            this.labSumReturn.TabIndex = 7;
            this.labSumReturn.Text = "0";
            // 
            // labReturn
            // 
            this.labReturn.AutoSize = true;
            this.labReturn.Location = new System.Drawing.Point(523, 23);
            this.labReturn.Name = "labReturn";
            this.labReturn.Size = new System.Drawing.Size(77, 12);
            this.labReturn.TabIndex = 6;
            this.labReturn.Text = "退回记录数：";
            // 
            // labSumOK
            // 
            this.labSumOK.AutoSize = true;
            this.labSumOK.Location = new System.Drawing.Point(445, 23);
            this.labSumOK.Name = "labSumOK";
            this.labSumOK.Size = new System.Drawing.Size(11, 12);
            this.labSumOK.TabIndex = 5;
            this.labSumOK.Text = "0";
            // 
            // labOK
            // 
            this.labOK.AutoSize = true;
            this.labOK.Location = new System.Drawing.Point(350, 23);
            this.labOK.Name = "labOK";
            this.labOK.Size = new System.Drawing.Size(89, 12);
            this.labOK.TabIndex = 4;
            this.labOK.Text = "已审批记录数：";
            // 
            // labSumSubmit
            // 
            this.labSumSubmit.AutoSize = true;
            this.labSumSubmit.Location = new System.Drawing.Point(272, 23);
            this.labSumSubmit.Name = "labSumSubmit";
            this.labSumSubmit.Size = new System.Drawing.Size(11, 12);
            this.labSumSubmit.TabIndex = 3;
            this.labSumSubmit.Text = "0";
            // 
            // labSubmit
            // 
            this.labSubmit.AutoSize = true;
            this.labSubmit.Location = new System.Drawing.Point(177, 23);
            this.labSubmit.Name = "labSubmit";
            this.labSubmit.Size = new System.Drawing.Size(89, 12);
            this.labSubmit.TabIndex = 2;
            this.labSubmit.Text = "已提交记录数：";
            // 
            // labSumEdit
            // 
            this.labSumEdit.AutoSize = true;
            this.labSumEdit.Location = new System.Drawing.Point(106, 23);
            this.labSumEdit.Name = "labSumEdit";
            this.labSumEdit.Size = new System.Drawing.Size(11, 12);
            this.labSumEdit.TabIndex = 1;
            this.labSumEdit.Text = "0";
            // 
            // labEdit
            // 
            this.labEdit.AutoSize = true;
            this.labEdit.Location = new System.Drawing.Point(11, 23);
            this.labEdit.Name = "labEdit";
            this.labEdit.Size = new System.Drawing.Size(89, 12);
            this.labEdit.TabIndex = 0;
            this.labEdit.Text = "在编辑记录数：";
            // 
            // tabRecord
            // 
            this.tabRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRecord.Controls.Add(this.tpSum);
            this.tabRecord.Controls.Add(this.tpEdit);
            this.tabRecord.Controls.Add(this.tpSubmit);
            this.tabRecord.Controls.Add(this.tpOK);
            this.tabRecord.Controls.Add(this.tpReturn);
            this.tabRecord.Controls.Add(this.tpDeleted);
            this.tabRecord.Controls.Add(this.tpQuery);
            this.tabRecord.Location = new System.Drawing.Point(12, 99);
            this.tabRecord.Name = "tabRecord";
            this.tabRecord.SelectedIndex = 0;
            this.tabRecord.Size = new System.Drawing.Size(736, 318);
            this.tabRecord.TabIndex = 1;
            this.tabRecord.SelectedIndexChanged += new System.EventHandler(this.tabRecord_SelectedIndexChanged);
            // 
            // tpDeleted
            // 
            this.tpDeleted.Location = new System.Drawing.Point(4, 22);
            this.tpDeleted.Name = "tpDeleted";
            this.tpDeleted.Size = new System.Drawing.Size(728, 292);
            this.tpDeleted.TabIndex = 6;
            this.tpDeleted.Text = "已删除记录";
            this.tpDeleted.UseVisualStyleBackColor = true;
            // 
            // toolTip_zhuanti
            // 
            this.toolTip_zhuanti.ShowAlways = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看记录ToolStripMenuItem,
            this.彻底删除记录ToolStripMenuItem,
            this.彻底删除记录ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 70);
            // 
            // 查看记录ToolStripMenuItem
            // 
            this.查看记录ToolStripMenuItem.Name = "查看记录ToolStripMenuItem";
            this.查看记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看记录ToolStripMenuItem.Text = "查看记录";
            this.查看记录ToolStripMenuItem.Click += new System.EventHandler(this.查看记录ToolStripMenuItem_Click);
            // 
            // 彻底删除记录ToolStripMenuItem
            // 
            this.彻底删除记录ToolStripMenuItem.Name = "彻底删除记录ToolStripMenuItem";
            this.彻底删除记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.彻底删除记录ToolStripMenuItem.Text = "恢复记录";
            this.彻底删除记录ToolStripMenuItem.Click += new System.EventHandler(this.彻底删除记录ToolStripMenuItem_Click);
            // 
            // 彻底删除记录ToolStripMenuItem1
            // 
            this.彻底删除记录ToolStripMenuItem1.Name = "彻底删除记录ToolStripMenuItem1";
            this.彻底删除记录ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.彻底删除记录ToolStripMenuItem1.Text = "彻底删除记录";
            this.彻底删除记录ToolStripMenuItem1.Click += new System.EventHandler(this.彻底删除记录ToolStripMenuItem1_Click);
            // 
            // RecordQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 429);
            this.Controls.Add(this.tabRecord);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecordQuery";
            this.Text = "RecordQuery";
            this.Load += new System.EventHandler(this.RecordQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tpSum.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpFit.ResumeLayout(false);
            this.grpFit.PerformLayout();
            this.grpRecord.ResumeLayout(false);
            this.grpRecord.PerformLayout();
            this.tabRecord.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbElement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFactory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpQuery;
        private System.Windows.Forms.DataGridView dgvRecord;
        private System.Windows.Forms.TabPage tpReturn;
        private System.Windows.Forms.TabPage tpOK;
        private System.Windows.Forms.TabPage tpSubmit;
        private System.Windows.Forms.TabPage tpEdit;
        private System.Windows.Forms.TabPage tpSum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labSumError;
        private System.Windows.Forms.Label labError;
        private System.Windows.Forms.GroupBox grpFit;
        private System.Windows.Forms.Label labSumFit;
        private System.Windows.Forms.Label labFit;
        private System.Windows.Forms.GroupBox grpRecord;
        private System.Windows.Forms.Label labSumRecord;
        private System.Windows.Forms.Label labRecord;
        private System.Windows.Forms.Label labSumReturn;
        private System.Windows.Forms.Label labReturn;
        private System.Windows.Forms.Label labSumOK;
        private System.Windows.Forms.Label labOK;
        private System.Windows.Forms.Label labSumSubmit;
        private System.Windows.Forms.Label labSubmit;
        private System.Windows.Forms.Label labSumEdit;
        private System.Windows.Forms.Label labEdit;
        private System.Windows.Forms.TabControl tabRecord;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label labSumDeleted;
        private System.Windows.Forms.Label labDeleted;
        private System.Windows.Forms.TabPage tpDeleted;
        private System.Windows.Forms.ToolTip toolTip_zhuanti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_against;
        private System.Windows.Forms.TextBox tb_factDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_export;
        private System.Windows.Forms.ComboBox comboBox_fhpc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBMITER;
        private System.Windows.Forms.DataGridViewTextBoxColumn APPROVER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBMITTIME;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LookintoRecord;
        private System.Windows.Forms.ToolStripMenuItem 删除记录ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 查看记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 彻底删除记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 彻底删除记录ToolStripMenuItem1;
    }
}