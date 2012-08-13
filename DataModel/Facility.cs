using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace APP
{
    //public enum EFacilityNo
    //{
    //    Q1,
    //    Q2,
    //    Q3,
    //    QM,
    //    QF,
    //    QN,
    //    QE,
    //    QS,
    //}
    //public enum EDanWei
    //{
    //    运行公司=0,
    //    成都一院=1,
    //    工程公司 =2,
    //    所105=5,
    //    院728=8,
    //}

    public class DanWeiManager
    {
        static DanWeiManager()
        {
            DanWeiList.Add("成都一院");
            DanWeiList.Add("工程公司");
            DanWeiList.Add("105所");
            DanWeiList.Add("728院");
            DanWeiList.Add("运行公司");
            DanWei[] allindb = DanWeiHelper.GetAll();
            if (allindb != null && allindb.Length > 0)
            {
                foreach (DanWei d in allindb)
                {
                    DanWeiList.Add(d.DanWeiName);
                }
            }
            else
            {
                //throw new Exception("没有单位信息！请查看安装目录是否却少BaseData.yap文件");
            }
        }
        public static List<string> DanWeiList = new List<string>();
    }

    [DB4OClassAttribute("System\\BaseData.yap")]
    public class DanWei
    {
        [Key("_id")]
        string _id;

        string _danweiName;

        public string DanWeiName
        {
            get { return _danweiName; }
            set { _danweiName = value;}
        }
        public string ID
        {
            get { return _id; }
            set { _id = value;}
        }
    }

    public class DanWeiHelper
    {
        public static DanWei GetDanweiById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                DanWei _danwei = new DanWei();
                _danwei.ID = id;
                Dictionary<string, string> _searchDic = DBHelper.GetKeySeachDictionary(_danwei);
                IObjectContainer _db = null;
                try
                {
                    _db = DBHelper.InitDB4O(typeof(DanWei));
                    if (_db != null)
                    {
                        if (_searchDic != null)
                        {
                            DanWei[] _uArray = DBHelper.Find<DanWei>(_db, JoinType.And, ContainType.Equal, _searchDic);
                            if (_uArray != null && _uArray.Length > 0)
                            {
                                return _uArray[0];
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception("没找到单位id: " + id);
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
        /// 获取所有单位
        /// </summary>
        /// <returns></returns>
        public static DanWei[] GetAll()
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(DanWei));
                IObjectSet sets = _db.QueryByExample(typeof(DanWei));
                if (sets != null && sets.Count > 0)
                {
                    DanWei[] danweis = new DanWei[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        danweis[i] = (DanWei)sets[i];
                    }
                    return danweis;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static bool AddAndUpdateDanwei(DanWei danwei)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(DanWei));
                if (_db != null)
                {
                    if (!DBHelper.SaveToDB(_db, danwei, true))
                        DBHelper.UpdateFromDB(_db, danwei);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteDanwei(string id)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(DanWei));
                DanWei danwei = DanWeiHelper.GetDanweiById(id);
                if (danwei != null)
                {
                    DBHelper.DeleteFromDB(_db, danwei);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static bool DeleteDanwei(DanWei danwei)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(DanWei));
                if (danwei != null)
                {
                    DBHelper.DeleteFromDB(_db, danwei);
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



    [DB4OClassAttribute("System\\BaseData.yap")]
    public class Facility
    {
        [Key("_id")]
        string _id;

        string _facilityName;

        public string FacilityName
        {
            get { return _facilityName; }
            set { _facilityName = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    public class FacilityHelper
    {
        public static Facility GetFacilityById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Facility _f = new Facility();
                _f.ID = id;
                Dictionary<string, string> _searchDic = DBHelper.GetKeySeachDictionary(_f);
                IObjectContainer _db = null;
                try
                {
                    _db = DBHelper.InitDB4O(typeof(Facility));
                    if (_db != null)
                    {
                        if (_searchDic != null)
                        {
                            Facility[] _uArray = DBHelper.Find<Facility>(_db, JoinType.And, ContainType.Equal, _searchDic);
                            if (_uArray != null && _uArray.Length > 0)
                            {
                                return _uArray[0];
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception("没找电厂id: " + id);
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
        /// 获取所有电厂
        /// </summary>
        /// <returns></returns>
        public static Facility[] GetAll()
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(Facility));
                IObjectSet sets = _db.QueryByExample(typeof(Facility));
                if (sets != null && sets.Count > 0)
                {
                    Facility[] fs = new Facility[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        fs[i] = (Facility)sets[i];
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

        public static bool AddAndUpdateFacility(Facility facillity)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(Facility));
                if (_db != null)
                {
                    if (!DBHelper.SaveToDB(_db, facillity, true))
                        DBHelper.UpdateFromDB(_db, facillity);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteFacility(string id)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(Facility));
                Facility f = FacilityHelper.GetFacilityById(id);
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

        public static bool DeleteFacility(Facility facility)
        {
            IObjectContainer _db = null;
            try
            {
                _db = DBHelper.InitDB4O(typeof(Facility));
                if (facility != null)
                {
                    DBHelper.DeleteFromDB(_db, facility);
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

    public class FacilityName
    {
        public static Dictionary<string, string> FacilityAndDescription = new Dictionary<string, string>();
        public static Dictionary<string, string> dictFactory = new Dictionary<string, string>();
        static FacilityName()
        {
            Facility[] facilitys = FacilityHelper.GetAll();
            if (facilitys != null && facilitys.Length > 0)
            {
                foreach (Facility f in facilitys)
                {
                    FacilityAndDescription.Add(f.ID, f.FacilityName);
                    dictFactory.Add(f.ID, f.FacilityName);
                }
            }
            //FacilityAndDescription.Add(EFacilityNo.Q1, "秦山核电厂320MWe");
            //FacilityAndDescription.Add(EFacilityNo.QF, "秦山核电厂扩建项目（方家山核电工程）");
            //FacilityAndDescription.Add(EFacilityNo.QN, "秦山第二核电厂1、2号机组");
            //FacilityAndDescription.Add(EFacilityNo.QE, "秦山第二核电厂3、4号机组");
            //FacilityAndDescription.Add(EFacilityNo.Q3, "秦山第三核电厂");
            //FacilityAndDescription.Add(EFacilityNo.QS, "秦山各核电厂");

            //dictFactory.Add("Q1", "秦山核电厂320MWe");
            //dictFactory.Add("QF", "秦山核电厂扩建项目（方家山核电工程）");
            //dictFactory.Add("QN", "秦山第二核电厂1、2号机组");
            //dictFactory.Add("QE", "秦山第二核电厂3、4号机组");
            //dictFactory.Add("Q3", "秦山第三核电厂");
            //dictFactory.Add("QS", "秦山各核电厂");
        }
        /// <summary>
        /// 根据电厂名称获取编号
        /// </summary>
        /// <param name="strFacilityName"></param>
        /// <returns></returns>
        public static string GetFacilityNO(string strFacilityName)
        {
            foreach(KeyValuePair<string,string> key in FacilityAndDescription)
            {
                if (key.Value == strFacilityName)
                {
                    return key.Key;//Enum.GetName(typeof(EFacilityNo), key.Key);
                }
            }
            return "";
        }
        /// <summary>
        /// 根据电厂编号获取名称
        /// </summary>
        /// <param name="strFacilityName"></param>
        /// <returns></returns>
        public static string GetFacilityNameByNO(string strFacilityNO)
        {
            foreach (KeyValuePair<string, string> keyPair in dictFactory)
            {
                if (keyPair.Key == strFacilityNO)
                {
                    return keyPair.Value;
                }
            }
            return "";
        }
    }
}
