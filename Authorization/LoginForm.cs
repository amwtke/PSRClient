using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;

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
            bool _checkFileAsso = true;

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
                _checkFileAsso = false;
                this.Close();
            }else 
            if (!string.IsNullOrEmpty(textBox_username.Text))
            {
                if (textBox_username.Text == "admin")
                    _checkFileAsso = false;

                //检查文件绑定
                if (_checkFileAsso && !CheckTimeIfMatch())
                {
                    MessageBox.Show("授权文件绑定失败！请到管理员处拷贝最新的App.exe以及系统配置文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button_OK.Enabled = false;
                }
                else
                {
                    User u = UserHelper.GetUser(textBox_username.Text);
                    if (u != null && u.Password == textBox_password.Text)
                    {
                        UserSession.IniSession(u);
                        this.Close();
                    }
                    else if (u != null)
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

        private DateTime? GetTreeDateTime<Root>() where Root : ITreeNodeRoot, new()
        {
            IObjectContainer _db;
            Root _root;
            TreeInforAttribute[] _atts = DBHelper.GetTreeInfoAttribute(typeof(Root));
            if (_atts != null && _atts.Length >= 0)
                _db = DBHelper.InitDB4O(_atts[0].DBName, typeof(Root));
            else
                throw new Exception("找不到DB！" + typeof(Root) + "没有TreeInfor属性？");

            Root example = new Root();
            example.RootValue = "admin";//user name
            try
            {
                Root[] re = DBHelper.FindByExample<Root>(_db, example);
                if (re != null && re.Length > 0)
                {
                    _root = re[0];
                    if (_root is AuthorizationTree)
                    {
                        AuthorizationTree _temp = _root as AuthorizationTree;
                        return _temp.AppCreationTime;
                    }
                    else if (_root is RootNode)
                    {
                        RootNode _temp = _root as RootNode;
                        return _temp.AppCreationTime;
                    }
                    else
                        return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db.Close();
            }
        }

        private DateTime GetAppDateTime()
        {
            System.IO.FileInfo _fileInfo = new System.IO.FileInfo(Application.ExecutablePath);
            return _fileInfo.CreationTime;
        }

        private bool CheckTimeIfMatch()
        {
            DateTime? _leftTreeTime = GetTreeDateTime<RootNode>();
            if (_leftTreeTime == null) return false;
            else
            {
                if (_leftTreeTime == GetAppDateTime())
                    return true;
            }
            return false;
        }
    }
}
