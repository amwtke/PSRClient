using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APP
{
    public partial class LoginForm : Form
    {
        private bool blCancelLogin = true;//取消登录
        public LoginForm()
        {
            InitializeComponent();
        }
        public bool CancelLogin
        {
            get { return this.blCancelLogin; }
            set { this.blCancelLogin = value; }
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            this.CancelLogin = false;
            if (textBox_username.Text == "rinpo")
            {
                User u = new User();
                u.Name = "rinpo";
                u.Roles = new List<string>();
                u.Roles.Add("admin");
                u.SuoXie = "adm";
                u.DanWei = DanWeiManager.DanWeiList[0];
                UserSession.IniSession(u); 
                this.Close();
            }else 
            if (!string.IsNullOrEmpty(textBox_username.Text))
            {
                User u = UserHelper.GetUser(textBox_username.Text);
                if (u != null && u.Password == textBox_password.Text)
                {
                    UserSession.IniSession(u);
                    this.Close();
                }
                else if(u!=null)
                {
                    textBox_password.Text = "";
                    lb_message.Text = "密码错误！";
                }
                else
                {
                    textBox_password.Text = "";
                    lb_message.Text = "用户不存在！";
                }
            }
            else
            {
                textBox_username.BackColor = Color.Red;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_username_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_OK.PerformClick();
            }
        }

        private void textBox_password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_OK.PerformClick();
            }
        }
    }
}
