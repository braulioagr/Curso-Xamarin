using System;
using System.Collections.Generic;
using System.Text;

namespace ListasDemo.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
