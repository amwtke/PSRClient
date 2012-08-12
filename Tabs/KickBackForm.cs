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
    public partial class KickBackForm : Form
    {
        public KickBackForm()
        {
            InitializeComponent();
        }
        Record _record = null;
        public KickBackForm(Record record)
        {
            _record = record;
            InitializeComponent();
        }
        public KickBackForm(Record record, bool isReadonly)
        {
            _record = record;
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = false;
            richTextBox1.Text = _record.SendBackReason;
            richTextBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定退回？", "退回记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _record.SendBackReason = richTextBox1.Text;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定取消关闭？", "退回记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.Close();
        }
    }
}
