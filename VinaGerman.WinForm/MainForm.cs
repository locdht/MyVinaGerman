using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using VinaGerman.WinForm.Utilities;
using VinaGerman.Views;
using DevExpress.XtraEditors;
using VinaGerman.Report;

namespace VinaGerman
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);
            RegisterImplementation();
            this.Hide();
            frmLogin frmLG = new frmLogin();
            frmLG.ShowDialog();

            if (ApplicationHelper.CurrentUserProfile == null)
                this.Close();
            else
            {
                this.Show();
                bsiUser.Caption = ApplicationHelper.CurrentUserProfile.FullName;
                bsiUser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            }
            //Logon_Temp();
        }
        public void RegisterImplementation()
        {
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.IReportDS, VinaGerman.DataSource.Implementation.ReportDS>();
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.ICommonDS, VinaGerman.DataSource.Implementation.CommonDS>();
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.ICompanyDS, VinaGerman.DataSource.Implementation.CompanyDS>();
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.IBaseDataDS, VinaGerman.DataSource.Implementation.BaseDataDS>();
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.IOrderDS, VinaGerman.DataSource.Implementation.OrderDS>();
        }  
        private int Method1(string sParam)
        {
            Console.WriteLine(sParam);
            GoToView(enumView.CompanyManagement);
            System.Threading.Thread.Sleep(5000);
            return 1;
        }

        public void PerformActionWithSplashScreen(Delegate method, params object[] args)
        {
            //Open Wait Form
            SplashScreenManager.ShowForm(typeof(MainSplashScreen));
            try
            {
                method.DynamicInvoke(args);
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        public object PerformActionWithLoading(Delegate method, params object[] args)
        {
            object result = null;
            Exception exc = null;
            //Open Wait Form
            SplashScreenManager.ShowForm(this, typeof(MainWaitForm), true, true, false);
            try
            {
                result = method.DynamicInvoke(args);
            }
            catch (Exception ex)
            {
                result = null;
                exc = ex;
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
                if (exc != null)
                {
                    Utilities.Utils.ShowError(exc.Message, exc);
                }                
            }
            return result;
        }

        private void fncCallFormInTab(XtraForm xtraForm)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                xtraForm.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName);
                if (xtraTabbedMdiManager1.Pages.Count > 0)
                {
                    int i = 0;
                    bool flag = false;
                    foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage obj in xtraTabbedMdiManager1.Pages)
                    {
                        if (obj.Text == xtraForm.Text)
                        {
                            flag = true;
                            break;
                        }
                        i++;
                    }
                    if (flag)
                        xtraTabbedMdiManager1.Pages.RemoveAt(i);
                }

                xtraForm.FormClosing += new FormClosingEventHandler(xtraForm_FormClosing);
                xtraForm.MdiParent = this;
                xtraForm.ShowInTaskbar = false;
                xtraForm.WindowState = FormWindowState.Maximized;
                xtraForm.Show();
            }
            catch
            {
                xtraForm.Close();
                xtraForm.Dispose();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Logon_Temp()
        {

            PerformActionWithLoading(new Action(() =>
            {                
                //save old parameters before logon
                string oldServerUrl = VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.ServerUrl;

                //redirect to new server url and logon
                VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.ServerUrl = "https://localhost:443/vinagerman";

                //call to service to get user account
                var profile = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.ICommonDS>().GetUserProfile("admin", "123456");

                if (profile != null && profile.UserAccountId > 0)
                {
                    //save succesfull logon information
                    VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.IsWindowAuthentication = false;
                    VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.Username = "admin";
                    VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.Password = "123456";

                    //ApplicationHelper.ServerUrl = ServerUrl;
                    //ApplicationHelper.UserName = UserName;
                    //ApplicationHelper.IsAuthenticated = true;
                    ApplicationHelper.CurrentUserProfile = profile;
                }
            }));            
        }
        private void xtraForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void ShowOrActivateForm<T>() where T : Form
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(T)).FirstOrDefault();
            if (k == null)
            {

                k = (Form)Activator.CreateInstance(typeof(T));
                k.MdiParent = this;
                k.WindowState = FormWindowState.Maximized;
                k.Show();
            }
            else
            {
                k.Activate();
            }
        }

        public void GoToView(enumView view, object parameter = null)
        {
            switch (view)
            {
                case enumView.CompanyManagement:
                    fncCallFormInTab(new frmCompanyManagement());
                    break;
                case enumView.PurchaseOrderDetail:
                    var frm = new frmPurchaseOrderDetail(this);
                    frm.CurrentOrder = (VinaGerman.Entity.BusinessEntity.OrderEntity)parameter;
                    fncCallFormInTab(frm);
                    break;
                default: break;
            }
        }

        private void barButtonDSPhongBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barButtonDSPhongBan":
                    fncCallFormInTab(new frmDepartmentManagement());
                    break;
                case "barButtonDSChiNhanh":
                    fncCallFormInTab(new frmLocationManagement());
                    break;
                case "barButtonDSNhanVien":
                    fncCallFormInTab(new frmContactManagement());
                    break;
                case "barButtonDSKhachHangNCC":
                    fncCallFormInTab(new frmCompanyManagement());
                    break;

                case "barButtonDSNganhNghe":
                    fncCallFormInTab(new frmIndustryManagement());
                    break;
                case "barButtonDSLinhVuc":
                    fncCallFormInTab(new frmBusinessManagement());
                    break;
                case "barButtonLoaiHangHoa":
                    fncCallFormInTab(new frmCategoryManagement());
                    break;
                case "barButtonBCHangTonKho":
                    fncCallFormInTab(new frmRPTPurchaseOrder() { _type = "TongHopTonKho" });
                    break;
                case "barButtonBCSoChiTietBanHang":
                    fncCallFormInTab(new frmRPTPurchaseOrder() { _type = "SoChiTietBanHang" });
                    break;
                case "barButtonBCSoChiTietMuaHang":
                    fncCallFormInTab(new frmRPTPurchaseOrder() { _type = "SoChiTietMuaHang" });
                    break;
                case "barButtonDSHangHoa":
                    fncCallFormInTab(new frmArticleManagement());
                    break;
                case "barButtonLapPhieuNhapHang":
                    fncCallFormInTab(new frmPurchaseOrderDetail(this));
                    break;
                case "barButtonLapPhieuBan":
                    fncCallFormInTab(new frmSaleOrderDetail(this));
                    break;
                case "barButtonTraCuuPhieuNhapHang":
                    fncCallFormInTab(new frmPurchaseOrderManagement(this));
                    break;
                case "barButtonTraCuuPhieuBanHang":
                    fncCallFormInTab(new frmSaleOrderManagement());
                    break;
            }
        }
    }
}