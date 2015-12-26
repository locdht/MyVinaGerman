using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Utilities
{
    public class WaitHelper
    {
        public bool CanHide { get; set; }
        public static SplashScreenManager Manager { get; set; }

        public void Show()
        {
            if (!Manager.IsSplashFormVisible)
            {
                this.CanHide = true;
                Manager.ShowWaitForm();
            }
        }

        public void Hide()
        {

            Hide(false);
        }

        public void Hide(bool force)
        {
            if ((force || this.CanHide) && Manager.IsSplashFormVisible)
                Manager.CloseWaitForm();
        }

        public void SetCaption(string caption)
        {
            Manager.SetWaitFormCaption(caption);
        }

        public void SetDescription(string desc)
        {
            Manager.SetWaitFormDescription(desc);
        }

        
    }
}
