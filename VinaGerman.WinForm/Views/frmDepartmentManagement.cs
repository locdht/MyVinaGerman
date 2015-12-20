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
using VinaGerman.DataSource;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Entity;
using VinaGerman.WinForm.Utilities;
using VinaGerman.Utilities;
using System.Reflection;

namespace VinaGerman.Views
{
    public partial class frmDepartmentManagement : DevExpress.XtraEditors.XtraForm
    {
        #region declare paramater
        public BindingSource source = new BindingSource();
        public List<Entity.BusinessEntity.DepartmentEntity> listDeleteDK;
        #endregion

        public frmDepartmentManagement()
        {
            InitializeComponent();
            listDeleteDK = new List<Entity.BusinessEntity.DepartmentEntity>();
        }

        private void frmDepartmentManagement_Load(object sender, EventArgs e)
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
                gvDepartment.MoveNext();
                gvDepartment.UpdateCurrentRow();
                source = (BindingSource)GridDepartment.DataSource;
                if (source.DataSource != null && ((List<Entity.BusinessEntity.DepartmentEntity>)source.DataSource).Count > 0)
                {
                    foreach (Entity.BusinessEntity.DepartmentEntity dr in source)
                    {
                        dr.CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId;
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateDepartment(dr);
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

        #region functions
        private void LoadData()
        {
            List<Entity.BusinessEntity.DepartmentEntity> list = Factory.Resolve<IBaseDataDS>().SearchDepartment(new DepartmentSearchEntity()
            {
                SearchText = ""
            });
            if (list != null && list.Count > 0)
            {
                source.DataSource = list;
                GridDepartment.DataSource = source;
            }
            else
            {
                List<Entity.BusinessEntity.DepartmentEntity> lst = new List<Entity.BusinessEntity.DepartmentEntity>();
                Entity.BusinessEntity.DepartmentEntity it = new Entity.BusinessEntity.DepartmentEntity();
                it.Description = "";
                lst.Add(it);
                source.DataSource = lst;
                GridDepartment.DataSource = source;
            }
        }

        public void DeleteList()
        {
            if (listDeleteDK != null && listDeleteDK.Count > 0)
            {
                foreach (Entity.BusinessEntity.DepartmentEntity i in listDeleteDK)
                {
                    try
                    {
                        if (i.DepartmentId > 0)
                            Factory.Resolve<IBaseDataDS>().DeleteDepartment(i);
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
                    index = this.gvDepartment.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridDepartment.DataSource;
                        List<Entity.BusinessEntity.DepartmentEntity> list = (List<Entity.BusinessEntity.DepartmentEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            Entity.BusinessEntity.DepartmentEntity a = (Entity.BusinessEntity.DepartmentEntity)list[index];
                            listDeleteDK.Add(a);
                        }
                        gvDepartment.DeleteRow(index);
                        gvDepartment.UpdateCurrentRow();
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
                List<Entity.BusinessEntity.DepartmentEntity> lst = (List<Entity.BusinessEntity.DepartmentEntity>)source.DataSource;
                int index = -1;
                index = this.gvDepartment.FocusedRowHandle;
                Entity.BusinessEntity.DepartmentEntity b = (Entity.BusinessEntity.DepartmentEntity)gvDepartment.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridDepartment.DataSource;
                    List<Entity.BusinessEntity.DepartmentEntity> list = (List<Entity.BusinessEntity.DepartmentEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        Entity.BusinessEntity.DepartmentEntity a = new Entity.BusinessEntity.DepartmentEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.DepartmentId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridDepartment.DataSource = source;
                    gvDepartment.RefreshData();
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

    }
}