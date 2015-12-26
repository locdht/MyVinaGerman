using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using VinaGerman.Utilities;

namespace VinaGerman.Report
{
    public partial class rptPhieuXuatKhoBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhieuXuatKhoBanHang()
        {
            InitializeComponent();
        }
        public void LoadHeader()
        {
            DataRow dr = purchaseOrderDetail1.PhieuXuatBanHangHeader.NewRow();
            dr["TenCTY"] = "Công ty TNHH VinaGerman Thiên Phú";
            dr["Diachi"] = "Tổ 3, ấp 1, Xã Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["Ngaythangnam"] = "Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy");
            dr["Nguoimua"] = "";
            dr["Tenkhachhang"] = "CÔNG TY TNHH Ý CHÍ VIỆT";
            dr["Diachinguoimua"] = "Cụm công nghiệp Thạnh Phú, Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["Diengiai"] = "";

            purchaseOrderDetail1.PhieuXuatBanHangHeader.Rows.Add(dr);
            purchaseOrderDetail1.PhieuXuatBanHangHeader.AcceptChanges();
        }

        public void LoadDetail()
        {
            Int64 sum = 0;
            for (int i = 0; i < 5; i++)
            {
                DataRow dr = purchaseOrderDetail1.PhieuXuatBanHangDetail.NewRow();
                dr["STT"] = (i + 1).ToString();
                dr["Tenhang"] = "hang hoa " + i.ToString();
                dr["Donvi"] = "kg";
                dr["Soluong"] = i + 1;
                dr["Dongia"] = (i + 1) * 1000;
                dr["Thanhtien"] = (i + 1) * (i + 1) * 1000;
                sum = sum + (i + 1) * (i + 1) * 1000;
                purchaseOrderDetail1.PhieuXuatBanHangDetail.Rows.Add(dr);
            }
            purchaseOrderDetail1.PhieuXuatBanHangDetail.AcceptChanges();
            lblVAT.Text = "10";
            lblTienVAT.Text =string.Format("{0:N0}", (10 * sum));
            lblTongTien.Text = string.Format("{0:N0}", (10 * sum) + sum);
            lblTienChu.Text = Common.ConvertToUpperFirst(Common.ReadNumber(((10 * sum) + sum).ToString()));
        }
    }
}
