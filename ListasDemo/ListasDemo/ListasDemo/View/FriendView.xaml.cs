using ListasDemo.Model;
using ListasDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListasDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendView : ContentPage
    {
        public FriendView(Friend friend = null)
        {
            InitializeComponent();

            BindingContext = (friend == null) ? new FriendViewViewModel(Navigation) : new FriendViewViewModel(Navigation, friend);
        }
    }
}