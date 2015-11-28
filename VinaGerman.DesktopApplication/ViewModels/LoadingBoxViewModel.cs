using VinaGerman.DesktopApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace VinaGerman.DesktopApplication.ViewModels
{
    public class LoadingBoxViewModel : BaseViewModel
    {
        public LoadingBoxViewModel()
        {
            IsShow = false;
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

        public void Show(string sMessage)
        {
            Message = sMessage;
            IsShow = true;            
        } 
    }
}
