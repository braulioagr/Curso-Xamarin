using ListasDemo.Helpers;
using ListasDemo.Model;
using ListasDemo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListasDemo.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public ObservableCollection
            <Grouping<string, Friend>> Friends
        { get; set; }

        public Command AddFriendCommand { get; set; }
        private INavigation Navigation;
        private Friend currentFriend;

        public Command ItemTappedCommand { get; set; }
        public Friend CurrentFriend {
            get => currentFriend;
            set
            {
                currentFriend = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(INavigation navigation)
        {
            FriendRepository repository
                = new FriendRepository();
            Friends = repository.GetAllGrouped();
            Navigation = navigation;
            AddFriendCommand = new Command(async () => await NavigateToFriendView());
            ItemTappedCommand = new Command(async () => await NavigateToEditFriendView());
        }

        public async Task NavigateToEditFriendView()
        {
            await Navigation.PushAsync(new FriendView( CurrentFriend ));
        }
        public async Task NavigateToFriendView()
        {
            await Navigation.PushAsync(new FriendView());
        }
    }
}
