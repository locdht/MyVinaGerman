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
using VinaGerman.DataSource;
using VinaGerman.Entity;
using VinaGerman.Utilities;
using System.Reflection;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.WinForm.Utilities;

namespace VinaGerman.Views
{
    public partial class frmCategoryManagement : DevExpress.XtraEditors.XtraForm
    {
        #region declare paramater
        public BindingSource source = new BindingSource();
        public List<CategoryEntity> listDeleteDK;
        #endregion
        public frmCategoryManagement()
        {
            InitializeComponent();
            listDeleteDK = new List<CategoryEntity>();
        }

        private void frmCategoryManagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                gvCategory.MoveNext();
                gvCategory.UpdateCurrentRow();
                source = (BindingSource)GridCategory.DataSource;
                if (source.DataSource != null && ((List<CategoryEntity>)source.DataSource).Count > 0)
                {
                    foreach (CategoryEntity dr in source)
                    {
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateCategory(dr);
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

        #region functions
        private void LoadData()
        {
            List<CategoryEntity> list = Factory.Resolve<IBaseDataDS>().SearchCategories(new CategorySearchEntity()
            {
                SearchText = ""
            });
            if (list != null && list.Count > 0)
            {
                source.DataSource = list;
                GridCategory.DataSource = source;
            }
            else
            {
                List<CategoryEntity> lst = new List<CategoryEntity>();
                CategoryEntity it = new CategoryEntity();
                it.Description = "";
                lst.Add(it);
                source.DataSource = lst;
                GridCategory.DataSource = source;
            }
        }

        public void DeleteList()
        {
            if (listDeleteDK != null && listDeleteDK.Count > 0)
            {
                foreach (CategoryEntity i in listDeleteDK)
                {
                    try
                    {
                        if (i.CategoryId > 0)
                            Factory.Resolve<IBaseDataDS>().DeleteCategory(i);
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
                    index = this.gvCategory.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridCategory.DataSource;
                        List<CategoryEntity> list = (List<CategoryEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            CategoryEntity a = (CategoryEntity)list[index];
                            listDeleteDK.Add(a);
                        }
                        gvCategory.DeleteRow(index);
                        gvCategory.UpdateCurrentRow();
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
                List<CategoryEntity> lst = (List<CategoryEntity>)source.DataSource;
                int index = -1;
                index = this.gvCategory.FocusedRowHandle;
                CategoryEntity b = (CategoryEntity)gvCategory.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridCategory.DataSource;
                    List<CategoryEntity> list = (List<CategoryEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        CategoryEntity a = new CategoryEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.CategoryId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridCategory.DataSource = source;
                    gvCategory.RefreshData();
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