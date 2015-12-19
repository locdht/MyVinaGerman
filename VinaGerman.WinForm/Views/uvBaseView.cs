using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Views
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))] 
    public class uvBaseView : DevExpress.XtraEditors.XtraUserControl
    {
        protected MainForm OwnerForm { get; set; }
        protected void PerformActionWithSplashScreen(Delegate method, params object[] args)
        {
            OwnerForm.PerformActionWithSplashScreen(method, args);
        }

        protected object PerformActionWithLoading(Delegate method, params object[] args)
        {
            return OwnerForm.PerformActionWithLoading(method, args);
        }
    }
}
