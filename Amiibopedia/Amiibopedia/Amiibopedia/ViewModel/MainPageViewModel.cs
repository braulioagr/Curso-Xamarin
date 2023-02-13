using Amiibopedia.Helpers;
using Amiibopedia.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Amiibopedia.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Amiibo> amiibos;

        public ICommand SearchCommand { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> Amiibos {
            get => amiibos;
            set
            {
                amiibos = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            SearchCommand = new Command(async (param) =>
            {
                IsBusy = true;
                var character = param as Character;
                if (character != null)
                {
                    string url = $"https://www.amiiboapi.com/api/amiibo/?character={character.name}";
                    var service = new HttpHelper<Amiibos>();
                    var amiibos = await service.GetRestServiceDataAysinc(url);
                    Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                }
                IsBusy= false;
            });
        }
        public async Task LoadCharacters()
        {
            IsBusy = true;
            string url = "https://www.amiiboapi.com/api/character/";
            var service = new HttpHelper<Characters>();
            var charactes = await service.GetRestServiceDataAysinc(url);
            Characters = new ObservableCollection<Character>(charactes.amiibo);
            IsBusy = false;
        }
    }
}
