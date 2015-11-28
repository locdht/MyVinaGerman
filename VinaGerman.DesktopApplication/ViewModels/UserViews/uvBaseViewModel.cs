using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Threading;
using GalaSoft.MvvmLight.Command;
using System.Drawing;
using VinaGerman.DesktopApplication.Translations;
using VinaGerman.DesktopApplication.Ultilities;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvBaseViewModel : BaseViewModel//, IBaseView
    {
        public MainWindowViewModel MainWindowModel { get; set; }
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand<enumView> GoToViewCommand { get; set; }
        public uvBaseViewModel(MainWindowViewModel pMainWindowViewModel)
        {            
            AcceptedToken.Add(MessageToken.ReloadMessage);
            MainWindowModel = pMainWindowViewModel;

            LoadingBoxModel = new LoadingBoxViewModel();
            MessageBoxModel = new MessageBoxViewModel();
                            
            BoxModel = LoadingBoxModel;

            GoToViewCommand = new RelayCommand<enumView>(GoToView);
            GoBackCommand = new RelayCommand(GoBack);
        }
        private BaseViewModel _boxModel;
        public BaseViewModel BoxModel
        {
            get { return _boxModel; }
            set
            {
                if (_boxModel != value)
                {
                    _boxModel = value;
                    RaisePropertyChanged("BoxModel");
                }
            }
        }
        private LoadingBoxViewModel _loadingBoxModel;
        public LoadingBoxViewModel LoadingBoxModel
        {
            get { return _loadingBoxModel; }
            set
            {
                if (_loadingBoxModel != value)
                {
                    _loadingBoxModel = value;
                    RaisePropertyChanged("LoadingBoxModel");
                }
            }
        }       

        private MessageBoxViewModel _messageBoxModel;
        public MessageBoxViewModel MessageBoxModel
        {
            get { return _messageBoxModel; }
            set
            {
                if (_messageBoxModel != value)
                {
                    _messageBoxModel = value;
                    RaisePropertyChanged("BoxModel");
                }
            }
        }       

        public virtual void BeforeGoBack()
        {
            if (IsChanged)
            {
                MessageBoxResult confirm = ShowMessageBox(StringResources.captionConfirm, StringResources.msgConfirmSave, MessageBoxButton.YesNoCancel);
                if (confirm == MessageBoxResult.Cancel)
                {
                    return;
                }
                if (confirm == MessageBoxResult.Yes)
                {
                    if (Validate())
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(delegate
                        {
                            try
                            {
                                ShowLoading(StringResources.captionInformation, StringResources.msgSaving);
                                bool isSuccess = Save();
                                HideLoading();
                                if (isSuccess)
                                {
                                    if (Application.Current != null && Application.Current.Dispatcher != null)
                                    {
                                        Application.Current.Dispatcher.Invoke(new Action(() =>
                                        {
                                            MainWindowModel.GoBack();
                                            AfterGoBack();
                                        }));
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                HideLoading();
                                ShowMessageBox(StringResources.captionError, ex.ToString(), MessageBoxButton.OK);
                            }
                        });                        
                    }
                }
                else
                {
                    MainWindowModel.GoBack();
                    AfterGoBack();                    
                }
            }
            else
            {
                MainWindowModel.GoBack();
                AfterGoBack();                
            }            
        }
        public virtual void GoBack()
        {
            BeforeGoBack();
        }
        public virtual void AfterGoBack()
        {

        }

        public virtual void GoToView(enumView view)
        {
            MainWindowModel.GoToView(view);
        }

        #region Loading,Message box       
        public void ShowLoading(string sCaption, string sMessage)
        {
            BoxModel = LoadingBoxModel;
            LoadingBoxModel.Show(sMessage);
        }

        public void HideLoading()
        {
            if (BoxModel != null)
            {
                if (typeof(LoadingBoxViewModel) == BoxModel.GetType())
                    ((LoadingBoxViewModel)BoxModel).IsShow = false;
            }
        }

        public System.Windows.MessageBoxResult ShowMessageBox(string sCaption, string sMessage, MessageBoxButton msgButtons)
        {
            BoxModel = MessageBoxModel;
            MessageBoxResult result = MessageBoxModel.Show(sCaption, sMessage, msgButtons);
            return result;
        }

        public T ShowDialog<T>(T pViewModel) where T : DialogViewModel
        {
            BoxModel = pViewModel;
            return pViewModel.Show<T>(pViewModel);
        }   
        #endregion       

        #region message processing
        private bool _isSaved = false;
        public bool IsSaved
        {
            get
            {
                return _isSaved;
            }
            set
            {
                _isSaved = value;
                RaisePropertyChanged("IsSaved");
            }
        }

        private bool _isChanged = false;
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
                RaisePropertyChanged("IsChanged");
                if (_isChanged)
                {
                    IsSaved = false;//automatically set IsSaved when has changes
                }
            }
        }

        public virtual bool Validate() { return true; }        
        public virtual bool Save() { return true; }        
        #endregion


        public void OnInvokeLoading(string sCaptionKey, string sMessageKey)
        {
            ShowLoading(sCaptionKey, sMessageKey);
        }
    }
}
