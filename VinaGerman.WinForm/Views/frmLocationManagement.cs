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
using VinaGerman.Entity;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.DataSource;
using System.Reflection;
using VinaGerman.Utilities;
using VinaGerman.WinForm.Utilities;
using DevExpress.XtraSplashScreen;

namespace VinaGerman.Views
{
    public partial class frmLocationManagement : DevExpress.XtraEditors.XtraForm
    {
        #region declare paramater
        public BindingSource source = new BindingSource();
        public List<VinaGerman.Entity.BusinessEntity.LocationEntity> listDeleteDK;
        #endregion

        public frmLocationManagement()
        {
            InitializeComponent();
            listDeleteDK = new List<VinaGerman.Entity.BusinessEntity.LocationEntity>();
        }

        #region functions
        private void LoadData()
        {
            List<VinaGerman.Entity.BusinessEntity.LocationEntity> list = Factory.Resolve<ICompanyDS>().SearchLocation(new LocationSearchEntity()
            {
                SearchText = ""
            });
            if (list != null && list.Count > 0)
            {
                source.DataSource = list;
                GridLocation.DataSource = source;
            }
            else
            {
                List<VinaGerman.Entity.BusinessEntity.LocationEntity> lst = new List<VinaGerman.Entity.BusinessEntity.LocationEntity>();
                VinaGerman.Entity.BusinessEntity.LocationEntity it = new VinaGerman.Entity.BusinessEntity.LocationEntity();
                it.Description = "";
                lst.Add(it);
                source.DataSource = lst;
                GridLocation.DataSource = source;
            }
        }

        public void DeleteList()
        {
            if (listDeleteDK != null && listDeleteDK.Count > 0)
            {
                foreach (VinaGerman.Entity.BusinessEntity.LocationEntity i in listDeleteDK)
                {
                    try
                    {
                        if (i.LocationId > 0)
                            Factory.Resolve<ICompanyDS>().DeleteLocation(i);
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
                    index = this.gvLocation.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridLocation.DataSource;
                        List<VinaGerman.Entity.BusinessEntity.LocationEntity> list = (List<VinaGerman.Entity.BusinessEntity.LocationEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            VinaGerman.Entity.BusinessEntity.LocationEntity a = (VinaGerman.Entity.BusinessEntity.LocationEntity)list[index];
                            listDeleteDK.Add(a);
                        }
                        gvLocation.DeleteRow(index);
                        gvLocation.UpdateCurrentRow();
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
                List<VinaGerman.Entity.BusinessEntity.LocationEntity> lst = (List<VinaGerman.Entity.BusinessEntity.LocationEntity>)source.DataSource;
                int index = -1;
                index = this.gvLocation.FocusedRowHandle;
                VinaGerman.Entity.BusinessEntity.LocationEntity b = (VinaGerman.Entity.BusinessEntity.LocationEntity)gvLocation.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridLocation.DataSource;
                    List<VinaGerman.Entity.BusinessEntity.LocationEntity> list = (List<VinaGerman.Entity.BusinessEntity.LocationEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        VinaGerman.Entity.BusinessEntity.LocationEntity a = new VinaGerman.Entity.BusinessEntity.LocationEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.LocationId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridLocation.DataSource = source;
                    gvLocation.RefreshData();
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

        private void frmLocationManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                gvLocation.MoveNext();
                gvLocation.UpdateCurrentRow();
                source = (BindingSource)GridLocation.DataSource;
                if (source.DataSource != null && ((List<Entity.BusinessEntity.LocationEntity>)source.DataSource).Count > 0)
                {
                    foreach (Entity.BusinessEntity.LocationEntity dr in source)
                    {
                        dr.CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId;
                        var updatedEntity = Factory.Resolve<ICompanyDS>().AddOrUpdateLocation(dr);
                    }
                }
                DeleteList();
                LoadData();
                CustomMessageBox.ShowError("Lưu thành công", "Thông báo", null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lưu thất bại ", "Thông báo");
                CustomMessageBox.ShowError("Lưu thất bại ", "Thông báo", ex);
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}