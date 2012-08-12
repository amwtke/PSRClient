using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace APP
{
    class ExcelClass
    {
        /// <summary>
        /// 获取单元格导出值
        /// </summary>
        /// <param name="strColName">列名</param>
        /// <param name="intRowIndex">行索引</param>
        /// <param name="dgv">要导出的dgv</param>
        /// <returns>单元格导出值</returns>
        public string GetCellExportValue(string strColName, int intRowIndex, DataGridView dgv)
        {
            Type colType = (Type)dgv.Columns[strColName].GetType();
            DataGridViewRow dgvr = dgv.Rows[intRowIndex];
            object objCellValue = dgvr.Cells[strColName].Value;
            //if (colType == typeof(DataGridViewTextBoxColumn))
            //{
            //    return objCellValue.ToString();
            //}
            if (colType == typeof(DataGridViewTextBoxColumn) || colType == typeof(DataGridViewComboBoxColumn))
            {
                return dgvr.Cells[strColName].FormattedValue.ToString();
            }
            if (colType == typeof(DataGridViewCheckBoxColumn))
            {
                if (Convert.ToBoolean(objCellValue))
                {
                    return "是";
                }
                else
                {
                    return "否";
                }
            }
            return objCellValue.ToString();
        }
        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="dgv">要导出的DataGridView</param>
        /// <param name="strExcelName">导出的Excel名称</param>
        /// <param name="blSelectedRows">是否仅导出所选记录</param>
        public void ExportToExcel(DataGridView dgv, string strExcelName, bool blSelectedRows)
        {
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Microsoft.Office.Interop.Excel.Workbook excelBook = null;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = null;
            Microsoft.Office.Interop.Excel.Range excelRange = null;
            object[,] objData = null;


            if (!blSelectedRows)
            {
                if (dgv.Rows.Count == 0 || (dgv.Rows.Count == 1 && dgv.Rows[0].IsNewRow))
                {
                    MessageBox.Show("没有可以导出的内容");
                    return;
                }
                objData = new object[dgv.Rows.Count + 1, dgv.ColumnCount];
            }
            else
            {
                if ((dgv.SelectedRows.Count == 0 && (dgv.CurrentRow == null || dgv.CurrentRow.IsNewRow)) || (dgv.SelectedRows.Count == 1 && dgv.SelectedRows[0].IsNewRow))
                {
                    MessageBox.Show("没有可以导出的内容");
                    return;
                }
                else if (dgv.SelectedRows.Count > 0)
                {
                    objData = new object[dgv.SelectedRows.Count + 1, dgv.ColumnCount];
                }
                else if (dgv.SelectedRows.Count == 0 && dgv.CurrentRow != null)
                {
                    objData = new object[2, dgv.ColumnCount];
                }
            }
            SaveFileDialog saveExcelDlg = new SaveFileDialog();
            saveExcelDlg.Filter = "Excel files (*.xls)|*.xls";
            saveExcelDlg.RestoreDirectory = true;
            saveExcelDlg.FileName = strExcelName;
            saveExcelDlg.Title = "导出到Excel";
            string strExportPath = "";//导出路径
            if (saveExcelDlg.ShowDialog() == DialogResult.OK)
            {
                strExportPath = saveExcelDlg.FileName;
                if (File.Exists(strExportPath))
                {
                    File.Delete(strExportPath);
                }
            }
            else
            {
                return;
            }
            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelBook = excelApp.Workbooks.Add(missing);
                excelSheet = excelBook.Worksheets.Add(missing, missing, 1, missing) as Microsoft.Office.Interop.Excel.Worksheet;
                excelSheet.Name = strExcelName;

                int intExcelColIndex = 0;
                for (int k = 0; k < dgv.Columns.Count; k++)//获取列标题
                {
                    if (!dgv.Columns[k].Visible)
                    {
                        continue;
                    }
                    intExcelColIndex++;
                    objData[0, intExcelColIndex - 1] = dgv.Columns[k].HeaderText;
                }
                int intExcelRowIndex = 1;//Excel行号
                if (!blSelectedRows)//导出全部
                {
                    excelRange = excelSheet.get_Range(excelApp.Cells[1, 1], excelApp.Cells[dgv.Rows.Count + 1, dgv.ColumnCount]);

                    for (int i = 0; i < dgv.Rows.Count; i++)//获取列内容
                    {
                        if (dgv.Rows[i].IsNewRow)
                        {
                            continue;
                        }
                        intExcelRowIndex++;
                        intExcelColIndex = 0;
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (!dgv.Columns[j].Visible)
                            {
                                continue;
                            }
                            intExcelColIndex++;
                            string strExportValue = GetCellExportValue(dgv.Columns[j].Name, i, dgv);
                            if (dgv.Rows[i].Cells[j].ValueType == typeof(string) || dgv.Rows[i].Cells[j].ValueType == typeof(DateTime))
                            {
                                objData[intExcelRowIndex - 1, intExcelColIndex - 1] = "'" + strExportValue;
                            }
                            else
                            {
                                objData[intExcelRowIndex - 1, intExcelColIndex - 1] = strExportValue;
                            }
                        }
                    }
                }
                else
                {
                    if (dgv.SelectedRows.Count == 0)//导出当前行
                    {
                        excelRange = excelSheet.get_Range(excelApp.Cells[1, 1], excelApp.Cells[2, dgv.ColumnCount]);

                        intExcelRowIndex++;
                        intExcelColIndex = 0;
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (!dgv.Columns[j].Visible)
                            {
                                continue;
                            }
                            intExcelColIndex++;
                            string strExportValue = this.GetCellExportValue(dgv.Columns[j].Name, dgv.CurrentRow.Index, dgv);
                            if (dgv.CurrentRow.Cells[j].ValueType == typeof(string) || dgv.CurrentRow.Cells[j].ValueType == typeof(DateTime))
                            {
                                objData[1, intExcelColIndex - 1] = "'" + strExportValue;
                            }
                            else
                            {
                                objData[1, intExcelColIndex - 1] = strExportValue;
                            }
                        }
                    }
                    else//导出当前所选
                    {
                        excelRange = excelSheet.get_Range(excelApp.Cells[1, 1], excelApp.Cells[dgv.SelectedRows.Count + 1, dgv.ColumnCount]);

                        for (int i = dgv.SelectedRows.Count - 1; i >= 0; i--)//获取列内容
                        {
                            if (dgv.SelectedRows[i].IsNewRow)
                            {
                                continue;
                            }
                            intExcelRowIndex++;
                            intExcelColIndex = 0;
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                if (!dgv.Columns[j].Visible)
                                {
                                    continue;
                                }
                                intExcelColIndex++;
                                string strExportValue = this.GetCellExportValue(dgv.Columns[j].Name, dgv.SelectedRows[i].Index, dgv);
                                if (dgv.Rows[i].Cells[j].ValueType == typeof(string) || dgv.Rows[i].Cells[j].ValueType == typeof(DateTime))
                                {
                                    objData[intExcelRowIndex - 1, intExcelColIndex - 1] = "'" + strExportValue;
                                }
                                else
                                {
                                    objData[intExcelRowIndex - 1, intExcelColIndex - 1] = strExportValue;
                                }
                            }
                        }
                    }
                }
                excelRange.Value2 = objData;
                excelSheet.Columns.EntireColumn.AutoFit();

                excelBook.SaveAs(strExportPath, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, missing, missing, missing, missing, missing);
                if (MessageBox.Show("导出成功，是否查看已生成的Excel文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    excelApp.Visible = true;
                }
                else
                {
                    excelApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);//释放COM
                excelApp = null;
                GC.Collect();
            }

        }
    }
}
