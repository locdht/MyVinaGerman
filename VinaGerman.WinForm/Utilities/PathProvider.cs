using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Utilities
{
    public static class PathProvider
    {
        public static string IniConfigPATH = AppDomain.CurrentDomain.BaseDirectory + @"config.ini";
        public static string DesktopPATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string HelpPATH = AppDomain.CurrentDomain.BaseDirectory + @"ConcungAppDX-Manual.chm";
        #region Icons

        /// <summary>
        /// Gets the path of info icon
        /// </summary>
        public static string INFO_ICON_PATH =
            AppDomain.CurrentDomain.BaseDirectory + @"\res\MsgBoxInfo.ico";

        /// <summary>
        /// Gets the path of warning icon
        /// </summary>
        public static string WARNING_ICON_PATH =
            AppDomain.CurrentDomain.BaseDirectory + @"\res\MsgBoxWarning.ico";

        /// <summary>
        /// Gets the path of question icon
        /// </summary>
        public static string QUESTION_ICON_PATH =
            AppDomain.CurrentDomain.BaseDirectory + @"\res\MsgBoxQuestion.ico";

        #endregion
    }
}
