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
    public partial class AddUIInform : Form
    {
        public AddUIInform()
        {
            InitializeComponent();
        }
        FormNode _node; AdminForm _form;
        public AddUIInform(FormNode node,AdminForm form)
        {
            InitializeComponent();
            _node = node;
            _form = form;
            if (_node.NodeObject != null)
            {
                List<string> _l = (List<string>)_node.NodeObject;
                richTextBox1.Lines = _l.ToArray();
            }
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Lines != null && richTextBox1.Lines.Length > 0)
            {
                List<string> exceptPerson = new List<string>();
                exceptPerson.AddRange(richTextBox1.Lines);
                _node.NodeObject = exceptPerson;
            }
            else
                _node.NodeObject = null;
            _form.innerFormNode = _node;
            this.Close();
        }

        private void AddUIInform_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BT_OK.PerformClick();
        }
    }
}
