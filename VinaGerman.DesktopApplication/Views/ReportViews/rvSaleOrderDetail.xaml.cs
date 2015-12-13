using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.ReportEntity;

namespace VinaGerman.DesktopApplication.Views.ReportViews
{
    /// <summary>
    /// Interaction logic for rvPurchaseOrderDetail.xaml
    /// </summary>
    public partial class rvSaleOrderDetail : UserControl
    {
        public rvSaleOrderDetail()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;
        }
        private bool _isReportViewerLoaded;

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                Microsoft.Reporting.WinForms.ReportDataSource headerReportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();

                List<HeaderReportEntity> headerList = new List<HeaderReportEntity>();
                headerList.Add(new HeaderReportEntity()
                {
                    Description = "Công ty TNHH VinaGerman Thiên phú",
                    Address = "Tổ 3, ấp 1, Xã Thạnh Phú, Vĩnh Cửu, Đồng Nai",
                    OfficialNoteCode="01-VT",
                    OfficialNoteDescription="(Ban hành theo thông tư số 200/2014/TT-BTC Ngày 22/12/2014 của Bộ Tài Chính"
                });               

                var OrderlineList = new List<OrderlineEntity>();
                for (int i = 0; i < 1000; i++)
                {
                    OrderlineList.Add(new OrderlineEntity()
                    {
                        ArticleId=i+1,
                        ArticleNo = "hang hoa 1" + i.ToString(),
                        Description = "hh" + i.ToString(),
                        Unit = "kg",
                        OrderId=i+1,
                        OrderlineId=i+1,
                        Price = (i + 1) * 1000,
                        Quantity =(i+1)*1000
                    });
                }             

                reportDataSource1.Name = "OrderlineDataSet"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = OrderlineList;

                headerReportDataSource.Name = "ReportHeaderDataSet";
                headerReportDataSource.Value = headerList;

                this._reportViewer.LocalReport.DataSources.Add(headerReportDataSource);
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "VinaGerman.DesktopApplication.Reports.rptSaleOrderDetail.rdlc";

                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }
    }
}
