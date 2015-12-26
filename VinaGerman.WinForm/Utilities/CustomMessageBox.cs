using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Utilities
{
    public static class CustomMessageBox
    {
        public static void ShowError(string text, string caption, Exception ex)
        {
            using (var f = new CustomMessageBoxForm(text, caption, ex))
            {
                f.ShowDialog();
            };
        }
    }
}
