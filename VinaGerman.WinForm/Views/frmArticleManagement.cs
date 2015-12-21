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
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.DataSource;
using VinaGerman.Entity;
using VinaGerman.Entity.SearchEntity;
using System.Reflection;
using VinaGerman.Utilities;
using DevExpress.XtraEditors.DXErrorProvider;
using VinaGerman.WinForm.Utilities;
using System.Collections;

namespace VinaGerman.Views
{
    public partial class frmArticleManagement : DevExpress.XtraEditors.XtraForm
    {
        public enum TypeAction
        {
            Insert,
            Delete,
            Update,
            None
        }
        TypeAction sTypeAction = TypeAction.None;
        public BindingSource source = new BindingSource();
        BindingSource sourceArt = new BindingSource();
        public List<ArticleRelationEntity> listDelete;
        public int ID;
        public frmArticleManagement()
        {
            InitializeComponent();
            listDelete = new List<ArticleRelationEntity>();
        }

        #region functions

        private void InitData()
        {
            OnloadData();
            enable_control(TypeAction.None);
            gvArticle.Focus();
            LoadCombobox();
        }

        private void LoadCombobox()
        {

            List<CategoryEntity> listCate = Factory.Resolve<IBaseDataDS>().SearchCategories(new CategorySearchEntity()
            {
                SearchText = ""
            });
            slkLoaihang.Properties.DataSource = rpsLoaiHang.DataSource = rpsLoaiHangRelation.DataSource = listCate;
        }

