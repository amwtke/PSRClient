namespace APP
{
    partial class UserInfo
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danWeiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suoXieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pingYingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bt_Adduser = new System.Windows.Forms.Button();
            this.bt_deleteuser = new System.Windows.Forms.Button();
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.roleDataGridViewTextBoxColumn,
            this.danWeiDataGridViewTextBoxColumn,
            this.suoXieDataGridViewTextBoxColumn,
            this.pingYingDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.telephoneDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(847, 433);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "登录名";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            this.roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            this.roleDataGridViewTextBoxColumn.HeaderText = "角色";
            this.roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            this.roleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // danWeiDataGridViewTextBoxColumn
            // 
            this.danWeiDataGridViewTextBoxColumn.DataPropertyName = "DanWei";
            this.danWeiDataGridViewTextBoxColumn.HeaderText = "单位";
            this.danWeiDataGridViewTextBoxColumn.Name = "danWeiDataGridViewTextBoxColumn";
            this.danWeiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // suoXieDataGridViewTextBoxColumn
            // 
            this.suoXieDataGridViewTextBoxColumn.DataPropertyName = "SuoXie";
            this.suoXieDataGridViewTextBoxColumn.HeaderText = "姓名缩写";
            this.suoXieDataGridViewTextBoxColumn.Name = "suoXieDataGridViewTextBoxColumn";
            this.suoXieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pingYingDataGridViewTextBoxColumn
            // 
            this.pingYingDataGridViewTextBoxColumn.DataPropertyName = "PingYing";
            this.pingYingDataGridViewTextBoxColumn.HeaderText = "姓名";
            this.pingYingDataGridViewTextBoxColumn.Name = "pingYingDataGridViewTextBoxColumn";
            this.pingYingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "电子邮箱";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telephoneDataGridViewTextBoxColumn
            // 
            this.telephoneDataGridViewTextBoxColumn.DataPropertyName = "Telephone";
            this.telephoneDataGridViewTextBoxColumn.HeaderText = "电话";
            this.telephoneDataGridViewTextBoxColumn.Name = "telephoneDataGridViewTextBoxColumn";
            this.telephoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userBindingSource2
            // 
            this.userBindingSource2.DataSource = typeof(APP.User);
            // 
            // bt_Adduser
            // 
            this.bt_Adduser.Location = new System.Drawing.Point(12, 12);
            this.bt_Adduser.Name = "bt_Adduser";
            this.bt_Adduser.Size = new System.Drawing.Size(75, 23);
            this.bt_Adduser.TabIndex = 1;
            this.bt_Adduser.Text = "添加用户";
            this.bt_Adduser.UseVisualStyleBackColor = true;
            this.bt_Adduser.Click += new System.EventHandler(this.bt_Adduser_Click);
            // 
            // bt_deleteuser
            // 
            this.bt_deleteuser.Location = new System.Drawing.Point(104, 12);
            this.bt_deleteuser.Name = "bt_deleteuser";
            this.bt_deleteuser.Size = new System.Drawing.Size(75, 23);
            this.bt_deleteuser.TabIndex = 2;
            this.bt_deleteuser.Text = "删除用户";
            this.bt_deleteuser.UseVisualStyleBackColor = true;
            this.bt_deleteuser.Click += new System.EventHandler(this.bt_deleteuser_Click);
            // 
            // userBindingSource1
            // 
            this.userBindingSource1.DataSource = typeof(APP.User);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(APP.User);
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 491);
            this.Controls.Add(this.bt_deleteuser);
            this.Controls.Add(this.bt_Adduser);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserInfo";
            this.Text = "UserInfo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_Adduser;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.BindingSource userBindingSource2;
        private System.Windows.Forms.Button bt_deleteuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn danWeiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suoXieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pingYingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephoneDataGridViewTextBoxColumn;
    }
}