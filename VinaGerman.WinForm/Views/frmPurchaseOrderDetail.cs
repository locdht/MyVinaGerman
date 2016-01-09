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
using VinaGerman.Entity.SearchEntity;
using VinaGerman.WinForm.Utilities;
using VinaGerman.Report;
using DevExpress.XtraGrid.Views.Grid;

namespace VinaGerman.Views
{
    public partial class frmPurchaseOrderDetail : DevExpress.XtraEditors.XtraForm
    {        
        #region properties
        public List<VinaGerman.Entity.DatabaseEntity.ArticleEntity> ArticleList { get; set; }
        public List<VinaGerman.Entity.DatabaseEntity.BusinessEntity> BusinessList { get; set; }
        public List<VinaGerman.Entity.DatabaseEntity.IndustryEntity> IndustryList { get; set; }
        public List<VinaGerman.Entity.DatabaseEntity.CompanyEntity> CustomerList { get; set; }
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> EmployeeList { get; set; }
        public List<KeyValuePair<int,string>> StatusList { get; set; }

        public OrderEntity CurrentOrder { get; set; }
        public BindingList<OrderlineEntity> OrderlineList { get; set; }
        public MainForm OwnerForm { get; set; }
        #endregion

        #region constructor
        public frmPurchaseOrderDetail(MainForm owner)
        {
            InitializeComponent();
            OwnerForm = owner;
        }
        #endregion

