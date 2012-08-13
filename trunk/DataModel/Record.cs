using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
namespace APP
{
    public class RecordStatus
    {
        public static readonly string Approved="已审批";
        public static readonly string HoldForApprove = "已提交";
        public static readonly string Inputed = "编辑中";
        public static readonly string ReturnBack = "已退回";
        public static readonly string Deleted = "已删除";
    }
    [DB4OClassAttribute("记录\\Record.yap")]
    public class Record
    {
        [Key("_id")]
        string _id;
        string _facility;//针对电厂名称
        string _count;//
        string _yaosubianhao;//要素编号
        string _zhuangtibianhao;//专题编号
        string _danwei;//单位名称
        string _inputUser;//录入者名称
        string _inputUserSuoXie;//录入者名称缩写
        string _status;//记录状态
        bool _haveAttached;
        bool _Haveruoxiang;
        bool _Haveqiangxiang;
        DateTime _inputTime;//录入时间
        bool _isDelete;//是否被删除
        string _topic;//记录主题
        string _result;//记录结论
        string _recordDesciption;//记录描述
        List<Fact> _facts;//事件
        string _approveBy;//审批人
        string _comments;//删除原因
        DateTime _approveTime;//审批时间
        

        bool _isUpLoad;
        bool _isUpDated;
        DateTime _UpLoadedTime;
        DateTime _UpdatedTime;

        //新加
        string _sendBackReason;//退回原因
        List<RecordResult> _results;
        public List<RecordResult> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        public string SendBackReason
        {
            get { return _sendBackReason; }
            set { _sendBackReason = value; }
        }

        bool _isActivityInspection;//活动观察
        public bool IsActivityInspection
        {
            get
            {
                return _isActivityInspection;
            }
            set
            {
                _isActivityInspection = value;}
        }

        bool _isWalkDown;//现场巡视
        public bool IsWalkDown
        {
            get
            {
                return _isWalkDown;}
            set
            {
                _isWalkDown = value;}
        }

        bool _isDocumentRevision;//文档审查
        public bool IsDocumentRevision
        {
            get { return _isDocumentRevision; }
            set { _isDocumentRevision = value; }
        }
        bool _isCommunication;//访谈
        public bool IsCommunication
        {
            get { return _isCommunication; }
            set { _isCommunication = value; }
        }
        bool _isCompliance;//比准校对
        public bool IsCompliance
        {
            get { return _isCompliance; }
            set { _isCompliance = value; }
        }

        string _equiptment;
        public string Equipment
        {
            get { return _equiptment; }
            set { _equiptment = value; }
        }
        //


        public DateTime ApproveTime
        {
            get { return _approveTime; }
            set { _approveTime = value; }
        }
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public string ApproveBy
        {
            get { return _approveBy; }
            set { _approveBy = value; }
        }
        public DateTime UpLoadedTime
        {
            get { return _UpLoadedTime; }
            set { _UpLoadedTime = value; }
        }
        public DateTime UpDatedTime
        {
            get { return _UpdatedTime; }
            set { _UpdatedTime = value; }
        }

        public bool IsUpLoad
        {
            get { return _isUpLoad; }
            set { _isUpLoad = value; }
        }
        public bool IsUpDated
        {
            get { return _isUpDated; }
            set { _isUpDated = value; }
        }
        public string ID
        {
            get 
            { 
                return _id; 
            }
            set { _id = value; }
        }
        public string Facility
        {
            get { return _facility; }
            set { _facility = value; }
        }
        public string Count
        {
            get
            {
                return _count;
            }
            set { _count = value; }
        }

        public string YaoSuBianHao
        {
            get { return _yaosubianhao; }
            set { _yaosubianhao = value; }
        }

        public string ZhuangTiBianHao
        {
            get { return _zhuangtibianhao; }
            set { _zhuangtibianhao = value; }
        }

        public string DanWei
        {
            get { return _danwei; }
            set { _danwei = value; }
        }

