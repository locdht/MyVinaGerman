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
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion


        public uvCompanyManagementViewModel(MainWindowViewModel pMainWindowViewModel)
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
        public void AddOrUpdateCompany(CompanyEntity newEntity)
        {
            CompanyEntity oldEntity = CompanyList.FirstOrDefault<CompanyEntity>(p => p.CompanyId == newEntity.CompanyId);

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

                        var updatedEntity = Factory.Resolve<ICompanyDS>().DeleteCompany(SelectedCompany);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteCompany(SelectedCompany);
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
        public void Save()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var updatedEntity = Factory.Resolve<ICompanyDS>().AddOrUpdateCompany(SelectedCompany);

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

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        CompanyList = list;
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
        #endregion
    }
}
