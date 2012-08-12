using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;

namespace APP
{
    public partial class BaseDataForm : Form
    {
        static IObjectContainer _db = null;
        List<Facility> _facilitList = new List<Facility>();
        List<YaoSu> _yaosuList = new List<YaoSu>();
        List<ZhuanTi> _zhuantiList = new List<ZhuanTi>();
        
        public BaseDataForm()
        {
            try
            {
                _db = DBHelper.InitDB4O(typeof(Facility));
                
                InitializeComponent();

                dataGridView_zhuanti.DataError += delegate(object sender, DataGridViewDataErrorEventArgs e) { };

                Facility[] _fs = FacilityHelper.GetAll();
                if(_fs!=null && _fs.Length>0)
                    _facilitList.AddRange(_fs);
                else
                {
                    Facility _facility = new Facility();
                    _facility.FacilityName="";
                    _facility.ID= "";
                    _facilitList.Add(_facility);
                }

                YaoSu[] _ys = YaoSuHelper.GetAll();
                if(_ys!=null && _ys.Length>0)
                    _yaosuList.AddRange(_ys);
                else
                {
                    YaoSu yao = new YaoSu();
                    yao.ID = "";
                    yao.YaoSuName = "";
                    _yaosuList.Add(yao);
                }



                YaoSu[] yaosus = YaoSuHelper.GetAll();
                if (yaosus != null && yaosus.Length > 0)
                {
                    List<string> _yss = new List<string>();
                    foreach (YaoSu y in yaosus)
                    {
                        _yss.Add(y.YaoSuName);
                    }
                    _yss.Add("");
                    ((DataGridViewComboBoxColumn)dataGridView_zhuanti.Columns[1]).DataSource = _yss;
                }
                ZhuanTi[] _zs = ZhuanTiHelper.GetAll();
                if(_zs!=null && _zs.Length>0)
                    _zhuantiList.AddRange(_zs);
                else
                {
                    ZhuanTi zhuan = new ZhuanTi();
                    zhuan.ID = "";
                    zhuan.YaosuName = "";
                    zhuan.ZhuanTiName = "";
                    _zhuantiList.Add(zhuan);
                }
                dataGridView_facility.DataSource = _facilitList;
                dataGridView_yaosu.DataSource = _yaosuList;
                dataGridView_zhuanti.DataSource = _zhuantiList;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        void updateallgrid()
        {
            if (tabControl.SelectedTab == tabPage_facility)
            {
                _facilitList.Clear();
                Facility[] _fs = FacilityHelper.GetAll();
                if (_fs != null && _fs.Length > 0)
                    _facilitList.AddRange(_fs);
                else
                {
                    Facility _facility = new Facility();
                    _facility.FacilityName = "";
                    _facility.ID = "";
                    _facilitList.Add(_facility);
                }
                dataGridView_facility.DataSource = null;
                dataGridView_facility.DataSource = _facilitList;
                dataGridView_facility.Refresh();
            }

            if (tabControl.SelectedTab == tabPage_yaosu)
            {
                _yaosuList.Clear();

                YaoSu[] _ys = YaoSuHelper.GetAll();
                if (_ys != null && _ys.Length > 0)
                    _yaosuList.AddRange(_ys);
                else
                {
                    YaoSu yao = new YaoSu();
                    yao.ID = "";
                    yao.YaoSuName = "";
                    _yaosuList.Add(yao);
                }
                dataGridView_yaosu.DataSource = null;
                dataGridView_yaosu.DataSource = _yaosuList;
                dataGridView_yaosu.Refresh();
            }

            if (tabControl.SelectedTab == tabPage_zhuanti)
            {

                YaoSu[] yaosus = YaoSuHelper.GetAll();

                if (yaosus != null && yaosus.Length > 0)
                {
                    List<string> _ys = new List<string>();
                    foreach (YaoSu y in yaosus)
                    {
                        _ys.Add(y.YaoSuName);
                    }
                    _ys.Add("");
                    ((DataGridViewComboBoxColumn)dataGridView_zhuanti.Columns[1]).DataSource = _ys;
                }


                _zhuantiList.Clear();
                ZhuanTi[] _zs = ZhuanTiHelper.GetAll();
                if (_zs != null && _zs.Length > 0)
                    _zhuantiList.AddRange(_zs);
                else
                {

                    ZhuanTi zhuan = new ZhuanTi();
                    zhuan.ID = "";
                    zhuan.YaosuName = "";
                    zhuan.ZhuanTiName = "";
                    _zhuantiList.Add(zhuan);
                }
                dataGridView_zhuanti.DataSource = null;
                dataGridView_zhuanti.DataSource = _zhuantiList;
                dataGridView_zhuanti.Refresh();
            }
        }

        private void tabControl__SelectedIndexChanged(object sender, EventArgs e)
        {
            updateallgrid();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView_facility.Rows)
            {
                if (r.Cells[0].Value !=null && !string.IsNullOrEmpty(r.Cells[0].Value.ToString()))
                {
                    Facility _f = new Facility();
                    _f.ID = r.Cells[0].Value.ToString();
                    if (r.Cells[1].Value != null)
                        _f.FacilityName = r.Cells[1].Value.ToString();
                    else
                        _f.FacilityName = "";
                    FacilityHelper.AddAndUpdateFacility(_f);
                }
            }

            foreach (DataGridViewRow r in dataGridView_yaosu.Rows)
            {
                if (r.Cells[0].Value != null && !string.IsNullOrEmpty(r.Cells[0].Value.ToString()))
                {
                    YaoSu _f = new YaoSu();
                    _f.ID = r.Cells[0].Value.ToString();
                    if (r.Cells[1].Value != null)
                        _f.YaoSuName = r.Cells[1].Value.ToString();
                    else
                        _f.YaoSuName = "";
                    YaoSuHelper.AddAndUpdateYaoSu(_f);
                }
            }

            foreach (DataGridViewRow r in dataGridView_zhuanti.Rows)
            {
                if (r.Cells[0].Value != null && !string.IsNullOrEmpty(r.Cells[0].Value.ToString()))
                {
                    ZhuanTi _f = new ZhuanTi();
                    _f.ID = r.Cells[0].Value.ToString();

                    if (r.Cells[2].Value!=null)
                        _f.ZhuanTiName = r.Cells[2].Value.ToString();
                    if (r.Cells[1].Value != null)
                        _f.YaosuName = r.Cells[1].Value.ToString();
                    ZhuanTiHelper.AddAndUpdateZhuanTi(_f);
                }
            }
            MessageBox.Show("保存完毕！");

            updateallgrid();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPage_facility)
            {
                Facility _f = new Facility();
                //_f.ID = "?";
                //_f.FacilityName = "?";
                _facilitList.Add(_f);
                dataGridView_facility.DataSource = null;
                dataGridView_facility.DataSource = _facilitList;
                dataGridView_facility.Refresh();
            }

            if (tabControl.SelectedTab == tabPage_yaosu)
            {
                YaoSu _f = new YaoSu();
                //_f.ID = "?";
                //_f.FacilityName = "?";
                _yaosuList.Add(_f);
                dataGridView_yaosu.DataSource = null;
                dataGridView_yaosu.DataSource = _yaosuList;
                dataGridView_yaosu.Refresh();
            }
            if (tabControl.SelectedTab == tabPage_zhuanti)
            {
                YaoSu[] yaosus = YaoSuHelper.GetAll();
                if (yaosus != null && yaosus.Length > 0)
                {
                    List<string> _ys = new List<string>();
                    foreach (YaoSu y in yaosus)
                    {
                        _ys.Add(y.YaoSuName);
                    }
                    _ys.Add("");
                    ((DataGridViewComboBoxColumn)dataGridView_zhuanti.Columns[1]).DataSource = _ys;
                }

                ZhuanTi _f = new ZhuanTi();
                //_f.ID = "?";
                _f.YaosuName = "";
                _zhuantiList.Add(_f);
                dataGridView_zhuanti.DataSource = null;
                dataGridView_zhuanti.DataSource = _zhuantiList;
                dataGridView_zhuanti.Refresh();
            }
        }

        string beforeChanged = "";
        private void dataGridView_yaosu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                object o = dataGridView_yaosu[e.ColumnIndex, e.RowIndex].Value;
                if (o != null)
                {
                    beforeChanged = o.ToString();
                }
            }
        }

        private void dataGridView_yaosu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (beforeChanged != "")
            {
                string id = dataGridView_yaosu[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
                string newValue = dataGridView_yaosu[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (beforeChanged != newValue)
                {
                    //先更新专题的下拉框
                    ZhuanTi example = new ZhuanTi();
                    example.YaosuName = beforeChanged;
                    ZhuanTi[] array = ZhuanTiHelper.FindZhuanti(example);
                    if (array != null && array.Length > 0)
                    {
                        foreach (ZhuanTi z in array)
                        {
                            z.YaosuName = newValue;
                        }
                    }

                    if(MessageBox.Show("请单击OK按钮提交要素更新!Cancel将取消专题菜单的更新！", "警告", MessageBoxButtons.OKCancel)==DialogResult.OK)
                        ZhuanTiHelper.AddAndUpdateZhuanTi(array);
                }
                beforeChanged = "";
                //button_ok.PerformClick();
                
            }
        }
    }
}
