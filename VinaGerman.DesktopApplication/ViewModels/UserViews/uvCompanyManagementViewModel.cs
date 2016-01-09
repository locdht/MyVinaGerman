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
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvCompanyManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
        private List<CompanyEntity> _companyList = null;
        public List<CompanyEntity> CompanyList 
        {
            get
            {
                return _companyList;
            }
            set
            {
                _companyList = value;
                RaisePropertyChanged("CompanyList");
                ContactList = null;
            }
        }

        private CompanyEntity _selectedCompany;
        public CompanyEntity SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            set
            {
                _selectedCompany = value;
                RaisePropertyChanged("SelectedCompany");
                RaisePropertyChanged("CanSave");
                RaisePropertyChanged("CanDelete");

                if (SelectedCompany != null)
                {
                    LoadContactForCompany();
                }
            }
        }

        private CompanyEntity _relatedCompany;
        public CompanyEntity RelatedCompany
        {
            get
            {
                return _relatedCompany;
            }
            set
            {
                _relatedCompany = value;
                RaisePropertyChanged("SelectedCompany");
                RaisePropertyChanged("CanAddRelatedCompany");
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

        private bool _isSupplier;
        public bool IsSupplier
        {
            get
            {
                return _isSupplier;
            }
            set
            {
                _isSupplier = value;
                RaisePropertyChanged("IsSupplier");
            }
        }

        private bool _isCustomer;
        public bool IsCustomer
        {
            get
            {
                return _isCustomer;
            }
            set
            {
                _isCustomer = value;
                RaisePropertyChanged("IsCustomer");
            }
        }

        private List<VinaGerman.Entity.BusinessEntity.ContactEntity> _contactList = null;
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
            }
        }

        private List<VinaGerman.Entity.BusinessEntity.DepartmentEntity> _departmentList = null;
        public List<VinaGerman.Entity.BusinessEntity.DepartmentEntity> DepartmentList
        {
            get
            {
                return _departmentList;
            }
            set
            {
                _departmentList = value;
                RaisePropertyChanged("DepartmentList");
            }
        }
        public bool CanSave
        {
            get
            {
                return _selectedCompany != null;
            }
        }

        public bool CanDelete
        {
            get
            {
                return _selectedCompany != null && _selectedCompany.CompanyId > 0;
            }
        }

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand<CompanyEntity> SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<CompanyEntity> DeleteCommand { get; set; }
        #endregion

        public RelayCommand<VinaGerman.Entity.BusinessEntity.ContactEntity> SaveContactCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand<VinaGerman.Entity.BusinessEntity.ContactEntity> DeleteContactCommand { get; set; }

        public uvCompanyManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchCommand = new RelayCommand(Search);
            SaveCommand = new RelayCommand<CompanyEntity>(Save);
            DeleteCommand = new RelayCommand<CompanyEntity>(Delete);
            AddCommand = new RelayCommand(Add);

            SaveContactCommand = new RelayCommand<VinaGerman.Entity.BusinessEntity.ContactEntity>(SaveContact);
            DeleteContactCommand = new RelayCommand<VinaGerman.Entity.BusinessEntity.ContactEntity>(DeleteContact);
            AddContactCommand = new RelayCommand(AddContact);

            ClearSearch();
        }
        #region method
        public void AddOrUpdateCompany(CompanyEntity newEntity)
        {
            CompanyEntity oldEntity = CompanyList.FirstOrDefault<CompanyEntity>(p => p.CompanyCode == newEntity.CompanyCode);

            if (oldEntity == null)
            {
                CompanyList.Insert(0, newEntity);
            }
            else
            {
                int index = CompanyList.IndexOf(oldEntity);
                CompanyList.Remove(oldEntity);
                CompanyList.Insert(index, newEntity);
            }

            CompanyList = new List<CompanyEntity>(_companyList);            
        }
        public void DeleteCompany(CompanyEntity newEntity)
        {
            CompanyEntity oldEntity = CompanyList.FirstOrDefault<CompanyEntity>(p => p.CompanyId == newEntity.CompanyId);

            if (oldEntity != null)
            {
                CompanyList.Remove(oldEntity);
            }
           
            CompanyList = new List<CompanyEntity>(_companyList);
        } 
        public void Add()
        {
            var newEntity = new CompanyEntity() {
                CompanyId = -1,
                CompanyOwner= ApplicationHelper.CurrentUserProfile.CompanyId,
                Deleted = false,
                IsCustomer = true,
                IsSupplier = true,
                TaxCode = "",
                CompanyCode = "",
                Address = "",
                Phone = "",
                Website = ""
            };
            SelectedCompany = newEntity;
            CompanyList.Add(newEntity);
            CompanyList = new List<CompanyEntity>(_companyList);
        }
        public void Delete(CompanyEntity entityObject)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<ICompanyDS>().DeleteCompany(entityObject);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteCompany(entityObject);
                            SelectedCompany = null;
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
        public void Save(CompanyEntity entityObject)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var updatedEntity = Factory.Resolve<ICompanyDS>().AddOrUpdateCompany(entityObject);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectedCompany = updatedEntity;
                        AddOrUpdateCompany(SelectedCompany);
                    }));
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });            
        }
        public void Search()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var list = Factory.Resolve<ICompanyDS>().SearchCompanies(new CompanySearchEntity()
                    {
                        SearchText = this.SearchText,
                        IsCustomer = this.IsCustomer,
                        IsSupplier = this.IsSupplier,
                        NotIncludedCompany = ApplicationHelper.CurrentUserProfile.CompanyId
                    });

                    var _Departmentlist = Factory.Resolve<ICompanyDS>().SearchDepartment(new DepartmentSearchEntity()
                    {
                        SearchText = ""
                    });
                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        CompanyList = list;
                        DepartmentList = _Departmentlist;
                        SelectedCompany = CompanyList.FirstOrDefault();
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
            IsCustomer = false;
            IsSupplier = false;
        }

        public void LoadContactForCompany()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var list = Factory.Resolve<ICompanyDS>().GetContactForCompany(SelectedCompany);

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

        public void SaveContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var updatedEntity = Factory.Resolve<ICompanyDS>().AddOrUpdateContact(entityObject);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        AddOrUpdateContact(updatedEntity);
                    }));
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });
        }

        public void AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.ContactEntity oldEntity = ContactList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.ContactEntity>(p => p.FullName == newEntity.FullName);

            if (oldEntity == null)
            {
                ContactList.Insert(0, newEntity);
            }
            else
            {
                int index = ContactList.IndexOf(oldEntity);
                ContactList.Remove(oldEntity);
                ContactList.Insert(index, newEntity);
            }

            ContactList = new List<VinaGerman.Entity.BusinessEntity.ContactEntity>(_contactList);
        }

        public void DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteContact(entityObject);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteContactForCompany(entityObject);
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

        public void DeleteContactForCompany(VinaGerman.Entity.BusinessEntity.ContactEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.ContactEntity oldEntity = ContactList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.ContactEntity>(p => p.ContactId == newEntity.ContactId);

            if (oldEntity != null)
            {
                ContactList.Remove(oldEntity);
            }

            ContactList = new List<VinaGerman.Entity.BusinessEntity.ContactEntity>(_contactList);
        }

        public void AddContact()
        {
            var newEntity = new VinaGerman.Entity.BusinessEntity.ContactEntity()
            {
                Deleted = false,
                FullName = "",
                Email = "",
                Phone = "",
                Address = "",
                CompanyId = SelectedCompany.CompanyId,
                UserAccountId = ApplicationHelper.CurrentUserProfile.UserAccountId,
                Position = "",
                DepartmentId = -1,
                ContactId = -1
            };
            ContactList.Add(newEntity);
            ContactList = new List<VinaGerman.Entity.BusinessEntity.ContactEntity>(_contactList);
        }
        #endregion

        #region Message processing
        public override void Reset()
        {
            ClearSearch();
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
