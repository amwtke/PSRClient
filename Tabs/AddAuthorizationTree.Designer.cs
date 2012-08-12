namespace APP
{
    partial class AddAuthorizationTree
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
            this.BT_OK = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckListBox_auth = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // BT_OK
            // 
            this.BT_OK.Location = new System.Drawing.Point(160, 255);
            this.BT_OK.Name = "BT_OK";
            this.BT_OK.Size = new System.Drawing.Size(75, 23);
            this.BT_OK.TabIndex = 0;
            this.BT_OK.Text = "OK";
            this.BT_OK.UseVisualStyleBackColor = true;
            this.BT_OK.Click += new System.EventHandler(this.BT_OK_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(79, 24);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(308, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称:";
            // 
            // CheckListBox_auth
            // 
            this.CheckListBox_auth.FormattingEnabled = true;
            this.CheckListBox_auth.Location = new System.Drawing.Point(14, 69);
            this.CheckListBox_auth.Name = "CheckListBox_auth";
            this.CheckListBox_auth.Size = new System.Drawing.Size(373, 180);
            this.CheckListBox_auth.TabIndex = 3;
            // 
            // AddAuthorizationTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 296);
            this.ControlBox = false;
            this.Controls.Add(this.CheckListBox_auth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.BT_OK);
            this.Name = "AddAuthorizationTree";
            this.Text = "AddAuthorizationTree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox CheckListBox_auth;
    }
}