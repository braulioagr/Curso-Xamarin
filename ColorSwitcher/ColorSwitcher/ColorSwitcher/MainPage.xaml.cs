using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorSwitcher
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void ChangeColor(object sender, EventArgs e)
        {

            var red = redSlider.Value;
            var green = greenSlider.Value;
            var blue = blueSlider.Value;


            Color bgColor = new Color(red, green, blue);

            boxColor.BackgroundColor = bgColor;

            lblDisplay.Text = ColorToHex(bgColor);

        }


        private string ColorToHex(Color color)
        {
            int red = (int) (color.R * 255);
            int green = (int) (color.G * 255);
            int blue = (int) (color.B * 255);
            int alpha = (int) (color.A * 255);

            return $"#{red:X2}{green:X2}{blue:X2}{alpha:X2}";
        }
    }
}
