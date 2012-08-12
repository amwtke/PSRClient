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
    public partial class ImportUserAndStatusForm : Form
    {
        AdminForm _senderForm = null;
        MainForm _sendMain = null;
        public ImportUserAndStatusForm(AdminForm sender)
        {
            InitializeComponent();
            comboBox1.Items.Add("");
            comboBox1.Items.Add(RecordStatus.Approved);
            comboBox1.Items.Add(RecordStatus.Deleted);
            comboBox1.Items.Add(RecordStatus.HoldForApprove);
            comboBox1.Items.Add(RecordStatus.Inputed);
            comboBox1.Items.Add(RecordStatus.ReturnBack);
            _senderForm = sender;
        }


        public ImportUserAndStatusForm(MainForm sender)
        {
            InitializeComponent();
            comboBox1.Items.Add("");
            comboBox1.Items.Add(RecordStatus.Approved);
            comboBox1.Items.Add(RecordStatus.Deleted);
            comboBox1.Items.Add(RecordStatus.HoldForApprove);
            comboBox1.Items.Add(RecordStatus.Inputed);
            comboBox1.Items.Add(RecordStatus.ReturnBack);
            _sendMain = sender;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (_senderForm != null)
            {
                _senderForm.RecordStatus = comboBox1.Text;
                _senderForm.ImportUserName = textBox1.Text;
            }

            if (_sendMain != null)
            {
                _sendMain.RecordStatus = comboBox1.Text;
                _sendMain.ImportUserName = textBox1.Text;
            }

            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
