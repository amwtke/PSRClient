namespace APP
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            DBHelper.CloseDB();
            RecordHelper.CloseRecordDB();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel_form = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainForm_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BT_ReviewRecord = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.BT_SysConfig = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.bt_readother = new System.Windows.Forms.Button();
            this.bt_loadData = new System.Windows.Forms.Button();
            this.BT_Logout = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.labLoginInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.MainForm_flowLayoutPanel.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_form
            // 
            this.panel_form.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_form.AutoScroll = true;
            this.panel_form.Location = new System.Drawing.Point(0, 37);
            this.panel_form.Name = "panel_form";
            this.panel_form.Size = new System.Drawing.Size(774, 463);
            this.panel_form.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(350, 567);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "中核核电运行管理有限公司 版权所有";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(0, 37);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(100, 463);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加记录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 添加记录ToolStripMenuItem
            // 
            this.添加记录ToolStripMenuItem.Name = "添加记录ToolStripMenuItem";
            this.添加记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加记录ToolStripMenuItem.Text = "添加记录";
            this.添加记录ToolStripMenuItem.Click += new System.EventHandler(this.添加记录ToolStripMenuItem_Click);
            // 
            // MainForm_flowLayoutPanel
            // 
            this.MainForm_flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.MainForm_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainForm_flowLayoutPanel.Controls.Add(this.BT_ReviewRecord);
            this.MainForm_flowLayoutPanel.Controls.Add(this.btnAddRecord);
            this.MainForm_flowLayoutPanel.Controls.Add(this.BT_SysConfig);
            this.MainForm_flowLayoutPanel.Controls.Add(this.btnQuery);
            this.MainForm_flowLayoutPanel.Controls.Add(this.bt_readother);
            this.MainForm_flowLayoutPanel.Controls.Add(this.bt_loadData);
            this.MainForm_flowLayoutPanel.Controls.Add(this.BT_Logout);
            this.MainForm_flowLayoutPanel.Controls.Add(this.btnHelp);
            this.MainForm_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainForm_flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainForm_flowLayoutPanel.Name = "MainForm_flowLayoutPanel";
            this.MainForm_flowLayoutPanel.Size = new System.Drawing.Size(774, 37);
            this.MainForm_flowLayoutPanel.TabIndex = 3;
            // 
            // BT_ReviewRecord
            // 
            this.BT_ReviewRecord.BackColor = System.Drawing.Color.White;
            this.BT_ReviewRecord.FlatAppearance.BorderSize = 0;
            this.BT_ReviewRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BT_ReviewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_ReviewRecord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_ReviewRecord.Location = new System.Drawing.Point(3, 3);
            this.BT_ReviewRecord.Name = "BT_ReviewRecord";
            this.BT_ReviewRecord.Size = new System.Drawing.Size(74, 33);
            this.BT_ReviewRecord.TabIndex = 0;
            this.BT_ReviewRecord.Text = "审查记录";
            this.BT_ReviewRecord.UseVisualStyleBackColor = false;
            this.BT_ReviewRecord.Click += new System.EventHandler(this.BT_ReviewRecord_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddRecord.FlatAppearance.BorderSize = 0;
            this.btnAddRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRecord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRecord.Location = new System.Drawing.Point(83, 3);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(75, 33);
            this.btnAddRecord.TabIndex = 1;
            this.btnAddRecord.Text = "添加记录";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // BT_SysConfig
            // 
            this.BT_SysConfig.FlatAppearance.BorderSize = 0;
            this.BT_SysConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BT_SysConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_SysConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_SysConfig.Location = new System.Drawing.Point(164, 3);
            this.BT_SysConfig.Name = "BT_SysConfig";
            this.BT_SysConfig.Size = new System.Drawing.Size(75, 33);
            this.BT_SysConfig.TabIndex = 3;
            this.BT_SysConfig.Text = "系统设置";
            this.BT_SysConfig.UseVisualStyleBackColor = true;
            this.BT_SysConfig.Click += new System.EventHandler(this.BT_SysConfig_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatAppearance.BorderSize = 0;
            this.btnQuery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(245, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 33);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // bt_readother
            // 
            this.bt_readother.FlatAppearance.BorderSize = 0;
            this.bt_readother.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bt_readother.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_readother.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_readother.Location = new System.Drawing.Point(326, 3);
            this.bt_readother.Name = "bt_readother";
            this.bt_readother.Size = new System.Drawing.Size(75, 33);
            this.bt_readother.TabIndex = 8;
            this.bt_readother.Text = "切换数据库";
            this.bt_readother.UseVisualStyleBackColor = true;
            this.bt_readother.Click += new System.EventHandler(this.bt_readother_Click);
            // 
            // bt_loadData
            // 
            this.bt_loadData.FlatAppearance.BorderSize = 0;
            this.bt_loadData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bt_loadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_loadData.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_loadData.Location = new System.Drawing.Point(407, 3);
            this.bt_loadData.Name = "bt_loadData";
            this.bt_loadData.Size = new System.Drawing.Size(75, 33);
            this.bt_loadData.TabIndex = 9;
            this.bt_loadData.Text = "导入数据";
            this.bt_loadData.UseVisualStyleBackColor = true;
            this.bt_loadData.Click += new System.EventHandler(this.bt_loadData_Click);
            // 
            // BT_Logout
            // 
            this.BT_Logout.FlatAppearance.BorderSize = 0;
            this.BT_Logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BT_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Logout.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Logout.Location = new System.Drawing.Point(488, 3);
            this.BT_Logout.Name = "BT_Logout";
            this.BT_Logout.Size = new System.Drawing.Size(75, 33);
            this.BT_Logout.TabIndex = 5;
            this.BT_Logout.Text = "登出";
            this.BT_Logout.UseVisualStyleBackColor = true;
            this.BT_Logout.Click += new System.EventHandler(this.BT_Logout_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHelp.Location = new System.Drawing.Point(569, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 33);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "帮助";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // labLoginInfo
            // 
            this.labLoginInfo.AutoSize = true;
            this.labLoginInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labLoginInfo.Location = new System.Drawing.Point(6, 12);
            this.labLoginInfo.Name = "labLoginInfo";
            this.labLoginInfo.Size = new System.Drawing.Size(47, 12);
            this.labLoginInfo.TabIndex = 4;
            this.labLoginInfo.Text = "审查员:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(311, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "PSR审查记录管理平台";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_form);
            this.splitContainer1.Panel2.Controls.Add(this.MainForm_flowLayoutPanel);
            this.splitContainer1.Size = new System.Drawing.Size(878, 500);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 10;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labLoginInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 37);
            this.panel1.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "files(*.yap)|*.yap";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 588);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PSR";
            this.MaximumSizeChanged += new System.EventHandler(this.MainForm_MaximumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.MainForm_flowLayoutPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel MainForm_flowLayoutPanel;
        private System.Windows.Forms.Button BT_ReviewRecord;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label labLoginInfo;
        private System.Windows.Forms.Button BT_SysConfig;
        private System.Windows.Forms.Button BT_Logout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel_form;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加记录ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button bt_readother;
        private System.Windows.Forms.Button bt_loadData;
    }
}

