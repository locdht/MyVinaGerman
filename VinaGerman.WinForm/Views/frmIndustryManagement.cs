using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity;
using VinaGerman.DataSource;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Utilities;
using System.Reflection;
using VinaGerman.WinForm.Utilities;

namespace VinaGerman.Views
{
    public partial class frmIndustryManagement : DevExpress.XtraEditors.XtraForm
    {
        #region declare paramater
        public BindingSource source = new BindingSource();
        public List<IndustryEntity> listDeleteDK;
        #endregion
        public frmIndustryManagement()
        {
            InitializeComponent();
            listDeleteDK = new List<IndustryEntity>();
        }

        #region functions
        private void LoadData()
        {
            List<IndustryEntity> list = Factory.Resolve<IBaseDataDS>().SearchIndustry(new IndustrySearchEntity()
            {
                SearchText = ""
            });
            if (list != null && list.Count > 0)
            {
                source.DataSource = list;
                GridIndustry.DataSource = source;
            }
            else
            {
                List<IndustryEntity> lst = new List<IndustryEntity>();
                IndustryEntity it = new IndustryEntity();
                it.Description = "";
                lst.Add(it);
                source.DataSource = lst;
                GridIndustry.DataSource = source;
            }
        }

        public void DeleteList()
        {
            if (listDeleteDK != null && listDeleteDK.Count > 0)
            {
                foreach (IndustryEntity i in listDeleteDK)
                {
                    try
                    {
                        if (i.IndustryId > 0)
                            Factory.Resolve<IBaseDataDS>().DeleteIndustry(i);
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
                    }
                }
                listDeleteDK.Clear();
            }
        }

        private void RowDeleted()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int index = -1;
                    index = this.gvIndustry.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridIndustry.DataSource;
                        List<IndustryEntity> list = (List<IndustryEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            IndustryEntity a = (IndustryEntity)list[index];
                            listDeleteDK.Add(a);
                        }
                        gvIndustry.DeleteRow(index);
                        gvIndustry.UpdateCurrentRow();
                    }
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(this, System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
            }
        }

        private void CopyRow()
        {
            try
            {
                List<IndustryEntity> lst = (List<IndustryEntity>)source.DataSource;
                int index = -1;
                index = this.gvIndustry.FocusedRowHandle;
                IndustryEntity b = (IndustryEntity)gvIndustry.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridIndustry.DataSource;
                    List<IndustryEntity> list = (List<IndustryEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        IndustryEntity a = new IndustryEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.IndustryId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridIndustry.DataSource = source;
                    gvIndustry.RefreshData();
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(this, System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.F3):
                    this.RowDeleted();
                    break;
                case (Keys.F2):
                    this.CopyRow();
                    break;

            };
            // return the key to the base class if not used.
            return base.ProcessCmdKey(ref msg, keyData);
        }


        #endregion

        private void frmIndustryManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                gvIndustry.MoveNext();
                gvIndustry.UpdateCurrentRow();
                source = (BindingSource)GridIndustry.DataSource;
                if (source.DataSource != null && ((List<IndustryEntity>)source.DataSource).Count > 0)
                {
                    foreach (IndustryEntity dr in source)
                    {
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateIndustry(dr);
                    }
                }
                DeleteList();
                LoadData();
                XtraMessageBox.Show("Lưu thành công ", "Thông báo");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lưu thất bại ", "Thông báo");
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}