using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.DesktopApplication.Translations
{
    public class LocalizedStrings : INotifyPropertyChanged
    {
        private static StringResources _localizedResources = new StringResources();

        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        public StringResources LocalizedResources { get { return _localizedResources; } }

        // Create the OnPropertyChanged method to raise the event 
        public void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
