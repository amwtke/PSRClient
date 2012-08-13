using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APP
{
    public class Authorization
    {
        public static bool IsControlVisiable(string parentControlName,string controlNmae,string checkPointName, string authParent)
        {
            if (!UserHelper.IsUserHaveAuth(checkPointName, authParent, UserSession.LoginUser.Roles[0]))
            {
                return UserHelper.DoesUserGotSpecialAuth(parentControlName, controlNmae);
            }
            return true;
        }

        public static bool IsControlVisiable(Control parent, Control control, string checkPointName, string authParent)
        {
            if (parent == null)
            {
                return IsControlVisiable(null, control.Name, checkPointName, authParent);

            }
            else
                return IsControlVisiable(parent.Name, control.Name, checkPointName, authParent);
        }
    }
}
