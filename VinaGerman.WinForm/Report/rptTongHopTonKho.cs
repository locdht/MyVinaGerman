using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace VinaGerman.Report
{
    public partial class rptTongHopTonKho : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTongHopTonKho()
        {
            InitializeComponent();
        }
        public void LoadDetail()
        {
            lblThangNam.Text = "Tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy");
            for (int i = 1; i <= 5; i++)
            {
                DataRow dr = purchaseOrderDetail1.TongHopTonKhoDetail.NewRow();
                dr["Mahang"] = "MH00" + i.ToString(); 
                dr["Tenkho"] = "KHO00" + i.ToString();
                dr["Tenhang"] = "Hang00 " + i.ToString();
                dr["Soluongdauky"] = i * 1000;
                dr["Giatridauky"] = i * 2000;
                dr["Soluongnhapkho"] = i * 1000;

                dr["Giatrinhapkho"] = i * 2000;
                dr["Soluongxuatkho"] = i * 1000;
                dr["Soluongcuoiky"] = (i * 1000)+(i*1000)-(i*1000);
                dr["Giatricuoiky"] = (i * 2000) + (i * 2000);
                dr["Chenhlech"] = 0;
                purchaseOrderDetail1.TongHopTonKhoDetail.Rows.Add(dr);
            }
            purchaseOrderDetail1.TongHopTonKhoDetail.AcceptChanges();

        }
    }
}
