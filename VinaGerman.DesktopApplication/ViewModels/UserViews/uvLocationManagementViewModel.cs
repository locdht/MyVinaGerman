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
    public class uvLocationManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
        private List<LocationEntity> _locationList = null;
        public List<LocationEntity> LocationList 
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

        private LocationEntity _selectedLocation;
        public LocationEntity SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                _selectedLocation = value;
                RaisePropertyChanged("SelectedLocation");
                RaisePropertyChanged("CanSave");
                RaisePropertyChanged("CanDelete");
                if (SelectedLocation != null)
                {
                    SelectedCompany = CompanyList.FirstOrDefault(c => c.CompanyId == SelectedLocation.CompanyId);
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

                if (SelectedLocation != null && SelectedCompany != null)
                {
                    SelectedLocation.CompanyId = SelectedCompany.CompanyId;
                }

            }
        }
        public bool CanSave
        {
            get
            {
                return _selectedLocation != null;
            }
        }

        public bool CanDelete
        {
            get
            {
                return _selectedLocation != null && _selectedLocation.LocationId > 0;
            }
        }

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion


        public uvLocationManagementViewModel(MainWindowViewModel pMainWindowViewModel)
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
        public void AddOrUpdateLocation(LocationEntity newEntity)
        {
            LocationEntity oldEntity = LocationList.FirstOrDefault<LocationEntity>(p => p.LocationId == newEntity.LocationId);

            if (oldEntity == null)
            {
                LocationList.Insert(0, newEntity);
            }
            else
            {
                int index = LocationList.IndexOf(oldEntity);
                LocationList.Remove(oldEntity);
                LocationList.Insert(index, newEntity);
            }

            LocationList = new List<LocationEntity>(_locationList);
        }
        public void DeleteLocation(LocationEntity newEntity)
        {
            LocationEntity oldEntity = LocationList.FirstOrDefault<LocationEntity>(p => p.LocationId == newEntity.LocationId);

            if (oldEntity != null)
            {
                LocationList.Remove(oldEntity);
            }

            LocationList = new List<LocationEntity>(_locationList);
        }
        public void Add()
        {
            var newEntity = new LocationEntity()
            {
                Deleted = false,
                Description = "",
                CompanyId=0
            };
            SelectedLocation = newEntity;
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

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteLocation(SelectedLocation);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteLocation(SelectedLocation);
                            SelectedLocation = null;
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

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateLocation(SelectedLocation);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectedLocation = updatedEntity;
                        AddOrUpdateLocation(SelectedLocation);
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchLocation(new LocationSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        LocationList = list;
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchLocation(new LocationSearchEntity()
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
                        LocationList = list;
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
