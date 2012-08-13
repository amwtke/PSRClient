using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    [DB4OClass("System\\User.yap")]
    public class User
    {
        string _stuffNo;
        [Key("_Name")]
        string _Name;
        string _pingying;
        string _password;
        string _telephone;
        string _email;
        List<string> _roles;
        bool _active;
        string _facility;
        string _danwei;
        string _suoxie;

        public string SuoXie
        {
            get { return _suoxie; }
            set { _suoxie = value; }
        }

        public string DanWei
        {
            get { return _danwei; }
            set { _danwei = value; }
        }

        public string Facility
        {
            get { return _facility; }
            set { _facility = value; }
        }
        public string StuffNo
        {
            get { return _stuffNo; }
            set { _stuffNo = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string PingYing
        {
            get { return _pingying; }
            set { _pingying = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public List<string> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        public string Role
        {
            get
            {
                if (_roles != null)
                {
                    return _roles[0];
                }
                return null;
            }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
    }
}
