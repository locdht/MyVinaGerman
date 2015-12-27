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
                    case "SoChiTietVatTuHangHoa":
                        rptSoChiTietVatTuHangHoa rptSCTVTHH = new rptSoChiTietVatTuHangHoa();
                        rptSCTVTHH.LoadHeader();
                        rptSCTVTHH.LoadDetail();
                        documentViewer1.DocumentSource = rptSCTVTHH;
                        rptSCTVTHH.CreateDocument();
                        break;
                    case "TongHopTonKho":
                        rptTongHopTonKho rptTHTK = new rptTongHopTonKho();
                        rptTHTK.LoadDetail();
                        documentViewer1.DocumentSource = rptTHTK;
                        rptTHTK.CreateDocument();
                        break;
                    case "LenhSanXuat":
                        rptLenhSanXuat rptLSX = new rptLenhSanXuat();
                        rptLSX.LoadHeader();
                        rptLSX.LoadDetail();
                        documentViewer1.DocumentSource = rptLSX;
                        rptLSX.CreateDocument();
                        break;
                    case "TongHopXuatKhoTheoLenhSX":
                        rptTongHopXuatKhoTheoLenhSX rptTHXKTLSX = new rptTongHopXuatKhoTheoLenhSX();
                        rptTHXKTLSX.LoadDetail();
                        documentViewer1.DocumentSource = rptTHXKTLSX;
                        rptTHXKTLSX.CreateDocument();
                        break;
                    //rptTongHopXuatKhoTheoLenhSX
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(ex.Message, "Thông báo", ex);
            }

        }
    }
}