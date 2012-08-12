namespace APP
{
    partial class BaseDataForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_facility = new System.Windows.Forms.TabPage();
            this.dataGridView_facility = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_yaosu = new System.Windows.Forms.TabPage();
            this.dataGridView_yaosu = new System.Windows.Forms.DataGridView();
            this.tabPage_zhuanti = new System.Windows.Forms.TabPage();
            this.dataGridView_zhuanti = new System.Windows.Forms.DataGridView();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facilityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yaoSuNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yaoSuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yaosuNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.zhuanTiNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhuanTiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl.SuspendLayout();
            this.tabPage_facility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_facility)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage_yaosu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_yaosu)).BeginInit();
            this.tabPage_zhuanti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zhuanti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facilityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yaoSuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhuanTiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_facility);
            this.tabControl.Controls.Add(this.tabPage_yaosu);
            this.tabControl.Controls.Add(this.tabPage_zhuanti);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(629, 426);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl__SelectedIndexChanged);
            // 
            // tabPage_facility
            // 
            this.tabPage_facility.Controls.Add(this.dataGridView_facility);
            this.tabPage_facility.Location = new System.Drawing.Point(4, 22);
            this.tabPage_facility.Name = "tabPage_facility";
            this.tabPage_facility.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_facility.Size = new System.Drawing.Size(621, 400);
            this.tabPage_facility.TabIndex = 0;
            this.tabPage_facility.Text = "电厂";
            this.tabPage_facility.UseVisualStyleBackColor = true;
            // 
            // dataGridView_facility
            // 
            this.dataGridView_facility.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_facility.AutoGenerateColumns = false;
            this.dataGridView_facility.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_facility.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.facilityNameDataGridViewTextBoxColumn});
            this.dataGridView_facility.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_facility.DataSource = this.facilityBindingSource;
            this.dataGridView_facility.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_facility.Name = "dataGridView_facility";
            this.dataGridView_facility.RowTemplate.Height = 23;
            this.dataGridView_facility.Size = new System.Drawing.Size(609, 388);
            this.dataGridView_facility.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // tabPage_yaosu
            // 
            this.tabPage_yaosu.Controls.Add(this.dataGridView_yaosu);
            this.tabPage_yaosu.Location = new System.Drawing.Point(4, 22);
            this.tabPage_yaosu.Name = "tabPage_yaosu";
            this.tabPage_yaosu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_yaosu.Size = new System.Drawing.Size(621, 400);
            this.tabPage_yaosu.TabIndex = 1;
            this.tabPage_yaosu.Text = "要素";
            this.tabPage_yaosu.UseVisualStyleBackColor = true;
            // 
            // dataGridView_yaosu
            // 
            this.dataGridView_yaosu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_yaosu.AutoGenerateColumns = false;
            this.dataGridView_yaosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_yaosu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.yaoSuNameDataGridViewTextBoxColumn});
            this.dataGridView_yaosu.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_yaosu.DataSource = this.yaoSuBindingSource;
            this.dataGridView_yaosu.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_yaosu.Name = "dataGridView_yaosu";
            this.dataGridView_yaosu.RowTemplate.Height = 23;
            this.dataGridView_yaosu.Size = new System.Drawing.Size(609, 388);
            this.dataGridView_yaosu.TabIndex = 0;
            this.dataGridView_yaosu.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_yaosu_CellBeginEdit);
            this.dataGridView_yaosu.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_yaosu_CellEndEdit);
            // 
            // tabPage_zhuanti
            // 
            this.tabPage_zhuanti.Controls.Add(this.dataGridView_zhuanti);
            this.tabPage_zhuanti.Location = new System.Drawing.Point(4, 22);
            this.tabPage_zhuanti.Name = "tabPage_zhuanti";
            this.tabPage_zhuanti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_zhuanti.Size = new System.Drawing.Size(621, 400);
            this.tabPage_zhuanti.TabIndex = 2;
            this.tabPage_zhuanti.Text = "专题";
            this.tabPage_zhuanti.UseVisualStyleBackColor = true;
            // 
            // dataGridView_zhuanti
            // 
            this.dataGridView_zhuanti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_zhuanti.AutoGenerateColumns = false;
            this.dataGridView_zhuanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_zhuanti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn2,
            this.yaosuNameDataGridViewTextBoxColumn1,
            this.zhuanTiNameDataGridViewTextBoxColumn});
            this.dataGridView_zhuanti.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_zhuanti.DataSource = this.zhuanTiBindingSource;
            this.dataGridView_zhuanti.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_zhuanti.Name = "dataGridView_zhuanti";
            this.dataGridView_zhuanti.RowTemplate.Height = 23;
            this.dataGridView_zhuanti.Size = new System.Drawing.Size(609, 388);
            this.dataGridView_zhuanti.TabIndex = 0;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_ok.Location = new System.Drawing.Point(219, 444);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(348, 444);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "电厂编号";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // facilityNameDataGridViewTextBoxColumn
            // 
            this.facilityNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.facilityNameDataGridViewTextBoxColumn.DataPropertyName = "FacilityName";
            this.facilityNameDataGridViewTextBoxColumn.HeaderText = "电厂名称";
            this.facilityNameDataGridViewTextBoxColumn.Name = "facilityNameDataGridViewTextBoxColumn";
            // 
            // facilityBindingSource
            // 
            this.facilityBindingSource.DataSource = typeof(APP.Facility);
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "要素编号";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            // 
            // yaoSuNameDataGridViewTextBoxColumn
            // 
            this.yaoSuNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yaoSuNameDataGridViewTextBoxColumn.DataPropertyName = "YaoSuName";
            this.yaoSuNameDataGridViewTextBoxColumn.HeaderText = "要素名称";
            this.yaoSuNameDataGridViewTextBoxColumn.Name = "yaoSuNameDataGridViewTextBoxColumn";
            // 
            // yaoSuBindingSource
            // 
            this.yaoSuBindingSource.DataSource = typeof(APP.YaoSu);
            // 
            // iDDataGridViewTextBoxColumn2
            // 
            this.iDDataGridViewTextBoxColumn2.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn2.HeaderText = "专题编号";
            this.iDDataGridViewTextBoxColumn2.Name = "iDDataGridViewTextBoxColumn2";
            // 
            // yaosuNameDataGridViewTextBoxColumn1
            // 
            this.yaosuNameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.yaosuNameDataGridViewTextBoxColumn1.DataPropertyName = "YaosuName";
            this.yaosuNameDataGridViewTextBoxColumn1.HeaderText = "属于要素";
            this.yaosuNameDataGridViewTextBoxColumn1.Name = "yaosuNameDataGridViewTextBoxColumn1";
            this.yaosuNameDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.yaosuNameDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.yaosuNameDataGridViewTextBoxColumn1.Width = 78;
            // 
            // zhuanTiNameDataGridViewTextBoxColumn
            // 
            this.zhuanTiNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zhuanTiNameDataGridViewTextBoxColumn.DataPropertyName = "ZhuanTiName";
            this.zhuanTiNameDataGridViewTextBoxColumn.HeaderText = "专题名";
            this.zhuanTiNameDataGridViewTextBoxColumn.Name = "zhuanTiNameDataGridViewTextBoxColumn";
            this.zhuanTiNameDataGridViewTextBoxColumn.Width = 66;
            // 
            // zhuanTiBindingSource
            // 
            this.zhuanTiBindingSource.DataSource = typeof(APP.ZhuanTi);
            // 
            // BaseDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 468);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.tabControl);
            this.Name = "BaseDataForm";
            this.Text = "码表配置";
            this.tabControl.ResumeLayout(false);
            this.tabPage_facility.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_facility)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage_yaosu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_yaosu)).EndInit();
            this.tabPage_zhuanti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zhuanti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facilityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yaoSuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhuanTiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_facility;
        private System.Windows.Forms.TabPage tabPage_yaosu;
        private System.Windows.Forms.TabPage tabPage_zhuanti;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.DataGridView dataGridView_facility;
        private System.Windows.Forms.DataGridView dataGridView_yaosu;
        private System.Windows.Forms.DataGridView dataGridView_zhuanti;
        private System.Windows.Forms.BindingSource facilityBindingSource;
        private System.Windows.Forms.BindingSource yaoSuBindingSource;
        private System.Windows.Forms.BindingSource zhuanTiBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facilityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn yaoSuNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn yaosuNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhuanTiNameDataGridViewTextBoxColumn;
    }
}