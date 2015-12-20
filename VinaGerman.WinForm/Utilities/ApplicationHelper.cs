using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Utilities;

namespace VinaGerman.WinForm.Utilities
{
    public static class ApplicationHelper
    {
        //public static string ServerUrl
        //{
        //    get
        //    {
        //        return Properties.Settings.Default.ServerUrl;
        //    }
        //    set
        //    {
        //        Properties.Settings.Default.ServerUrl = value;
        //        Properties.Settings.Default.Save();
        //    }
        //}        
        //public static string UserName
        //{
        //    get
        //    {
        //        return Properties.Settings.Default.UserName;
        //    }
        //    set
        //    {
        //        Properties.Settings.Default.UserName = value;
        //        Properties.Settings.Default.Save();
        //    }
        //}

        //public static string Language
        //{
        //    get
        //    {
        //        return Properties.Settings.Default.Language;
        //    }
        //    set
        //    {
        //        Properties.Settings.Default.Language = value;
        //        Properties.Settings.Default.Save();
        //    }
        //}    
        public static bool IsAuthenticated { get; set; }
        public static UserProfileEntity CurrentUserProfile { get; set; }

        public static void TranferProperiesEx(object source, object Destination)
        {
            try
            {
                foreach (PropertyInfo s in source.GetType().GetProperties())
                {
                    object value = s.GetValue(source, null);
                    // if (value == null) continue;
                    foreach (PropertyInfo d in Destination.GetType().GetProperties())
                    {
                        if (s.Name.ToUpper() == d.Name.ToUpper())
                        {
                            string strValue = "";
                            //Cung type
                            //  strValue = (value == null | value == "") ? "" : value.ToString();
                            if (s.PropertyType == d.PropertyType)
                            {
                                d.SetValue(Destination, value, null);
                            }
                            else
                            {
                                d.SetValue(Destination, value, null);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
            }
        }
    
    
    }
}
