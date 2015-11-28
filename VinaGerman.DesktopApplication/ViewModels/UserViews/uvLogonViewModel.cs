using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Ultilities;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvLogonViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
        public RelayCommand<PasswordBox> LogonCommand { get; set; }

        private string _serverUrl;
        public string ServerUrl
        {
            get
            {
                return _serverUrl;
            }
            set
            {
                _serverUrl = value;
                RaisePropertyChanged("ServerUrl");
            }
        }

        private string _username;
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged("UserName");                
            }
        }        
        #endregion
        public uvLogonViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            LogonCommand = new RelayCommand<PasswordBox>(Logon);
        }

        public void Logon(PasswordBox password)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    //save old parameters before logon
                    string oldServerUrl = VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.ServerUrl;

                    //redirect to new server url and logon
                    VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.ServerUrl = ServerUrl;

                    //call to service to get user account
                    var profile = VinaGerman.Entity.Factory.Resolve<VinaGerman.DataSource.ICommonDS>().GetUserProfile(UserName, password.Password);
                    
                    HideLoading();

                    if (profile != null && profile.UserAccountId > 0)
                    {
                        //save succesfull logon information
                        VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.IsWindowAuthentication = false;
                        VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.Username = UserName;
                        VinaGerman.Wcf.Security.Client.ClientPersonnelHeaderContext.HeaderInformation.Password = password.Password;

                        ApplicationHelper.ServerUrl = ServerUrl;
                        ApplicationHelper.UserName = UserName;
                        ApplicationHelper.IsAuthenticated = true;
                        ApplicationHelper.CurrentUserProfile = profile;

                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            GoToView(enumView.CompanyManagement);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });
        }

        #region Message processing
        public override void Reset() 
        {
            ServerUrl = ApplicationHelper.ServerUrl;
            UserName = ApplicationHelper.UserName;
        }
        protected override void MessageHandler(BaseMessage pMessage)
        {
            if (pMessage.Token == MessageToken.ReloadMessage)
            {
                Reset();
            }
        }

        #endregion
    }
}
