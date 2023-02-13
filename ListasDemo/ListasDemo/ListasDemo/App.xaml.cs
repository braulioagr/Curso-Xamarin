using ListasDemo.Data;
using ListasDemo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListasDemo
{
    public partial class App : Application
    {
        private static FriendDataBase dataBase;

        public static FriendDataBase DataBase
        {
            get
            {
                if(dataBase == null)
                {
                    dataBase = 
                        new FriendDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("friendsdb.db3"));
                }
                return dataBase;
            }
        }

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
