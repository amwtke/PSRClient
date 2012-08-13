﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using ExportToWord;
using System.Data;
using System.Collections;
using System.Linq;

namespace APP
{
    public delegate void ProcessControl(System.Windows.Forms.Control c);
   
    public class CommonHelper
    {
        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是 file:// 的长度
            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }
            return _FolderPath;
        }

        public static string GetPicFolderPath()
        {
            string picfoldername = "记录\\"+UserSession.LoginUser.PingYing + "- 图片";
            string folderPath = System.IO.Path.Combine(GetAssemblyPath(), picfoldername);
            if(!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);
            return folderPath;
        }

        public static string GetRecordPath(string recordId,string factNo)
        {
            string recordFolder =  System.IO.Path.Combine(CommonHelper.GetPicFolderPath(), recordId);
            if (!System.IO.Directory.Exists(recordFolder))
                System.IO.Directory.CreateDirectory(recordFolder);
            string factPath = System.IO.Path.Combine(recordFolder, "事实"+factNo);
            return factPath;
        }

        public static void DeleteFolder(string path)
        {
            if(System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path,true);
            }
        }

        public static void OpenInExplorer(string path)
        {
            if(!string.IsNullOrEmpty(path))
                System.Diagnostics.Process.Start(path);
        }

        public static void WordOutPut(DataGridViewRow selectRow)
        {
            String strID = selectRow.Cells["recordno"].Value.ToString();
            Record _record = RecordHelper.GetByRecordId(strID);
            if (_record == null)
                return;

            int returnCount = 0;
            WordClass word = null;
            string strPath = Application.StartupPath;
            string strWordFilePath = strPath + @"\template\approve.doc";

            FolderBrowserDialog _fbd = new FolderBrowserDialog();
            _fbd.Description = "选择导出word文件目录";
            _fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            _fbd.ShowNewFolderButton = true;

            string outputDir = "";
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                outputDir = _fbd.SelectedPath;
            }
            else
            {
                return;
            }

            if (_record == null)
            {
                MessageBox.Show("记录查找失败，不能导出！");
                return;
            }

            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            string strExportPath = outputDir + "\\审批记录" + _record.ID + ".doc";

            Dictionary<string, string> dictReplace = new Dictionary<string, string>();
            dictReplace.Add("<dianchang>", FacilityName.GetFacilityNameByNO(_record.Facility));//电厂
            dictReplace.Add("<yaosu>", YaoSuManager.GetElementNameByNO(_record.YaoSuBianHao));//要素
            dictReplace.Add("<zhuanti>", ZhuanTiManager.GetSubjectNameByNO(_record.ZhuangTiBianHao));
            dictReplace.Add("<recordno>", _record.ID);
            dictReplace.Add("<user>", _record.InputUser);
            dictReplace.Add("<name>", _record.Topic);

            //审批部分
            dictReplace.Add("<approvename>", _record.ApproveBy);
            dictReplace.Add("<approvetime>", _record.ApproveTime.ToString());
            dictReplace.Add("<status>", _record.Status);//状态
            dictReplace.Add("<resultNo>", _record.Results.Count.ToString());
            dictReplace.Add("<factNo>", _record.Facts.Count.ToString());

            String strDesc = _record.RecordDesciption;
            String strDescReplace = strDesc.Replace("\n", "^p");


            dictReplace.Add("<gaishu>", strDescReplace);


            //char[] a = { '\n' };
            //String[] strDescArray = strDesc.Split(a);
            //returnCount = strDescArray.Length - 1;

            //事实
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("factno");
            dtSource.Columns.Add("factcontent");
            for (int i = 0; i < _record.Facts.Count; i++)//事实个数
            {
                Fact fact = _record.Facts.ElementAt(i);

                DataRow dr = dtSource.NewRow();
                dr["factno"] = "编号：" + (i + 1).ToString();//fact.ID.Substring(fact.ID.Length - 3, 3);
                dr["factcontent"] = fact.Content;

                dtSource.Rows.Add(dr);
            }

            //结论
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("resultNo");
            dtResult.Columns.Add("resultContent");
            dtResult.Columns.Add("factAgainst");
            dtResult.Columns.Add("xiang");

            for (int i = 0; i < _record.Results.Count; i++)//事实个数
            {
                RecordResult result = _record.Results.ElementAt(i);

                DataRow dr = dtResult.NewRow();
                dr["resultNo"] = "编号" + (i + 1).ToString();
                dr["resultContent"] = result.Content;
                dr["factAgainst"] = result.AgainstFacts;
                if (result.IsFH)
                    dr["xiang"] = "符合项";
                if (result.IsPC)
                    dr["xiang"] = "偏差项";

                dtResult.Rows.Add(dr);
            }
            try
            {
                word = new WordClass();
                word.OpenDocument(strWordFilePath, false);
                word.ReplaceInBatch(dictReplace);//批量替换
                word.GetSelection();//获取光标
                word.MoveDownByLine(1);//下移至表格中
                word.MoveToTableRowLineEnd();//移至行尾
                word.AddTableData(7 + returnCount, dtSource);//增加表格事实数据 
                word.AddTableData(2, dtResult);//增加表格结论数据
                word.SaveAs(strExportPath);
                //blSuccessfull = true;
            }
            catch (Exception ex)
            {
                //blSuccessfull = false;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (word != null)
                {
                    MessageBox.Show(word.Document.Name + " 创建成功！");
                    word.Close(false);
                    word.Dispose();
                    word = null;
                    GC.Collect();
                }
            }
        }

        public static void WordOutPut(Record record)
        {
            if (record == null)
                return;

            int returnCount = 0;
            WordClass word = null;
            string strPath = Application.StartupPath;
            string strWordFilePath = strPath + @"\template\approve.doc";

            FolderBrowserDialog _fbd = new FolderBrowserDialog();
            _fbd.Description="选择导出word文件目录";
            _fbd.RootFolder= Environment.SpecialFolder.MyComputer;
            _fbd.ShowNewFolderButton = true;

            string outputDir = "";
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                outputDir = _fbd.SelectedPath;
            }
            else
            {
                return;
            }
            
            Record _record = record;

            if (_record == null)
            {
                MessageBox.Show("记录查找失败，不能导出！");
                return;
            }

            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            string strExportPath = outputDir + "\\审批记录" + _record.ID + ".doc";

            Dictionary<string, string> dictReplace = new Dictionary<string, string>();
            dictReplace.Add("<dianchang>", FacilityName.GetFacilityNameByNO(_record.Facility));//电厂
            dictReplace.Add("<yaosu>", YaoSuManager.GetElementNameByNO(_record.YaoSuBianHao));//要素
            dictReplace.Add("<zhuanti>", ZhuanTiManager.GetSubjectNameByNO(_record.ZhuangTiBianHao));
            dictReplace.Add("<recordno>", _record.ID);
            dictReplace.Add("<user>", _record.InputUser);
            dictReplace.Add("<name>", _record.Topic);

            //审批部分
            dictReplace.Add("<approvename>", _record.ApproveBy);
            dictReplace.Add("<approvetime>", _record.ApproveTime.ToString());
            dictReplace.Add("<status>", _record.Status);//状态
            dictReplace.Add("<resultNo>", _record.Results.Count.ToString());
            dictReplace.Add("<factNo>", _record.Facts.Count.ToString());

            String strDesc = _record.RecordDesciption;
            String strDescReplace = strDesc.Replace("\n", "^p");


            dictReplace.Add("<gaishu>", strDescReplace);


            //char[] a = { '\n' };
            //String[] strDescArray = strDesc.Split(a);
            //returnCount = strDescArray.Length - 1;

            //事实
            //Dictionary<string, string> factReplace = new Dictionary<string, string>();
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("factno");
            dtSource.Columns.Add("factcontent");
            for (int i = 0; i < _record.Facts.Count; i++)//事实个数
            {
                Fact fact = _record.Facts.ElementAt(i);

                DataRow dr = dtSource.NewRow();
                dr["factno"] = "编号：" + (i + 1).ToString();//fact.ID.Substring(fact.ID.Length - 3, 3);
                dr["factcontent"] = fact.Content;
                //dr["factno"] = "<fNo"+(i+1).ToString()+ ">";
                //dr["factcontent"] = "<fcontentNo" + (i + 1).ToString() + ">";

                //factReplace.Add("<fNo" + (i + 1).ToString() + ">", "");
                //factReplace.Add("<fcontentNo" + (i + 1).ToString() + ">", "");

                dtSource.Rows.Add(dr);
            }

            //结论
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("resultNo");
            dtResult.Columns.Add("resultContent");
            dtResult.Columns.Add("factAgainst");
            dtResult.Columns.Add("xiang");

            for (int i = 0; i < _record.Results.Count; i++)//事实个数
            {
                RecordResult result = _record.Results.ElementAt(i);

                DataRow dr = dtResult.NewRow();
                dr["resultNo"] = "编号"+(i + 1).ToString();
                dr["resultContent"] = result.Content;
                dr["factAgainst"] = result.AgainstFacts;
                if (result.IsFH)
                    dr["xiang"] = "不符合项";
                if (result.IsPC)
                    dr["xiang"] = "偏差项";

                dtResult.Rows.Add(dr);
            }
            try
            {
                word = new WordClass();
                word.OpenDocument(strWordFilePath, false);
                word.ReplaceInBatch(dictReplace);//批量替换
                word.GetSelection();//获取光标
                word.MoveDownByLine(1);//下移至表格中
                word.MoveToTableRowLineEnd();//移至行尾
                word.AddTableData(7 + returnCount, dtSource);//增加表格事实数据 
                word.AddTableData(2, dtResult);//增加表格结论数据
                word.SaveAs(strExportPath);
                //blSuccessfull = true;
            }
            catch (Exception ex)
            {
                //blSuccessfull = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (word != null)
                {
                    MessageBox.Show(word.Document.Name + " 创建成功！");
                    word.Close(false);
                    word.Dispose();
                    word = null;
                    GC.Collect();
                }
            }
        }

        #region Reflect
        //深度复制对象
        public static void CopyObject<T>(T original, T updated)
        {
            PropertyInfo[] ps = typeof(T).GetProperties();
            for (int j = 0; j < ps.Length - 1; j++)
            {
                ps[j].SetValue(original, ps[j].GetValue(updated, null), null);
            }
        }

        /// <summary>
        ///为类设置其Property的值
        /// </summary>
        /// <param name="o">对象实例</param>
        /// <param name="propertyName">Property名称</param>
        /// <param name="value">值</param>
        public static void SetPropertyValueByPropertyName(object o, string propertyName, object value)
        {
            PropertyInfo[] ps = o.GetType().GetProperties();
            foreach (PropertyInfo p in ps)
            {
                if (p.Name == propertyName)
                {
                    p.SetValue(o, value, null);
                }
            }
        }

        /// <summary>
        /// 为类设置字段的值
        /// </summary>
        /// <param name="o">类实例</param>
        /// <param name="fieldName">字段名</param>
        /// <returns></returns>
        public static object GetFieldValueByFieldName(object o, string fieldName)
        {
            FieldInfo f = o.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return f.GetValue(o);
        }

        //public static void CreateObject<T>(string filePath)
        //{
        //    foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
        //    {
        //        if (t.IsClass && t.GetInterface("IFunctionConponent", true) != null)
        //        {
        //            IFunctionConponent temp = (IFunctionConponent)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, null);
        //            if (temp is IFunctionConponent)
        //                Add(temp);
        //        }

        //    }
        //}

        /// <summary>
        /// 加载DLL，并从中获取T类型的实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="vt"></param>
        /// <returns></returns>
        public static T Get<T>(string path, string vt)
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(path);
            //string vt = "Laptop.Order.PDF.WABPdfProvider2";
            T r = default(T);
            Type tt = ass.GetType(vt);
            ConstructorInfo ci = tt.GetConstructor(System.Type.EmptyTypes);
            r = (T)ci.Invoke(null);
            return r;
        }

        /// <summary>
        /// 本地获取类型实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vt">全名--Laptop.Order.PDF.WABPdfProvider2</param>
        /// <returns></returns>
        public static T Get<T>(string vt)
        {
            T r = default(T);
            Type tt = System.Reflection.Assembly.GetExecutingAssembly().GetType(vt);
            ConstructorInfo ci = tt.GetConstructor(System.Type.EmptyTypes);
            r = (T)ci.Invoke(null);
            return r;
        }

        /// <summary>
        /// 获取基类的类名的实例集合
        /// </summary>
        /// <typeparam name="T">返回实例的类型</typeparam>
        /// <param name="BaseTypeName">基类类名如Form</param>
        /// <returns></returns>
        public static T[] GenTypesObjectFromAssembly<T>(string BaseTypeName)
        {
            List<T> list = new List<T>();
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsClass && t.BaseType.Name == BaseTypeName)
                {
                    T temp = (T)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, null);
                    if (temp != null)
                        list.Add(temp);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 获取接口的实例集合。
        /// </summary>
        /// <typeparam name="T">返回实例类型</typeparam>
        /// <param name="interFaceName">接口名</param>
        /// <returns></returns>
        public static T[] GetInterfaceObjectFromAssembly<T>(string interFaceName)
        {
            List<T> list = new List<T>();

            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsClass && t.GetInterface(interFaceName, true) != null)
                {
                    T temp = (T)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, null);
                    if (temp != null)
                        list.Add(temp);
                }
            }
            return list.ToArray();
        }
        #endregion

        #region control
        public static void ControlRecusive(System.Windows.Forms.Control c, ProcessControl p)
        {
            p(c);
            if (c.Controls != null && c.Controls.Count >= 1 && p!=null)
            {
                foreach (System.Windows.Forms.Control cc in c.Controls)
                {
                    ControlRecusive(cc, p);
                }
            }
        }

        /// <summary>
        /// 自动设置子node选中
        /// </summary>
        /// <param name="node"></param>
        public static void SetChildNodeChecked(System.Windows.Forms.TreeNode node,bool check)
        {
            if (node.Nodes != null && node.Nodes.Count > 0)
            {
                foreach (System.Windows.Forms.TreeNode n in node.Nodes)
                {
                    n.Checked = check;
                    SetChildNodeChecked(n, check);
                }
            }
        }
        #endregion 



        public static string GetRealName(string no, int level)
        {
            string facilityNo = FacilityName.GetFacilityNameByNO(no);
            string zhuantiNo = ZhuanTiManager.GetSubjectNameByNO(no);
            string yaosuNo = YaoSuManager.GetElementNameByNO(no);
            string str = "";
            if (facilityNo != "" && level == 1)
            {
                str = facilityNo;
            }
            if (zhuantiNo != "" && level == 3)
                str = zhuantiNo;
            if (yaosuNo != "" && level == 2)
                str = yaosuNo;
            return str;
        }

        public static string GetRealNo(string name,int level)
        {
            string facilityNo = FacilityName.GetFacilityNO(name);
            string zhuantiNo = ZhuanTiManager.GetSubjectNO(name);
            string yaosuNo = YaoSuManager.GetYaoSuBianHao(name);
            string str = "";
            if (facilityNo != "" && level == 1)
            {
                str = facilityNo;
            }
            if (zhuantiNo != "" && level == 3)
                str = zhuantiNo;
            if (yaosuNo != "" && level == 2)
                str = yaosuNo;
            return str;
        }
        public static string GetRidOfIndexPrefix(string nodename)
        {
            int index = nodename.LastIndexOf('.');
            if (index != -1)
                return nodename.Remove(0, index + 1);
            return nodename;
        }
    }
}
