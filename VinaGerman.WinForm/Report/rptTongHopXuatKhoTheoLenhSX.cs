using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace VinaGerman.Report
{
    public partial class rptTongHopXuatKhoTheoLenhSX : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTongHopXuatKhoTheoLenhSX()
        {
            InitializeComponent();
        }
        public void LoadDetail()
        {
            lblThangNam.Text="Tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy");
            for (int i = 1; i <= 5; i++)
            {
                DataRow dr = purchaseOrderDetail1.TongHopXuatKhoTheoLenhSXDetail.NewRow();
                dr["Ngay"] = DateTime.Today.AddDays(-i).ToString("dd/MM/yyyy");
                dr["Lenhsanxuat"] = "LSX00" + i.ToString();
                dr["Tenthanhpham"] = "TP " + i.ToString();
                dr["Soluongthanhpham"] = i * 2000;
                dr["Manguyenlieu"] = "MaNPL00" + i.ToString();
                dr["Tennguyenlieu"] = "TenNPL00 " + i.ToString();

                dr["DVT"] = "kg";
                dr["Soluongdinhmuc"] = i * 1000;
                dr["Soluongthucte"] = i * 1000;
                dr["Chenhlech"] = 0;
                purchaseOrderDetail1.TongHopXuatKhoTheoLenhSXDetail.Rows.Add(dr);
            }
            purchaseOrderDetail1.TongHopXuatKhoTheoLenhSXDetail.AcceptChanges();

        }
    }
}
