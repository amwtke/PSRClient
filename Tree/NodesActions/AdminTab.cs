using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    public enum ControlAuthor
    {
        Enable,
        Disable,
        Invisible,
        Show,
        EnableAndInvisible,
        EnableAndShow,
        DisableAndInvisible,
        DisableAndShow,
    }
    public class AdminTab : ITreeNodeAction
    {
        string _nodeName;
        string ITreeNodeAction.getNoteName
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

        void ITreeNodeAction.ShowForm()
        {
            TreeNodeHelper.ShowFormInPanel<AdminForm>();
        }
    }
}
