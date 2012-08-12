using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    class RecordQueryTab:ITreeNodeAction
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
            TreeNodeHelper.ShowFormInPanel<RecordQuery>();
        }
    }
}
