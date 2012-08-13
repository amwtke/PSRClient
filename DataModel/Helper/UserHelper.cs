using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
namespace APP
{
    public class UserHelper
    {
        public static User[] GetALlUser()
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(User));
                IObjectSet sets = _db.QueryByExample(typeof(User));
                if (sets.Count > 0)
                {
                    User[] users = new User[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        users[i] = (User)sets[i];
                    }
                    return users;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static User GetUser(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                User _u = new User();
                _u.Name = name;
                Dictionary<string, string> _searchDic = DBHelper.GetKeySeachDictionary(_u);
                IObjectContainer _db = null;
                try
                {
                    _db = DBHelper.InitDB4O(typeof(User));
                    if (_db != null)
                    {
                        if (_searchDic != null)
                        {
                            User[] _uArray = DBHelper.Find<User>(_db,JoinType.And, ContainType.Equal, _searchDic);
                            if (_uArray != null && _uArray.Length > 0)
                            {
                                return _uArray[0];
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception("没找到用户: "+name);
                }
                //finally
                //{
                //    if(_db!=null)
                //        _db.Close();
                //}
            }
            return null;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public static User[] GetAllUser()
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(User));
                IObjectSet sets = _db.QueryByExample(typeof(User));
                if (sets != null && sets.Count > 0)
                {
                    User[] users = new User[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        users[i] = (User)sets[i];
                    }
                    return users;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static bool AddAndUpdateUser(User user)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(user.GetType());
                if (_db != null)
                {
                    if(!DBHelper.SaveToDB(_db,user,true))
                        DBHelper.UpdateFromDB(_db, user);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    if (_db != null)
            //        _db.Close();
            //}
        }

        /// <summary>
        /// 健全
        /// </summary>
        /// <param name="authName"></param>
        /// <param name="authparentName"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsUserHaveAuth(string authName, string authparentName, string username)
        {
            AuthorizationNode authNode = null;
            if (TreeNodeHelper.GetNodeFromDB<AuthorizationTree, AuthorizationNode>("admin", authparentName, authName, out authNode))
            {
                if (authNode.NodeObject != null)
                {
                    List<string> _l = (List<string>)authNode.NodeObject;
                    foreach (string s in _l)
                    {
                        if (s == username)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool DeleteUser(string userName)
        {
            IObjectContainer _db = null;
            try
            {
                _db=DBHelper.InitDB4O(typeof(User));
                User user = UserHelper.GetUser(userName);
                if (user != null)
                {
                    DBHelper.DeleteFromDB(_db, user);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static bool DeleteUser(User user)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(User));
                if (user != null)
                {
                    DBHelper.DeleteFromDB(_db, user);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static bool DoesUserGotSpecialAuth(string parentControlName, string controlName)
        {
            FormNode node = null;
            if (TreeNodeHelper.GetNodeFromDB<TreeOfForms, FormNode>("admin", parentControlName, controlName, out node))
            {
                if (node.NodeObject != null)
                {
                    List<string>_l=(List<string>)node.NodeObject;
                    foreach (string s in _l)
                    {
                        if (s == UserSession.LoginUser.Name)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static User[] GetByExample(User user)
        {
            IObjectContainer _db = null;
            try
            {
                if (user != null)
                {
                    _db = DBHelper.InitDB4O(typeof(User));
                    IObjectSet sets = _db.QueryByExample(user);
                    if (sets != null && sets.Count > 0)
                    {
                        User[] users = new User[sets.Count];
                        for (int i = 0; i < sets.Count; i++)
                        {
                            users[i] = (User)sets[i];
                        }
                        return users;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
