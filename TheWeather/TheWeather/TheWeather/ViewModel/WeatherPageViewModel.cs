using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheWeather.Model;
using Xamarin.Forms;

namespace TheWeather.ViewModel
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        private WeatherData data;
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public WeatherData Data
        {
            get => data; set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }

        public WeatherPageViewModel()
        {
            SearchCommand = new Command(async (searchTerm) =>
            {
                //x,y 19.431,-99.132
                var entrada = searchTerm as string;
                string[] datos = entrada.Split(',');
                var lat = datos[0];
                var lon = datos[1];
                await GetData($"https://api.weatherbit.io/v2.0/current?lat={lat}&lon={lon}&lang=es&key=2c15aac33a3849b881eda2c50e501355");
            });
        }


        private async Task GetData(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject<WeatherData>(jsonResult);
        }
    }
}
