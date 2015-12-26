using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace VinaGerman.Report
{
    public partial class rptSoChiTietBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSoChiTietBanHang()
        {
            InitializeComponent();
        }
        public void LoadHeader()
        {
            DataRow dr = purchaseOrderDetail1.PhieuXuatBanHangHeader.NewRow();
            dr["TenCTY"] = "Công ty TNHH VinaGerman Thiên Phú";
            dr["Diachi"] = "Tổ 3, ấp 1, Xã Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["Ngaythangnam"] = "Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy");
            purchaseOrderDetail1.PhieuXuatBanHangHeader.Rows.Add(dr);
            purchaseOrderDetail1.PhieuXuatBanHangHeader.AcceptChanges();
        }

        public void LoadDetail()
        {
            Int64 sum = 0;
            for (int i = 1; i <= 5; i++)
            {
                DataRow dr = purchaseOrderDetail1.SoChiTietBanHangDetail.NewRow();
                dr["Ngaychungtu"] = DateTime.Today.AddDays(-i).ToString("dd/MM/yyyy");
                dr["Sochungtu"] = "SCT " + i.ToString();
                dr["Makhachhang "] = "MKH " + i.ToString();
                dr["Tenkhachhang"] = "Ten KH" + i.ToString();
                dr["DVT"] = "kg";
                dr["Soluongban"] = i;

                dr["Dongia"] = (i*1000);
                dr["Doanhsoban"] = 0;
                dr["Chietkhau"] = 0;
                dr["Soluongtralai"] =0;
                dr["Giatritralai"] = 0;

                dr["ThueGTGT"] = 10;
                dr["Tongthanhtoan"] = i * (i*1000);
                dr["Mahang"] = "MH " + i.ToString();
                
                purchaseOrderDetail1.SoChiTietBanHangDetail.Rows.Add(dr);
            }
            purchaseOrderDetail1.SoChiTietBanHangDetail.AcceptChanges();
            
        }
    }
}
