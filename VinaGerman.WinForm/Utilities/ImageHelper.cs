using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Utilities
{
    public static class ImageHelper
    {
        /// <summary>
        /// Load icon from .ico
        /// </summary>
        public static Icon LoadIconFile(string icoPath)
        {
            if (!File.Exists(icoPath)) return null;

            Icon ico = null;
            try
            {
                using (var fs = new FileStream(icoPath, FileMode.Open, FileAccess.Read))
                {
                    ico = new Icon(fs);
                    fs.Close();
                }
            }
            catch (ArgumentException) { }
            return ico;
        }

        /// <summary>
        /// Load image from image file
        /// </summary>
        public static Image LoadImageFile(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            Image output = null;
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    output = Image.FromStream(fs);
                    fs.Close();
                }
            }
            catch (ArgumentException) { }
            return output;
        }

        /// <summary>
        /// Load image from an Uri
        /// </summary>
        public static Image LoadImageUri(string uri)
        {
            Image output = null;

            var request = WebRequest.Create(uri);

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    output = Image.FromStream(stream);
                }
            }

            return output;
        }
    }
}
