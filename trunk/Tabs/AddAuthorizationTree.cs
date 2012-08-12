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
    public partial class AddAuthorizationTree : Form
    {
        public AddAuthorizationTree()
        {
            InitializeComponent();
            CheckListBox_auth.Items.AddRange(Roles.GetRoleList().ToArray());
        }
        AdminForm _form;
        AuthorizationNode _node = new AuthorizationNode();
        public AddAuthorizationTree(AuthorizationNode node, AdminForm form)
        {
            InitializeComponent();
            CheckListBox_auth.Items.AddRange(Roles.GetRoleList().ToArray());
            _form = form;
            _node = node;
            textBox_name.Text = _node.NodeName;
            List<string> _l = (List<string>)node.NodeObject;
            if (_l.Count > 0)
            {
                foreach(string s in _l)
                {
                    if (CheckListBox_auth.Items.IndexOf(s)>=0)
                        CheckListBox_auth.SetItemChecked(CheckListBox_auth.Items.IndexOf(s), true);
                }
            }
        }
        public AddAuthorizationTree(AdminForm form)
        {
            InitializeComponent();
            _form = form;
            CheckListBox_auth.Items.AddRange(Roles.GetRoleList().ToArray());
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            bool isClose = true;
            if (string.IsNullOrEmpty(textBox_name.Text))
            {
                isClose = false;
                textBox_name.BackColor = Color.Red;
            }
            else
            {
                _node.NodeName = textBox_name.Text;
            }

            List<string> authList = new List<string>(); 
            foreach(object o in CheckListBox_auth.CheckedItems)
            {
                authList.Add(o.ToString());
            }
            _node.NodeObject = authList;
            _form.innerAuthNode = _node;
            if(isClose)
                this.Close();
        }
    }
}
