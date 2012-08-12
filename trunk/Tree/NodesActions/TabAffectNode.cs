using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APP
{
    public class TabAffectNode : ITreeNodeAction
    {
        string _nodeName;
        public string getNoteName
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

        public void ShowForm()
        {
            TreeNodeHelper.ShowFormInPanel<Tab1_AddAffectForm>();
        }
    }
}