        private void OnloadData()
        {
            try
            {
                List<ArticleEntity> lstart = new List<ArticleEntity>();
                
                lstart = Factory.Resolve<IBaseDataDS>().SearchArticle(new ArticleSearchEntity()
                {
                    SearchText = ""
                });
                if (lstart != null && lstart.Count > 0)
                {
                    sourceArt.DataSource = lstart.OrderByDescending(c=>c.ArticleId).ToList();
                    GridArticle.DataSource = rpsMathang.DataSource = sourceArt;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void enable_control(TypeAction sType)
        {
            switch (sType)
            {
                case TypeAction.Insert:
                    txtMahang.Properties.ReadOnly = false;
                    txtTenhang.Properties.ReadOnly = false;
                    txtDVT.Properties.ReadOnly = false;
                    slkLoaihang.Properties.ReadOnly = false;
                    enable_control(true);
                    break;
                case TypeAction.Delete:
                    enable_control(true);
                    break;
                case TypeAction.Update:
                    txtMahang.Properties.ReadOnly = false;
                    txtTenhang.Properties.ReadOnly = false;
                    txtDVT.Properties.ReadOnly = false;
                    slkLoaihang.Properties.ReadOnly = false;
                    enable_control(true);
                    break;
                case TypeAction.None:
                    txtMahang.Properties.ReadOnly = true;
                    txtTenhang.Properties.ReadOnly = true;
                    txtDVT.Properties.ReadOnly = true;
                    slkLoaihang.Properties.ReadOnly = true;
                    enable_control(false);
                    break;
            }
        }

        private void enable_control(bool isAction)
        {
            if (isAction)
            {
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnLuu.Visible = true;
                btnHuyBo.Visible = true;
                GridArticleRelation.Enabled = true;
            }
            else
            {
                btnThem.Visible = true;
                btnXoa.Visible = true;
                btnSua.Visible = true;
                btnLuu.Visible = false;
                btnHuyBo.Visible = false;
                GridArticleRelation.Enabled = false;
            }
        }

        private void Clear_Text()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
            txtDVT.Text = "";
            slkLoaihang.Text = "";
            GridArticleRelation.DataSource = null;
            List<ArticleRelationEntity> lst = new List<ArticleRelationEntity>();
            ArticleRelationEntity it = new ArticleRelationEntity();
            it.Comment = "";
            lst.Add(it);
            source.DataSource = lst;
            GridArticleRelation.DataSource = source;
        }

        private bool fncCheckControl()
        {
            if (string.IsNullOrEmpty(txtMahang.Text))
            {
                err.SetError(txtMahang, "Không thể để trống thông tin này!", ErrorType.Critical);
                txtMahang.Focus();
                return false;
            }
            else
            {
                err.SetError(txtMahang, "");
            }
            if (string.IsNullOrEmpty(txtTenhang.Text))
            {
                err.SetError(txtTenhang, "Không thể để trống thông tin này!", ErrorType.Critical);
                txtTenhang.Focus();
                return false;
            }
            else
            {
                err.SetError(txtTenhang, "");
            }
            return true;
        }

        public void DeleteList()
        {
            if (listDelete != null && listDelete.Count > 0)
            {
                foreach (ArticleRelationEntity i in listDelete)
                {
                    try
                    {
                        if (i.ArticleRelationId > 0)
                            Factory.Resolve<IBaseDataDS>().DeleteArticleRelation(i);
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
                    }
                }
                listDelete.Clear();
            }
        }

        private void RowDeleted()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int index = -1;
                    index = this.gvArticleRelation.FocusedRowHandle;
                    if (index >= 0)
                    {
                        source = (BindingSource)GridArticleRelation.DataSource;
                        List<ArticleRelationEntity> list = (List<ArticleRelationEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            ArticleRelationEntity a = (ArticleRelationEntity)list[index];
                            listDelete.Add(a);
                        }
                        gvArticleRelation.DeleteRow(index);
                        gvArticleRelation.UpdateCurrentRow();
                    }
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(this, System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
            }
        }

        private void RowArticleDeleted()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int index = -1;
                    index = this.gvArticle.FocusedRowHandle;
                    if (index >= 0)
                    {
                        sourceArt = (BindingSource)GridArticle.DataSource;
                        List<ArticleEntity> list = (List<ArticleEntity>)source.DataSource;
                        if (list != null && list.Count > 0)
                        {
                            ArticleEntity a = (ArticleEntity)list[index];
                            Factory.Resolve<IBaseDataDS>().DeleteArticle(a);
                        }
                        gvArticle.DeleteRow(index);
                        gvArticle.UpdateCurrentRow();
                        Clear_Text();
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
                List<ArticleRelationEntity> lst = (List<ArticleRelationEntity>)source.DataSource;
                int index = -1;
                index = this.gvArticleRelation.FocusedRowHandle;
                ArticleRelationEntity b = (ArticleRelationEntity)gvArticleRelation.GetFocusedRow();
                if (b != null)
                {
                    source = (BindingSource)GridArticleRelation.DataSource;
                    List<ArticleRelationEntity> list = (List<ArticleRelationEntity>)source.DataSource;
                    if (list != null && list.Count > 0)
                    {
                        ArticleRelationEntity a = new ArticleRelationEntity();
                        ApplicationHelper.TranferProperiesEx(b, a);
                        a.ArticleRelationId = 0;
                        list.Add(a);
                    }
                    source.DataSource = list;
                    GridArticleRelation.DataSource = source;
                    gvArticleRelation.RefreshData();
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(this, System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
            }
        }

        private bool SaveAction()
        {
            try
            {
                if (!fncCheckControl()) return false;
                ArticleEntity art = new ArticleEntity();
                art.ArticleNo = txtMahang.Text.Trim();
                art.Description = txtTenhang.Text.Trim();
                art.Unit = txtDVT.Text.Trim();
                art.CategoryId = int.Parse(slkLoaihang.EditValue.ToString());
                ArticleEntity artID = Factory.Resolve<IBaseDataDS>().AddOrUpdateArticle(art);
                if (artID.ArticleId > 0)
                {
                    ID = artID.ArticleId;
                    lblID.Text = ID.ToString();
                    
                    //insert chi tiet 
                    gvArticleRelation.MoveNext();
                    gvArticleRelation.UpdateCurrentRow();
                    source = (BindingSource)GridArticleRelation.DataSource;
                    if (source.DataSource != null && ((List<ArticleRelationEntity>)source.DataSource).Count > 0)
                    {
                        foreach (ArticleRelationEntity dr in source)
                        {
                            if (dr.ArticleId>0)
                            {
                                dr.RelatedArticleId = ID;
                                Factory.Resolve<IBaseDataDS>().AddOrUpdateArticleRelation(dr);
                            }
                        }
                    }
                    DeleteList();
                    OnloadData();
                    XtraMessageBox.Show("Thêm mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    XtraMessageBox.Show("Thêm mặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool DeleteAction()
        {
            bool result = false;
            try
            {
                if (string.IsNullOrEmpty(lblID.Text))
                    return false;
                ArticleEntity art = Factory.Resolve<IBaseDataDS>().GetArticleByID(Convert.ToInt32(lblID.Text));
                if (art != null)
                {
                    //xoa chi tiet 
                    List<ArticleRelationEntity> lst = Factory.Resolve<IBaseDataDS>().GetArticleRelationsForArticle(art);
                    foreach (ArticleRelationEntity item in lst)
                    {
                        Factory.Resolve<IBaseDataDS>().DeleteArticleRelation(item);
                    }

                    if (Factory.Resolve<IBaseDataDS>().DeleteArticle(art))
                    {
                        Clear_Text();
                        OnloadData();
                        XtraMessageBox.Show("Xóa mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        result= true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa mặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        result= false;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
        }

        private bool UpdateAction()
        {
            try
            {
                if (string.IsNullOrEmpty(lblID.Text)) return false;
                ArticleEntity art = Factory.Resolve<IBaseDataDS>().GetArticleByID(Convert.ToInt32(lblID.Text));
                art.ArticleNo = txtMahang.Text.Trim();
                art.Description = txtTenhang.Text.Trim();
                art.Unit = txtDVT.Text.Trim();
                art.CategoryId = int.Parse(slkLoaihang.EditValue.ToString());
                ArticleEntity artID = Factory.Resolve<IBaseDataDS>().AddOrUpdateArticle(art);
                if (artID.ArticleId > 0)
                {
                    ID = artID.ArticleId;
                    lblID.Text = ID.ToString();
                    //insert chi tiet 
                    gvArticleRelation.MoveNext();
                    gvArticleRelation.UpdateCurrentRow();
                    source = (BindingSource)GridArticleRelation.DataSource;
                    if (source.DataSource != null && ((List<ArticleRelationEntity>)source.DataSource).Count > 0)
                    {
                        foreach (ArticleRelationEntity dr in source)
                        {
                            if (dr.ArticleId>0)
                            {
                                dr.RelatedArticleId = ID;
                                Factory.Resolve<IBaseDataDS>().AddOrUpdateArticleRelation(dr);
                            }
                        }
                    }
                    DeleteList();
                    OnloadData();
                    XtraMessageBox.Show("Cập nhật mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật mặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
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
                case (Keys.F1):
                    this.RowArticleDeleted();
                    break;

            };
            // return the key to the base class if not used.
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void fncLoadDetail(ArticleEntity art)
        {
            try
            {
                txtMahang.Text = art.ArticleNo ?? "";
                txtTenhang.Text = art.Description ?? "";
                txtDVT.Text = art.Unit ?? "";
                slkLoaihang.EditValue = art.CategoryId;
                lblID.Text = art.ArticleId.ToString();
                //load chi tiet
                List<ArticleRelationEntity> lst = new List<ArticleRelationEntity>();
                if (art != null)
                    lst = Factory.Resolve<IBaseDataDS>().GetArticleRelationsForArticle(art);
                if (lst != null && lst.Count > 0)
                {
                    source.DataSource = lst;
                    GridArticleRelation.DataSource = source;
                }
                else
                {
                    source.DataSource = null;
                    GridArticleRelation.DataSource = source;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SimpleButton btn = (SimpleButton)sender;
            if (btn.Equals(btnThem))
            {
                Clear_Text();
                sTypeAction = TypeAction.Insert;
                enable_control(sTypeAction);
            }
            else if (btn.Equals(btnXoa))
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (DeleteAction())
                    {
                        sTypeAction = TypeAction.None;
                    }
                    enable_control(sTypeAction);
                }
            }
            else if (btn.Equals(btnSua))
            {
                sTypeAction = TypeAction.Update;
                enable_control(sTypeAction);
            }
            else if (btn.Equals(btnDong))
            {
                Close();
            }
            else if (btn.Equals(btnLuu))
            {
                bool result = true;
                switch (sTypeAction)
                {
                    case TypeAction.Insert:
                        if (SaveAction()) result = true;
                        else result = false;
                        break;
                    case TypeAction.Delete:
                        if (DeleteAction()) { result = true;}
                        else result = false;
                        break;
                    case TypeAction.Update:
                        if (UpdateAction()) result = true;
                        else result = false;
                        break;
                }
                if (result)
                {
                    sTypeAction = TypeAction.None;
                    enable_control(sTypeAction);
                }
            }
            else if (btn.Equals(btnHuyBo))
            {
                sTypeAction = TypeAction.None;
                enable_control(sTypeAction);
                OnloadData();
                fncLoadDetail((ArticleEntity)gvArticle.GetFocusedRow());
            }
        }

        private void frmArticleManagement_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void gvArticle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ArticleEntity r = (ArticleEntity)gvArticle.GetFocusedRow();
            fncLoadDetail(r);
        }

        private void rpsMathang_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit edit = (SearchLookUpEdit)sender;
            IList list = edit.Properties.DataSource as IList;
            if (string.IsNullOrEmpty(((DevExpress.XtraEditors.TextEdit)(edit)).Text))
                return;
            ArticleEntity art = (ArticleEntity)edit.Properties.View.GetFocusedRow();
            if (art != null)
            {
                ArticleRelationEntity obj = (ArticleRelationEntity)gvArticleRelation.GetFocusedRow();
                if (obj != null)
                {
                    obj.ArticleId = art.ArticleId;
                    obj.ArticleNo = art.ArticleNo;
                    obj.Description = art.Description;
                    obj.Unit = art.Unit;
                    obj.CategoryId = art.CategoryId;
                }
                gvArticleRelation.UpdateCurrentRow();
            }
        }
    }
}