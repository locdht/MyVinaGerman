using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VinaGerman.DesktopApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1500; // Miliseconds
        private const int SPLASH_FADE_TIME = 500;     // Miliseconds

        public static ISplashScreen StartupScreen;
        private ManualResetEvent ResetSplashCreated;
        private Thread SplashThread;

        protected override void OnStartup(StartupEventArgs e)
        {
            // ManualResetEvent acts as a block. It waits for a signal to be set.
            ResetSplashCreated = new ManualResetEvent(false);

            // Create a new thread for the splash screen to run on
            SplashThread = new Thread(ShowSplash);
            SplashThread.SetApartmentState(ApartmentState.STA);
            SplashThread.IsBackground = true;
            SplashThread.Name = "Splash Screen";
            SplashThread.Start();

            // Wait for the blocker to be signaled before continuing. This is essentially the same as: while(ResetSplashCreated.NotSet) {}
            ResetSplashCreated.WaitOne();

            // Step 3 - Load your windows but don't show it yet            
            MainWindow main = new MainWindow();
            main.Show();
            base.OnStartup(e);
        }

        private void ShowSplash()
        {
            // Create the window
            SplashWindow splashWin = new SplashWindow();
            StartupScreen = splashWin;

            // Show it
            splashWin.Show();

            // Now that the window is created, allow the rest of the startup to run
            ResetSplashCreated.Set();
            System.Windows.Threading.Dispatcher.Run();
        }
    }
}
