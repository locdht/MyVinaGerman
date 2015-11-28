using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace VinaGerman.DesktopApplication.ViewModels
{
    public class DialogViewModel : VinaGerman.DesktopApplication.ViewModels.BaseViewModel
    {
        private bool _hideRequest = false;

        public RelayCommand CloseCommand { get; set; }

        public float BoxOpacity
        {
            get { return 0.6f; }
        }
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

        public DialogViewModel()
        {
            CloseCommand = new RelayCommand(Close);
        }

        public void Close()
        {
            _hideRequest = true;
        }

        public T Show<T>(T pViewModel)
        {
            
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
            return pViewModel;
        } 
    }
}
