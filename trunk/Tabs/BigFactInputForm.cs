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
    public partial class BigFactInputForm : Form
    {
        Tab1_AddAffectForm owner = null;
        public BigFactInputForm()
        {
            InitializeComponent();
        }
        public BigFactInputForm(string factNo, string content, Tab1_AddAffectForm tabAffect)
        {
            InitializeComponent();
            richTextBox1.Text = content;
            owner = tabAffect;
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            this.Text = "大窗口编写" + "  事实编号:" + factNo;
            this.WindowState = FormWindowState.Maximized;
        }

        public BigFactInputForm(string factNo, string content, Tab1_AddAffectForm tabAffect,bool isFact)
        {
            InitializeComponent();
            richTextBox1.Text = content;
            owner = tabAffect;
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
            this.Text = "大窗口编写" + "  - 结论编号:" + factNo;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (owner != null)
            {
                owner.TransferFromBig = richTextBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要关闭不保存？", "关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox _this = richTextBox1; ;
            

            IDataObject dataObj = Clipboard.GetDataObject();
            if (dataObj.GetDataPresent(DataFormats.StringFormat))
            {
                //e.Handled = true; //去掉格式文本的格式 
                int selectionStart = _this.SelectionStart;
                string txt = (string)Clipboard.GetData(DataFormats.StringFormat);
                int copytailpos = selectionStart + txt.Length;
                _this.Text = _this.Text.Insert(selectionStart, txt);
                _this.Select(copytailpos, 0);
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
    }
}
