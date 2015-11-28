using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VinaGerman.DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VinaGerman.DesktopApplication.ViewModels.MainWindowViewModel();
        }

        //public void ShowChildForm(string sTitle, int iHeight, int iWidth,
        //    VinaGerman.DesktopApplication.ViewModels.BaseViewModel model)
        //{
        //    MahApps.Metro.Controls.MetroWindow window = new MahApps.Metro.Controls.MetroWindow()
        //    {
        //        Title=sTitle,
        //        Height=iHeight,
        //        Width=iWidth,
        //        WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
        //        GlowBrush = (SolidColorBrush)FindResource("AccentColorBrush"),
        //        ShowMinButton=false,
        //        ShowMaxRestoreButton=false,
        //        DataContext = model
        //    };            
        //    window.ShowDialog();
        //}
        //protected T GetBusiness<T>()
        //{
        //    return VinaGerman.Entity.EntityHelper.GetInstance().Resolve<T>();
        //}
    }
}
