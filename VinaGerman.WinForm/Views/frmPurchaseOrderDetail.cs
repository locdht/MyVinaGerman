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
using VinaGerman.Model;

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
        public BindingList<OrderlineModel> OrderlineList { get; set; }
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
        public void LoadOrder()
        {
            //reset orderlines
            OrderlineList = new BindingList<OrderlineModel>();
            DataGrid.DataSource = OrderlineList;
            if (CurrentOrder == null)
            {
                CurrentOrder = new OrderEntity()
                {
                    OrderType = (int)enumOrderType.Purchase,
                    OrderDate = DateTime.Now,
                    CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId,
                    CreatedBy = ApplicationHelper.CurrentUserProfile.ContactId,
                    ResponsibleBy = ApplicationHelper.CurrentUserProfile.ContactId,
                    OrderNumber = ""
                };                
            }
            else
            {
                var orderlines = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().GetOrderlinesForOrder(CurrentOrder, true);
                if (orderlines != null && orderlines.Count > 0)
                {
                    for (int i = 0; i < orderlines.Count; i++)
                    {
                        var newOrderline = new OrderlineModel()
                        {
                            OrderlineId = orderlines[i].OrderlineId,
                            OrderId = orderlines[i].OrderId,
                            ArticleId = orderlines[i].ArticleId,
                            CreatedBy = orderlines[i].CreatedBy,                            
                            ModifiedBy = orderlines[i].ModifiedBy,
                            ModifiedDate = orderlines[i].ModifiedDate,
                            PaidDate = orderlines[i].PaidDate,
                            PayDate = orderlines[i].PayDate,
                            Price = orderlines[i].Price,
                            Quantity = orderlines[i].Quantity,
                            RealQuantity = orderlines[i].RealQuantity,
                            RemainingQuantity = orderlines[i].RemainingQuantity,
                            Unit = orderlines[i].Unit
                        };

                        //populate loan list
                        if (orderlines[i].LoanList != null && orderlines[i].LoanList.Count > 0)
                        {
                            for (int j = 0; j < orderlines[i].LoanList.Count; j++)
                            {
                                newOrderline.ChildList.Add(new LoanModel()
                                {
                                    LoanId = orderlines[i].LoanList[j].LoanId,
                                    OrderlineId = orderlines[i].LoanList[j].OrderlineId,                                    
                                    ArticleId = orderlines[i].LoanList[j].ArticleId,
                                    Quantity = orderlines[i].LoanList[j].Quantity,
                                    RemainingQuantity = orderlines[i].LoanList[j].RemainingQuantity,
                                    Unit = orderlines[i].Unit
                                });
                            }                            
                        }

                        OrderlineList.Add(newOrderline);
                    }
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

            this.txtOrderDate.EditValue = CurrentOrder.OrderDate;
            this.txtOrderNumber.Text = CurrentOrder.OrderNumber;

            ExpandAllRows(MasterGridView);
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
            }));
        }

        public void ExpandAllRows(GridView View)
        {
            View.BeginUpdate();
            try
            {
                int dataRowCount = View.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                {
                    var data = (OrderlineModel)View.GetRow(rHandle);
                    if (data.ChildList != null && data.ChildList.Count > 0)
                        View.SetMasterRowExpanded(rHandle, true);
                    else
                        View.SetMasterRowExpanded(rHandle, false);
                }
            }
            finally
            {
                View.EndUpdate();
            }
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
            //populate current value to order
            CurrentOrder.ModifiedBy = ApplicationHelper.CurrentUserProfile.ContactId;
            CurrentOrder.OrderDate = (DateTime)txtOrderDate.EditValue;
            CurrentOrder.OrderStatus = (int)cboStatus.EditValue;
            CurrentOrder.BusinessId = (int)cboStatus.EditValue;
            CurrentOrder.IndustryId = (int)cboStatus.EditValue;
            CurrentOrder.ResponsibleBy = (int)cboStatus.EditValue;
            CurrentOrder.OrderType = (int)enumOrderType.Purchase;
            CurrentOrder.OrderStatus = (int)cboStatus.EditValue;
            CurrentOrder.CustomerCompanyId = (int)cboCustomer.EditValue;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateOrder())
            {
                OwnerForm.PerformActionWithLoading(new Action(() =>
                {
                    List<OrderlineEntity> orderlines = new List<OrderlineEntity>();
                    for (int i = 0; i < OrderlineList.Count; i++)
                    {
                        var newOrderline = new OrderlineEntity()
                        {
                            OrderlineId = OrderlineList[i].OrderlineId,
                            OrderId = OrderlineList[i].OrderId,
                            ArticleId = OrderlineList[i].ArticleId,
                            CreatedBy = OrderlineList[i].CreatedBy,                            
                            ModifiedBy = OrderlineList[i].ModifiedBy,                            
                            PaidDate = OrderlineList[i].PaidDate,
                            PayDate = OrderlineList[i].PayDate,
                            Price = OrderlineList[i].Price,
                            Quantity = OrderlineList[i].Quantity,
                            RealQuantity = OrderlineList[i].RealQuantity
                        };

                        //populate loan list
                        if (OrderlineList[i].ChildList != null && OrderlineList[i].ChildList.Count > 0)
                        {
                            for (int j = 0; j < OrderlineList[i].ChildList.Count; j++)
                            {
                                newOrderline.LoanList.Add(new LoanEntity()
                                {
                                    LoanId = OrderlineList[i].ChildList[j].LoanId,
                                    OrderlineId = OrderlineList[i].ChildList[j].OrderlineId,
                                    ArticleId = OrderlineList[i].ChildList[j].ArticleId,
                                    Quantity = OrderlineList[i].ChildList[j].Quantity
                                });
                            }
                        }

                        orderlines.Add(newOrderline);
                    }
                    
                    var order = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().SaveOrder(CurrentOrder, orderlines);
                    if (order != null && order.OrderId > 0)
                    {
                        CurrentOrder = order;
                        LoadOrder();
                    }
                    else
                    {
                        VinaGerman.Utilities.Utils.ShowError("Lưu phiếu nhập kho không thành công!");
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
                    var entityObject = (OrderlineModel)e.Row;
                    entityObject.CreatedBy = ApplicationHelper.CurrentUserProfile.ContactId;
                    //get article relation
                    var relatedArticleList = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IBaseDataDS>().GetArticleRelationsForArticle(new VinaGerman.Entity.DatabaseEntity.ArticleEntity() { ArticleId = entityObject.ArticleId });
                    if (relatedArticleList != null && relatedArticleList.Count > 0)
                    {
                        for (int i = 0; i < relatedArticleList.Count; i++)
                        {
                            entityObject.ChildList.Add(new LoanModel()
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
            GridView view = (GridView)DataGrid.FocusedView;
            LoanModel selectedRow = (LoanModel)view.GetFocusedRow();
            ((LoanModel)selectedRow).Quantity = 1000;
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