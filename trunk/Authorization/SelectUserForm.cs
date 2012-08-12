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
    public partial class SelectUserForm : Form
    {
        AdminForm _adminForm = null;
        
        public SelectUserForm()
        {
            InitializeComponent();
        }

        public SelectUserForm(AdminForm _form)
        {
            _adminForm = _form;
            InitializeComponent();
        }

        private void SelectUserForm_Load(object sender, EventArgs e)
        {
            User[] _users = UserHelper.GetAllUser();
            if (_users != null && _users.Length > 0)
            {
                foreach (User u in _users)
                {
                    comboBox1.AutoCompleteCustomSource.Add(u.Name);
                    comboBox1.Items.Add(u.Name);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            User _u = UserHelper.GetUser(comboBox1.Text.Trim());
            _adminForm.ImportedToUser = _u.Name;
            label1.Text = "将树导入到用户:" + _u.PingYing + "。";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            User _u = UserHelper.GetUser(comboBox1.Text.Trim());
            _adminForm.ImportedToUser = _u.Name;
            label1.Text = "将树导入到用户:" + _u.PingYing + "。";
        }
    }
}
