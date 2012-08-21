
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
            #region �ֶ� 
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
            #region ���캯������������ 
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
            #region ���� 
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
            #region �������� 
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
            #region ������� 
            /// &lt;summary> 
            /// ���ͼƬ 
            /// &lt;/summary> 
            /// &lt;param name="picName">&lt;/param> 
            public void AddPicture(string picName) 
            { 
                if (m_WordApp != null) 
                    m_WordApp.Selection.InlineShapes.AddPicture(picName, ref missing, ref missing, ref missing); 
            } 
            /// &lt;summary> 
            /// ����ҳü 
            /// &lt;/summary> 
            /// &lt;param name="text">&lt;/param> 
            /// &lt;param name="align">&lt;/param> 
            public void SetHeader(string text, WdParagraphAlignment align) 
            { 
                this.m_WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView; 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader; 
                this.m_WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(text); //�����ı� 
                this.m_WordApp.Selection.ParagraphFormat.Alignment = align;  //���ö��뷽ʽ 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // ����ҳü���� 
            } 
            /// &lt;summary> 
            /// ����ҳ�� 
            /// &lt;/summary> 
            /// &lt;param name="text">&lt;/param> 
            /// &lt;param name="align">&lt;/param> 
            public void SetFooter(string text, WdParagraphAlignment align) 
            { 
                this.m_WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView; 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryFooter; 
                this.m_WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(text); //�����ı� 
                this.m_WordApp.Selection.ParagraphFormat.Alignment = align;  //���ö��뷽ʽ 
                this.m_WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // ����ҳü���� 
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
            #region �ĵ��е��ı��Ͷ��� 
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

            #region �������滻�ĵ��е��ı� 
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
            /// �����滻
            /// </summary>
            /// <param name="dict">Wordģ���б���ֵ��ʵ��ֵһһ��Ӧ</param>
            public void ReplaceInBatch(Dictionary<string, string> dict)
            {
                foreach (KeyValuePair<string, string> kvp in dict)
                {
                    this.Replace(kvp.Key, kvp.Value);
                }
            }
 
            #endregion 

            #region ����ճ��
            /// <summary>
            /// ���Ƶ�ǰ
            /// </summary>
            public void Copy()
            {
                this.m_Selection.Copy();
            }
            /// <summary>
            /// ����ʽճ��
            /// </summary>
            public void PasteAndFormat()
            {
                this.m_Selection.PasteAndFormat(WdRecoveryType.wdPasteDefault);
            }
            #endregion ����ճ��
            #region �ĵ��е�Word���
            /// &lt;summary> 
            /// ���ĵ��в����� 
            /// &lt;/summary> 
            /// &lt;param name="startIndex">��ʼλ��&lt;/param> 
            /// &lt;param name="endIndex">����λ��&lt;/param> 
            /// &lt;param name="rowCount">����&lt;/param> 
            /// &lt;param name="columnCount">����&lt;/param> 
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
            //    newdoc.Tables[1].Cell(1, 1).Range.Text = "��Ʒ��Ŀ";
            //    newdoc.Tables[1].Cell(1, 2).Range.Text = "����";
            //    newdoc.Tables[1].Cell(1, 3).Range.Text = "�ֻ�";
            //    newdoc.Tables[1].Cell(2, 1).Range.Text = "����(kg)";
            //    newdoc.Tables[1].Cell(3, 1).Range.Text = "�۸�(Ԫ)";
            //    newdoc.Tables[1].Cell(4, 1).Range.Text = "��ͬ��Ϣ";
            //    newdoc.Tables[1].Cell(4, 2).Range.Text = "��ϢA";
            //    newdoc.Tables[1].Cell(4, 3).Range.Text = "��ϢB";
            //}

            /// &lt;summary> 
            /// ����� 
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
            /// ����� 
            /// &lt;/summary> 
            /// &lt;param name="table">&lt;/param> 
            /// &lt;returns>&lt;/returns> 
            public Column AppendColumn(Table table) 
            { 
                object column = table.Columns[1]; 
                return table.Columns.Add(ref column); 
            } 
            /// &lt;summary> 
            /// ���õ�Ԫ����ı��Ͷ��뷽ʽ 
            /// &lt;/summary> 
            /// &lt;param name="cell">��Ԫ��&lt;/param> 
            /// &lt;param name="text">�ı�&lt;/param> 
            /// &lt;param name="align">���뷽ʽ&lt;/param> 
            public void SetCellText(Cell cell, string text, WdParagraphAlignment align) 
            { 
                cell.Range.Text = text; 
                cell.Range.ParagraphFormat.Alignment = align; 
            } 
            #endregion 

            #region IDisposable ��Ա 
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

            #region ������
            /// <summary>
            /// ��ȡ���
            /// </summary>
            public void GetSelection()
            {
                this.m_Selection = m_WordApp.Selection; 
            }
            /// <summary>
            /// ��������Ƽ����ַ�
            /// </summary>
            /// <param name="intMoveCount">�ƶ��ַ���</param>
            public void MoveRightByChar(int intMoveCount)
            {
                object objMoveCount=intMoveCount;
                this.m_Selection.MoveRight(ref objUnitChar, ref objMoveCount, ref missing);
            }
            /// <summary>
            /// ��갴Word�ı�������
            /// </summary>
            /// <param name="intMoveCount"></param>
            public void MoveDownByLine(int intMoveCount)
            {
                object objMoveCount = intMoveCount;
                this.m_Selection.MoveDown(ref objUnitLine, ref objMoveCount, ref missing);
            }
            /// <summary>
            /// ��갴Word��������ƣ���ʼ�������MoveToTableRowLineEnd()�����ȶ�λ�ڱ����β��
            /// </summary>
            /// <param name="intRowCount">����Word�������</param>
            public void MoveDownByTableRow(int intRowCount)
            {
                for (int i = 0; i < intRowCount; i++)
                {
                    //this.MoveToTableRowLineEnd();
                    //this.MoveDownByLine(1);
                    object objParaCount = 1;
                    this.m_Selection.MoveDown(ref objUnitParagraph, ref objParaCount, ref missing);//Ctrl+����ϼ�
                    this.MoveToTableRowLineEnd();
                }
            }
            /// <summary>
            /// ��סshift����
            /// </summary>
            /// <param name="intLineCount">��������</param>
            public void MoveDownByShift(int intLineCount)
            {
                object objLineCount = intLineCount;
                this.m_Selection.MoveDown(ref objUnitLine, ref objLineCount, ref objExtendShift);
            }

            /// <summary>
            /// ���Ƶ�����
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
            /// ��������ı���ĩβ
            /// </summary>
            public void MoveToTextLineEnd()
            {
                this.m_Selection.EndKey(ref objUnitLine, ref missing);
            }
            /// <summary>
            /// �������Word���ǰ�����һ����Ԫ�����ݵ���ǰ��
            /// </summary>
            public void MoveToTableRowLastCellStart()
            {
                this.m_Selection.EndKey(ref objUnitRow, ref missing);
            }
            /// <summary>
            /// �������Word���ǰ�����һ����Ԫ�����ݵ������
            /// </summary>
            public void MoveToTableRowLastCellEnd()
            {
                this.MoveToTableRowLastCellStart();
                this.MoveToTextLineEnd();
            }
            /// <summary>
            /// �������Word���ǰ���ұ߿������
            /// </summary>
            public void MoveToTableRowLineEnd()
            {
                object objItemCount = 1;
                this.m_Selection.EndKey(ref objUnitRow, ref missing);//Alt+End
                //this.MoveRightByChar(1);
                //this.m_Selection.MoveDown(ref objUnitParagraph, ref objParaDownCount, ref missing);//Ctrl+��
                this.m_Selection.MoveRight(ref objUnitItem,ref objItemCount, ref missing);
            }
            /// <summary>
            /// �������Word���ǰ�е�һ����Ԫ�����ݵ���ǰ��
            /// </summary>
            public void MoveToTableRowFirstCellStart()
            {
                this.m_Selection.HomeKey(ref objUnitRow, ref missing);
            }

            /// <summary>
            /// �س�����
            /// </summary>
            public void AddNewParagraph()
            {
                this.m_Selection.TypeParagraph();
            }
            #endregion ������

            #region Word������
            /// <summary>
            /// ����հ���
            /// </summary>
            /// <param name="intRowCount">����</param>
            public void InsertEmptyRow(int intRowCount)
            {
                object objRowCount=intRowCount;
                m_Selection.InsertRows(ref objRowCount);
            }
            /// <summary>
            /// ���������
            /// </summary>
            /// <param name="dr">������</param>
            /// <param name="intColCount">����</param>
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
            /// ��Word���������·����ӱ�����
            /// </summary>
            /// <param name="intMoveDownLineCount">Ҫ���Ƶ���������ǰ���λ�õ��������У�</param>
            /// <param name="dtSource"></param>
            public void AddTableData(int intMoveDownLineCount,DataTable dtSource)
            {
                //this.m_Selection = this.m_WordApp.Selection;
                int intColCount=dtSource.Columns.Count;
                //this.MoveDownByLine(intMoveDownLineCount);//��������������������
                if (intMoveDownLineCount > 0)
                {
                    this.MoveDownByTableRow(intMoveDownLineCount);
                }
                this.MoveToTableRowLineEnd();//�����������ұ߿��Ҳ�
                foreach (DataRow dr in dtSource.Rows)
                {
                    this.InsertEmptyRow(1);
                    this.FillRowData(dr, intColCount);
                }
            }
            #endregion Word������


            //public void wordview()
            //{
            //    if (MessageBox.Show("�����ɹ����Ƿ�鿴�����ɵ�Excel�ļ���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
 
