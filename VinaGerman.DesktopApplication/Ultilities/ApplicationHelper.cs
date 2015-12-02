using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;

namespace VinaGerman.DesktopApplication.Ultilities
{
    public static class ApplicationHelper
    {
        public static string ServerUrl
        {
            get
            {
                return Properties.Settings.Default.ServerUrl;
            }
            set
            {
                Properties.Settings.Default.ServerUrl = value;
                Properties.Settings.Default.Save();
            }
        }        
        public static string UserName
        {
            get
            {
                return Properties.Settings.Default.UserName;
            }
            set
            {
                Properties.Settings.Default.UserName = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string Language
        {
            get
            {
                return Properties.Settings.Default.Language;
            }
            set
            {
                Properties.Settings.Default.Language = value;
                Properties.Settings.Default.Save();
            }
        }    
        public static bool IsAuthenticated { get; set; }
        public static UserProfileEntity CurrentUserProfile { get; set; }
    }
}
