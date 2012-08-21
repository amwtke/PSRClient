
using System; 
using System.Collections.Generic; 
using System.Text; 
using Microsoft.Office.Interop.Word; 
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
namespace ExportToWord 
    { 
        public class WordClass : IDisposable 
        { 
            #region 字段 
            private _Application m_WordApp = null; 
            private _Document m_Document = null;
            Selection m_Selection = null;
            private object missing = System.Reflection.Missing.Value;
            object objUnitChar = WdUnits.wdCharacter;
            object objUnitLine = WdUnits.wdLine;
            object objUnitRow = WdUnits.wdRow;
            object objUnitParagraph = WdUnits.wdParagraph;
            object objUnitItem = WdUnits.wdItem;
            object objCollapseStart = WdCollapseDirection.wdCollapseStart;
            object objExtendShift = WdMovementType.wdExtend;

            #endregion 
            #region 构造函数与析构函数 
            public WordClass() 
            { 
                m_WordApp = new ApplicationClass();
                m_Selection = m_WordApp.Selection;
            } 

            ~WordClass() 
            { 
                try 
                { 
                    if (m_WordApp != null) 
                        m_WordApp.Quit(ref missing, ref missing, ref missing); 
                } 
                catch (Exception ex) 
                { 
                    Debug.Write(ex.ToString()); 
                } 
            } 
            #endregion 
            #region 属性 
            public _Document Document 
            { 
                get 
                { 
                    return m_Document; 
                } 
            } 
            public _Application WordApplication 
            { 
                get 
                { 
                    return m_WordApp; 
                } 
            } 
            public int WordCount 
            { 
                get 
                { 
                    if (m_Document != null) 
                    { 
                        Range rng = m_Document.Content; 
                        rng.Select(); 
                        return m_Document.Characters.Count; 
                    } 
                    else 
                        return -1; 
                } 
            } 
            public object Missing 
            { 
                get 
                { 
                    return missing; 
                } 
            } 
            #endregion 
            #region 基本任务 
            #region CreateDocument 
            public void CreateDocument(string template) 
            { 
                object obj_template = template; 
                if (template.Length == 0) obj_template = missing; 
                m_Document = m_WordApp.Documents.Add(ref obj_template, ref missing, ref missing, ref missing); 
            } 
            public void CreateDocument() 
            { 
                this.CreateDocument(""); 
            } 
            #endregion 
            #region OpenDocument 
            public void OpenDocument(string fileName, bool readOnly) 
            { 
                object obj_FileName = fileName; 
                object obj_ReadOnly = readOnly; 
                m_Document = m_WordApp.Documents.Open(ref obj_FileName,ref missing, ref obj_ReadOnly, ref missing, 
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, 
                    ref missing, ref missing, ref missing, ref missing); 
            } 
            public void OpenDocument(string fileName) 
            { 
                this.OpenDocument(fileName, false); 
            } 
            #endregion 
            #region Save & SaveAs 
            public void Save() 
            { 
                if (m_Document != null) 
                    m_Document.Save(); 
            } 
            public void SaveAs(string fileName) 
            { 
                object obj_FileName = fileName; 
                if (m_Document != null) 
                {
                    //if (System.IO.File.Exists(fileName))
                    //{
                    //    m_Document.Save();
                    //    return;
                    //}
                    m_Document.SaveAs(ref obj_FileName, ref missing, ref missing, ref missing, ref missing, 
                        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, 
                        ref missing, ref missing, ref missing, ref missing); 
                } 
            } 
            #endregion 
            #region Close 
            public void Close(bool isSaveChanges) 
            { 
                object saveChanges = WdSaveOptions.wdDoNotSaveChanges; 
                if (isSaveChanges) 
                    saveChanges = WdSaveOptions.wdSaveChanges; 
                if (m_Document != null) 
                    m_Document.Close(ref saveChanges, ref missing, ref missing); 
            } 
            #endregion 
            #region 添加数据 
            /// &lt;summary> 
            /// 添加图片 
            /// &lt;/summary> 
            /// &lt;param name="picName">&lt;/param> 
            public void AddPicture(string picName) 
            { 
                if (m_WordApp != null) 
                    m_WordApp.Selection.InlineShapes.AddPicture(picName, ref missing, ref missing, ref missing); 
            } 
            /// &lt;summary> 
            /// 插入页眉 
            /// &lt;/summary> 
            /// &lt;param name="text">&lt;/param> 
            /// &lt;param name="align">&lt;/param> 
            public void SetHeader(string text, WdParagraphAlignment align) 
            { 
                this.m_WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView; 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader; 
                this.m_WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(text); //插入文本 
                this.m_WordApp.Selection.ParagraphFormat.Alignment = align;  //设置对齐方式 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // 跳出页眉设置 
            } 
            /// &lt;summary> 
            /// 插入页脚 
            /// &lt;/summary> 
            /// &lt;param name="text">&lt;/param> 
            /// &lt;param name="align">&lt;/param> 
            public void SetFooter(string text, WdParagraphAlignment align) 
            { 
                this.m_WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView; 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryFooter; 
                this.m_WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(text); //插入文本 
                this.m_WordApp.Selection.ParagraphFormat.Alignment = align;  //设置对齐方式 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // 跳出页眉设置 
            } 
            #endregion 
            #region Print 
 
public void PrintOut() 
            { 
                object copies = "1"; 
                object pages = ""; 
                object range = WdPrintOutRange.wdPrintAllDocument; 
                object items = WdPrintOutItem.wdPrintDocumentContent; 
                object pageType = WdPrintOutPages.wdPrintAllPages; 
                object oTrue = true; 
                object oFalse = false; 
                this.m_Document.PrintOut( 
                    ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing, 
                    ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue, 
                    ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing); 
            } 
            public void PrintPreview() 
            { 
                if (m_Document != null) 
                    m_Document.PrintPreview(); 
            } 
            #endregion 
            public void Paste() 
            { 
                try 
                { 
                    if (m_Document != null) 
                    { 
                        m_Document.ActiveWindow.Selection.Paste(); 
                    } 
                } 
                catch (Exception ex) 
                { 
                    Debug.Write(ex.Message); 
                } 
            } 
            #endregion 
            #region 文档中的文本和对象 
            public void AppendText(string text) 
            { 
                Selection currentSelection = this.m_WordApp.Selection; 
                // Store the user's current Overtype selection 
                bool userOvertype = this.m_WordApp.Options.Overtype; 
                // Make sure Overtype is turned off. 
                if (this.m_WordApp.Options.Overtype) 
                { 
                    this.m_WordApp.Options.Overtype = false; 
                } 
                // Test to see if selection is an insertion point. 
                if (currentSelection.Type == WdSelectionType.wdSelectionIP) 
                { 
                    currentSelection.TypeText(text); 
                    currentSelection.TypeParagraph(); 
                } 
                else 
                    if (currentSelection.Type == WdSelectionType.wdSelectionNormal) 
                    { 
                        // Move to start of selection. 
                        if (this.m_WordApp.Options.ReplaceSelection) 
                        { 
                            object direction = WdCollapseDirection.wdCollapseStart; 
                            currentSelection.Collapse(ref direction); 
                        } 
                        currentSelection.TypeText(text); 
                        currentSelection.TypeParagraph(); 
                    } 
                    else 
                    { 
                        // Do nothing. 
                    } 
                // Restore the user's Overtype selection 
                this.m_WordApp.Options.Overtype = userOvertype; 
            } 
            #endregion 

            #region 搜索和替换文档中的文本 
            public void Replace(string oriText, string replaceText) 
            {                 
                object replaceAll = WdReplace.wdReplaceAll;

                this.m_WordApp.Selection.Find.ClearFormatting(); 
                this.m_WordApp.Selection.Find.Text = oriText; 
                this.m_WordApp.Selection.Find.Replacement.ClearFormatting(); 
                this.m_WordApp.Selection.Find.Replacement.Text = replaceText;
                this.m_WordApp.Selection.Find.Wrap = WdFindWrap.wdFindContinue;
                this.m_WordApp.Selection.Find.Execute( 
                    ref missing, ref missing, ref missing, ref missing, ref missing, 
                    ref missing, ref missing, ref missing, ref missing, ref missing, 
                    ref replaceAll, ref missing, ref missing, ref missing, ref missing); 
            }
            /// <summary>
            /// 批量替换
            /// </summary>
            /// <param name="dict">Word模板中变量值与实际值一一对应</param>
            public void ReplaceInBatch(Dictionary<string, string> dict)
            {
                foreach (KeyValuePair<string, string> kvp in dict)
                {
                    this.Replace(kvp.Key, kvp.Value);
                }
            }
 
            #endregion 

            #region 复制粘贴
            /// <summary>
            /// 复制当前
            /// </summary>
            public void Copy()
            {
                this.m_Selection.Copy();
            }
            /// <summary>
            /// 带格式粘贴
            /// </summary>
            public void PasteAndFormat()
            {
                this.m_Selection.PasteAndFormat(WdRecoveryType.wdPasteDefault);
            }
            #endregion 复制粘贴
            #region 文档中的Word表格
            /// &lt;summary> 
            /// 向文档中插入表格 
            /// &lt;/summary> 
            /// &lt;param name="startIndex">开始位置&lt;/param> 
            /// &lt;param name="endIndex">结束位置&lt;/param> 
            /// &lt;param name="rowCount">行数&lt;/param> 
            /// &lt;param name="columnCount">列数&lt;/param> 
            /// &lt;returns>&lt;/returns> 
            public Table AppendTable(int startIndex, int endIndex, int rowCount, int columnCount) 
            { 
                object start = startIndex; 
                object end = endIndex; 
                Range tableLocation = this.m_Document.Range(ref start, ref end); 
                return this.m_Document.Tables.Add(tableLocation, rowCount, columnCount, ref missing, ref missing); 
            }
            //public void AddTable()
            //{
            //    Document newdoc = this.m_WordApp.ActiveDocument;
            //    Table table1 = newdoc.Tables.Add(this.m_WordApp.Selection.Range, 4, 3, ref missing, ref missing);
            //    newdoc.Tables[1].Cell(1, 1).Range.Text = "产品项目";
            //    newdoc.Tables[1].Cell(1, 2).Range.Text = "电脑";
            //    newdoc.Tables[1].Cell(1, 3).Range.Text = "手机";
            //    newdoc.Tables[1].Cell(2, 1).Range.Text = "重量(kg)";
            //    newdoc.Tables[1].Cell(3, 1).Range.Text = "价格(元)";
            //    newdoc.Tables[1].Cell(4, 1).Range.Text = "共同信息";
            //    newdoc.Tables[1].Cell(4, 2).Range.Text = "信息A";
            //    newdoc.Tables[1].Cell(4, 3).Range.Text = "信息B";
            //}

            /// &lt;summary> 
            /// 添加行 
            /// &lt;/summary> 
            /// &lt;param name="table">&lt;/param> 
            /// &lt;returns>&lt;/returns> 
            public Row AppendRow(Table table) 
            {
                object row = table.Rows[1];
                return table.Rows.Add(ref row); 
            }
            //public void AppendRow()
            //{
            //    Selection selection = this.m_WordApp.Selection;
            //    object objRows = 1;
                
            //    object objMoveCount=14;
                
            //    this.m_WordApp.Selection.MoveDown(ref objUnitLine,ref objMoveCount,ref missing);
            //    //this.AppendTable(0, 1, 3, 3);
            //    //this.m_WordApp.ActiveDocument.Tables.Add(m_WordApp.Selection.Range,15,3,ref missing,ref missing);
            //    //this.m_WordApp.Selection.Tables[1].Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            //    //this.m_WordApp.Selection.Tables[1].Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            //    //this.m_WordApp.Selection.Tables[1].Columns[1].SetWidth((float)100.0,WdRulerStyle.wdAdjustFirstColumn);
            //    //this.m_WordApp.Selection.Tables[1].ApplyStyleFirstColumn = true;

            //    selection.EndKey(ref objUnitRow, ref missing);
            //    selection.EndKey(ref objUnitLine, ref missing);
            //    selection.MoveRight(ref objUnitChar, ref missing, ref missing);
            //    this.m_WordApp.Selection.InsertRows(ref objRows);

            //    this.m_WordApp.Selection.Collapse(ref objCollapseStart);
            //    this.m_WordApp.Selection.TypeText("11111111");

            //    this.m_WordApp.Selection.MoveRight(ref objUnitChar, ref missing, ref missing);
            //    this.m_WordApp.Selection.TypeText("2222");
            //    this.m_WordApp.Selection.MoveRight(ref objUnitChar, ref missing, ref missing);
            //    this.m_WordApp.Selection.TypeText("3333");


            //    selection.MoveRight(ref objUnitChar, ref missing, ref missing);

            //    this.m_WordApp.Selection.InsertRows(ref objRows);
            //    this.m_WordApp.Selection.Collapse(ref objCollapseStart);

            //    this.m_WordApp.Selection.TypeText("4444");               
            //}

            /// &lt;summary> 
            /// 添加列 
            /// &lt;/summary> 
            /// &lt;param name="table">&lt;/param> 
            /// &lt;returns>&lt;/returns> 
            public Column AppendColumn(Table table) 
            { 
                object column = table.Columns[1]; 
                return table.Columns.Add(ref column); 
            } 
            /// &lt;summary> 
            /// 设置单元格的文本和对齐方式 
            /// &lt;/summary> 
            /// &lt;param name="cell">单元格&lt;/param> 
            /// &lt;param name="text">文本&lt;/param> 
            /// &lt;param name="align">对齐方式&lt;/param> 
            public void SetCellText(Cell cell, string text, WdParagraphAlignment align) 
            { 
                cell.Range.Text = text; 
                cell.Range.ParagraphFormat.Alignment = align; 
            } 
            #endregion 

            #region IDisposable 成员 
            public void Dispose() 
            { 
                try 
                { 
                    if (m_WordApp != null) 
                        m_WordApp.Quit(ref missing, ref missing, ref missing); 
                } 
                catch (Exception ex) 
                { 
                    Debug.Write(ex.ToString()); 
                } 
            } 
            #endregion 

            #region 光标操作
            /// <summary>
            /// 获取光标
            /// </summary>
            public void GetSelection()
            {
                this.m_Selection = m_WordApp.Selection; 
            }
            /// <summary>
            /// 光标往后移几个字符
            /// </summary>
            /// <param name="intMoveCount">移动字符数</param>
            public void MoveRightByChar(int intMoveCount)
            {
                object objMoveCount=intMoveCount;
                this.m_Selection.MoveRight(ref objUnitChar, ref objMoveCount, ref missing);
            }
            /// <summary>
            /// 光标按Word文本行下移
            /// </summary>
            /// <param name="intMoveCount"></param>
            public void MoveDownByLine(int intMoveCount)
            {
                object objMoveCount = intMoveCount;
                this.m_Selection.MoveDown(ref objUnitLine, ref objMoveCount, ref missing);
            }
            /// <summary>
            /// 光标按Word表格行下移（初始光标须用MoveToTableRowLineEnd()方法先定位在表格行尾）
            /// </summary>
            /// <param name="intRowCount">下移Word表格行数</param>
            public void MoveDownByTableRow(int intRowCount)
            {
                for (int i = 0; i < intRowCount; i++)
                {
                    //this.MoveToTableRowLineEnd();
                    //this.MoveDownByLine(1);
                    object objParaCount = 1;
                    this.m_Selection.MoveDown(ref objUnitParagraph, ref objParaCount, ref missing);//Ctrl+↓组合键
                    this.MoveToTableRowLineEnd();
                }
            }
            /// <summary>
            /// 按住shift下移
            /// </summary>
            /// <param name="intLineCount">下移行数</param>
            public void MoveDownByShift(int intLineCount)
            {
                object objLineCount = intLineCount;
                this.m_Selection.MoveDown(ref objUnitLine, ref objLineCount, ref objExtendShift);
            }

            /// <summary>
            /// 下移到段首
            /// </summary>
            /// <param name="intParaCount"></param>
            public void MoveDownToParaStart(int intParaCount)
            {
                object objParaCount = intParaCount;
                this.m_Selection.MoveDown(ref objUnitParagraph, ref objParaCount,ref missing);
            }

            public void MoveUpByLine(int intLineCount)
            {
                object objLineCount = intLineCount;
                this.m_Selection.MoveUp(ref objUnitLine, ref objLineCount, ref missing);
            }

            /// <summary>
            /// 光标移至文本行末尾
            /// </summary>
            public void MoveToTextLineEnd()
            {
                this.m_Selection.EndKey(ref objUnitLine, ref missing);
            }
            /// <summary>
            /// 光标移至Word表格当前行最后一个单元格内容的最前面
            /// </summary>
            public void MoveToTableRowLastCellStart()
            {
                this.m_Selection.EndKey(ref objUnitRow, ref missing);
            }
            /// <summary>
            /// 光标移至Word表格当前行最后一个单元格内容的最后面
            /// </summary>
            public void MoveToTableRowLastCellEnd()
            {
                this.MoveToTableRowLastCellStart();
                this.MoveToTextLineEnd();
            }
            /// <summary>
            /// 光标移至Word表格当前行右边框的外面
            /// </summary>
            public void MoveToTableRowLineEnd()
            {
                object objItemCount = 1;
                this.m_Selection.EndKey(ref objUnitRow, ref missing);//Alt+End
                //this.MoveRightByChar(1);
                //this.m_Selection.MoveDown(ref objUnitParagraph, ref objParaDownCount, ref missing);//Ctrl+↓
                this.m_Selection.MoveRight(ref objUnitItem,ref objItemCount, ref missing);
            }
            /// <summary>
            /// 光标移至Word表格当前行第一个单元格内容的最前面
            /// </summary>
            public void MoveToTableRowFirstCellStart()
            {
                this.m_Selection.HomeKey(ref objUnitRow, ref missing);
            }

            /// <summary>
            /// 回车换行
            /// </summary>
            public void AddNewParagraph()
            {
                this.m_Selection.TypeParagraph();
            }
            #endregion 光标操作

            #region Word表格操作
            /// <summary>
            /// 插入空白行
            /// </summary>
            /// <param name="intRowCount">行数</param>
            public void InsertEmptyRow(int intRowCount)
            {
                object objRowCount=intRowCount;
                m_Selection.InsertRows(ref objRowCount);
            }
            /// <summary>
            /// 填充行内容
            /// </summary>
            /// <param name="dr">数据行</param>
            /// <param name="intColCount">列数</param>
            public void FillRowData(DataRow dr,int intColCount)
            {
                m_Selection.Collapse(ref objCollapseStart);
                for (int i = 0; i < intColCount; i++)
                {
                    string strCellValue=dr[i].ToString();
                    m_Selection.TypeText(strCellValue);
                    this.MoveRightByChar(1);
                }
            }
            /// <summary>
            /// 在Word表格标题行下方增加表数据
            /// </summary>
            /// <param name="intMoveDownLineCount">要下移的行数（当前光标位置到表格标题行）</param>
            /// <param name="dtSource"></param>
            public void AddTableData(int intMoveDownLineCount,DataTable dtSource)
            {
                //this.m_Selection = this.m_WordApp.Selection;
                int intColCount=dtSource.Columns.Count;
                //this.MoveDownByLine(intMoveDownLineCount);//向下移至表格标题所在行
                if (intMoveDownLineCount > 0)
                {
                    this.MoveDownByTableRow(intMoveDownLineCount);
                }
                this.MoveToTableRowLineEnd();//移至标题行右边框右侧
                foreach (DataRow dr in dtSource.Rows)
                {
                    this.InsertEmptyRow(1);
                    this.FillRowData(dr, intColCount);
                }
            }
            #endregion Word表格操作


            //public void wordview()
            //{
            //    if (MessageBox.Show("导出成功，是否查看已生成的Excel文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    {
            //        m_WordApp.Visible = true;
            //    }
            //    else
            //    {
            //        m_WordApp.Quit();
            //    }
            //}
        } 
    } 
 
