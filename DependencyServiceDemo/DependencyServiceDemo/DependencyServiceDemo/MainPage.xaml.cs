using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyServiceDemo.DependencyServices;
using Xamarin.Forms;

namespace DependencyServiceDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var service = DependencyService.Get<IPlatformMessage>();
            var message = service.GetMessage();
            await DisplayAlert("Service", message, "OK");
        }

        private void TextToSpeech_OnClicked(object sender, EventArgs e)
        {
            var service = 
                DependencyService.Get<ITextToSpeech>();
            service.Speak("Hola desde Xamarin!");
        }
    }
}
