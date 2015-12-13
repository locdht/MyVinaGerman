using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using VinaGerman.DataSource;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Utilities;
using VinaGerman.DesktopApplication.ViewModels.ReportViews;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvPurchaseOrderDetailViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
        private List<VinaGerman.Entity.BusinessEntity.LocationEntity> _locationList = null;
        public List<VinaGerman.Entity.BusinessEntity.LocationEntity> LocationList
        {
            get
            {
                return _locationList;
            }
            set
            {
                _locationList = value;
                RaisePropertyChanged("LocationList");
            }
        }

        private List<ArticleEntity> _articleList = null;
        public List<ArticleEntity> ArticleList
        {
            get
            {
                return _articleList;
            }
            set
            {
                _articleList = value;
                RaisePropertyChanged("ArticleList");

                //SelectedArticle = null;
                //ArticleRelationList = null;
                RelatedArticle = null;
            }
        }

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

        private OrderEntity _selectedOrder;
        public OrderEntity SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                RaisePropertyChanged("SelectedOrder");
                RaisePropertyChanged("CanSave");
                RaisePropertyChanged("CanDelete");

                if (SelectedOrder != null)
                {
                    SelectedCustomer = CustomerList.FirstOrDefault(c => c.CompanyId == SelectedOrder.CustomerCompanyId);
                    SelectedContact = ContactList.FirstOrDefault(c => c.ContactId == SelectedOrder.CustomerContactId);
                    SelectedEmployee = EmployeeList.FirstOrDefault(c => c.UserAccountId == SelectedOrder.CreatedBy);
                    SelectedBusiness = BusinessList.FirstOrDefault(c => c.BusinessId == SelectedOrder.BusinessId);
                    SelectedIndustry = IndustryList.FirstOrDefault(c => c.IndustryId == SelectedOrder.IndustryId);
                    SelectedLocation = LocationList.FirstOrDefault(c => c.LocationId == SelectedOrder.LocationId);
                    SelectedStatus = StatusList.FirstOrDefault(c => c.Key == SelectedOrder.OrderStatus);
                }
            }
        }

        private List<CompanyEntity> _customerList = null;
        public List<CompanyEntity> CustomerList
        {
            get
            {
                return _customerList;
            }
            set
            {
                _customerList = value;
                RaisePropertyChanged("CustomerList");
            }
        }

        private CompanyEntity _selectedCustomer;
        public CompanyEntity SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");

                if (SelectedOrder != null && _selectedCustomer != null)
                {
                    SelectedOrder.CustomerCompanyId = _selectedCustomer.CompanyId;
                    LoadContactForCompany();
                }
            }
        }

        private List<VinaGerman.Entity.BusinessEntity.ContactEntity> _contactList = null;//ContactList
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> ContactList
        {
            get
            {
                return _contactList;
            }
            set
            {
                _contactList = value;
                RaisePropertyChanged("ContactList");
            }
        }

        private VinaGerman.Entity.BusinessEntity.ContactEntity _selectedContact;
        public VinaGerman.Entity.BusinessEntity.ContactEntity SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                RaisePropertyChanged("SelectedContact");

                if (SelectedOrder != null && _selectedContact != null)
                {
                    SelectedOrder.CustomerContactId = _selectedContact.ContactId;
                }
            }
        }

        private List<UserProfileEntity> _employeeList = null;
        public List<UserProfileEntity> EmployeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                RaisePropertyChanged("EmployeeList");
            }
        }

        private UserProfileEntity _selectedEmployee;
        public UserProfileEntity SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");

                if (SelectedOrder != null && _selectedEmployee != null)
                {
                    SelectedOrder.CreatedBy = _selectedEmployee.ContactId;
                }
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

                if (SelectedOrder != null && _selectedBusiness != null)
                {
                    SelectedOrder.BusinessId = _selectedBusiness.BusinessId;
                }
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

                if (SelectedOrder != null && _selectedIndustry != null)
                {
                    SelectedOrder.IndustryId = _selectedIndustry.IndustryId;
                }
            }
        }

        private VinaGerman.Entity.BusinessEntity.LocationEntity _selectedLocation;
        public VinaGerman.Entity.BusinessEntity.LocationEntity SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                _selectedLocation = value;
                RaisePropertyChanged("SelectedLocation");

                if (SelectedOrder != null && _selectedLocation != null)
                {
                    SelectedOrder.LocationId = _selectedLocation.LocationId;
                }
            }
        }

        private ArticleEntity _selectedArticle;
        public ArticleEntity SelectedArticle
        {
            get
            {
                return _selectedArticle;
            }
            set
            {
                _selectedArticle = value;
                RaisePropertyChanged("SelectedArticle");
                RaisePropertyChanged("CanAddOrderline");
            }
        }

        private ArticleEntity _relatedArticle;
        public ArticleEntity RelatedArticle
        {
            get
            {
                return _relatedArticle;
            }
            set
            {
                _relatedArticle = value;
                RaisePropertyChanged("RelatedArticle");
                RaisePropertyChanged("CanAddLoan");
            }
        }

        private OrderlineEntity _selectedOrderline;
        public OrderlineEntity SelectedOrderline
        {
            get
            {
                return _selectedOrderline;
            }
            set
            {
                _selectedOrderline = value;
                RaisePropertyChanged("SelectedOrderline");//SelectedOrderRelation

                LoadLoans();
            }
        }

        private LoanEntity _selectedLoan;
        public LoanEntity SelectedLoan
        {
            get
            {
                return _selectedLoan;
            }
            set
            {
                _selectedLoan = value;
                RaisePropertyChanged("SelectedLoan");
            }
        }

        private KeyValuePair<int, string> _SelectedStatus;
        public KeyValuePair<int, string> SelectedStatus
        {
            get
            {
                return _SelectedStatus;
            }
            set
            {
                _SelectedStatus = value;
                RaisePropertyChanged("SelectedStatus");

                if (SelectedOrder != null)
                {
                    SelectedOrder.OrderStatus = _SelectedStatus.Key;
                }
            }
        }

        public bool CanAddOrderline
        {
            get
            {
                return _selectedOrder != null && _selectedOrder.OrderId > 0 && _selectedArticle != null && _selectedArticle.ArticleId > 0;
            }
        }

        public bool CanAddLoan
        {
            get
            {
                return _selectedOrderline != null && _selectedOrderline.OrderId > 0 && _relatedArticle != null && _relatedArticle.ArticleId > 0;
            }
        }

        public bool CanDeleteOrder
        {
            get
            {
                return _selectedOrder != null && _selectedOrder.OrderId > 0;
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

        private List<KeyValuePair<int, string>> _StatusList;
        public List<KeyValuePair<int,string>> StatusList
        {
            get
            {
                return _StatusList;
            }
            set
            {
                _StatusList = value;
                RaisePropertyChanged("StatusList");
            }
        }
        
        public RelayCommand SaveOrderCommand { get; set; }
        public RelayCommand DeleteOrderCommand { get; set; }
        public RelayCommand ShowReportCommand { get; set; }

        public RelayCommand AddOrderlineCommand { get; set; }
        public RelayCommand<OrderlineEntity> SaveOrderlineCommand { get; set; }
        public RelayCommand<OrderlineEntity> DeleteOrderlineCommand { get; set; }

        public RelayCommand AddLoanCommand { get; set; }
        public RelayCommand<LoanEntity> SaveLoanCommand { get; set; }        
        public RelayCommand<LoanEntity> DeleteLoanCommand { get; set; }
        #endregion


        public uvPurchaseOrderDetailViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            SaveOrderCommand = new RelayCommand(SaveOrder);
            DeleteOrderCommand = new RelayCommand(DeleteOrder);
            ShowReportCommand = new RelayCommand(ShowReport);

            AddOrderlineCommand = new RelayCommand(AddOrderline);
            SaveOrderlineCommand = new RelayCommand<OrderlineEntity>(SaveOrderline);
            DeleteOrderlineCommand = new RelayCommand<OrderlineEntity>(DeleteOrderline);

            AddLoanCommand = new RelayCommand(AddLoan);
            SaveLoanCommand = new RelayCommand<LoanEntity>(SaveLoan);
            DeleteLoanCommand = new RelayCommand<LoanEntity>(DeleteLoan);            
        }
        #region method      
        
        #region order
        public void ShowReport()
        {
            ShowDialog<rvPurchaseOrderDetailViewModel>(new rvPurchaseOrderDetailViewModel() 
            { 
            });
        }        
        public void DeleteOrder()
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteOrder(SelectedOrder);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            GoToView(enumView.PurchaseOrderManagement);
                        }));
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void SaveOrder()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateOrder(SelectedOrder);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectedOrder = updatedEntity;
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
        #endregion

        #region orderline
        public void LoadOrderlines()
        {
            if (SelectedOrder != null && SelectedOrder.OrderId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var _oOrderlineList = Factory.Resolve<IBaseDataDS>().GetOrderlinesForOrder(SelectedOrder);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            OrderlineList = _oOrderlineList;
                            SelectedOrderline = OrderlineList.FirstOrDefault();
                        }));
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void AddOrderline()
        {
            if (SelectedOrder != null && SelectedOrder.OrderId > 0 && SelectedArticle != null && SelectedArticle.ArticleId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        OrderlineEntity newEntity = new OrderlineEntity()
                        {
                            OrderId = SelectedOrder.OrderId,
                            ArticleId = SelectedArticle.ArticleId,
                            Quantity = 0,
                            RemainingQuantity = 0,
                            Price = 0,
                            PayDate = DateTime.Now.AddDays(7)
                        };

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateOrderline(newEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            AddOrUpdateOrderlineToList(updatedEntity);
                        }));
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }        
        public void AddOrUpdateOrderlineToList(OrderlineEntity newEntity)
        {
            if (OrderlineList == null) OrderlineList = new List<OrderlineEntity>();

            OrderlineEntity oldEntity = OrderlineList.FirstOrDefault<OrderlineEntity>(p => p.OrderlineId == newEntity.OrderlineId);

            if (oldEntity == null)
            {
                OrderlineList.Insert(0, newEntity);
            }
            else
            {
                int index = OrderlineList.IndexOf(oldEntity);
                OrderlineList.Remove(oldEntity);
                OrderlineList.Insert(index, newEntity);
            }

            OrderlineList = new List<OrderlineEntity>(_orderlineList);

            SelectedOrderline = newEntity;
        }
        public void SaveOrderline(OrderlineEntity entityObject)
        {
            if (entityObject != null && entityObject.OrderlineId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateOrderline(entityObject);

                        HideLoading();
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void DeleteOrderline(OrderlineEntity entityObject)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var isSuccess = Factory.Resolve<IBaseDataDS>().DeleteOrderline(entityObject);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            if (isSuccess)
                            {
                                DeleteOrderlineFromList(entityObject);
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void DeleteOrderlineFromList(OrderlineEntity newEntity)
        {
            OrderlineEntity oldEntity = OrderlineList.FirstOrDefault<OrderlineEntity>(p => p.OrderlineId == newEntity.OrderlineId);

            if (oldEntity != null)
            {
                OrderlineList.Remove(oldEntity);
            }

            OrderlineList = new List<OrderlineEntity>(_orderlineList);
        }
        #endregion

        #region loan
        public void LoadLoans()
        {
            if (SelectedOrderline != null && SelectedOrderline.OrderlineId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var _oLoanList = Factory.Resolve<IBaseDataDS>().GetLoansForOrderline(SelectedOrderline);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            LoanList = _oLoanList;
                        }));
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void AddLoan()
        {
            if (SelectedOrderline != null && SelectedOrderline.OrderId > 0 && RelatedArticle != null && RelatedArticle.ArticleId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        LoanEntity newEntity = new LoanEntity()
                        {
                            OrderlineId = SelectedOrderline.OrderlineId,
                            ArticleId = RelatedArticle.ArticleId,
                            Quantity = 0,
                            RemainingQuantity = 0
                        };
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateLoan(newEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            AddOrUpdateLoanToList(updatedEntity);
                        }));
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void AddOrUpdateLoanToList(LoanEntity newEntity)
        {
            if (LoanList == null) LoanList = new List<LoanEntity>();

            LoanEntity oldEntity = LoanList.FirstOrDefault<LoanEntity>(p => p.LoanId == newEntity.LoanId);

            if (oldEntity == null)
            {
                LoanList.Insert(0, newEntity);
            }
            else
            {
                int index = LoanList.IndexOf(oldEntity);
                LoanList.Remove(oldEntity);
                LoanList.Insert(index, newEntity);
            }

            LoanList = new List<LoanEntity>(_loanList);
        }
        public void SaveLoan(LoanEntity entityObject)
        {
            if (entityObject != null && entityObject.LoanId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateLoan(entityObject);

                        HideLoading();
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void DeleteLoan(LoanEntity entityObject)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var isSuccess = Factory.Resolve<IBaseDataDS>().DeleteLoan(entityObject);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            if (isSuccess)
                            {
                                DeleteLoanFromList(entityObject);
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        HideLoading();
                        ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                    }
                });
            }
        }
        public void DeleteLoanFromList(LoanEntity newEntity)
        {
            LoanEntity oldEntity = LoanList.FirstOrDefault<LoanEntity>(p => p.LoanId == newEntity.LoanId);

            if (oldEntity != null)
            {
                LoanList.Remove(oldEntity);
            }

            LoanList = new List<LoanEntity>(_loanList);
        }                
        #endregion

        public void LoadContactForCompany()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var list = Factory.Resolve<IBaseDataDS>().GetContactForCompany(SelectedCustomer);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ContactList = list;
                    }));
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });
        }


        public void Reload(OrderEntity order)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    //load order information
                    if (order == null) order = new OrderEntity()
                    {
                        OrderDate = DateTime.Now,
                        OrderNumber = "",
                        OrderType = (int)enumOrderType.Purchase,
                        CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId,
                        CreatedBy = ApplicationHelper.CurrentUserProfile.ContactId,
                        ResponsibleBy = ApplicationHelper.CurrentUserProfile.ContactId,
                        OrderStatus = (int)enumOrderStatus.Ready
                    };

                    _employeeList = new List<UserProfileEntity>();

                    var _ocompanyList = Factory.Resolve<ICompanyDS>().SearchCompanies(new CompanySearchEntity()
                    {
                        SearchText = "",
                        IsSupplier = true
                    });

                    var _ocontactList = Factory.Resolve<IBaseDataDS>().SearchContact(new ContactSearchEntity()
                    {
                        SearchText = ""
                    });                    

                    var _obusinessList = Factory.Resolve<IBaseDataDS>().SearchBusiness(new BusinessSearchEntity()
                    {
                        SearchText = ""
                    });

                    var _oindustryList = Factory.Resolve<IBaseDataDS>().SearchIndustry(new IndustrySearchEntity()
                    {
                        SearchText = ""
                    });

                    var _oArticleList = Factory.Resolve<IBaseDataDS>().SearchArticle(new ArticleSearchEntity()
                    {
                        SearchText = ""
                    });

                    var _oLocationList = Factory.Resolve<IBaseDataDS>().SearchLocation(new LocationSearchEntity()
                    {
                        SearchText = ""
                    });

                    List<UserProfileEntity> _oEmployeeList = new List<UserProfileEntity>();
                    _oEmployeeList.Add(ApplicationHelper.CurrentUserProfile);

                    List<KeyValuePair<int, string>> _oStatusList = new List<KeyValuePair<int, string>>();
                    if (order.OrderStatus == (int)enumOrderStatus.Ready)
                    {
                        _oStatusList.Add(new KeyValuePair<int,string>((int)enumOrderStatus.Ready, StringResources.ORDERSTATUS_READY));
                        _oStatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Approved, StringResources.ORDERSTATUS_APPROVED));
                    }
                    else if (order.OrderStatus == (int)enumOrderStatus.Approved)
                    {
                        _oStatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Approved, StringResources.ORDERSTATUS_APPROVED));
                        _oStatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Processed, StringResources.ORDERSTATUS_PROCESSED));
                    }
                    else if (order.OrderStatus == (int)enumOrderStatus.Approved)
                    {
                        _oStatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Processed, StringResources.ORDERSTATUS_PROCESSED));
                    }
                    else
                    {
                        _oStatusList.Add(new KeyValuePair<int, string>((int)enumOrderStatus.Ready, StringResources.ORDERSTATUS_READY));
                    }
                    HideLoading();

                    //display to UI UserProfileEntity
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        CustomerList = _ocompanyList;
                        ContactList = _ocontactList;
                        EmployeeList = _oEmployeeList;
                        BusinessList = _obusinessList;
                        IndustryList = _oindustryList;
                        ArticleList = _oArticleList;
                        LocationList = _oLocationList;
                        StatusList = _oStatusList;

                        OrderlineList = new List<OrderlineEntity>();
                        LoanList = new List<LoanEntity>();                        

                        SelectedOrder = order;

                        LoadOrderlines();
                    }));
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });
        }
        
        
        #endregion

        #region Message processing
        protected override void MessageHandler(BaseMessage pMessage)
        {
            if (pMessage.Token == MessageToken.ReloadMessage)
            {
                OrderEntity order = null;
                if (pMessage.Parameters != null && pMessage.Parameters.ContainsKey("Order"))
                {
                    order = (OrderEntity)pMessage.Parameters["Order"];                    
                }
                //reset left panel
                SearchText = "";
                //reload view
                Reload(order);
            }
        }
        #endregion
    }
}