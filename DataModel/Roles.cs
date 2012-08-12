using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP
{
    public class Roles
    {
        //public static readonly string RolePSRManager = "PSR项目负责人";
        public static readonly string RoleFactorTeamManager = "要素负责人";
        public static readonly string RoleInvestigator = "要素审查员";
        public static readonly string Admin = "管理员";

        static Dictionary<string, string> _roleDescription = new Dictionary<string, string>();
        static Roles()
        {
            //_roleDescription[RolePSRManager] = "浏览、查询各厂、各要素及专题下审查记录；检索全部记录、对抽查到的审查记录退回审查员并签署意见";
            _roleDescription[RoleFactorTeamManager] = "对本要素组所负责的记录有填写、确认、退回并签署意见，查询本要素组所负责记录";
            _roleDescription[RoleInvestigator] = "填写、提交本人负责部分的审查记录，修改被退回的记录，查询本人负责的记录";
            _roleDescription[Admin] = "超级管理员";
        }

        public static Dictionary<string, string> RoleDescription
        {
            get
            {
                return _roleDescription;
            }
        }

        public static List<string> GetRoleList()
        {
            List<string> _l = new List<string>();
            //_l.Add(RolePSRManager);
            _l.Add(RoleInvestigator);_l.Add(RoleFactorTeamManager);
            _l.Add(Admin);
            return _l;
        }
    }
}
