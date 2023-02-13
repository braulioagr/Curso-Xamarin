using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ListasDemo.iOS.Services;
using UIKit;
using ListasDemo.Services;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace ListasDemo.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder =
                Path.Combine(docFolder, "..", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}