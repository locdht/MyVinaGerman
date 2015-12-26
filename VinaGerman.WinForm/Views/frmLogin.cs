using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Threading;
using VinaGerman.WinForm.Utilities;
using VinaGerman.Utilities;
namespace VinaGerman.Views
{
    public partial class frmLogin : XtraForm
    {
        #region Init
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = "admin";
            txtMK.Text = "123456";
        }
        #endregion

        #region Function
        
        bool DoLogin()
        {
            
            bool result = false;
            string user = txtTenDN.Text.Trim();
            string pass = txtMK.Text.Trim();
            string oldServerUrl = VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.ServerUrl;

            //redirect to new server url and logon
            VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.ServerUrl = "https://localhost:443/vinagerman";
            var profile = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.ICommonDS>().GetUserProfile(user, pass);
            if (profile != null && profile.UserAccountId > 0)
            {
                //save succesfull logon information
                VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.IsWindowAuthentication = false;
                VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.Username = user;
                VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.Password = pass;
                ApplicationHelper.CurrentUserProfile = profile;
                result = true;
            }
            return result;
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnDN_Click(null, null);               
            }
        }
        #endregion

        #region Event
        private   void btnDN_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string strMessage = string.Empty;
            
            if (!string.IsNullOrEmpty(txtTenDN.Text.Trim()) && !string.IsNullOrEmpty(txtMK.Text))
            {
                try
                {
                    bool kq = DoLogin();
                    if (kq)
                    {
                        this.Close();
                    }
                    else
                        strMessage = "Thông tin đăng nhập không hợp lệ. Vui lòng kiểm tra lại";
                }
                catch
                {
                    strMessage = "Không thể kết nối với máy chủ. Vui lòng kiểm tra đường truyền.";
                }
            }
            else
                strMessage = "Vui lòng nhập tên đăng nhập hoặc mật khẩu để thực hiện đăng nhập.";
            this.Cursor = Cursors.Default;
            if (!string.IsNullOrEmpty(strMessage))
            {
                txtMK.Text = string.Empty;
                Utils.ShowMsg(strMessage);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
