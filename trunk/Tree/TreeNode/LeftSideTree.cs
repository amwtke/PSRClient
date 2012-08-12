using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
namespace APP
{
    /// <summary>
    /// LeftSideTree
    /// </summary>
    [XmlRootAttribute("TreeView", Namespace = "http://www.RINPO.com",
   IsNullable = false)]
    [TreeInfor("TreeLeft.yap", "LeftTree")]
    public class RootNode : ITreeNodeRoot
    {
        ITreeNode[] _nodes;

        [Key("_rootName")]
        String _rootName;

        [Key("_rootValue")]
        string _rootValue;

        bool _CheckBox;
        public RootNode()
        {
            _rootName = DBHelper.GetTreeInfoAttribute(typeof(TreeOfForms))[0].TreeName;
        }
        [XmlAttribute("TreeName")]
        public string TreeName
        {
            get 
            { 
                return _rootName;
            }
        }

        public string RootValue
        {
            get { return _rootValue; }
            set
            {
                _rootValue = value;
            }
        }

        [XmlArrayAttribute("Nodes", IsNullable = false)]
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

    public class Node : ITreeNode
    {
        [Key("_nodeName")]
        string _nodeName;
        string _control;
        Color _backClor;
        bool _checked;
        ITreeNode[] _childNodes;

        public string NodeName
        {
            get { return _nodeName; }
            set { _nodeName = value; }
        }
        public string ControlType
        {
            get { return _control; }
            set { _control = value; }
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
        
        public ITreeNode[] ChildNodes
        {
            get { return _childNodes; }
            set { _childNodes = value; }
        }
        public override bool Equals(object obj)
        {
            if (obj is Node)
            {
                Node node = (Node)obj;
                if (this.NodeName == node.NodeName)
                    return true;
            }
            return false;
        }
        object _object;
        public object NodeObject
        {
            get { return _object; }
            set { _object = value; }
        }
    }

}
