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
    public partial class AddNodeForm : Form
    {
        List<string> _facilitys = new List<string>();
        List<string> _yaosus = new List<string>();
        List<string> _zhuantis = new List<string>();

        void updateList()
        {
            foreach (KeyValuePair<string,string> pair in FacilityName.dictFactory)
            {
                _facilitys.Add(pair.Value);
            }

            _yaosus = YaoSuManager.YaoSus;

            foreach (KeyValuePair<string, string> pair in ZhuanTiManager.dictSubject)
            {
                _zhuantis.Add(pair.Value);
            }
        }
        public AddNodeForm()
        {
            InitializeComponent();
            updateList();
        }

        /// <summary>
        /// direction==true同级加 反之下级加
        /// </summary>
        /// <param name="form"></param>
        /// <param name="level"></param>
        /// <param name="direction"></param>
        public AddNodeForm(AdminForm form,int level,bool direction)
        {
            InitializeComponent();
            updateList();
            _retForm = form;

            ITreeNodeAction[] ITreeNodeActionObjects = CommonHelper.GetInterfaceObjectFromAssembly<ITreeNodeAction>("ITreeNodeAction");
            foreach (ITreeNodeAction i in ITreeNodeActionObjects)
            {
                comboBox1.Items.Add(i.GetType());
            }
            //comboBox1.SelectedIndex = 0;
            _color = Color.White;

            if (direction == true)
            {
                if (level == 0)
                {
                    comboBox_name.DataSource = _facilitys;
                }
                if (level == 1)
                {
                    comboBox_name.DataSource = _yaosus;
                }
                if (level >= 2)
                {
                    comboBox_name.DataSource = _zhuantis;
                }
            }
            else
            {
                level = level + 1;
                if (level == 0)
                {
                    comboBox_name.DataSource = _facilitys;
                }
                if (level == 1)
                {
                    comboBox_name.DataSource = _yaosus;
                }
                if (level >= 2)
                {
                    comboBox_name.DataSource = _zhuantis;
                }
            }
        }
        public AddNodeForm(Node node,AdminForm form,int level)
        {
            InitializeComponent();
            updateList();
            ITreeNodeAction[] ITreeNodeActionObjects = CommonHelper.GetInterfaceObjectFromAssembly<ITreeNodeAction>("ITreeNodeAction");
            foreach (ITreeNodeAction i in ITreeNodeActionObjects)
            {
                comboBox1.Items.Add(i.GetType());
            }
            comboBox1.SelectedIndex = 0;

            tb_backColor.BackColor = node.BackColor;
            _retForm = form;
            comboBox_name.Text = node.NodeName;
            comboBox1.Text = node.ControlType;
            _returnNode = node;
        }
        Color _color;
        string _name;
        string _contolShow;
        AdminForm _retForm;
        Node _returnNode = new Node();
        private void tb_backColor_Click(object sender, EventArgs e)
        {
            colorDialog1.SolidColorOnly = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _color = colorDialog1.Color;
            }
            tb_backColor.BackColor = _color;
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            bool isClose = true;

            if (comboBox_name.Text != "")
            {
                string realNodeName="";
                if (comboBox_name.DataSource.Equals(_facilitys))
                    realNodeName = FacilityName.GetFacilityNO(CommonHelper.GetRidOfIndexPrefix(comboBox_name.Text));
                if (comboBox_name.DataSource.Equals(_yaosus))
                    realNodeName = YaoSuManager.GetYaoSuBianHao(CommonHelper.GetRidOfIndexPrefix(comboBox_name.Text));
                if (comboBox_name.DataSource.Equals(_zhuantis))
                    realNodeName = ZhuanTiManager.GetSubjectNO(CommonHelper.GetRidOfIndexPrefix(comboBox_name.Text));

                _name = realNodeName;
            }
            else
            {
                comboBox_name.BackColor = Color.Red;
                isClose = false;
            }

            if (comboBox1.Text != "")
                _contolShow = comboBox1.Text;
            
            if (_color == null) _color = Color.White;

            if (isClose)
            {
                Random r = new Random();
                
                _returnNode.BackColor = _color;
                _returnNode.ControlType = _contolShow;
                _returnNode.NodeName = r.Next(1000).ToString()+"."+_name;
                _retForm.innerNode = _returnNode;
                this.Close();
            }
        }
    }
}
