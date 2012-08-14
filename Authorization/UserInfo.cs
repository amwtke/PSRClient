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
    public partial class UserInfo : Form
    {
        User[] _allUser = null;
        public UserInfo()
        {
            InitializeComponent();
            LoadForm();
        }

        private void bt_Adduser_Click(object sender, EventArgs e)
        {
            AddUser addForm = new AddUser();
            addForm.ShowDialog();
            BindData();
        }

        private void LoadForm()
        {
            BindData();
        }

        void BindData()
        {
            _allUser = UserHelper.GetALlUser();
            DataView v = FillDataView(_allUser);

            dataGridView1.DataSource = v;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                User _u = new User();

                if (dataGridView1[0, e.RowIndex].Value!=null)
                {
                    _u.Name = dataGridView1[0, e.RowIndex].Value.ToString();
                    //_u.Roles = new List<string>();
                    //_u.Roles.Add(dataGridView1[1, e.RowIndex].Value.ToString());
                    //_u.DanWei = dataGridView1[2, e.RowIndex].Value.ToString();
                    //_u.SuoXie = dataGridView1[3, e.RowIndex].Value.ToString();
                    //_u.PingYing = dataGridView1[4, e.RowIndex].Value.ToString();
                    //_u.Email = dataGridView1[5, e.RowIndex].Value.ToString();
                    //_u.Telephone = dataGridView1[6, e.RowIndex].Value.ToString();
                    _u = UserHelper.GetByExample(_u)[0];
                    AddUser adduser = new AddUser(_u);
                    adduser.ShowDialog();
                    BindData();
                }
            }
        }

        private void bt_deleteuser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定删除？", "删除", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    List<int> _index = new List<int>();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        _index.Add(row.Index);
                    }

                    foreach (int i in _index)
                    {
                        User _u = new User();
                        if (dataGridView1[0, i].Value != null)
                        {
                            _u.Name = dataGridView1[0, i].Value.ToString();
                            UserHelper.DeleteUser(_u);
                        }
                    }

                    BindData();
                }
            }

        }

        private DataView FillDataView(User[] users)
        {
            if (users != null && users.Length > 0)
            {
                DataTable _table = new DataTable();
                _table.Columns.Add("Name");
                _table.Columns.Add("Role");
                _table.Columns.Add("DanWei");
                _table.Columns.Add("SuoXie");
                _table.Columns.Add("PingYing");
                _table.Columns.Add("Email");
                _table.Columns.Add("Telephone");

                _table.Rows.Clear();
                foreach (User u in users)
                {
                    DataRow r = _table.NewRow();
                    r["Name"] = u.Name;
                    r["Role"] = u.Role;
                    r["DanWei"] = u.DanWei;
                    r["SuoXie"] = u.SuoXie;
                    r["PingYing"] = u.PingYing;
                    r["Email"] = u.Email;
                    r["Telephone"] = u.Telephone;
                    _table.Rows.Add(r);
                }

                DataView v = new DataView(_table);
                v.Sort = "Name ASC";
                return v;
            }
            return null;
        }
    }
}
