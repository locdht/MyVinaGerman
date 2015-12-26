using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Utilities
{
    public static class Global
    {
        #region Icons

        public static Icon InfoIcon { get; set; }
        public static Icon WarningIcon { get; set; }
        public static Icon QuestionIcon { get; set; }

        /// <summary>
        /// Load icons for MessageBox.
        /// </summary>
        public static bool LoadIcons()
        {
            InfoIcon = ImageHelper.LoadIconFile(PathProvider.INFO_ICON_PATH);
            WarningIcon = ImageHelper.LoadIconFile(PathProvider.WARNING_ICON_PATH);
            QuestionIcon = ImageHelper.LoadIconFile(PathProvider.QUESTION_ICON_PATH);

            if (InfoIcon == null || WarningIcon == null || QuestionIcon == null)
                return false;

            return true;
        }
        #endregion

        public static void ReleaseAll()
        {
            InfoIcon.Dispose();
            WarningIcon.Dispose();
            QuestionIcon.Dispose();
        }
    }
}
