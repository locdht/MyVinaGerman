using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VinaGerman.DataSource;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Utilities;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvPurchaseOrderManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties

        private List<OrderEntity> _orderList = null;
        public List<OrderEntity> OrderList
        {
            get
            {
                return _orderList;
            }
            set
            {
                _orderList = value;
                RaisePropertyChanged("OrderList");
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

        private List<BusinessEntity> _businessList = null;
        public List<BusinessEntity> BusinessList
        {
            get
            {
                return _businessList;
            }
            set
            {
                _businessList = value;
                RaisePropertyChanged("BusinessList");
            }
        }

        private BusinessEntity _selectedBusiness;
        public BusinessEntity SelectedBusiness
        {
            get
            {
                return _selectedBusiness;
            }
            set
            {
                _selectedBusiness = value;
                RaisePropertyChanged("SelectedBusiness");
            }
        }

        private List<IndustryEntity> _industryList = null;
        public List<IndustryEntity> IndustryList
        {
            get
            {
                return _industryList;
            }
            set
            {
                _industryList = value;
                RaisePropertyChanged("IndustryList");
            }
        }

        private IndustryEntity _selectedIndustry;
        public IndustryEntity SelectedIndustry
        {
            get
            {
                return _selectedIndustry;
            }
            set
            {
                _selectedIndustry = value;
                RaisePropertyChanged("SelectedIndustry");
            }
        }
        public RelayCommand<OrderEntity> OpenOrderCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        #endregion


        public uvPurchaseOrderManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            SearchCommand = new RelayCommand(Search);
            OpenOrderCommand = new RelayCommand<OrderEntity>(OpenOrder);
            ClearSearch();
        }
        #region method      
        public void OpenOrder(OrderEntity entityObject)
        {
            if (entityObject != null && entityObject.OrderId > 0)
            {
                Dictionary<string, object> dicParams = new Dictionary<string, object>();
                dicParams.Add("Order", entityObject);
                SendMessage(MessageToken.ReloadMessage, dicParams, enumView.PurchaseOrderDetail.ToString());
                GoToView(enumView.PurchaseOrderDetail);
            }
        }
        public void Search()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var list = Factory.Resolve<IBaseDataDS>().SearchOrder(new OrderSearchEntity()
                    {
                        SearchText = this.SearchText,
                        BusinessId = SelectedBusiness!=null?SelectedBusiness.BusinessId:0,
                        IndustryId = SelectedIndustry != null?SelectedIndustry.IndustryId:0,
                        OrderType=(int)enumOrderType.Purchase
                    });
                    var _obusinessList = Factory.Resolve<IBaseDataDS>().SearchBusiness(new BusinessSearchEntity()
                    {
                        SearchText = ""
                    });

                    var _oindustryList = Factory.Resolve<IBaseDataDS>().SearchIndustry(new IndustrySearchEntity()
                    {
                        SearchText = ""
                    });
                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        OrderList = list.Where(c => c.OrderType == (int)enumOrderType.Purchase).ToList(); ;
                        BusinessEntity itbs = new BusinessEntity() {BusinessId=0,Description="" };
                        BusinessList = _obusinessList;
                        BusinessList.Insert(0, itbs);
                        SelectedBusiness = BusinessList.FirstOrDefault();
                        IndustryEntity itin = new IndustryEntity() { IndustryId=0,Description=""};
                        IndustryList = _oindustryList;
                        IndustryList.Insert(0, itin);
                        SelectedIndustry = IndustryList.FirstOrDefault();
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
