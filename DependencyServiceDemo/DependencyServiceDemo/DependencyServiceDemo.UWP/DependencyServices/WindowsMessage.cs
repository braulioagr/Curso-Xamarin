using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyServiceDemo.DependencyServices;
using DependencyServiceDemo.UWP.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(WindowsMessage))]
namespace DependencyServiceDemo.UWP.DependencyServices
{
    public class WindowsMessage : IPlatformMessage
    {
        public String GetMessage()
        {
            return "I´m on Windows!";
        }
    }
}
