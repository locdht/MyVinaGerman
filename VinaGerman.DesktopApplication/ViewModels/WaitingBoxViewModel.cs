using VinaGerman.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VinaGerman.ViewModels
{
    public class WaitingBoxViewModel : BaseViewModel
    {
        public WaitingBoxViewModel()
        {
            IsShow = false;
        }
        public float BoxOpacity
        {
            get { return 0.4f; }
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
    
        public void Show(enumView eView)
        {            
            ViewType = eView;
            IsShow = true;
        } 
    }
}
