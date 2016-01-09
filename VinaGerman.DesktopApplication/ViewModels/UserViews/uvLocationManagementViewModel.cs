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
    public class uvLocationManagementViewModel : uvBaseViewModel
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
        public RelayCommand<VinaGerman.Entity.BusinessEntity.LocationEntity> SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<VinaGerman.Entity.BusinessEntity.LocationEntity> DeleteCommand { get; set; }
        #endregion


        public uvLocationManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchCommand = new RelayCommand(Search);
            SaveCommand = new RelayCommand<VinaGerman.Entity.BusinessEntity.LocationEntity>(Save);
            DeleteCommand = new RelayCommand<VinaGerman.Entity.BusinessEntity.LocationEntity>(Delete);
            AddCommand = new RelayCommand(Add);
            ClearSearch();
        }
        #region method
        public void AddOrUpdateLocation(VinaGerman.Entity.BusinessEntity.LocationEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.LocationEntity oldEntity = LocationList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.LocationEntity>(p => p.Description == newEntity.Description);

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

            LocationList = new List<VinaGerman.Entity.BusinessEntity.LocationEntity>(_locationList);
        }
        public void DeleteLocation(VinaGerman.Entity.BusinessEntity.LocationEntity newEntity)
        {
            VinaGerman.Entity.BusinessEntity.LocationEntity oldEntity = LocationList.FirstOrDefault<VinaGerman.Entity.BusinessEntity.LocationEntity>(p => p.LocationId == newEntity.LocationId);

            if (oldEntity != null)
            {
                LocationList.Remove(oldEntity);
            }

            LocationList = new List<VinaGerman.Entity.BusinessEntity.LocationEntity>(_locationList);
        }
        public void Add()
        {
            var newEntity = new VinaGerman.Entity.BusinessEntity.LocationEntity()
            {
                Deleted = false,
                Description = "",
                Address="",
                CompanyId = ApplicationHelper.CurrentUserProfile.CompanyId,
                LocationId=-1
            };
            LocationList.Add(newEntity);
            LocationList = new List<VinaGerman.Entity.BusinessEntity.LocationEntity>(_locationList);
        }

        public void Delete(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<ICompanyDS>().DeleteLocation(entityObject);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteLocation(entityObject);
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
        public void Save(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var updatedEntity = Factory.Resolve<ICompanyDS>().AddOrUpdateLocation(entityObject);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        AddOrUpdateLocation(updatedEntity);
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

                    var list = Factory.Resolve<ICompanyDS>().SearchLocation(new LocationSearchEntity()
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
