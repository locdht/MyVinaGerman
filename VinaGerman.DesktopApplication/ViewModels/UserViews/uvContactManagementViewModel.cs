using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VinaGerman.DataSource;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Ultilities;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvContactManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
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
                RaisePropertyChanged("CanSave");
                RaisePropertyChanged("CanDelete");
                if (SelectedContact != null)
                {
                    SelectedCompany = CompanyList.FirstOrDefault(c => c.CompanyId == SelectedContact.CompanyId);
                }
            }
        }

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

                if (SelectedContact != null && SelectedCompany != null)
                {
                    SelectedContact.CompanyId = SelectedCompany.CompanyId;
                }

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

        private VinaGerman.Entity.BusinessEntity.DepartmentEntity _selectedDepartment;
        public VinaGerman.Entity.BusinessEntity.DepartmentEntity SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                RaisePropertyChanged("SelectedDepartment");

                if (SelectedContact != null && SelectedCompany != null && SelectedDepartment != null)
                {
                    SelectedContact.CompanyId = SelectedCompany.CompanyId;
                    SelectedContact.DepartmentId = SelectedDepartment.DepartmentId;
                }

            }
        }
        
        public bool CanSave
        {
            get
            {
                return _selectedContact != null;
            }
        }

        public bool CanDelete
        {
            get
            {
                return _selectedContact != null && _selectedContact.ContactId > 0;
            }
        }

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion


        public uvContactManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchCommand = new RelayCommand(Search);
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);
            ClearSearch();
        }
        #region method
        public void AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.ContactEntity oldEntity = ContactList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.ContactEntity>(p => p.ContactId == newEntity.ContactId);

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
        public void DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.ContactEntity oldEntity = ContactList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.ContactEntity>(p => p.ContactId == newEntity.ContactId);

            if (oldEntity != null)
            {
                ContactList.Remove(oldEntity);
            }

            ContactList = new List<VinaGerman.Entity.BusinessEntity.ContactEntity>(_contactList);
        }
        public void Add()
        {
            var newEntity = new VinaGerman.Entity.BusinessEntity.ContactEntity()
            {
                Deleted = false,
                FullName="",
                Email="",
                Phone="",
                Address="",
                CompanyId=0,
                UserAccountId=0,
                Position="",
                DepartmentId=0,
            };
            SelectedContact = newEntity;
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

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteContact(SelectedContact);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteContact(SelectedContact);
                            SelectedContact = null;
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

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateContact(SelectedContact);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectedContact = updatedEntity;
                        AddOrUpdateContact(SelectedContact);
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchContact(new ContactSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

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
            //ShowDialog<uvCompanyDetailViewModel>(new uvCompanyDetailViewModel() { 
            //    OriginalCompany = SelectCompany
            //});
        }

        public void Reload()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var list = Factory.Resolve<IBaseDataDS>().SearchContact(new ContactSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    var Companylist = Factory.Resolve<ICompanyDS>().SearchCompanies(new CompanySearchEntity()
                    {
                        SearchText = ""
                    });

                    var Departmentlist = Factory.Resolve<IBaseDataDS>().SearchDepartment(new DepartmentSearchEntity()
                    {
                        SearchText = ""
                    });
                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ContactList = list;
                        CompanyList = Companylist;
                        this.DepartmentList = Departmentlist;
                    }));
                }
                catch (Exception ex)
                {
                    HideLoading();
                    ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                }
            });
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
            //reload list
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
