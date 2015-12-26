using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace VinaGerman.Report
{
    public partial class rptSoChiTietMuaHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSoChiTietMuaHang()
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
            for (int i = 1; i <= 5; i++)
            {
                DataRow dr = purchaseOrderDetail1.SoChiTietMuaHangDetail.NewRow();
                dr["Ngayhoachtoan"] = DateTime.Today.AddDays(-i).ToString("dd/MM/yyyy");
                dr["Sochungtu"] = "SCT " + i.ToString();
                dr["Ngayhoadon"] = DateTime.Today.AddDays(-i).ToString("dd/MM/yyyy");
                dr["Sohoadon"] = "SoHD" + i.ToString();
                dr["Manhacungcap"] = "MaNCC" + i.ToString();
                dr["Tenhang"] = "NCC " + i.ToString();
                dr["DVT"] = "kg";
                dr["Soluongmua"] = i;
                dr["Dongia"] = i*1000;
                dr["Giatrimua"] = i*(i*1000);
                dr["Soluongtralai"] = 0;
                dr["Giatritralai"] = 0;
                purchaseOrderDetail1.SoChiTietMuaHangDetail.Rows.Add(dr);
            }
            purchaseOrderDetail1.SoChiTietMuaHangDetail.AcceptChanges();

        }
    }
}
