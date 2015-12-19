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
            PerformActionWithLoading(new Func<string, int>(Method1), "MyString1");
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
            //Open Wait Form
            SplashScreenManager.ShowForm(this, typeof(MainWaitForm), true, true, false);
            try
            {
                return method.DynamicInvoke(args);
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }            
        }

        public void GoToView(enumView view)
        {
            switch (view)
            {
                case enumView.CompanyManagement:
                    var child = new frmCompanyManagement();
                    child.MdiParent = this;
                    child.Show();
                    break;
                default: break;
            }
        }
    }
}