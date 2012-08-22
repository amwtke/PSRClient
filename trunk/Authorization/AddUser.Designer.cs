namespace APP
{
    partial class AddUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_staffNo = new System.Windows.Forms.TextBox();
            this.textBox_loginName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pinying = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_tele = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_role = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_SuoXie = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1_danwei = new System.Windows.Forms.ComboBox();
            this.button1_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.bt_genpassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "员工编号";
            // 
            // textBox_staffNo
            // 
            this.textBox_staffNo.Enabled = false;
            this.textBox_staffNo.Location = new System.Drawing.Point(84, 30);
            this.textBox_staffNo.Name = "textBox_staffNo";
            this.textBox_staffNo.Size = new System.Drawing.Size(107, 21);
            this.textBox_staffNo.TabIndex = 1;
            this.textBox_staffNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_staffNo_KeyUp);
            // 
            // textBox_loginName
            // 
            this.textBox_loginName.Location = new System.Drawing.Point(84, 69);
            this.textBox_loginName.Name = "textBox_loginName";
            this.textBox_loginName.Size = new System.Drawing.Size(107, 21);
            this.textBox_loginName.TabIndex = 3;
            this.textBox_loginName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_loginName_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "登录名";
            // 
            // textBox_pinying
            // 
            this.textBox_pinying.Location = new System.Drawing.Point(258, 33);
            this.textBox_pinying.Name = "textBox_pinying";
            this.textBox_pinying.Size = new System.Drawing.Size(107, 21);
            this.textBox_pinying.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "中文名";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(84, 112);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(107, 21);
            this.textBox_password.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码";
            // 
            // textBox_tele
            // 
            this.textBox_tele.Location = new System.Drawing.Point(259, 110);
            this.textBox_tele.Name = "textBox_tele";
            this.textBox_tele.Size = new System.Drawing.Size(107, 21);
            this.textBox_tele.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "电话";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(84, 178);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(290, 21);
            this.textBox_email.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "EMail";
            // 
            // comboBox_role
            // 
            this.comboBox_role.FormattingEnabled = true;
            this.comboBox_role.Location = new System.Drawing.Point(84, 221);
            this.comboBox_role.Name = "comboBox_role";
            this.comboBox_role.Size = new System.Drawing.Size(272, 20);
            this.comboBox_role.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "角色";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "拼音缩写";
            // 
            // textBox_SuoXie
            // 
            this.textBox_SuoXie.Location = new System.Drawing.Point(258, 69);
            this.textBox_SuoXie.MaxLength = 5;
            this.textBox_SuoXie.Name = "textBox_SuoXie";
            this.textBox_SuoXie.Size = new System.Drawing.Size(107, 21);
            this.textBox_SuoXie.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "单位";
            // 
            // comboBox1_danwei
            // 
            this.comboBox1_danwei.FormattingEnabled = true;
            this.comboBox1_danwei.Location = new System.Drawing.Point(84, 263);
            this.comboBox1_danwei.Name = "comboBox1_danwei";
            this.comboBox1_danwei.Size = new System.Drawing.Size(272, 20);
            this.comboBox1_danwei.TabIndex = 14;
            // 
            // button1_OK
            // 
            this.button1_OK.Location = new System.Drawing.Point(116, 301);
            this.button1_OK.Name = "button1_OK";
            this.button1_OK.Size = new System.Drawing.Size(75, 23);
            this.button1_OK.TabIndex = 16;
            this.button1_OK.Text = "OK";
            this.button1_OK.UseVisualStyleBackColor = true;
            this.button1_OK.Click += new System.EventHandler(this.button1_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(234, 301);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 17;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // bt_genpassword
            // 
            this.bt_genpassword.Location = new System.Drawing.Point(102, 141);
            this.bt_genpassword.Name = "bt_genpassword";
            this.bt_genpassword.Size = new System.Drawing.Size(75, 23);
            this.bt_genpassword.TabIndex = 18;
            this.bt_genpassword.Text = "随机密码";
            this.bt_genpassword.UseVisualStyleBackColor = true;
            this.bt_genpassword.Click += new System.EventHandler(this.bt_genpassword_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 333);
            this.Controls.Add(this.bt_genpassword);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button1_OK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1_danwei);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_role);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_tele);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_SuoXie);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_pinying);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_loginName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_staffNo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_staffNo;
        private System.Windows.Forms.TextBox textBox_loginName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_pinying;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_tele;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_role;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_SuoXie;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1_danwei;
        private System.Windows.Forms.Button button1_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button bt_genpassword;

    }
}