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
using VinaGerman.WinForm.Utilities;
using VinaGerman.Entity;
using VinaGerman.DataSource;
using VinaGerman.Utilities;
using System.Reflection;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Views
{
    public partial class frmContactManagement : DevExpress.XtraEditors.XtraForm
    {
        #region declare paramater
        public BindingSource source = new BindingSource();
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> listDeleteDK;
        #endregion

        public frmContactManagement()
        {
            InitializeComponent();
            listDeleteDK = new List<VinaGerman.Entity.BusinessEntity.ContactEntity>();
        }

        #region functions
        private void LoadData()
        {
            List<VinaGerman.Entity.BusinessEntity.ContactEntity> list = Factory.Resolve<IBaseDataDS>().SearchContact(new ContactSearchEntity()
            {
                SearchText = ""
            });
            if (list != null && list.Count > 0)
            {
                source.DataSource = list;
                GridContact.DataSource = source;
            }
            else
            {
                List<VinaGerman.Entity.BusinessEntity.ContactEntity> lst = new List<VinaGerman.Entity.BusinessEntity.ContactEntity>();
                VinaGerman.Entity.BusinessEntity.ContactEntity it = new VinaGerman.Entity.BusinessEntity.ContactEntity();
                it.FullName = "";
                lst.Add(it);
                source.DataSource = lst;
                GridContact.DataSource = source;
            }
            
        }

        public void DeleteList()
        {
            if (listDeleteDK != null && listDeleteDK.Count > 0)
            {
                foreach (VinaGerman.Entity.BusinessEntity.ContactEntity i in listDeleteDK)
                {
                    try
                    {
                        if (i.ContactId > 0)
                            Factory.Resolve<IBaseDataDS>().DeleteContact(i);
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
                    index = this.gvContact.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridContact.DataSource;
                        List<VinaGerman.Entity.BusinessEntity.ContactEntity> list = (List<VinaGerman.Entity.BusinessEntity.ContactEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            VinaGerman.Entity.BusinessEntity.ContactEntity a = (VinaGerman.Entity.BusinessEntity.ContactEntity)list[index];
                            listDeleteDK.Add(a);
                        }
                        gvContact.DeleteRow(index);
                        gvContact.UpdateCurrentRow();
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
                List<VinaGerman.Entity.BusinessEntity.ContactEntity> lst = (List<VinaGerman.Entity.BusinessEntity.ContactEntity>)source.DataSource;
                int index = -1;
                index = this.gvContact.FocusedRowHandle;
                VinaGerman.Entity.BusinessEntity.ContactEntity b = (VinaGerman.Entity.BusinessEntity.ContactEntity)gvContact.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridContact.DataSource;
                    List<VinaGerman.Entity.BusinessEntity.ContactEntity> list = (List<VinaGerman.Entity.BusinessEntity.ContactEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        VinaGerman.Entity.BusinessEntity.ContactEntity a = new VinaGerman.Entity.BusinessEntity.ContactEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.ContactId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridContact.DataSource = source;
                    gvContact.RefreshData();
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

        private void frmContactManagement_Load(object sender, EventArgs e)
        {
            List<Entity.BusinessEntity.DepartmentEntity> list = Factory.Resolve<IBaseDataDS>().SearchDepartment(new DepartmentSearchEntity()
            {
                SearchText = ""
            });
            rpsDepartment.DataSource = list;
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                gvContact.MoveNext();
                gvContact.UpdateCurrentRow();
                source = (BindingSource)GridContact.DataSource;
                if (source.DataSource != null && ((List<VinaGerman.Entity.BusinessEntity.ContactEntity>)source.DataSource).Count > 0)
                {
                    foreach (VinaGerman.Entity.BusinessEntity.ContactEntity dr in source)
                    {
                        dr.CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId;
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateContact(dr);
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