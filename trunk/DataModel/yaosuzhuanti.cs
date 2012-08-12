using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace APP
{
    [DB4OClassAttribute("BaseData.yap")]
    public class YaoSu
    {
        [Key("_id")]
        string _id;

        string _yaosuName;

        public string YaoSuName
        {
            get { return _yaosuName; }
            set { _yaosuName = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    public class YaoSuManager
    {
        public static List<string> YaoSus = new List<string>();
        public static Dictionary<string, string> dictElement = new Dictionary<string, string>();

        static YaoSuManager()
        {
            YaoSu[] yaosus = YaoSuHelper.GetAll();
            if (yaosus != null && yaosus.Length > 0)
            {
                foreach (YaoSu y in yaosus)
                {
                    YaoSus.Add(y.YaoSuName);
                    dictElement.Add(y.ID, y.YaoSuName);
                }
            }
            else
            {
                //throw new Exception("未能正确加载要素数据！");
            }

            //YaoSus.Add("核动力厂设计");
            //YaoSus.Add("设备合格鉴定");
            //YaoSus.Add("构筑物、系统和部件的实际状态");
            //YaoSus.Add("老化");
            //YaoSus.Add("确定论安全分析");
            //YaoSus.Add("概率安全分析");
            //YaoSus.Add("灾害分析");
            //YaoSus.Add("安全性能");
            //YaoSus.Add("其它核动力经验及研究成果的应用");
            //YaoSus.Add("组织机构和行政管理");
            //YaoSus.Add("程序");
            //YaoSus.Add("人因");
            //YaoSus.Add("应急计划");
            //YaoSus.Add("辐射环境影响");

            //dictElement.Add("01", "核动力厂设计");
            //dictElement.Add("02", "设备合格鉴定");
            //dictElement.Add("03", "构筑物、系统和部件的实际状态");
            //dictElement.Add("04", "老化");
            //dictElement.Add("05", "确定论安全分析");
            //dictElement.Add("06", "概率安全分析");
            //dictElement.Add("07", "灾害分析");
            //dictElement.Add("08", "安全性能");
            //dictElement.Add("09", "其它核动力经验及研究成果的应用");
            //dictElement.Add("10", "组织机构和行政管理");
            //dictElement.Add("11", "程序");
            //dictElement.Add("12", "人因");
            //dictElement.Add("13", "应急计划");
            //dictElement.Add("14", "辐射环境影响");
        }

        public static string GetYaoSuBianHao(string YaoSuName)       
        {
            foreach (KeyValuePair<string, string> pair in dictElement)
            {
                if (pair.Value == YaoSuName)
                    return pair.Key;
            }
            return string.Empty;  
        }

        /// <summary>
        /// 根据要素编号获取要素名称
        /// </summary>
        /// <param name="strElementNO"></param>
        /// <returns></returns>
        public static string GetElementNameByNO(string strElementNO)
        {
            foreach(KeyValuePair<string,string> keypair in dictElement)
            {
                if (keypair.Key == strElementNO)
                {
                    return keypair.Value;
                }
            }
            return "";
        }

    }

    public class YaoSuHelper
    {
        public static YaoSu GetYaoSuById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                YaoSu _yaosu = new YaoSu();
                _yaosu.ID = id;
                Dictionary<string, string> _searchDic = DBHelper.GetKeySeachDictionary(_yaosu);
                IObjectContainer _db = null;
                try
                {
                    _db = DBHelper.InitDB4O(typeof(YaoSu));
                    if (_db != null)
                    {
                        if (_searchDic != null)
                        {
                            YaoSu[] _uArray = DBHelper.Find<YaoSu>(_db, JoinType.And, ContainType.Equal, _searchDic);
                            if (_uArray != null && _uArray.Length > 0)
                            {
                                return _uArray[0];
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception("没找要素id: " + id);
                }
            }
            return null;
        }

        /// <summary>
        /// 获取所有要素
        /// </summary>
        /// <returns></returns>
        public static YaoSu[] GetAll()
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(YaoSu));
                IObjectSet sets = _db.QueryByExample(typeof(YaoSu));
                if (sets != null && sets.Count > 0)
                {
                    YaoSu[] fs = new YaoSu[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        fs[i] = (YaoSu)sets[i];
                    }
                    return fs;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static bool AddAndUpdateYaoSu(YaoSu yaosu)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(YaoSu));
                if (_db != null)
                {
                    if (!DBHelper.SaveToDB(_db, yaosu, true))
                        DBHelper.UpdateFromDB(_db, yaosu);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteYaoSu(string id)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(YaoSu));
                YaoSu f = YaoSuHelper.GetYaoSuById(id);
                if (f != null)
                {
                    DBHelper.DeleteFromDB(_db, f);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static bool DeleteYaoSuy(YaoSu yaosu)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(YaoSu));
                if (yaosu != null)
                {
                    DBHelper.DeleteFromDB(_db, yaosu);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }







    [DB4OClassAttribute("BaseData.yap")]
    public class ZhuanTi
    {
        [Key("_id")]
        string _id;

        string _zhuantiName;

        string _yaosu;
        public string ZhuanTiName
        {
            get { return _zhuantiName; }
            set { _zhuantiName = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string YaosuName
        {
            get { return _yaosu; }
            set { _yaosu = value; }
        }
    }
    public class ZhuanTiManager
    {
        public static Dictionary<string, List<string>> ZhuanTis = new Dictionary<string, List<string>>();
        public static Dictionary<string, string> dictSubject = new Dictionary<string, string>();
        static ZhuanTiManager()
        {
            ZhuanTi[] zhuantis = ZhuanTiHelper.GetAll();
            if (zhuantis!= null && zhuantis.Length > 0)
            {
                foreach (ZhuanTi z in zhuantis)
                {
                    if (!string.IsNullOrEmpty(z.YaosuName))
                    {
                        if (ZhuanTis.ContainsKey(z.YaosuName))
                        {
                            ZhuanTis[z.YaosuName].Add(z.ZhuanTiName);
                        }
                        else
                        {
                            ZhuanTis[z.YaosuName] = new List<string>();
                            ZhuanTis[z.YaosuName].Add(z.ZhuanTiName);
                        }
                    }
                    dictSubject.Add(z.ID, z.ZhuanTiName);
                }
            }

            //ZhuanTis["组织机构和行政管理"] = new List<string>();
            //ZhuanTis["组织机构和行政管理"].Add("电厂的安全机制专题");
            //ZhuanTis["组织机构和行政管理"].Add("电厂的基本安全组织专题");
            //ZhuanTis["组织机构和行政管理"].Add("与国家核安全局的组织联系专题");
            //ZhuanTis["组织机构和行政管理"].Add("质保体系维护专题");
            //ZhuanTis["组织机构和行政管理"].Add("与国际核电厂组织的良好实践对照专题");

            //ZhuanTis["程序"] = new List<string>();
            //ZhuanTis["程序"].Add("事故规程审查、运行技术规范审查专题");
            //ZhuanTis["程序"].Add("事故规程审查、运行以来所有实施的改造对文件的影响专题");
            //ZhuanTis["程序"].Add("运行以来发生的事件对相关技术文件的影响专题");
            //ZhuanTis["程序"].Add("监督大纲的完整性审查专题");
            //ZhuanTis["程序"].Add("涉及运行、维修、监督、辐射防护、在役检查五类主要技术程序的修改、维护和控制的审查专题");
            //ZhuanTis["程序"].Add("定期试验监督大纲的审查专题");
            //ZhuanTis["程序"].Add("新技术规范可用性审查专题");

            //ZhuanTis["应急计划"] = new List<string>();
            //ZhuanTis["应急计划"].Add("应急对策及应急组织专题");
            //ZhuanTis["应急计划"].Add("应急计划、执行程序专题");
            //ZhuanTis["应急计划"].Add("应急设施设备和资源保障专题");
            //ZhuanTis["应急计划"].Add("应急响应能力的维持专题");
            //ZhuanTis["应急计划"].Add("与场外应急组织和支援单位的协调专题");

            //ZhuanTis["辐射环境影响"] = new List<string>();
            //ZhuanTis["辐射环境影响"].Add("电厂环境管理体系及周围环境辐射水平现状专题");
            //ZhuanTis["辐射环境影响"].Add("放射性排出流的废物管理专题");
            //ZhuanTis["辐射环境影响"].Add("厂址特征参数审查专题");

            //dictSubject.Add("00", string.Empty);
            //dictSubject.Add("01", "电厂的安全机制专题");
            //dictSubject.Add("02", "电厂的基本安全组织专题");
            //dictSubject.Add("03", "与国家核安全局的组织联系专题");
            //dictSubject.Add("04", "质保体系维护专题");
            //dictSubject.Add("05", "与国际核电厂组织的良好实践对照专题");

            //dictSubject.Add("06", "事故规程审查、运行技术规范审查专题");
            //dictSubject.Add("07", "事故规程审查、运行以来所有实施的改造对文件的影响专题");
            //dictSubject.Add("08", "运行以来发生的事件对相关技术文件的影响专题");
            //dictSubject.Add("09", "监督大纲的完整性审查专题");
            //dictSubject.Add("10", "涉及运行、维修、监督、辐射防护、在役检查五类主要技术程序的修改、维护和控制的审查专题");
            //dictSubject.Add("11", "定期试验监督大纲的审查专题");
            //dictSubject.Add("12", "新技术规范可用性审查专题");

            //dictSubject.Add("13", "应急对策及应急组织专题");
            //dictSubject.Add("14", "应急计划、执行程序专题");
            //dictSubject.Add("15", "应急设施设备和资源保障专题");
            //dictSubject.Add("16", "应急响应能力的维持专题");
            //dictSubject.Add("17", "与场外应急组织和支援单位的协调专题");

            //dictSubject.Add("18", "电厂环境管理体系及周围环境辐射水平现状专题");
            //dictSubject.Add("19", "放射性排出流的废物管理专题");
            //dictSubject.Add("20", "厂址特征参数审查专题");

        }
        /// <summary>
        /// 获取专题编号
        /// </summary>
        /// <param name="strSubjectName"></param>
        /// <returns></returns>
        public static string GetSubjectNO(string strSubjectName)
        {
            foreach (KeyValuePair<string, string> keyPair in dictSubject)
            {
                if (keyPair.Value == strSubjectName)
                {
                    return keyPair.Key;
                }
            }
            return "";
        }
        /// <summary>
        /// 获取专题编号
        /// </summary>
        /// <param name="strSubjectName"></param>
        /// <returns></returns>
        public static string GetSubjectNameByNO(string strSubjectNO)
        {
            foreach (KeyValuePair<string, string> keyPair in dictSubject)
            {
                if (keyPair.Key == strSubjectNO)
                {
                    return keyPair.Value;
                }
            }
            return "";
        }

    }

    public class ZhuanTiHelper
    {
        public static ZhuanTi GetZhuanTiById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ZhuanTi _f = new ZhuanTi();
                _f.ID = id;
                Dictionary<string, string> _searchDic = DBHelper.GetKeySeachDictionary(_f);
                IObjectContainer _db = null;
                try
                {
                    _db = DBHelper.InitDB4O(typeof(ZhuanTi));
                    if (_db != null)
                    {
                        if (_searchDic != null)
                        {
                            ZhuanTi[] _uArray = DBHelper.Find<ZhuanTi>(_db, JoinType.And, ContainType.Equal, _searchDic);
                            if (_uArray != null && _uArray.Length > 0)
                            {
                                return _uArray[0];
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception("没找专题id: " + id);
                }
            }
            return null;
        }

        /// <summary>
        /// 获取所有ZhuanTi
        /// </summary>
        /// <returns></returns>
        public static ZhuanTi[] GetAll()
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(ZhuanTi));
                IObjectSet sets = _db.QueryByExample(typeof(ZhuanTi));
                if (sets != null && sets.Count > 0)
                {
                    ZhuanTi[] fs = new ZhuanTi[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        fs[i] = (ZhuanTi)sets[i];
                    }
                    return fs;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static void AddAndUpdateZhuanTi(ZhuanTi[] zhuantis)
        {
            if (zhuantis != null && zhuantis.Length > 0)
            {
                foreach (ZhuanTi z in zhuantis)
                {
                    AddAndUpdateZhuanTi(z);
                }
            }
        }

        public static bool AddAndUpdateZhuanTi(ZhuanTi zhuanti)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(ZhuanTi));
                if (_db != null)
                {
                    if (!DBHelper.SaveToDB(_db, zhuanti, true))
                        DBHelper.UpdateFromDB(_db, zhuanti);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteZhuanTi(string id)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(ZhuanTi));
                ZhuanTi f = ZhuanTiHelper.GetZhuanTiById(id);
                if (f != null)
                {
                    DBHelper.DeleteFromDB(_db, f);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static bool DeleteZhuanTi(ZhuanTi zhuanti)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(ZhuanTi));
                if (zhuanti != null)
                {
                    DBHelper.DeleteFromDB(_db, zhuanti);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static ZhuanTi[] FindZhuanti(ZhuanTi zhuanti)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(ZhuanTi));
                if (zhuanti != null)
                {
                    return DBHelper.FindByExample<ZhuanTi>(_db, zhuanti);
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
