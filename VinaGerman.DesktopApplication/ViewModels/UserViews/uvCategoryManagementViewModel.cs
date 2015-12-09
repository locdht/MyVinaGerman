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
    public class uvCategoryManagementViewModel : uvBaseViewModel
    {
        //search customer model
        #region properties
        private List<CategoryEntity> _categoryList = null;
        public List<CategoryEntity> CategoryList 
        {
            get
            {
                return _categoryList;
            }
            set
            {
                _categoryList = value;
                RaisePropertyChanged("CategoryList");
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
        public RelayCommand<CategoryEntity> SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<CategoryEntity> DeleteCommand { get; set; }
        #endregion


        public uvCategoryManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchCommand = new RelayCommand(Search);
            SaveCommand = new RelayCommand<CategoryEntity>(Save);
            DeleteCommand = new RelayCommand<CategoryEntity>(Delete);
            AddCommand = new RelayCommand(Add);

            ClearSearch();
        }
        #region method
        public void AddOrUpdateCategory(CategoryEntity newEntity)
        {
            CategoryEntity oldEntity = CategoryList.FirstOrDefault<CategoryEntity>(p => p.Description == newEntity.Description);

            if (oldEntity == null)
            {
                CategoryList.Insert(0, newEntity);
            }
            else
            {
                int index = CategoryList.IndexOf(oldEntity);
                CategoryList.Remove(oldEntity);
                CategoryList.Insert(index, newEntity);
            }

            CategoryList = new List<CategoryEntity>(_categoryList);
        }
        public void DeleteCategory(CategoryEntity newEntity)
        {
            CategoryEntity oldEntity = CategoryList.FirstOrDefault<CategoryEntity>(p => p.CategoryId == newEntity.CategoryId);

            if (oldEntity != null)
            {
                CategoryList.Remove(oldEntity);
            }

            CategoryList = new List<CategoryEntity>(_categoryList);
        }
        public void Add()
        {
            var newEntity = new CategoryEntity()
            {
                Deleted = false,
                Description = "",
                CategoryId=-1
            };
            CategoryList.Add(newEntity);
            CategoryList = new List<CategoryEntity>(_categoryList);
        }
        
        public void Delete(CategoryEntity entityObject)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteCategory(entityObject);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteCategory(entityObject);
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

        public void Save(CategoryEntity entityObject)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateCategory(entityObject);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        AddOrUpdateCategory(updatedEntity);
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchCategories(new CategorySearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        CategoryList = list;
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
