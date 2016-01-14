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
using VinaGerman.Entity;
using VinaGerman.DataSource;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Utilities;
using System.Reflection;
using VinaGerman.WinForm.Utilities;

namespace VinaGerman.Views
{
    public partial class frmPurchaseOrderManagement : DevExpress.XtraEditors.XtraForm
    {
        public MainForm OwnerForm { get; set; }
        public BindingSource source = new BindingSource();
        public frmPurchaseOrderManagement(MainForm parent)
        {
            InitializeComponent();
            OwnerForm = parent;
        }
        private DataTable CreateStatus()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Ten", typeof(string));

            dt.Rows.Add((int)enumOrderStatus.Ready, "Chờ duyệt");
            dt.Rows.Add((int)enumOrderStatus.Approved, "Đã duyệt");
            dt.Rows.Add((int)enumOrderStatus.Processed, "Đã xử lí");
            return dt;
        }
        private void frmPurchaseOrderManagement_Load(object sender, EventArgs e)
        {
            try
            {
                rpsLKStatus.DataSource = CreateStatus();
                List<OrderEntity> lstSource = new List<OrderEntity>();

                lstSource = Factory.Resolve<IOrderDS>().SearchOrder(new OrderSearchEntity()
                {
                    SearchText = "",
                    OrderType = (int)enumOrderType.Purchase
                });
                if (lstSource != null && lstSource.Count > 0)
                {
                    source.DataSource = lstSource;
                    GridPurchase.DataSource = source;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(ex.Message, "Thông báo", ex);
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void rpsHPLXoa_Click(object sender, EventArgs e)
        {

        }

        private void rpsHPLDel_Click(object sender, EventArgs e)
        {
            try
            {
                OrderEntity it = (OrderEntity)gvPurchase.GetFocusedRow();
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (Factory.Resolve<IOrderDS>().DeleteOrder(it))
                        XtraMessageBox.Show("Xóa thành công", "Thông báo");
                    else
                        XtraMessageBox.Show("Xóa thất bại", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(ex.Message, "Thông báo", ex);
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void rpsHPOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OrderEntity order = (OrderEntity)gvPurchase.GetFocusedRow();
                OwnerForm.GoToView(enumView.PurchaseOrderDetail, order);
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(ex.Message, "Thông báo", ex);
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}