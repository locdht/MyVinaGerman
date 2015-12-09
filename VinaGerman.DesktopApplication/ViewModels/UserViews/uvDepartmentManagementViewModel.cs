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
    public class uvDepartmentManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
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
                RaisePropertyChanged("CanSave");
                RaisePropertyChanged("CanDelete");
                if (SelectedDepartment != null)
                {
                    SelectedCompany = CompanyList.FirstOrDefault(c => c.CompanyId == SelectedDepartment.CompanyId);
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

                if (SelectedDepartment != null && SelectedCompany != null)
                {
                    SelectedDepartment.CompanyId = SelectedCompany.CompanyId;
                }

            }
        }
        public bool CanSave
        {
            get
            {
                return _selectedDepartment != null;
            }
        }

        public bool CanDelete
        {
            get
            {
                return _selectedDepartment != null && _selectedDepartment.DepartmentId > 0;
            }
        }

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion


        public uvDepartmentManagementViewModel(MainWindowViewModel pMainWindowViewModel)
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
        public void AddOrUpdateDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.DepartmentEntity oldEntity = DepartmentList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.DepartmentEntity>(p => p.DepartmentId == newEntity.DepartmentId);

            if (oldEntity == null)
            {
                DepartmentList.Insert(0, newEntity);
            }
            else
            {
                int index = DepartmentList.IndexOf(oldEntity);
                DepartmentList.Remove(oldEntity);
                DepartmentList.Insert(index, newEntity);
            }

            DepartmentList = new List<VinaGerman.Entity.BusinessEntity.DepartmentEntity>(_departmentList);
        }
        public void DeleteDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.DepartmentEntity oldEntity = DepartmentList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.DepartmentEntity>(p => p.DepartmentId == newEntity.DepartmentId);

            if (oldEntity != null)
            {
                DepartmentList.Remove(oldEntity);
            }

            DepartmentList = new List<VinaGerman.Entity.BusinessEntity.DepartmentEntity>(_departmentList);
        }
        public void Add()
        {
            var newEntity = new VinaGerman.Entity.BusinessEntity.DepartmentEntity()
            {
                Deleted = false,
                Description = "",
                CompanyId=0
            };
            SelectedDepartment = newEntity;
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

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteDepartment(SelectedDepartment);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteDepartment(SelectedDepartment);
                            SelectedDepartment = null;
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

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateDepartment(SelectedDepartment);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectedDepartment = updatedEntity;
                        AddOrUpdateDepartment(SelectedDepartment);
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchDepartment(new DepartmentSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        DepartmentList = list;
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchDepartment(new DepartmentSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    var Companylist = Factory.Resolve<ICompanyDS>().SearchCompanies(new CompanySearchEntity()
                    {
                        SearchText = ""
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        DepartmentList = list;
                        CompanyList = Companylist;
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
