using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace VinaGerman.Report
{
    public partial class rptSoChiTietVatTuHangHoa : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSoChiTietVatTuHangHoa()
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
            for (int i = 1; i <= 6; i++)
            {
                DataRow dr = purchaseOrderDetail1.SoChiTietVatTuHangHoaDetail.NewRow();
                if(i<5)
                    dr["Makho"] = "MKHO1";
                else
                    dr["Makho"] = "MKHO2";
                if(i%2==0)
                    dr["Mahang"] = "MHANG1";
                else
                    dr["Mahang"] = "MHANG2";
                dr["Tenkho"] = "KHO " + i.ToString();
                dr["Tenhang"] = "HANG " + i.ToString();
                dr["Ngaychungtu"] = DateTime.Today.AddDays(-i).ToString("dd/MM/yyyy");
                dr["Sochungtu"] = i;

                dr["Diengiai"] = "Diễn giải " + i.ToString();
                dr["DVT"] = "kg";
                dr["Soluongnhap"] = i+1;
                dr["Soluongxuat"] = i;
                dr["Soluongton"] = i;

                dr["Madoituong"] = "DT " + i.ToString();
                dr["Dongia"] = i * (i * 1000);

                purchaseOrderDetail1.SoChiTietVatTuHangHoaDetail.Rows.Add(dr);
            }
            purchaseOrderDetail1.SoChiTietVatTuHangHoaDetail.AcceptChanges();

        }
    }
}
