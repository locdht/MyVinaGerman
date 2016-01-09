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
    public partial class frmSaleOrderManagement : DevExpress.XtraEditors.XtraForm
    {
        public BindingSource source = new BindingSource();
        public frmSaleOrderManagement()
        {
            InitializeComponent();
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
        private void frmSaleOrderManagement_Load(object sender, EventArgs e)
        {
            try
            {
                rpsLKStatus.DataSource = CreateStatus();
                List<OrderEntity> lstSource = new List<OrderEntity>();

                lstSource = Factory.Resolve<IOrderDS>().SearchOrder(new OrderSearchEntity()
                {
                    SearchText = ""
                });
                if (lstSource != null && lstSource.Count > 0)
                {
                    source.DataSource = lstSource.Where(c => c.OrderType == (int)enumOrderType.Sale).OrderByDescending(c => c.OrderId).ToList();
                    GridPurchase.DataSource = source;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(ex.Message, "Thông báo", ex);
                Log.WriteLog(this, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
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
    }
}