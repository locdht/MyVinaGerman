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
    public class uvBusinessManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
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
                RaisePropertyChanged("CanSave");
                RaisePropertyChanged("CanDelete");
            }
        }

        public bool CanSave
        {
            get
            {
                return _selectedBusiness != null;
            }
        }

        public bool CanDelete
        {
            get
            {
                return _selectedBusiness != null && _selectedBusiness.BusinessId > 0;
            }
        }

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion


        public uvBusinessManagementViewModel(MainWindowViewModel pMainWindowViewModel)
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
        public void AddOrUpdateBusiness(BusinessEntity newEntity)
        {
            BusinessEntity oldEntity = BusinessList.FirstOrDefault<BusinessEntity>(p => p.BusinessId == newEntity.BusinessId);

            if (oldEntity == null)
            {
                BusinessList.Insert(0, newEntity);
            }
            else
            {
                int index = BusinessList.IndexOf(oldEntity);
                BusinessList.Remove(oldEntity);
                BusinessList.Insert(index, newEntity);
            }

            BusinessList = new List<BusinessEntity>(_businessList);
        }
        public void DeleteBusiness(BusinessEntity newEntity)
        {
            BusinessEntity oldEntity = BusinessList.FirstOrDefault<BusinessEntity>(p => p.BusinessId == newEntity.BusinessId);

            if (oldEntity != null)
            {
                BusinessList.Remove(oldEntity);
            }

            BusinessList = new List<BusinessEntity>(_businessList);
        }
        public void Add()
        {
            var newEntity = new BusinessEntity()
            {
                Deleted = false,
                Description = ""
            };
            SelectedBusiness = newEntity;
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

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteBusiness(SelectedBusiness);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteBusiness(SelectedBusiness);
                            SelectedBusiness = null;
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

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateBusiness(SelectedBusiness);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectedBusiness = updatedEntity;
                        AddOrUpdateBusiness(SelectedBusiness);
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchBusiness(new BusinessSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        BusinessList = list;
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
            //reload list
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
