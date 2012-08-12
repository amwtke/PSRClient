using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    public class UserSession
    {
        static User _loginUser = null;
        public static void IniSession(User u)
        {
            _loginUser = u;
        }
        public static User LoginUser
        {
            get
            {
                if (_loginUser != null)
                    return _loginUser;
                //throw new Exception("Session丢失");
                return null;
            }
        }
    }
}
