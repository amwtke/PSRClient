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
    public partial class SelectAgainstFactsForm : Form
    {
        Tab1_AddAffectForm _innerForm = null;
        TextBox _innerTB = null;
        SortedList<int, string> _temp = new SortedList<int, string>();

        public static int OpenCount = 0;
        public SelectAgainstFactsForm()
        {
            InitializeComponent();
        }

        public SelectAgainstFactsForm(Tab1_AddAffectForm form,TextBox _textBox)
        {
            InitializeComponent();
            _innerForm = form;
            _innerTB = _textBox;

            foreach (int i in _innerForm._unAgainstFactNo.Keys)
            {
                _temp.Add(i, "    " + _innerForm.GetTextOfPanelByIndex(i));
                //checkedListBox1.Items.Add(i.ToString() + "    " + _innerForm.GetTextOfPanelByIndex(i), false);
            }

            if (_textBox.Text != null && _textBox.Text.Length > 0)
            {
                string[] myselflist = _textBox.Text.Split(new char[] { ',' });
                if (myselflist != null && myselflist.Length > 0)
                {
                    foreach (string s in myselflist)
                    {
                        _temp.Add(int.Parse(s), "    " + _innerForm.GetTextOfPanelByIndex(int.Parse(s)));
                        //checkedListBox1.Items.Add(s.ToString() + "    " + _innerForm.GetTextOfPanelByIndex(int.Parse(s)), false);
                    }
                }
            }

            foreach (KeyValuePair<int, string> pair in _temp)
            {
                checkedListBox1.Items.Add(pair.Key + pair.Value, false);
            }

            OpenCount++;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                if (_innerForm != null)
                {
                    List<int> tempList = new List<int>();
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        int temp = int.Parse(checkedListBox1.CheckedItems[i].ToString().Trim().Split(new char[] { ' ' })[0]);
                        tempList.Add(temp);
                        _temp.Remove(temp);
                    }
                    _innerForm._unAgainstFactNo = _temp;
                    _innerForm.AgainstStr = _innerForm.FormSelectFactString(tempList);
                    _innerTB.Text = _innerForm.AgainstStr;
                    _innerTB.Refresh();
                }
            }
            this.Close();
        }

        private void SelectAgainstFactsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OpenCount--;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedIndex>=0)
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
        }
    }
}
