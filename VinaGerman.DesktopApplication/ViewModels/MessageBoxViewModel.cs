using GalaSoft.MvvmLight.Command;
using VinaGerman.DesktopApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using VinaGerman.DesktopApplication;

namespace VinaGerman.DesktopApplication.ViewModels
{
    public class MessageBoxViewModel : VinaGerman.DesktopApplication.ViewModels.BaseViewModel
    {
        #region properties
        private bool _isShow;
        public bool IsShow
        {
            get { return _isShow; }
            set
            {
                if (_isShow != value)
                {
                    _isShow = value;
                    RaisePropertyChanged("IsShow");
                }
            }
        }

        public float BoxOpacity
        {
            get { return 0.6f; }
        }      

        private string _Caption;
        public string Caption
        {
            get { return _Caption; }
            set
            {
                if (_Caption != value)
                {
                    _Caption = value;
                    RaisePropertyChanged("Caption");
                }
            }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                if (_Message != value)
                {
                    _Message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }


        private MessageBoxResult _response;
        public MessageBoxResult Response
        {
            get { return _response; }
            set
            {
                if (_response != value)
                {
                    _response = value;
                    RaisePropertyChanged("Response");
                }
            }
        }

        private MessageBoxButton _buttons;
        public MessageBoxButton Buttons
        {
            get { return _buttons; }
            set
            {
                if (_buttons != value)
                {
                    _buttons = value;
                    RaisePropertyChanged("Buttons");
                    RaisePropertyChanged("WidthColumnOK");
                    RaisePropertyChanged("WidthColumnCANCEL");
                    RaisePropertyChanged("WidthColumnYES");
                    RaisePropertyChanged("WidthColumnNO");
                    RaisePropertyChanged("CanShowOK");
                    RaisePropertyChanged("CanShowCANCEL");
                    RaisePropertyChanged("CanShowYES");
                    RaisePropertyChanged("CanShowNO");
                }
            }
        }      

        public GridLength WidthColumnOK
        {
            get
            {
                switch (Buttons)
                {
                    case MessageBoxButton.OK: return new GridLength(10, GridUnitType.Star);
                    case MessageBoxButton.OKCancel: return new GridLength(5, GridUnitType.Star);
                    default: return new GridLength(0, GridUnitType.Pixel);
                }
            }
        }

        public GridLength WidthColumnCANCEL
        {
            get
            {
                switch (Buttons)
                {
                    case MessageBoxButton.OKCancel: return new GridLength(5, GridUnitType.Star);
                    case MessageBoxButton.YesNoCancel: return new GridLength(3, GridUnitType.Star);
                    default: return new GridLength(0, GridUnitType.Pixel);
                }
            }
        }

        public GridLength WidthColumnYES
        {
            get
            {
                switch (Buttons)
                {
                    case MessageBoxButton.YesNo: return new GridLength(5, GridUnitType.Star);
                    case MessageBoxButton.YesNoCancel: return new GridLength(3, GridUnitType.Star);
                    default: return new GridLength(0, GridUnitType.Pixel);
                }
            }
        }

        public GridLength WidthColumnNO
        {
            get
            {
                switch (Buttons)
                {
                    case MessageBoxButton.YesNo: return new GridLength(5, GridUnitType.Star);
                    case MessageBoxButton.YesNoCancel: return new GridLength(3, GridUnitType.Star);
                    default: return new GridLength(0, GridUnitType.Pixel);
                }
            }
        }

        public Visibility CanShowOK
        {
            get
            {
                if (Buttons == MessageBoxButton.OK || Buttons == MessageBoxButton.OKCancel)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }

        public Visibility CanShowCANCEL
        {
            get
            {
                if (Buttons == MessageBoxButton.OKCancel || Buttons == MessageBoxButton.YesNoCancel)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }

        public Visibility CanShowYES
        {
            get
            {
                if (Buttons == MessageBoxButton.YesNo || Buttons == MessageBoxButton.YesNoCancel)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }

        public Visibility CanShowNO
        {
            get
            {
                if (Buttons == MessageBoxButton.YesNo || Buttons == MessageBoxButton.YesNoCancel)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }
        #endregion

        #region Ctor
        public RelayCommand YesCommand { get; set; }
        public RelayCommand NoCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }        

        private bool _hideRequest = false;
        public MessageBoxViewModel()
        {
            IsShow = false;
            YesCommand = new RelayCommand(Yes_Click);
            NoCommand = new RelayCommand(No_Click);
            OkCommand = new RelayCommand(Ok_Click);
            CancelCommand = new RelayCommand(Cancel_Click);
        }
        public MessageBoxResult Show(string sCaption, string sMessage, MessageBoxButton msgButtons)
        {
            Buttons = msgButtons;
            Caption = sCaption;
            Message = sMessage;
            IsShow = true;

            _hideRequest = false;
            while (!_hideRequest)
            {
                if (App.Current == null || App.Current.Dispatcher == null)
                    break;

                // HACK: Simulate "DoEvents"
                App.Current.Dispatcher.Invoke(
                    DispatcherPriority.Background,
                    new ThreadStart(delegate { }));
                Thread.Sleep(20);
            }
            
            IsShow = false;
            return Response;
        }       
       
        public void Yes_Click()
        {
            Response = MessageBoxResult.Yes;
            _hideRequest = true;
        }

        public void No_Click()
        {
            Response = MessageBoxResult.No;
            _hideRequest = true;
        }

        public void Ok_Click()
        {
            Response = MessageBoxResult.OK;
            _hideRequest = true;
        }

        public void Cancel_Click()
        {
            Response = MessageBoxResult.Cancel;
            _hideRequest = true;
        }
        #endregion
    }
}
