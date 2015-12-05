using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinaGerman.DesktopApplication.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.ComponentModel;
using System.IO;
using VinaGerman.DesktopApplication.ViewModels.UserViews;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Ultilities;

namespace VinaGerman.DesktopApplication.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties
        public uvBaseViewModel ContactManagementModel { get; set; }
        public uvBaseViewModel LocationManagementModel { get; set; }
        public uvBaseViewModel PurchaseOrderDetailModel { get; set; }
        public uvBaseViewModel PurchaseOrderManagementModel { get; set; }
        public uvBaseViewModel DepartmentManagementModel { get; set; }
        public uvBaseViewModel ArticleManagementModel { get; set; }
        public uvBaseViewModel IndustryManagementModel { get; set; }
        public uvBaseViewModel BusinessManagementModel { get; set; }
        public uvBaseViewModel CategoryManagementModel { get; set; }
        public uvBaseViewModel CompanyManagementModel { get; set; }
        public uvBaseViewModel LogonModel { get; set; }         

        private uvBaseViewModel _currentModel;        

        public uvBaseViewModel CurrentModel
        {
            get { return _currentModel; }
            set
            {
                if (_currentModel != value)
                {
                    _currentModel = value;
                    RaisePropertyChanged("CurrentModel");
                }
            }
        }

        private string _scanner;
        public string Scanner
        {
            get
            {
                return _scanner;
            }
            set
            {
                _scanner = value;
                RaisePropertyChanged("Scanner");
            }
        }
       
        public List<uvBaseViewModel> ModelQueue { get; set; }
       
        #endregion   
 
        #region Constructors

        public MainWindowViewModel()
        {
            ControlHelper.ApplyLanguage(ApplicationHelper.Language);

            App.StartupScreen.SetMessage(StringResources.msgLoading);            

            SetFormTitleAndVersion();
            
            //register implementation
            RegisterImplementation();

            //register accepted tokens
            RegisterAcceptedToken();
           
            //load user credential,server address and check connection            
            //InspectionHelper.LoadUserCredentialFromSystemSetting();                                            

            //LocDHT: check connection
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            /*App.StartupScreen.SetMessage(StringResources.msgCheckConnection);            
            _networkStatus = new NetworkStatus();
            _networkStatus.AvailabilityChanged += new NetworkStatusChangedHandler(DoNetworkAvailabilityChanged);*/

            // Init all module
            ModelQueue = new List<uvBaseViewModel>();

            CompanyManagementModel = new uvCompanyManagementViewModel(this) { MessengerID = enumView.CompanyManagement.ToString() };
            CategoryManagementModel = new uvCategoryManagementViewModel(this) { MessengerID = enumView.CategoryManagement.ToString() };
            BusinessManagementModel = new uvBusinessManagementViewModel(this) { MessengerID = enumView.BusinessManagement.ToString() };
            IndustryManagementModel = new uvIndustryManagementViewModel(this) { MessengerID = enumView.IndustryManagement.ToString() };
            ArticleManagementModel = new uvArticleManagementViewModel(this) { MessengerID = enumView.ArticleManagement.ToString() };
            DepartmentManagementModel = new uvDepartmentManagementViewModel(this) { MessengerID = enumView.DepartmentManagement.ToString() };
            LocationManagementModel = new uvLocationManagementViewModel(this) { MessengerID = enumView.LocationManagement.ToString() };
            ContactManagementModel = new uvContactManagementViewModel(this) { MessengerID = enumView.ContactManagement.ToString() };
            PurchaseOrderManagementModel = new uvPurchaseOrderManagementViewModel(this) { MessengerID = enumView.PurchaseOrderManagement.ToString() };
            PurchaseOrderDetailModel = new uvPurchaseOrderDetailViewModel(this) { MessengerID = enumView.PurchaseOrderDetail.ToString() };
            LogonModel = new uvLogonViewModel(this) { MessengerID = enumView.Logon.ToString() };
            //check if user is authorized or not
            if (!ApplicationHelper.IsAuthenticated)
            {
                SendMessage(MessageToken.ReloadMessage, null, enumView.Logon.ToString());
                GoToView(enumView.Logon);
            }
            else
            {
                SendMessage(MessageToken.ReloadMessage, null, enumView.CompanyManagement.ToString());
                GoToView(enumView.CompanyManagement);
            }          
            App.StartupScreen.LoadComplete();            
        }

        //public void ShowWindow(string sTitle, int iHeight, int iWidth,
        //    VinaGerman.DesktopApplication.ViewModels.BaseViewModel model)
        //{
        //    ((MainWindow)Application.Current.MainWindow).ShowChildForm(
        //        sTitle, iHeight, iWidth, model
        //    );
        //}

        private void RegisterAcceptedToken()
        {
            AcceptedToken.Add(MessageToken.GoToViewMessage);
            AcceptedToken.Add(MessageToken.GoBackMessage);
            AcceptedToken.Add(MessageToken.ReloadMessage);
        }

        public void SetFormTitleAndVersion()
        {
            /*string version;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }

            App.StartupScreen.SetTitle(StringResources.titleInspection);
            App.StartupScreen.SetVersion(version); */           
        }

        protected override void MessageHandler(BaseMessage pMessage)
        {
            if (pMessage.Token == MessageToken.GoToViewMessage)
            {
                if (pMessage.Parameters != null && pMessage.Parameters.ContainsKey("ViewType"))
                {
                    //enumView view = (enumView)pMessage.Parameters["ViewType"];
                    //GoToView(view);
                }
            }
            else if (pMessage.Token == MessageToken.GoBackMessage)
            {
                GoBack();
            }
            else if (pMessage.Token == MessageToken.ReloadMessage) //receive this message after restoring
            {
                //reset everything
                for (int i = 0;ModelQueue != null && i < ModelQueue.Count; i++)
                {
                    ModelQueue[i].Reset();
                }
            }
        }

        #endregion

        #region Initialize function
        
        public void RegisterImplementation()
        {
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.ICommonDS, VinaGerman.DataSource.Implementation.CommonDS>();
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.ICompanyDS, VinaGerman.DataSource.Implementation.CompanyDS>();
            VinaGerman.Entity.Factory.Register<VinaGerman.DataSource.IBaseDataDS, VinaGerman.DataSource.Implementation.BaseDataDS>();
        }       
        #endregion

        public void CloseWindow(CancelEventArgs e)
        {
            MessageBoxResult confirm = CurrentModel.ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmQuit, MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        public void GoToView(enumView view)
        {
            switch (view)
            {
                //
                case enumView.ContactManagement:
                    CurrentModel = ContactManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.ContactManagement.ToString());
                    break;
                case enumView.LocationManagement:
                    CurrentModel = LocationManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.LocationManagement.ToString());
                    break;
                case enumView.DepartmentManagement:
                    CurrentModel = DepartmentManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.DepartmentManagement.ToString());
                    break;
                case enumView.PurchaseOrderDetail:
                    CurrentModel = PurchaseOrderDetailModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.PurchaseOrderDetail.ToString());
                    break;
                case enumView.PurchaseOrderManagement:
                    CurrentModel = PurchaseOrderManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.PurchaseOrderManagement.ToString());
                    break;
                case enumView.ArticleManagement:
                    CurrentModel = ArticleManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.ArticleManagement.ToString());
                    break;
                case enumView.IndustryManagement:
                    CurrentModel = IndustryManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.IndustryManagement.ToString());
                    break;
                case enumView.BusinessManagement:
                    CurrentModel = BusinessManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.BusinessManagement.ToString());
                    break;
                case enumView.CategoryManagement:
                    CurrentModel = CategoryManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.CategoryManagement.ToString());
                    break;
                case enumView.CompanyManagement:
                    CurrentModel = CompanyManagementModel;
                    SendMessage(MessageToken.ReloadMessage, null, enumView.CategoryManagement.ToString());
                    break;
                case enumView.Logon:
                    CurrentModel = LogonModel;
                    break;               
                default:
                    CurrentModel = LogonModel;
                    break;
            }
            ModelQueue.Add(CurrentModel);
        }        

        public void GoBack(bool Reload=false)
        {
            if (ModelQueue.Count > 0)
            {
                //remove currentmodel from modelqueue                
                ModelQueue.RemoveAt(ModelQueue.Count - 1);
                if (ModelQueue.Count > 0)
                {
                    CurrentModel = ModelQueue[ModelQueue.Count - 1];
                }
                else
                {
                    GoToView(enumView.Logon);
                }                
            }
        }
      
        public string GetCurrentMessengerID()
        {
            if (CurrentModel != null)
            {
                return CurrentModel.MessengerID;
            }
            else
            {
                return "";
            }
        } 
        #region Implement IView interface
        public void ShowLoading(string sCaptionKey, string sKeyMessage)
        {
            if (CurrentModel != null)
                CurrentModel.ShowLoading(sCaptionKey, sKeyMessage);
        }
        #endregion     
    }
}