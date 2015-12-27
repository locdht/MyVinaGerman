using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace VinaGerman.Report
{
    public partial class rptLenhSanXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLenhSanXuat()
        {
            InitializeComponent();
        }
        public void LoadHeader()
        {
            DataRow dr = purchaseOrderDetail1.LenhSanXuatHeader.NewRow();
            dr["TenCTY"] = "Công ty TNHH VinaGerman Thiên Phú";
            dr["Diachi"] = "Tổ 3, ấp 1, Xã Thạnh Phú, Vĩnh Cửu, Đồng Nai";
            dr["So"] = "LSX00512";
            dr["Ngay"] = "Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy");
            purchaseOrderDetail1.LenhSanXuatHeader.Rows.Add(dr);
            purchaseOrderDetail1.LenhSanXuatHeader.AcceptChanges();
        }

        public void LoadDetail()
        {
            for (int i = 1; i <= 5; i++)
            {
                DataRow dr = purchaseOrderDetail1.LenhSanXuatDetail.NewRow();
                dr["Mathanhpham"] = "MTP" + i.ToString();
                dr["Tenthanhpham"] = "TP " + i.ToString();
                dr["Soluong"] = i * 10;
                dr["DoituongTHCP"] = "DT " + i.ToString();
                dr["DVT"] = "kg";
                purchaseOrderDetail1.LenhSanXuatDetail.Rows.Add(dr);
            }
            purchaseOrderDetail1.LenhSanXuatDetail.AcceptChanges();

        }
    }
}
