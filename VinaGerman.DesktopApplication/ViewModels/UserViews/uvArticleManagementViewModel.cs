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
    public class uvArticleManagementViewModel : uvBaseViewModel
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
                RaisePropertyChanged("CanSave");
                RaisePropertyChanged("CanDelete");
            }
        }

        public bool CanSave
        {
            get
            {
                return _selectedArticle != null;
            }
        }

        public bool CanDelete
        {
            get
            {
                return _selectedArticle != null && _selectedArticle.ArticleId > 0;
            }
        }

        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion


        public uvArticleManagementViewModel(MainWindowViewModel pMainWindowViewModel)
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
        public void AddOrUpdateArticle(ArticleEntity newEntity)
        {
            ArticleEntity oldEntity = ArticleList.FirstOrDefault<ArticleEntity>(p => p.ArticleId == newEntity.ArticleId);

            if (oldEntity == null)
            {
                ArticleList.Insert(0, newEntity);
            }
            else
            {
                int index = ArticleList.IndexOf(oldEntity);
                ArticleList.Remove(oldEntity);
                ArticleList.Insert(index, newEntity);
            }

            ArticleList = new List<ArticleEntity>(_articleList);
        }
        public void DeleteArticle(ArticleEntity newEntity)
        {
            ArticleEntity oldEntity = ArticleList.FirstOrDefault<ArticleEntity>(p => p.ArticleId == newEntity.ArticleId);

            if (oldEntity != null)
            {
                ArticleList.Remove(oldEntity);
            }

            ArticleList = new List<ArticleEntity>(_articleList);
        }
        public void Add()
        {
            var newEntity = new ArticleEntity()
            {
                Deleted = false,
                Description = ""
            };
            SelectedArticle = newEntity;
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

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteArticle(SelectedArticle);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteArticle(SelectedArticle);
                            SelectedArticle = null;
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

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateArticle(SelectedArticle);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SelectedArticle = updatedEntity;
                        AddOrUpdateArticle(SelectedArticle);
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

                    var list = Factory.Resolve<IBaseDataDS>().SearchArticle(new ArticleSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ArticleList = list;
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
