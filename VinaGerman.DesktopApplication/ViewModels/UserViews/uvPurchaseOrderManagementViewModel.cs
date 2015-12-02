using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VinaGerman.DesktopApplication.Translations;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvPurchaseOrderManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        #endregion


        public uvPurchaseOrderManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchCommand = new RelayCommand(Search);            

            ClearSearch();
        }
        #region method      
        public void Search()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    //var list = Factory.Resolve<ICompanyDS>().SearchCompanies(new CompanySearchEntity()
                    //{
                    //    SearchText = this.SearchText,
                    //    IsCustomer = this.IsCustomer,
                    //    IsSupplier = this.IsSupplier,
                    //    NotIncludedCompany = ApplicationHelper.CurrentUserProfile.CompanyId
                    //});

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        //CompanyList = list;
                    }));                    
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });            
            //ShowDialog<uvCompanyDetailViewModel>(new uvCompanyDetailViewModel() { 
            //    OriginalCompany = SelectCompany
            //});
        }
        public void ClearSearch()
        {
            SearchText = "";
        }
        #endregion
    }
}
