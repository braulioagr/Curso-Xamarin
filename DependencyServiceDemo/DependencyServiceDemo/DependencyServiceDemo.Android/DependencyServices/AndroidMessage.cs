using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DependencyServiceDemo.DependencyServices;
using DependencyServiceDemo.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidMessage))]
namespace DependencyServiceDemo.Droid.DependencyServices
{
    public class AndroidMessage : IPlatformMessage
    {
        public string GetMessage()
        {
            return "I´m On Android";
        }
    }
}