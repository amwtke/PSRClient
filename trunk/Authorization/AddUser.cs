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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            comboBox_role.Items.AddRange(Roles.GetRoleList().ToArray());
            comboBox1_danwei.Items.AddRange(DanWeiManager.DanWeiList.ToArray());
            
        }
        public AddUser(User _u)
        {
            InitializeComponent();
            comboBox_role.Items.AddRange(Roles.GetRoleList().ToArray());
            comboBox1_danwei.Items.AddRange(DanWeiManager.DanWeiList.ToArray());
            if (_u != null)
            {
                textBox_loginName.Text = _u.Name;
                textBox_password.Text = _u.Password;
                textBox_SuoXie.Text = _u.SuoXie;
                textBox_email.Text = _u.Email;
                textBox_staffNo.Text = _u.StuffNo;
                textBox_pinying.Text = _u.PingYing;
                textBox_tele.Text = _u.Telephone;
                textBox_pinying.Text = _u.PingYing;
                if (!string.IsNullOrEmpty(_u.Roles[0]))
                    comboBox_role.SelectedIndex = comboBox_role.Items.IndexOf(_u.Roles[0]);
                if (!string.IsNullOrEmpty(_u.DanWei))
                    comboBox1_danwei.SelectedIndex = comboBox1_danwei.Items.IndexOf(_u.DanWei);
            }
        }
        private void button1_OK_Click(object sender, EventArgs e)
        {
            User _user = new User();
            bool close = true;

            if (!string.IsNullOrEmpty(textBox_email.Text))
            {
                _user.Email = textBox_email.Text;
            }

            if (!string.IsNullOrEmpty(textBox_tele.Text))
            {
                _user.Telephone = textBox_tele.Text;
            }

            //密码
            if (!string.IsNullOrEmpty(textBox_password.Text))
            {
                _user.Password = textBox_password.Text;
            }
            else
            {
                close = false;
                textBox_password.BackColor = Color.Red;
            }

            //登录名
            if (!string.IsNullOrEmpty(textBox_loginName.Text))
            {
                string _userName = textBox_loginName.Text.Trim();
                User _u = UserHelper.GetUser(_userName);
                if (_u!=null)
                {
                    if (MessageBox.Show("已经存在用户：" + _userName + "，是否更新？","更新？",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        textBox_loginName.BackColor = Color.Red;
                        return;
                    }
                }
                _user.Name = _userName;
            }
            else
            {
                close = false;
                textBox_loginName.BackColor = Color.Red;
            }

            //中文名
            if (!string.IsNullOrEmpty(textBox_pinying.Text))
            {
                _user.PingYing = textBox_pinying.Text;
                User u = new User();
                u.PingYing = _user.PingYing;
                User[] users = UserHelper.GetByExample(u);
                if (users != null && users.Length > 0)
                {
                    MessageBox.Show("已经存在此中文名用户，请更改！");
                    textBox_pinying.BackColor = Color.Red;
                    return;
                }
            }
            else
            {
                MessageBox.Show("请填写中文名！");
                textBox_pinying.BackColor = Color.Red;
                return;
            }

            if (!string.IsNullOrEmpty(textBox_SuoXie.Text))
            {
                _user.SuoXie = textBox_SuoXie.Text;
            }
            else
            {
                close = false;
                textBox_SuoXie.BackColor = Color.Red;
            }

            if (!string.IsNullOrEmpty(comboBox1_danwei.Text))
            {
                _user.DanWei = comboBox1_danwei.Text;
            }
            else
            {
                close = false;
                comboBox1_danwei.BackColor = Color.Red;
            }

            if (!string.IsNullOrEmpty(comboBox_role.Text))
            {
                _user.Roles = new List<string>();
                _user.Roles.Add(comboBox_role.Text);
            }
            else
            {
                close = false;
                comboBox_role.BackColor = Color.Red;
            }

            if (close)
            {
                UserHelper.AddAndUpdateUser(_user);
                this.Close();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_staffNo_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox_loginName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox_loginName.Text != string.Empty)
                {
                    User _u = UserHelper.GetUser(textBox_loginName.Text);
                    if (_u != null)
                    {
                        textBox_password.Text = _u.Password;
                        textBox_SuoXie.Text = _u.SuoXie;
                        textBox_email.Text = _u.Email;
                        textBox_staffNo.Text = _u.StuffNo;
                        textBox_pinying.Text = _u.PingYing;
                        textBox_tele.Text = _u.Telephone;

                        if(!string.IsNullOrEmpty(_u.Roles[0]))
                            comboBox_role.SelectedIndex = comboBox_role.Items.IndexOf(_u.Roles[0]);
                        if (!string.IsNullOrEmpty(_u.DanWei))
                            comboBox1_danwei.SelectedIndex = comboBox1_danwei.Items.IndexOf(_u.DanWei);
                    }
                }
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void bt_genpassword_Click(object sender, EventArgs e)
        {
            textBox_password.Text = RandomPassword.GetRandomPassword(6);
        }
    }

    public class RandomPassword
    {
        private static string randomChars = "abcdefghijklmnopqrstuvwxyz012346789";

        public static string GetRandomPassword(int passwordLen)
        {
            string password = string.Empty;
            int randomNum;
            Random random = new Random();
            for (int i = 0; i < passwordLen; i++)
            {
                randomNum = random.Next(randomChars.Length);
                password += randomChars[randomNum];
            }
            return password;
        }
    }
}