        #region public method
        public void LoadOrder(OrderEntity order = null)
        {
            //reset orderlines
            OrderlineList = new BindingList<OrderlineEntity>();
            DataGrid.DataSource = OrderlineList;
            if (order == null)
            {
                order = new OrderEntity()
                {
                    OrderType = (int)enumOrderType.Purchase,
                    CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId,
                    CreatedBy = ApplicationHelper.CurrentUserProfile.ContactId,
                    ResponsibleBy = ApplicationHelper.CurrentUserProfile.ContactId,
                    OrderNumber = ""
                };
                CurrentOrder = order;                
            }
            else
            {
                CurrentOrder = order;
                var orderlines = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().GetOrderlinesForOrder(CurrentOrder);
                for (int i = 0; i < orderlines.Count; i++)
                {
                    var newOrderline = new OrderlineEntity()
                    {
                        ArticleId = orderlines[i].ArticleId,
                        ArticleNo = orderlines[i].ArticleNo,
                        CategoryId = orderlines[i].CategoryId,
                        Commission = orderlines[i].Commission,
                        CreatedBy = orderlines[i].CreatedBy,
                        CreatedDate = orderlines[i].CreatedDate,
                        Deleted = orderlines[i].Deleted,
                        Description = orderlines[i].Description,
                        ModifiedBy = orderlines[i].ModifiedBy,
                        ModifiedDate = orderlines[i].ModifiedDate,
                        OrderId = orderlines[i].OrderId,
                        OrderlineId = orderlines[i].OrderlineId,
                        PaidDate = orderlines[i].PaidDate,
                        PayDate = orderlines[i].PayDate,
                        Price = orderlines[i].Price,
                        Quantity = orderlines[i].Quantity,
                        RemainingQuantity = orderlines[i].RemainingQuantity,
                        Unit = orderlines[i].Unit                      
                    };
                    //populate loan list            
                    newOrderline.ChildList = new BindingList<LoanEntity>();

                    var loanList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().GetLoansForOrderline(orderlines[i]);
                    for (int j = 0; j < loanList.Count; j++)
                    {
                        newOrderline.ChildList.Add(new LoanEntity() 
                        {
                            ArticleId = orderlines[i].ArticleId,
                            ArticleNo = orderlines[i].ArticleNo,
                            CategoryId = orderlines[i].CategoryId,                          
                            Deleted = orderlines[i].Deleted,
                            Description = orderlines[i].Description,                                                       
                            OrderlineId = orderlines[i].OrderlineId,
                            Quantity = orderlines[i].Quantity,
                            RemainingQuantity = orderlines[i].RemainingQuantity,
                            Unit = orderlines[i].Unit,
                        });
                    }
                    OrderlineList.Add(newOrderline);                    
                }
            }            

            StatusList = new List<KeyValuePair<int, string>>();
            StatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Ready, "Chờ xử lí"));
            StatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Approved, "Đã duyệt"));
            StatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Processed, "Đã xử lí"));

            ArticleList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IBaseDataDS>().SearchArticle(new ArticleSearchEntity() { SearchText = "" });
            BusinessList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IBaseDataDS>().SearchBusiness(new BusinessSearchEntity() { SearchText = "" });
            IndustryList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IBaseDataDS>().SearchIndustry(new IndustrySearchEntity() { SearchText = "" });
            CustomerList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.ICompanyDS>().SearchCompanies(new CompanySearchEntity() { SearchText = "", IsSupplier = true, NotIncludedCompany = ApplicationHelper.CurrentUserProfile.CompanyId });
            EmployeeList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.ICompanyDS>().SearchContact(new ContactSearchEntity() { SearchText = "" });

            this.RepositoryArticleLookupEdit.DataSource = ArticleList;
            this.cboCustomer.Properties.DataSource = CustomerList;
            this.cboCustomer.EditValue = CurrentOrder.CustomerCompanyId;

            this.cboEmployee.Properties.DataSource = EmployeeList;
            this.cboEmployee.EditValue = ApplicationHelper.CurrentUserProfile.ContactId;

            this.cboBusiness.Properties.DataSource = BusinessList;
            this.cboBusiness.EditValue = CurrentOrder.BusinessId;

            this.cboIndustry.Properties.DataSource = IndustryList;
            this.cboIndustry.EditValue = CurrentOrder.IndustryId;

            this.cboStatus.Properties.DataSource = StatusList;
            this.cboStatus.EditValue = CurrentOrder.OrderStatus;
        }

        void OrderlineList_ListChanged(object sender, ListChangedEventArgs e)
        {
            var selectedRow = MasterGridView.GetRowCellValue(MasterGridView.SourceRowHandle, "ArticleId");

        }
        #endregion

        #region event handler
        private void frmPurchaseOrderDetail_Shown(object sender, EventArgs e)
        {
            OwnerForm.PerformActionWithLoading(new Action(() =>
            {
                LoadOrder();
                //update UI
                //DataGrid.Enabled = CurrentOrder != null && CurrentOrder.OrderId > 0;
            }));
        }        

        private void MasterGridView_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "ChildView";
        }

        private bool ValidateOrder()
        {
            if (txtOrderDate.EditValue == null)
            {
                VinaGerman.Utilities.Utils.ShowMsg("Thiếu thông tin ngày nhập!");
                return false;
            }
            if (cboCustomer.EditValue == null)
            {
                VinaGerman.Utilities.Utils.ShowMsg("Thiếu thông tin khách hàng!");
                return false;
            }
            if (cboEmployee.EditValue == null)
            {
                VinaGerman.Utilities.Utils.ShowMsg("Thiếu thông tin nhân viên!");
                return false;
            }
            if (cboBusiness.EditValue == null)
            {
                VinaGerman.Utilities.Utils.ShowMsg("Thiếu thông tin lĩnh vực!");
                return false;
            }
            if (cboIndustry.EditValue == null)
            {
                VinaGerman.Utilities.Utils.ShowMsg("Thiếu thông tin ngành nghề!");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateOrder())
            {
                OwnerForm.PerformActionWithLoading(new Action(() =>
                {
                    //save order first
                    if (CurrentOrder != null)
                    {
                        CurrentOrder.OrderDate = (DateTime)txtOrderDate.EditValue;
                        CurrentOrder.CustomerCompanyId = (int)cboCustomer.EditValue;
                        CurrentOrder.BusinessId = (int)cboBusiness.EditValue;
                        CurrentOrder.IndustryId = (int)cboIndustry.EditValue;
                        CurrentOrder.ResponsibleBy = (int)cboEmployee.EditValue;
                        CurrentOrder.OrderStatus = (int)cboStatus.EditValue;
                        CurrentOrder = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().AddOrUpdateOrder(CurrentOrder);

                        if (CurrentOrder != null && CurrentOrder.OrderId > 0)
                        {
                            //save orderlines
                            for (int i = 0; i < OrderlineList.Count; i++)
                            {
                                OrderlineList[i].OrderId = CurrentOrder.OrderId;
                                var newOrderline = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().AddOrUpdateOrderline((VinaGerman.Entity.BusinessEntity.OrderlineEntity)OrderlineList[i]);
                                if (newOrderline != null && newOrderline.OrderlineId > 0)
                                {
                                    OrderlineList[i].OrderlineId = newOrderline.OrderlineId;
                                    //save loan
                                    for (int j = 0; j < OrderlineList[i].ChildList.Count; j++)
                                    {
                                        OrderlineList[i].ChildList[j].OrderlineId = OrderlineList[i].OrderlineId;
                                        var newLoan = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().AddOrUpdateLoan((VinaGerman.Entity.BusinessEntity.LoanEntity)OrderlineList[i].ChildList[j]);
                                        if (newLoan != null && newLoan.LoanId > 0)
                                        {
                                            OrderlineList[i].ChildList[j].LoanId = newLoan.LoanId;
                                        }
                                    }
                                }
                            }
                        }
                    }                      
                }));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion                

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new frmRPTPurchaseOrder() { _type = "PhieuXuat" };
            frm.ShowDialog();
        }

        private void RepositoryArticleLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            var selectedRow = MasterGridView.GetRowCellValue(MasterGridView.SourceRowHandle, "ArticleId");
        }

        private void MasterGridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row != null)
            {
                OwnerForm.PerformActionWithLoading(new Action(() =>
                {
                    var entityObject = (OrderlineEntity)e.Row;
                    //get article relation
                    var relatedArticleList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IBaseDataDS>().GetArticleRelationsForArticle(new VinaGerman.Entity.DatabaseEntity.ArticleEntity() { ArticleId = entityObject.ArticleId });
                    if (relatedArticleList != null && relatedArticleList.Count > 0)
                    {
                        for (int i = 0; i < relatedArticleList.Count; i++)
                        {
                            entityObject.ChildList.Add(new LoanEntity()
                            {
                                ArticleId = relatedArticleList[i].ArticleId,
                                Description = relatedArticleList[i].Description,
                                ArticleNo = relatedArticleList[i].ArticleNo,
                                CategoryId = relatedArticleList[i].CategoryId,
                                Quantity = 0
                            });
                        }
                        //auto expand detail view
                        GridView view = sender as GridView;
                        if (!view.IsNewItemRow(e.RowHandle)) return;
                        view.SetMasterRowExpanded(view.FocusedRowHandle, true);
                    }       
                }));
            }
        }

        private void RepositoryButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {            
            DevExpress.XtraGrid.GridControl grid = (DevExpress.XtraGrid.GridControl)(((ButtonEdit)sender).Parent);//MasterGridView.GetRow,SourceRowHandle
            GridView view = (GridView)grid.FocusedView;
            LoanEntity selectedRow = (LoanEntity)view.GetFocusedRow();
            ((LoanEntity)selectedRow).Quantity = 1000;
            view.RefreshRow(view.FocusedRowHandle);
            //view.DeleteRow(view.FocusedRowHandle);
        }

        private void ChildGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "ArticleId") return;
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, "Quantity", 1000);            
        }
    }   
}