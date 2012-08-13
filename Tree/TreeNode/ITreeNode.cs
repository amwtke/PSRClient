using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace APP
{

    public interface ITreeNodeRoot
    {
        string TreeName { get; }
        string RootValue { get; set; }
        bool CheckBox { get; set; }
        ITreeNode[] ChildNodes{ get; set; }
    }
   
    public interface ITreeNode
    {
        string NodeName { get; set; }
        string ControlType { get; set; }
        bool Checked { get; set; }
        Color BackColor { get; set; }
        ITreeNode[] ChildNodes { get; set; }
        object NodeObject { get; set; }
    }
}
