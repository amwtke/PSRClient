using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    [TreeInforAttribute("Tree.yap","AuthorizationTree")]
    public class AuthorizationTree:ITreeNodeRoot
    {
        [Key("_treeName")]
        string _treeName;

        [Key("_role")]
        string _role;

        public AuthorizationTree()
        {
            _treeName = DBHelper.GetTreeInfoAttribute(typeof(TreeOfForms))[0].TreeName;
        }
        public string TreeName
        {
            get { return _treeName; }
        }

        public string RootValue
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }

        bool _checkBox;
        public bool CheckBox
        {
            get
            {
                return _checkBox;
            }
            set
            {
                _checkBox = value;
            }
        }

        ITreeNode[] _childNodes;
        public ITreeNode[] ChildNodes
        {
            get
            {
                return _childNodes;
            }
            set
            {
                _childNodes = value;
            }
        }
    }

    public class AuthorizationNode : ITreeNode
    {
        [Key("_nodeName")]
        string _nodeName;
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

        string _controlType;
        public string ControlType
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
        bool _checked;
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
            }
        }

        System.Drawing.Color _backColor;
        public System.Drawing.Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }

        ITreeNode[] _childNodes;
        public ITreeNode[] ChildNodes
        {
            get
            {
                return _childNodes;
            }
            set
            {
                _childNodes = value;
            }
        }

        /// <summary>
        /// 用于存放权限列表
        /// </summary>
        object _object;
        public object NodeObject
        {
            get { return _object; }
            set { _object = value; }
        }
    }
}
