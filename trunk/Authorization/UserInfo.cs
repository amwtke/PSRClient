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
            dataGridView1.DataSource = _allUser;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AddUser adduser = new AddUser(_allUser[e.RowIndex]);
                adduser.ShowDialog();
                BindData();
            }
        }

        private void bt_deleteuser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("确定删除？", "删除", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    List<int> _index = new List<int>();
                    foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                    {
                        _index.Add(cell.RowIndex);
                    }

                    foreach (int i in _index)
                    {
                        UserHelper.DeleteUser(_allUser[i]);
                    }

                    BindData();
                }
            }

        }
    }
}
