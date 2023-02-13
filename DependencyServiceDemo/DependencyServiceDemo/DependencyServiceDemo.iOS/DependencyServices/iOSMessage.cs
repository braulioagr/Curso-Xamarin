using System;
using System.Collections.Generic;
using System.Text;
using DependencyServiceDemo.DependencyServices;
using DependencyServiceDemo.iOS.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSMessage))]
namespace DependencyServiceDemo.iOS.DependencyServices
{
    public class iOSMessage : IPlatformMessage
    {
        public string GetMessage()
        {
            return "I´m on iOS";
        }
    }
}