        public string InputUser
        {
            get { return _inputUser; }
            set { _inputUser = value; }
        }
        public string InputUserSuoXie
        {
            get { return _inputUserSuoXie; }
            set { _inputUserSuoXie = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public bool HaveAttached
        {
            get { return _haveAttached; }
            set { _haveAttached = value; }
        }

        public bool HaveRuoXiang
        {
            get { return _Haveruoxiang; }
            set { _Haveruoxiang = value; }
        }

        public bool HaveQiangxiang
        {
            get { return _Haveqiangxiang; }
            set { _Haveqiangxiang = value; }
        }

        public DateTime InputTime
        {
            get { return _inputTime; }
            set { _inputTime = value; }
        }

        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
        

        public string Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }

        public string RecordDesciption
        {
            get { return _recordDesciption; }
            set { _recordDesciption = value; }
        }

        public List<Fact> Facts
        {
            get { return _facts; }
            set { _facts = value; }
        }

        public void GenId()
        {
            int liushuihao = RecordHelper.GetRecordCount(_inputUser, _facility, _yaosubianhao, _zhuangtibianhao) + 1;
            if (_facility == "Q1")
            {
                _count = "2";
            }
            else
            {
                _count = "1";
            }
            /*
             * 审查记录编号规则：

                电厂（2位）+审查次数（1位）+要素编号（两位）+专题编号（2位）+单                 位（两位）+  人（3位）+流水，如无专题编号为0。

                事实编号：审查记录编号+流水号（3位）
             */
            string liu;
            if (liushuihao >= 1000 || liushuihao<0) throw new OverflowException(liushuihao.ToString() + "大于1000");
            else if (liushuihao > 99)
            {
                liu = liushuihao.ToString();
            }
            else if (liushuihao > 9)
            {
                liu = "0" + liushuihao.ToString();
            }
            else
                liu = "00" + liushuihao.ToString();
            _danwei = UserSession.LoginUser.DanWei;
            _id = _facility + _count + _yaosubianhao + _zhuangtibianhao + _danwei + _inputUserSuoXie + liu;
        }
    }

    [DB4OClassAttribute("记录\\Record.yap")]
    public class Fact
    {
        [KeyAttribute("_id")]
        string _id;
        string _recordNo;
        string _content;
        string _FuHeXiang;
        string _PianChaXiang;
        DateTime _timeStamp;
        string strFactStatus;//事实状态
        string strFactApproveComment;//事实审批意见
        int _associateResult;
        bool _isFh;
        bool _isPc;
        public int AssociateResult
        {
            get { return _associateResult; }
            set { _associateResult = value; }
        }
        public bool IsFH
        {
            get { return _isFh; }
            set { _isFh = value; }
        }

