using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace APP
{
    [TreeInfor("System\\Tree.yap", "UITree")]
    public class TreeOfForms : ITreeNodeRoot
    {
        [Key("_treeName")]
        string _treeName;
            
        [Key("_ownUser")]
        string _ownUser;

        bool _CheckBox;

        ITreeNode[] _nodes;
        public TreeOfForms()
        {
            _treeName = DBHelper.GetTreeInfoAttribute(typeof(TreeOfForms))[0].TreeName;
        }
        public string TreeName
        {
            get
            {
                return _treeName;
            }
        }

       public string RootValue
        {
            get
            {
                return _ownUser;
            }
            set
            {
                _ownUser = value;
            }
        }

        public ITreeNode[] ChildNodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }

        public bool CheckBox
        {
            get { return _CheckBox; }
            set
            {
                _CheckBox = value;
            }
        }
    }

    public class FormNode : ITreeNode
    {
        [Key("_nodeName")]
        string _nodeName;
        string _controlType;
        ITreeNode[] _childNodes;
        Color _backClor;
        bool _checked;
        ControlAuthor _nodeAuthor;
        public ControlAuthor NodeAuthor
        {
            get { return _nodeAuthor; }
            set { _nodeAuthor = value; }
        }
        public string NodeName
        {
            get
            {
                return _nodeName;
            }
            set
            {
                _nodeName = value;
            }
        }

       public  string ControlType
        {
            get
            {
                return _controlType;
            }
            set
            {
                _controlType = value;
            }
        }

        public ITreeNode[] ChildNodes
        {
            get { return _childNodes; }
            set { _childNodes = value; }
        }

        public Color BackColor
        {
            get { return _backClor; }
            set { _backClor = value; }
        }
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }

        object _object;
        public object NodeObject
        {
            get { return _object; }
            set { _object = value; }
        }
    }
}
