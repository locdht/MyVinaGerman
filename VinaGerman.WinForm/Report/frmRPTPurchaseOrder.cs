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
using VinaGerman.Utilities;

namespace VinaGerman.Report
{
    public partial class frmRPTPurchaseOrder : DevExpress.XtraEditors.XtraForm
    {
        public string _type { set; get; }// 1: nhap, 2: xuat
        public frmRPTPurchaseOrder()
        {
            InitializeComponent();
        }

        private void frmRPTPurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                switch (_type)
                {
                    case "PhieuNhap":
                    case "PhieuXuat":
                        rptPurchaseOrderDetail rpt = new rptPurchaseOrderDetail();
                        rpt._type = this._type;
                        rpt.LoadHeader();
                        rpt.LoadDetail();
                        documentViewer1.DocumentSource = rpt;
                        rpt.CreateDocument();
                        break;
                    case "PhieuThu":
                        rptPhieuThu rptPThu = new rptPhieuThu();
                        rptPThu.LoadHeader();
                        documentViewer1.DocumentSource = rptPThu;
                        rptPThu.CreateDocument();
                        break;
                    case "PhieuXuatKhoBanHang":
                        rptPhieuXuatKhoBanHang rptPXKBH = new rptPhieuXuatKhoBanHang();
                        rptPXKBH.LoadHeader();
                        rptPXKBH.LoadDetail();
                        documentViewer1.DocumentSource = rptPXKBH;
                        rptPXKBH.CreateDocument();
                        break;
                    case "SoChiTietBanHang":
                        rptSoChiTietBanHang rptSCTBH = new rptSoChiTietBanHang();
                        rptSCTBH.LoadHeader();
                        rptSCTBH.LoadDetail();
                        documentViewer1.DocumentSource = rptSCTBH;
                        rptSCTBH.CreateDocument();
                        break;
                    case "SoChiTietMuaHang":
                        rptSoChiTietMuaHang rptSCTMH = new rptSoChiTietMuaHang();
                        rptSCTMH.LoadHeader();
                        rptSCTMH.LoadDetail();
                        documentViewer1.DocumentSource = rptSCTMH;
                        rptSCTMH.CreateDocument();
                        break;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(ex.Message, "Thông báo", ex);
            }

        }
    }
}