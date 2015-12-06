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
using VinaGerman.DesktopApplication.Ultilities;
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
                    LoadRelatedOrders();
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

                if (SelectedOrder != null && SelectedCustomer != null)
                {
                    SelectedOrder.CustomerCompanyId = SelectedCustomer.CompanyId;
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

                if (SelectedOrder != null && SelectedContact != null)
                {
                    SelectedOrder.CustomerContactId = SelectedContact.ContactId;
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

                if (SelectedOrder != null && SelectedEmployee != null)
                {
                    SelectedOrder.CreatedBy = SelectedEmployee.UserAccountId;
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

                if (SelectedOrder != null && SelectedBusiness != null)
                {
                    SelectedOrder.BusinessId = SelectedBusiness.BusinessId;
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

                if (SelectedOrder != null && SelectedIndustry != null)
                {
                    SelectedOrder.IndustryId = SelectedIndustry.IndustryId;
                }
            }
        }


        private OrderEntity _relatedOrder;
        public OrderEntity RelatedOrder
        {
            get
            {
                return _relatedOrder;
            }
            set
            {
                _relatedOrder = value;
                RaisePropertyChanged("SelectedOrder");
                RaisePropertyChanged("CanAddRelatedOrder");
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
                RaisePropertyChanged("SelectedOrder");
                RaisePropertyChanged("CanAddRelatedArticle");
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

        public bool CanSave
        {
            get
            {
                return _selectedOrder != null;
            }
        }

        public bool CanDelete
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

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public RelayCommand SaveOrderRelationCommand { get; set; }
        public RelayCommand<OrderlineEntity> DeleteOrderRelationCommand { get; set; }

        public RelayCommand SaveOrderRelationLoanCommand { get; set; }
        public RelayCommand<LoanEntity> DeleteOrderRelationLoanCommand { get; set; }
        #endregion


        public uvPurchaseOrderDetailViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchCommand = new RelayCommand(Search);
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);

            SaveOrderRelationCommand = new RelayCommand(SaveOrderRelation);
            DeleteOrderRelationCommand = new RelayCommand<OrderlineEntity>(DeleteOrderRelation);

            SaveOrderRelationLoanCommand = new RelayCommand(SaveOrderRelationLoan);
            DeleteOrderRelationLoanCommand = new RelayCommand<LoanEntity>(DeleteOrderRelationLoan);

            ClearSearch();
        }
        #region method      
        
        


        public void Add()
        {
            var newEntity = new OrderEntity()
            {
                OrderType = 0,
                BusinessId=0,
                IndustryId=0,
                CreatedBy=0,
                ResponsibleBy=0,
                OrderDate=DateTime.Today,
                CreatedDate=DateTime.Today,
                CustomerCompanyId=0,
                CustomerContactId=0,
                OrderNumber="",
                Description = ""
            };
            SelectedOrder = newEntity;
        }
        public void Delete()
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
                            SelectedOrder = null;
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
        public void Save()
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
        public void SaveOrderRelation()
        {
            if (SelectedOrder != null && SelectedOrder.OrderId > 0 && RelatedOrder != null && RelatedOrder.OrderId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        OrderlineEntity newEntity = new OrderlineEntity()
                        {
                            OrderId = SelectedOrder.OrderId,
                            ArticleId = RelatedArticle.ArticleId,
                        };
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateOrderRelation(newEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            AddOrUpdateOrderRelation(updatedEntity);
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
        public void AddOrUpdateOrderRelation(OrderlineEntity newEntity)
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
        }
        public void DeleteOrderRelation(OrderlineEntity relationEntity)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var isSuccess = Factory.Resolve<IBaseDataDS>().DeleteOrderRelation(relationEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            if (isSuccess)
                            {
                                DeleteOrderRelationFromList(relationEntity);
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
        public void DeleteOrderRelationFromList(OrderlineEntity newEntity)
        {
            OrderlineEntity oldEntity = OrderlineList.FirstOrDefault<OrderlineEntity>(p => p.OrderlineId == newEntity.OrderlineId);

            if (oldEntity != null)
            {
                OrderlineList.Remove(oldEntity);
            }

            OrderlineList = new List<OrderlineEntity>(_orderlineList);
        }

        public void SaveOrderRelationLoan()
        {
            if (SelectedOrder != null && SelectedOrder.OrderId > 0 && RelatedOrder != null && RelatedOrder.OrderId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        LoanEntity newEntity = new LoanEntity()
                        {
                            OrderId = SelectedOrder.OrderId,
                            ArticleId = RelatedArticle.ArticleId,
                        };
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateOrderRelationLoan(newEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            AddOrUpdateOrderRelationLoan(updatedEntity);
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
        public void AddOrUpdateOrderRelationLoan(LoanEntity newEntity)
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

            OrderlineList = new List<OrderlineEntity>(_orderlineList);
        }

        public void DeleteOrderRelationLoan(LoanEntity relationEntity)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var isSuccess = Factory.Resolve<IBaseDataDS>().DeleteOrderRelationLoan(relationEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            if (isSuccess)
                            {
                                DeleteOrderRelationLoanFromList(relationEntity);
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
        public void DeleteOrderRelationLoanFromList(LoanEntity newEntity)
        {
            LoanEntity oldEntity = LoanList.FirstOrDefault<LoanEntity>(p => p.LoanId == newEntity.LoanId);

            if (oldEntity != null)
            {
                LoanList.Remove(oldEntity);
            }

            LoanList = new List<LoanEntity>(_loanList);
        }
        
        public void LoadRelatedOrders()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var _oOrderlineList = Factory.Resolve<IBaseDataDS>().GetOrderRelationsForOrder(SelectedOrder);
                    var _oLoanList = Factory.Resolve<IBaseDataDS>().GetOrderRelationsLoanForOrder(SelectedOrder);
                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        OrderlineList = _oOrderlineList;
                        LoanList = _oLoanList;
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

        public void Reload()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var _ocompanyList = Factory.Resolve<ICompanyDS>().SearchCompanies(new CompanySearchEntity()
                    {
                        SearchText = ""
                    });

                    var _ocontactList = Factory.Resolve<IBaseDataDS>().SearchContact(new ContactSearchEntity()
                    {
                        SearchText = ""
                    });

                    var _oUserProfileList = Factory.Resolve<ICommonDS>().GetUserProfile("admin", "123456");

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
                    HideLoading();

                    //display to UI UserProfileEntity
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        CustomerList = _ocompanyList;
                        ContactList = _ocontactList;
                        EmployeeList.Clear();
                        EmployeeList.Add(_oUserProfileList);
                        BusinessList = _obusinessList;
                        IndustryList = _oindustryList;
                        ArticleList = _oArticleList;
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
        public override void Reset()
        {
            //reset left panel
            SearchText = "";
            //reload view
            Reload();
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