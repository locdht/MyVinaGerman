using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Ultilities;
using VinaGerman.Entity.BusinessEntity;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvPurchaseOrderDetailViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
        private List<OrderlineEntity> _orderlineList = null;
        public List<OrderlineEntity> OrderlineList
        {
            get
            {
                return _orderlineList;
            }
            set
            {
                _orderlineList = value;
                RaisePropertyChanged("OrderlineList");
            }
        }

        private List<LoanEntity> _loanList = null;
        public List<LoanEntity> LoanList
        {
            get
            {
                return _loanList;
            }
            set
            {
                _loanList = value;
                RaisePropertyChanged("LoanList");
            }
        }

        public XmlLanguage CurrentLanguage
        {
            get
            {
                switch (ApplicationHelper.Language)
                {
                    case "en-us": return XmlLanguage.GetLanguage("en-US");
                    default: return XmlLanguage.GetLanguage("vi-VN");
                }
            }
        }

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


        public uvPurchaseOrderDetailViewModel(MainWindowViewModel pMainWindowViewModel)
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

                    OrderlineList = new List<OrderlineEntity>();
                    OrderlineList.Add(new OrderlineEntity() 
                    { 
                        Quantity=5,
                        RemainingQuantity=6,
                        Price=300000,
                        Commission=100000,
                        Description="hang hoa 1",
                        Unit="kg",
                        ArticleNo="hh1"
                    });
                    OrderlineList.Add(new OrderlineEntity()
                    {
                        Quantity = 5,
                        RemainingQuantity = 6,
                        Price = 300000,
                        Commission = 100000,
                        Description = "hang hoa 2",
                        Unit = "kg",
                        ArticleNo = "hh2"
                    });
                    OrderlineList.Add(new OrderlineEntity()
                    {
                        Quantity = 5,
                        RemainingQuantity = 6,
                        Price = 300000,
                        Commission = 100000,
                        Description = "hang hoa 3",
                        Unit = "kg",
                        ArticleNo = "hh3"
                    });

                    LoanList = new List<LoanEntity>();
                    LoanList.Add(new LoanEntity()
                    {
                        Quantity = 5,
                        RemainingQuantity = 6,                        
                        Description = "hang hoa 1",
                        Unit = "kg",
                        ArticleNo = "hh1"
                    });
                    LoanList.Add(new LoanEntity()
                    {
                        Quantity = 5,
                        RemainingQuantity = 6,
                        Description = "hang hoa 2",
                        Unit = "kg",
                        ArticleNo = "hh2"
                    });
                    LoanList.Add(new LoanEntity()
                    {
                        Quantity = 5,
                        RemainingQuantity = 6,
                        Description = "hang hoa 3",
                        Unit = "kg",
                        ArticleNo = "hh3"
                    });
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

        #region Message processing
        public override void Reset()
        {
            //reset left panel
            SearchText = "";
            //reload view
            Search();
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