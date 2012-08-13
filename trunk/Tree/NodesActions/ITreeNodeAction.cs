using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    public interface ITreeNodeAction
    {
        string getNoteName { set; get; }
        void ShowForm();
    }
}
