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

namespace VinaGerman.Report
{
    public partial class frmRPTPurchaseOrder : DevExpress.XtraEditors.XtraForm
    {
        public int _type { set; get; }// 1: nhap, 2: xuat
        public frmRPTPurchaseOrder()
        {
            InitializeComponent();
        }

        private void frmRPTPurchaseOrder_Load(object sender, EventArgs e)
        {
            rptPurchaseOrderDetail rpt = new rptPurchaseOrderDetail();
            rpt._type = this._type;
            rpt.LoadHeader();
            rpt.LoadDetail();
            documentViewer1.DocumentSource = rpt;
            rpt.CreateDocument();

        }
    }
}