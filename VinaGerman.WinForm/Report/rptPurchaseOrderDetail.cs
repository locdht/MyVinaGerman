using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using VinaGerman.Utilities;

namespace VinaGerman.Report
{
    public partial class rptPurchaseOrderDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public string _type { set; get; }// 1: nhap, 2: xuat
        public rptPurchaseOrderDetail()
        {
            InitializeComponent();
        }

        public void LoadHeader()
        {
            if (_type == "PhieuNhap")
                lblHeader.Text = "PHIẾU NHẬP KHO";
            else if (_type == "PhieuXuat")
                lblHeader.Text = "PHIẾU XUẤT KHO";
            DataRow dr = purchaseOrderDetail1.HeaderPurchase.NewRow();
            dr["TenCTY"] = "Công ty TNHH VinaGerman Thiên Phú";
            dr["Diachi"] = "Tổ 3, ấp 1, Xã Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["Mauso"] = "01-VT";
            dr["Thongtu"] = "(Ban hành theo thông tư số 200/2014/TT-BTC Ngày 22/12/2014 của Bộ Tài Chính";
            dr["So"] = "NK03470";
            dr["Ngaythangnam"] = "Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy");
            dr["Nguoigiao"] = "CÔNG TY TNHH MỘT THÀNH VIÊN QUANG PHÚC PHÁT";
            dr["Theongay"] = "Theo ........... ngày ........... của .....................................";
            dr["Diadiem"] = "Cụm công nghiệp Thạnh Phú, Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["Nhapkhotai"] = "Hóa chất";
            
            purchaseOrderDetail1.HeaderPurchase.Rows.Add(dr);
            purchaseOrderDetail1.HeaderPurchase.AcceptChanges();
        }

        public void LoadDetail()
        {
            Int64 sum = 0;
            for (int i = 0; i < 5; i++)
            {
                DataRow dr = purchaseOrderDetail1.DetailPurchase.NewRow();
                dr["STT"] = (i + 1).ToString();
                dr["Tenhang"] = "hang hoa " + i.ToString();
                dr["Maso"] = "hh" + i.ToString();
                dr["DVT"] = "kg";
                dr["SLThucnhap"] =i+1;
                dr["SLTheochungtu"] = i+1;
                dr["Dongia"] = (i+1)*1000;
                dr["Thanhtien"] = (i+1)*(i+1)*1000;
                sum = sum + (i + 1) * (i + 1) * 1000;
                purchaseOrderDetail1.DetailPurchase.Rows.Add(dr);
            }
            purchaseOrderDetail1.DetailPurchase.AcceptChanges();
            lblTongTienChu.Text = Common.ConvertToUpperFirst(Common.ReadNumber(sum.ToString()));
        }

    }
}
