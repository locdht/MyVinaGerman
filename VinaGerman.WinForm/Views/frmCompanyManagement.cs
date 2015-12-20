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
    public partial class frmCompanyManagement : DevExpress.XtraEditors.XtraForm
    {
        #region declare paramater
        public BindingSource source = new BindingSource();
        public List<CompanyEntity> listDeleteDK;
        #endregion
        public frmCompanyManagement()
        {
            InitializeComponent();
            listDeleteDK = new List<CompanyEntity>();
        }

        #region functions
        private void LoadData()
        {
            List<CompanyEntity> list = Factory.Resolve<ICompanyDS>().SearchCompanies(new CompanySearchEntity()
            {
                SearchText = ""
            });
            if (list != null && list.Count > 0)
            {
                source.DataSource = list;
                GridCompany.DataSource = source;
            }
            else
            {
                List<CompanyEntity> lst = new List<CompanyEntity>();
                CompanyEntity it = new CompanyEntity();
                it.Description = "";
                lst.Add(it);
                source.DataSource = lst;
                GridCompany.DataSource = source;
            }
        }

        public void DeleteList()
        {
            if (listDeleteDK != null && listDeleteDK.Count > 0)
            {
                foreach (CompanyEntity i in listDeleteDK)
                {
                    try
                    {
                        if (i.CompanyId > 0)
                            Factory.Resolve<ICompanyDS>().DeleteCompany(i);
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
                    index = this.gvCompany.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridCompany.DataSource;
                        List<CompanyEntity> list = (List<CompanyEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            CompanyEntity a = (CompanyEntity)list[index];
                            listDeleteDK.Add(a);
                        }
                        gvCompany.DeleteRow(index);
                        gvCompany.UpdateCurrentRow();
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
                List<CompanyEntity> lst = (List<CompanyEntity>)source.DataSource;
                int index = -1;
                index = this.gvCompany.FocusedRowHandle;
                CompanyEntity b = (CompanyEntity)gvCompany.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridCompany.DataSource;
                    List<CompanyEntity> list = (List<CompanyEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        CompanyEntity a = new CompanyEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.CompanyId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridCompany.DataSource = source;
                    gvCompany.RefreshData();
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

        private void frmCompanyManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                gvCompany.MoveNext();
                gvCompany.UpdateCurrentRow();
                source = (BindingSource)GridCompany.DataSource;
                if (source.DataSource != null && ((List<CompanyEntity>)source.DataSource).Count > 0)
                {
                    foreach (CompanyEntity dr in source)
                    {
                        dr.CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId;
                        var updatedEntity = Factory.Resolve<ICompanyDS>().AddOrUpdateCompany(dr);
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