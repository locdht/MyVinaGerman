using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace VinaGerman.DesktopApplication
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window, ISplashScreen
    {
        public SplashWindow()
        {
            InitializeComponent();
        }
        public void SetMessage(string message)
        {
            Dispatcher.Invoke((Action)delegate()
            {
                this.lblMessage.Content = message;
            });
        }        
        public void SetVersion(string message)
        {
            Dispatcher.Invoke((Action)delegate()
            {
                this.lblVersion.Content = message;
            });
        }
        public void SetCopyright(string message)
        {
            Dispatcher.Invoke((Action)delegate()
            {
                this.lblCopyRight.Content = message;
            });
        }
        public void LoadComplete()
        {
            Dispatcher.InvokeShutdown();
        }
    }
    public interface ISplashScreen
    {        
        void SetMessage(string message);
        void SetVersion(string message);
        void SetCopyright(string message);

        void LoadComplete();
    }
}