        public bool IsPC
        {
            get { return _isPc; }
            set { _isPc = value; }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public string FuHeXiang
        {
            get { return _FuHeXiang; }
            set { _FuHeXiang = value; }
        }

        public string PianChaXiang
        {
            get { return _PianChaXiang; }
            set { _PianChaXiang = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string RecordNo
        {
            get { return _recordNo; }
            set { _recordNo = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// 事实状态
        /// </summary>
        public string FactStatus
        {
            get { return strFactStatus; }
            set { strFactStatus = value; }
        }
        /// <summary>
        /// 事实审批意见
        /// </summary>
        public string FactApproveComment
        {
            get { return strFactApproveComment; }
            set { strFactApproveComment = value; }
        }
    }

    [DB4OClassAttribute("记录\\Record.yap")]
    public class RecordResult
    {
        [KeyAttribute("_id")]
        string _id;
        [KeyAttribute("_recordNo")]
        string _recordNo;
        string _content;
        string _againstFacts;
        bool _isPC;
        bool _isFH;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string RecordNo
        {
            get { return _recordNo; }
            set { _recordNo = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public string AgainstFacts
        {
            get { return _againstFacts; }
            set { _againstFacts = value; }
        }

        public bool IsFH
        {
            get { return _isFH; }
            set { _isFH = value; }
        }
        public bool IsPC
        {
            get { return _isPC; }
            set { _isPC = value; }
        }
    }

    public class RecordHelper
    {
        static IObjectContainer _dbRecord = null;
        static string _recordPath = "";
        
        public static  string RecordBelongsTo
        {
            get
            {
                if (_recordPath != "")
                {
                    string[] temp = _recordPath.Split(new char[1] { '\\' });
                    if (temp != null && temp.Length > 0)
                    {
                        string suoxie = temp[temp.Length - 1].Split(new char[1] { '.' })[0];
                        User _u = UserHelper.GetUser(suoxie);
                        if (_u != null)
                            return _u.PingYing;
                    }
                }
                return "";
            }
        }
        public static IObjectContainer DBRecord
        {
            get { return _dbRecord; }
        }
        static RecordHelper()
        {
            string jiluPath = AppDomain.CurrentDomain.BaseDirectory + "记录\\";
            if(!System.IO.Directory.Exists(jiluPath))
            {
                System.IO.Directory.CreateDirectory(jiluPath);
            }
            string YapFileName = jiluPath + UserSession.LoginUser.PingYing + ".yap";

            _recordPath = YapFileName;

            Type _type = typeof(Record);
            try
            {
                IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
                config.Common.ObjectClass(_type).CascadeOnActivate(true);
                config.Common.ObjectClass(_type).CascadeOnDelete(true);
                config.Common.ObjectClass(_type).CascadeOnUpdate(true);
                config.Common.ActivationDepth = 20;
                _dbRecord = Db4oEmbedded.OpenFile(config, YapFileName);
                if (_dbRecord == null)
                    throw new Exception("记录数据库初始化失败！");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void RefreshDBOfRecord(string dbPath)
        {   
            if(System.IO.File.Exists(dbPath))
            {
                IObjectContainer _originalDB = _dbRecord;
                string YapFileName = dbPath;
                _recordPath = YapFileName;

                Type _type = typeof(Record);
                try
                {
                    IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
                    config.Common.ObjectClass(_type).CascadeOnActivate(true);
                    config.Common.ObjectClass(_type).CascadeOnDelete(true);
                    config.Common.ObjectClass(_type).CascadeOnUpdate(true);
                    config.Common.ActivationDepth = 20;
                    _dbRecord = Db4oEmbedded.OpenFile(config, YapFileName);
                    if (_dbRecord == null)
                        throw new Exception("记录数据库刷新失败！");

                    //关闭原来的数据库，更新Fact与Result的引用。
                    _originalDB.Close();
                    FactHelper.RefreshDBFact();
                    ResultHelper.RefreshDBResult();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void CloseRecordDB()
        {
            if(_dbRecord!=null)
                _dbRecord.Close();
        }

        public static Record GetByRecordId(string recordId)
        {
            if (!string.IsNullOrEmpty(recordId))
            {
                Record record = new Record();
                record.ID = recordId;

                Dictionary<string, string> _searchDic = DBHelper.GetKeySeachDictionary(record);
                //IObjectContainer _db = null;
                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Record));
                    if (_dbRecord != null)
                    {
                        if (_searchDic != null)
                        {
                            Record[] _uArray = DBHelper.Find<Record>(_dbRecord, JoinType.And, ContainType.Equal, _searchDic);
                            if (_uArray != null && _uArray.Length > 0)
                            {
                                return _uArray[0];
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public static Record[] GetByExampleArray(Record record)
        {
            if (record != null)
            {
                //IObjectContainer _db = null;
                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Record));
                    IObjectSet sets = _dbRecord.QueryByExample(record);
                    Record[] records = new Record[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        records[i] = (Record)sets[i];
                    }
                    return records;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public static bool AddRecord(Record record)
        {
            if (record != null)
            {
                //IObjectContainer _db = null;

                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Record));
                    return DBHelper.SaveToDB(_dbRecord, record, true);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }

        public static void UpdateRecords(Record[] records)
        {
            if (records != null && records.Length > 0)
            {
                //IObjectContainer _db = null;
                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Record));
                    foreach (Record r in records)
                    {
                        if (DBHelper.IsKeysHaveValue(typeof(Record),r))
                        {
                            if (!DBHelper.SaveToDB(_dbRecord, r, true))
                            {
                                DBHelper.UpdateFromDB(_dbRecord, r);
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void UpdateRecords(IList<Record> records)
        {
            if (records != null && records.Count > 0)
            {
                //IObjectContainer _db = null;
                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Record));
                    foreach (Record r in records)
                    {
                        if (DBHelper.IsKeysHaveValue(typeof(Record), r))
                        {
                            if (!DBHelper.SaveToDB(_dbRecord, r, true))
                            {
                                DBHelper.UpdateFromDB(_dbRecord, r);
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static int GetRecordCount(string inputUser,string facility,string yaosubianhao,string zhuantibianhao)
        {
            Record r = new Record();
            r.InputUser = inputUser;
            r.Facility = facility;
            r.YaoSuBianHao = yaosubianhao;
            r.ZhuangTiBianHao = zhuantibianhao;

            if (r != null)
            {
                //IObjectContainer _db = null;
                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Record));
                    IObjectSet sets = _dbRecord.QueryByExample(r);
                    return sets.Count;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return 0;
        }

        public static Record[] GetAll()
        {
            //IObjectContainer _db = null;
            try
            {
                //_db = DBHelper.InitDB4O(typeof(Record));
                IObjectSet sets = _dbRecord.QueryByExample(typeof(Record));
                if (sets != null && sets.Count > 0)
                {
                    Record[] records = new Record[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        records[i] = (Record)sets[i];
                    }
                    return records;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
    public class FactHelper
    {
        static IObjectContainer _dbFact = RecordHelper.DBRecord;
        public static void RefreshDBFact()
        {
            _dbFact = RecordHelper.DBRecord;
        }
        public static Fact[] GetByExampleArray(Fact fact)
        {
            if (fact != null)
            {
                //IObjectContainer _db = null;
                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Fact));
                    IObjectSet sets = _dbFact.QueryByExample(fact);
                    Fact[] facts = new Fact[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        facts[i] = (Fact)sets[i];
                    }
                    return facts;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }
        public static Fact[] GetAll()
        {
            //IObjectContainer _db = null;
            try
            {
                //_db = DBHelper.InitDB4O(typeof(Fact));
                IObjectSet sets = _dbFact.QueryByExample(typeof(Fact));
                if (sets != null && sets.Count > 0)
                {
                    Fact[] Facts = new Fact[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        Facts[i] = (Fact)sets[i];
                    }
                    return Facts;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }

    public class ResultHelper
    {
        static IObjectContainer _dbResult = RecordHelper.DBRecord;
        public static void RefreshDBResult()
        {
            _dbResult = RecordHelper.DBRecord;
        }
        public static RecordResult[] GetByExampleArray(RecordResult result)
        {
            if (result != null)
            {
                //IObjectContainer _db = null;
                try
                {
                    //_db = DBHelper.InitDB4O(typeof(Fact));
                    IObjectSet sets = _dbResult.QueryByExample(result);
                    RecordResult[] results = new RecordResult[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        results[i] = (RecordResult)sets[i];
                    }
                    return results;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }
        public static RecordResult[] GetAll()
        {
            //IObjectContainer _db = null;
            try
            {
                //_db = DBHelper.InitDB4O(typeof(Fact));
                IObjectSet sets = _dbResult.QueryByExample(typeof(RecordResult));
                if (sets != null && sets.Count > 0)
                {
                    RecordResult[] resuls = new RecordResult[sets.Count];
                    for (int i = 0; i < sets.Count; i++)
                    {
                        resuls[i] = (RecordResult)sets[i];
                    }
                    return resuls;
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
