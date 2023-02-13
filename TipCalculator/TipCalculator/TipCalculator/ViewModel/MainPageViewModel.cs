using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TipCalculator.ViewModel
{
    public class MainPageViewModel
    {
        public Command OperationsCommand { get; set; }
        public TipModel tipModel { get; set; }
        public MainPageViewModel()
        {
            OperationsCommand = new Command(DoOperations);
            tipModel = new TipModel
            {
                Propina = 5,
                NoPersonas = 2
            };
        }

        private void DoOperations()
        {
            tipModel.TotalPropina =
                (tipModel.Total * tipModel.Propina) / 100;

            tipModel.TotalConPropina =
                tipModel.TotalPropina + tipModel.Total;

            tipModel.PropinaPorPersona =
                tipModel.TotalPropina / tipModel.NoPersonas;

            tipModel.TotalPorPersona =
                (tipModel.Total + tipModel.TotalPropina) / tipModel.NoPersonas;
        }
    }
}
