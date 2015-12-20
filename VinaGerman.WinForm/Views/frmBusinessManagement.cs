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
using VinaGerman.Entity.SearchEntity;
using VinaGerman.DataSource;
using VinaGerman.Entity;
using System.Reflection;
using VinaGerman.Utilities;
using VinaGerman.WinForm.Utilities;

namespace VinaGerman.Views
{
    public partial class frmBusinessManagement : DevExpress.XtraEditors.XtraForm
    {
        #region declare paramater
        public BindingSource source = new BindingSource();
        public List<BusinessEntity> listDeleteDK;
        #endregion
        public frmBusinessManagement()
        {
            InitializeComponent();
            listDeleteDK = new List<BusinessEntity>();
        }

        #region functions
        private void LoadData()
        {
            List<BusinessEntity> list = Factory.Resolve<IBaseDataDS>().SearchBusiness(new BusinessSearchEntity()
            {
                SearchText = ""
            });
            if (list != null && list.Count > 0)
            {
                source.DataSource = list;
                GridBusiness.DataSource = source;
            }
            else
            {
                List<BusinessEntity> lst = new List<BusinessEntity>();
                BusinessEntity it = new BusinessEntity();
                it.Description = "";
                lst.Add(it);
                source.DataSource = lst;
                GridBusiness.DataSource = source;
            }
        }

        public void DeleteList()
        {
            if (listDeleteDK != null && listDeleteDK.Count > 0)
            {
                foreach (BusinessEntity i in listDeleteDK)
                {
                    try
                    {
                        if (i.BusinessId > 0)
                            Factory.Resolve<IBaseDataDS>().DeleteBusiness(i);
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
                    index = this.gvBusiness.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridBusiness.DataSource;
                        List<BusinessEntity> list = (List<BusinessEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            BusinessEntity a = (BusinessEntity)list[index];
                            listDeleteDK.Add(a);
                        }
                        gvBusiness.DeleteRow(index);
                        gvBusiness.UpdateCurrentRow();
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
                List<BusinessEntity> lst = (List<BusinessEntity>)source.DataSource;
                int index = -1;
                index = this.gvBusiness.FocusedRowHandle;
                BusinessEntity b = (BusinessEntity)gvBusiness.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridBusiness.DataSource;
                    List<BusinessEntity> list = (List<BusinessEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        BusinessEntity a = new BusinessEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.BusinessId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridBusiness.DataSource = source;
                    gvBusiness.RefreshData();
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

        private void frmBusinessManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                gvBusiness.MoveNext();
                gvBusiness.UpdateCurrentRow();
                source = (BindingSource)GridBusiness.DataSource;
                if (source.DataSource != null && ((List<BusinessEntity>)source.DataSource).Count > 0)
                {
                    foreach (BusinessEntity dr in source)
                    {
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateBusiness(dr);
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