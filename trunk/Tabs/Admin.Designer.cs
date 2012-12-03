namespace APP
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.同级添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下级添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改当前节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.加入特殊人员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.同级加入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下级加入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_adduser = new System.Windows.Forms.Button();
            this.button_importData = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.treeView1 = new MWControls.MWTreeView();
            this.bt_refreshBaseTable = new System.Windows.Forms.Button();
            this.bt_baseData = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_attachLeftTree = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同级添加ToolStripMenuItem,
            this.下级添加ToolStripMenuItem,
            this.删除选中ToolStripMenuItem,
            this.修改当前节点ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 136);
            // 
            // 同级添加ToolStripMenuItem
            // 
            this.同级添加ToolStripMenuItem.Name = "同级添加ToolStripMenuItem";
            this.同级添加ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.同级添加ToolStripMenuItem.Text = "同级添加";
            this.同级添加ToolStripMenuItem.Click += new System.EventHandler(this.同级添加ToolStripMenuItem_Click);
            // 
            // 下级添加ToolStripMenuItem
            // 
            this.下级添加ToolStripMenuItem.Name = "下级添加ToolStripMenuItem";
            this.下级添加ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.下级添加ToolStripMenuItem.Text = "下级添加";
            this.下级添加ToolStripMenuItem.Click += new System.EventHandler(this.下级添加ToolStripMenuItem_Click);
            // 
            // 删除选中ToolStripMenuItem
            // 
            this.删除选中ToolStripMenuItem.Name = "删除选中ToolStripMenuItem";
            this.删除选中ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除选中ToolStripMenuItem.Text = "删除选中";
            this.删除选中ToolStripMenuItem.Click += new System.EventHandler(this.删除选中ToolStripMenuItem_Click);
            // 
            // 修改当前节点ToolStripMenuItem
            // 
            this.修改当前节点ToolStripMenuItem.Enabled = false;
            this.修改当前节点ToolStripMenuItem.Name = "修改当前节点ToolStripMenuItem";
            this.修改当前节点ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改当前节点ToolStripMenuItem.Text = "修改当前节点";
            this.修改当前节点ToolStripMenuItem.Click += new System.EventHandler(this.修改当前节点ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.refreshToolStripMenuItem.Text = "重置所有节点";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView2.ContextMenuStrip = this.contextMenuStrip3;
            this.treeView2.Location = new System.Drawing.Point(278, 27);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(263, 400);
            this.treeView2.TabIndex = 2;
            this.treeView2.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterCheck);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.保存ToolStripMenuItem2,
            this.加入特殊人员ToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(149, 70);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem2
            // 
            this.保存ToolStripMenuItem2.Name = "保存ToolStripMenuItem2";
            this.保存ToolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.保存ToolStripMenuItem2.Text = "保存";
            this.保存ToolStripMenuItem2.Click += new System.EventHandler(this.保存ToolStripMenuItem2_Click);
            // 
            // 加入特殊人员ToolStripMenuItem
            // 
            this.加入特殊人员ToolStripMenuItem.Name = "加入特殊人员ToolStripMenuItem";
            this.加入特殊人员ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.加入特殊人员ToolStripMenuItem.Text = "加入特殊人员";
            this.加入特殊人员ToolStripMenuItem.Click += new System.EventHandler(this.加入特殊人员ToolStripMenuItem_Click);
            // 
            // treeView3
            // 
            this.treeView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView3.Location = new System.Drawing.Point(564, 27);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(269, 400);
            this.treeView3.TabIndex = 3;
            this.treeView3.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView3_AfterCheck);
            this.treeView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView3_MouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同级加入ToolStripMenuItem,
            this.下级加入ToolStripMenuItem,
            this.修改节点ToolStripMenuItem,
            this.删除节点ToolStripMenuItem,
            this.保存ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 114);
            // 
            // 同级加入ToolStripMenuItem
            // 
            this.同级加入ToolStripMenuItem.Name = "同级加入ToolStripMenuItem";
            this.同级加入ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.同级加入ToolStripMenuItem.Text = "同级加入";
            this.同级加入ToolStripMenuItem.Click += new System.EventHandler(this.同级加入ToolStripMenuItem_Click);
            // 
            // 下级加入ToolStripMenuItem
            // 
            this.下级加入ToolStripMenuItem.Name = "下级加入ToolStripMenuItem";
            this.下级加入ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.下级加入ToolStripMenuItem.Text = "下级加入";
            this.下级加入ToolStripMenuItem.Click += new System.EventHandler(this.下级加入ToolStripMenuItem_Click);
            // 
            // 修改节点ToolStripMenuItem
            // 
            this.修改节点ToolStripMenuItem.Name = "修改节点ToolStripMenuItem";
            this.修改节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改节点ToolStripMenuItem.Text = "修改节点";
            this.修改节点ToolStripMenuItem.Click += new System.EventHandler(this.修改节点ToolStripMenuItem_Click);
            // 
            // 删除节点ToolStripMenuItem
            // 
            this.删除节点ToolStripMenuItem.Name = "删除节点ToolStripMenuItem";
            this.删除节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除节点ToolStripMenuItem.Text = "删除节点";
            this.删除节点ToolStripMenuItem.Click += new System.EventHandler(this.删除节点ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem1
            // 
            this.保存ToolStripMenuItem1.Name = "保存ToolStripMenuItem1";
            this.保存ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.保存ToolStripMenuItem1.Text = "保存";
            this.保存ToolStripMenuItem1.Click += new System.EventHandler(this.保存ToolStripMenuItem1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(856, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "刷新UI列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(856, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "列表入数据库";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "左侧菜单设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "特殊权限设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(669, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "角色权限设置";
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(173, 6);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(76, 21);
            this.textBox_user.TabIndex = 8;
            this.textBox_user.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_user_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "用户的树";
            // 
            // button_adduser
            // 
            this.button_adduser.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_adduser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_adduser.Location = new System.Drawing.Point(856, 27);
            this.button_adduser.Name = "button_adduser";
            this.button_adduser.Size = new System.Drawing.Size(75, 43);
            this.button_adduser.TabIndex = 10;
            this.button_adduser.Text = "用户管理";
            this.button_adduser.UseVisualStyleBackColor = false;
            this.button_adduser.Click += new System.EventHandler(this.button_adduser_Click);
            // 
            // button_importData
            // 
            this.button_importData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_importData.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_importData.Location = new System.Drawing.Point(856, 76);
            this.button_importData.Name = "button_importData";
            this.button_importData.Size = new System.Drawing.Size(75, 39);
            this.button_importData.TabIndex = 11;
            this.button_importData.Text = "导入记录数据";
            this.button_importData.UseVisualStyleBackColor = false;
            this.button_importData.Click += new System.EventHandler(this.button_importData_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.yap";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "files(*.yap)|*.yap";
            this.openFileDialog1.Title = "选择记录数据文件";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.CheckedNodes = ((System.Collections.Hashtable)(resources.GetObject("treeView1.CheckedNodes")));
            this.treeView1.Location = new System.Drawing.Point(12, 33);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelNodes = ((System.Collections.Hashtable)(resources.GetObject("treeView1.SelNodes")));
            this.treeView1.Size = new System.Drawing.Size(249, 394);
            this.treeView1.TabIndex = 12;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
            // 
            // bt_refreshBaseTable
            // 
            this.bt_refreshBaseTable.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bt_refreshBaseTable.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bt_refreshBaseTable.Location = new System.Drawing.Point(856, 170);
            this.bt_refreshBaseTable.Name = "bt_refreshBaseTable";
            this.bt_refreshBaseTable.Size = new System.Drawing.Size(75, 43);
            this.bt_refreshBaseTable.TabIndex = 13;
            this.bt_refreshBaseTable.Text = "更新电厂名称";
            this.bt_refreshBaseTable.UseVisualStyleBackColor = true;
            this.bt_refreshBaseTable.Click += new System.EventHandler(this.bt_refreshBaseTable_Click);
            // 
            // bt_baseData
            // 
            this.bt_baseData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bt_baseData.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bt_baseData.Location = new System.Drawing.Point(856, 121);
            this.bt_baseData.Name = "bt_baseData";
            this.bt_baseData.Size = new System.Drawing.Size(75, 43);
            this.bt_baseData.TabIndex = 14;
            this.bt_baseData.Text = "更新代码表";
            this.bt_baseData.UseVisualStyleBackColor = false;
            this.bt_baseData.Click += new System.EventHandler(this.bt_baseData_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.SystemColors.HotTrack;
            // 
            // bt_attachLeftTree
            // 
            this.bt_attachLeftTree.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bt_attachLeftTree.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bt_attachLeftTree.Location = new System.Drawing.Point(856, 274);
            this.bt_attachLeftTree.Name = "bt_attachLeftTree";
            this.bt_attachLeftTree.Size = new System.Drawing.Size(75, 43);
            this.bt_attachLeftTree.TabIndex = 15;
            this.bt_attachLeftTree.Text = "绑定授权文件";
            this.bt_attachLeftTree.UseVisualStyleBackColor = true;
            this.bt_attachLeftTree.Click += new System.EventHandler(this.bt_attachLeftTree_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 439);
            this.Controls.Add(this.bt_attachLeftTree);
            this.Controls.Add(this.bt_baseData);
            this.Controls.Add(this.bt_refreshBaseTable);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button_importData);
            this.Controls.Add(this.button_adduser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.treeView3);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.button1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 同级添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下级添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改当前节点ToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 同级加入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下级加入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 加入特殊人员ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button button_adduser;
        private System.Windows.Forms.Button button_importData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MWControls.MWTreeView treeView1;
        private System.Windows.Forms.Button bt_refreshBaseTable;
        private System.Windows.Forms.Button bt_baseData;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bt_attachLeftTree;
    }
}