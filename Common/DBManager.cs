using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    public enum DBType
    {
        Data,
        Tree,
    }
    public class DBManager
    {
        static Dictionary<DBType, string> _DBNameDic = new Dictionary<DBType, string>();
        static DBManager()
        {
            _DBNameDic.Add(DBType.Tree, "Tree.yap");
            _DBNameDic.Add(DBType.Data, "Data.yap");
        }

        public static string GetDBName(DBType dbtype)
        {
            return _DBNameDic[dbtype];
        }
    }
}
