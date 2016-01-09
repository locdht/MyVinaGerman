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

namespace VinaGerman.Views
{
    public partial class frmSaleOrderDetail : DevExpress.XtraEditors.XtraForm
    {
        #region sub classes
        public class PurchaseOrderlineEntity : OrderlineEntity
        {
            public BindingList<LoanEntity> ChildList { get; set; }
        }
        #endregion

        #region properties
        public List<VinaGerman.Entity.DatabaseEntity.ArticleEntity> ArticleList { get; set; }
        public List<VinaGerman.Entity.DatabaseEntity.BusinessEntity> BusinessList { get; set; }
        public List<VinaGerman.Entity.DatabaseEntity.IndustryEntity> IndustryList { get; set; }
        public List<VinaGerman.Entity.DatabaseEntity.CompanyEntity> CustomerList { get; set; }
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> EmployeeList { get; set; }
        public List<KeyValuePair<int,string>> StatusList { get; set; }

        public OrderEntity CurrentOrder { get; set; }
        public BindingList<PurchaseOrderlineEntity> OrderlineList { get; set; }
        public MainForm OwnerForm { get; set; }
        #endregion

        #region constructor
        public frmSaleOrderDetail(MainForm owner)
        {
            InitializeComponent();
            OwnerForm = owner;
        }
        #endregion

        #region public method
        public void LoadOrder(OrderEntity order = null)
        {
            //reset orderlines
            OrderlineList = new BindingList<PurchaseOrderlineEntity>();
            OrderlineList.AddingNew += OrderlineList_AddingNew;
            DataGrid.DataSource = OrderlineList;
            if (order == null)
            {
                order = new OrderEntity()
                {
                    OrderType = (int)enumOrderType.Purchase,
                    CreatedBy = ApplicationHelper.CurrentUserProfile.ContactId
                };
                CurrentOrder = order;                
            }
            else
            {
                CurrentOrder = order;
                var orderlines = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().GetOrderlinesForOrder(CurrentOrder);
                for (int i = 0; i < orderlines.Count; i++)
                {
                    OrderlineList.Add(new PurchaseOrderlineEntity()
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
                        Unit = orderlines[i].Unit,
                        //populate loan list
                        ChildList = new BindingList<LoanEntity>(VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.IOrderDS>().GetLoansForOrderline(orderlines[i]))
                    });
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
            this.cboEmployee.Properties.DataSource = EmployeeList;
            this.cboEmployee.EditValue = ApplicationHelper.CurrentUserProfile.ContactId;
            this.cboBusiness.Properties.DataSource = BusinessList;
            this.cboIndustry.Properties.DataSource = IndustryList;
            this.cboStatus.Properties.DataSource = StatusList;
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

        private void OrderlineList_AddingNew(object sender, AddingNewEventArgs e)
        {
            OwnerForm.PerformActionWithLoading(new Action(() =>
            {
                System.Threading.Thread.Sleep(5000);
                var newObject =new PurchaseOrderlineEntity()
                {
                    OrderlineId = -1,
                    OrderId = CurrentOrder.OrderId,
                    ChildList = new BindingList<LoanEntity>()
                };
                newObject.ChildList.AddingNew += ChildList_AddingNew;
                e.NewObject = newObject;
            }));
        }

        void ChildList_AddingNew(object sender, AddingNewEventArgs e)
        {
            var newObject = new LoanEntity()
            {
                OrderlineId = -1               
            };            
            e.NewObject = newObject;
        }

        private void MasterGridView_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "ChildView";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        #endregion                

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frm = new frmRPTPurchaseOrder() { _type = "PhieuXuatKhoBanHang" };
            frm.ShowDialog();
        }

        private void cboCustomer_EditValueChanged(object sender, EventArgs e)
        {
            var selectedObject = cboCustomer.GetSelectedDataRow();
            cboCustomerContact.Properties.DataSource = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.ICompanyDS>().GetContactForCompany((VinaGerman.Entity.DatabaseEntity.CompanyEntity)selectedObject);
        }
    }
}