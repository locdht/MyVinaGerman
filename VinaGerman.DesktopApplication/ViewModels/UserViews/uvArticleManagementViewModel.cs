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
using VinaGerman.Entity.BusinessEntity;
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

                SelectedArticle = null;
                ArticleRelationList = null;
                RelatedArticle = null;
            }
        }

        private List<ArticleRelationEntity> _articleRelationList = null;
        public List<ArticleRelationEntity> ArticleRelationList
        {
            get
            {
                return _articleRelationList;
            }
            set
            {
                _articleRelationList = value;
                RaisePropertyChanged("ArticleRelationList");
            }
        }

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

        private CategoryEntity _selectedCategory;
        public CategoryEntity SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");

                if (SelectedArticle != null && SelectedCategory != null)
                {
                    SelectedArticle.CategoryId = SelectedCategory.CategoryId;
                }

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

                if (SelectedArticle != null)
                {
                    SelectedCategory = CategoryList.FirstOrDefault(c => c.CategoryId == SelectedArticle.CategoryId);

                    LoadRelatedArticles();
                }
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
                RaisePropertyChanged("SelectedArticle");
                RaisePropertyChanged("CanAddRelatedArticle");
            }
        }

        private ArticleRelationEntity _selectedArticleRelation;
        public ArticleRelationEntity SelectedArticleRelation
        {
            get
            {
                return _selectedArticleRelation;
            }
            set
            {
                _selectedArticleRelation = value;
                RaisePropertyChanged("SelectedArticleRelation");
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
        public RelayCommand<ArticleEntity> SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<ArticleEntity> DeleteCommand { get; set; }

        public RelayCommand SaveArticleRelationCommand { get; set; }
        public RelayCommand<ArticleRelationEntity> DeleteArticleRelationCommand { get; set; }
        #endregion


        public uvArticleManagementViewModel(MainWindowViewModel pMainWindowViewModel)
            : base(pMainWindowViewModel)
        {
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchCommand = new RelayCommand(Search);
            SaveCommand = new RelayCommand<ArticleEntity>(Save);
            DeleteCommand = new RelayCommand<ArticleEntity>(Delete);
            AddCommand = new RelayCommand(Add);

            SaveArticleRelationCommand = new RelayCommand(SaveArticleRelation);
            DeleteArticleRelationCommand = new RelayCommand<ArticleRelationEntity>(DeleteArticleRelation);

            ClearSearch();
        }
        #region method
        public void DeleteArticleRelation(ArticleRelationEntity relationEntity)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var isSuccess = Factory.Resolve<IBaseDataDS>().DeleteArticleRelation(relationEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            if (isSuccess)
                            {
                                DeleteArticleRelationFromList(relationEntity);
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
        public void DeleteArticleRelationFromList(ArticleRelationEntity newEntity)
        {
            ArticleRelationEntity oldEntity = ArticleRelationList.FirstOrDefault<ArticleRelationEntity>(p => p.ArticleRelationId == newEntity.ArticleRelationId);

            if (oldEntity != null)
            {
                ArticleRelationList.Remove(oldEntity);
            }

            ArticleRelationList = new List<ArticleRelationEntity>(_articleRelationList);
        }

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
        public void AddOrUpdateArticleRelation(ArticleRelationEntity newEntity)
        {
            if (ArticleRelationList == null) ArticleRelationList = new List<ArticleRelationEntity>();

            ArticleRelationEntity oldEntity = ArticleRelationList.FirstOrDefault<ArticleRelationEntity>(p => p.ArticleRelationId == newEntity.ArticleRelationId);

            if (oldEntity == null)
            {
                ArticleRelationList.Insert(0, newEntity);
            }
            else
            {
                int index = ArticleRelationList.IndexOf(oldEntity);
                ArticleRelationList.Remove(oldEntity);
                ArticleRelationList.Insert(index, newEntity);
            }

            ArticleRelationList = new List<ArticleRelationEntity>(_articleRelationList);
        }

        public void DeleteArticleFromList(ArticleEntity newEntity)
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
                Description = "",
                ArticleNo="",
                ArticleId=-1
            };
            SelectedArticle = newEntity;
            ArticleList.Add(newEntity);
            ArticleList = new List<ArticleEntity>(_articleList);
        }

        public void Delete(ArticleEntity entityObject)
        {
            if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteArticle(entityObject);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            DeleteArticleFromList(entityObject);
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

        //public void Delete()
        //{
        //    if (ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmDelete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //    {
        //        System.Threading.ThreadPool.QueueUserWorkItem(delegate
        //        {
        //            try
        //            {
        //                ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

        //                var updatedEntity = Factory.Resolve<IBaseDataDS>().DeleteArticle(SelectedArticle);

        //                HideLoading();

        //                //display to UI
        //                Application.Current.Dispatcher.Invoke(new Action(() =>
        //                {
        //                    DeleteArticleFromList(SelectedArticle);
        //                    SelectedArticle = null;
        //                }));
        //            }
        //            catch (Exception ex)
        //            {
        //                HideLoading();
        //                ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
        //            }
        //        });
        //    }
        //}

        public void Save(ArticleEntity entityObject)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateArticle(entityObject);

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
        }
        //public void Save()
        //{
        //    System.Threading.ThreadPool.QueueUserWorkItem(delegate
        //    {
        //        try
        //        {
        //            ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

        //            var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateArticle(SelectedArticle);

        //            HideLoading();

        //            //display to UI
        //            Application.Current.Dispatcher.Invoke(new Action(() =>
        //            {
        //                SelectedArticle = updatedEntity;
        //                AddOrUpdateArticle(SelectedArticle);
        //            }));
        //        }
        //        catch (Exception ex)
        //        {
        //            HideLoading();
        //            ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
        //        }
        //    });
        //    //ShowDialog<uvCompanyDetailViewModel>(new uvCompanyDetailViewModel() { 
        //    //    OriginalCompany = SelectCompany
        //    //});
        //}
        public void SaveArticleRelation()
        {
            if (SelectedArticle != null && SelectedArticle.ArticleId > 0 && RelatedArticle != null && RelatedArticle.ArticleId > 0)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                        ArticleRelationEntity newEntity = new ArticleRelationEntity()
                        {
                            ArticleId = SelectedArticle.ArticleId,
                            RelatedArticleId = RelatedArticle.ArticleId,
                            Comment = ""
                        };
                        var updatedEntity = Factory.Resolve<IBaseDataDS>().AddOrUpdateArticleRelation(newEntity);

                        HideLoading();

                        //display to UI
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            AddOrUpdateArticleRelation(updatedEntity);
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
        public void LoadRelatedArticles()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var list = Factory.Resolve<IBaseDataDS>().GetArticleRelationsForArticle(SelectedArticle);

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ArticleRelationList = list;
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
        public void Reload()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    ShowLoading(StringResources.captionInformation, StringResources.msgLoading);

                    var articleList = Factory.Resolve<IBaseDataDS>().SearchArticle(new ArticleSearchEntity()
                    {
                        SearchText = this.SearchText
                    });

                    var categoryList = Factory.Resolve<IBaseDataDS>().SearchCategories(new CategorySearchEntity()
                    {
                        SearchText = ""
                    });

                    HideLoading();

                    //display to UI
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ArticleList = articleList;
                        CategoryList = categoryList;
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
