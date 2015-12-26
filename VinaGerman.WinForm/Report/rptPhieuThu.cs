using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using VinaGerman.Utilities;

namespace VinaGerman.Report
{
    public partial class rptPhieuThu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhieuThu()
        {
            InitializeComponent();
        }
        public void LoadHeader()
        {
            DataRow dr = purchaseOrderDetail1.PhieuThu.NewRow();
            dr["TenCTY"] = "Công ty TNHH VinaGerman Thiên Phú";
            dr["Diachi"] = "Tổ 3, ấp 1, Xã Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["Mauso"] = "01-VT";
            dr["Thongtu"] = "(Ban hành theo thông tư số 200/2014/TT-BTC Ngày 22/12/2014 của Bộ Tài Chính";
            dr["Ngaythangnam"] = "Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy");

            dr["Nguoinop"] = "ANH TUẤN CÔNG TY TNHH CHÂU THỚI";
            dr["Diachinguoinop"] = "Tổ 3, ấp 1, Xã Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["Lydo"] = "THU TIỀN HÀNG CHÂU THỚI";
            dr["Sotien"] = "12.500.000 VND";
            lblChu.Text = lblChu2.Text = Common.ConvertToUpperFirst(Common.ReadNumber("12500000"));
            purchaseOrderDetail1.PhieuThu.Rows.Add(dr);
            purchaseOrderDetail1.PhieuThu.AcceptChanges();
        }
    }
}
