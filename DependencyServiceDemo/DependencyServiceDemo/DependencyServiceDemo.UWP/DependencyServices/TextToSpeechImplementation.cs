using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using DependencyServiceDemo.DependencyServices;
using DependencyServiceDemo.UWP.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace DependencyServiceDemo.UWP.DependencyServices
{
    public class TextToSpeechImplementation:
        ITextToSpeech
    {
        public async void Speak(string Text)
        {
            var mediaElement = 
                new MediaElement();
            var synth = 
                new SpeechSynthesizer();
            var stream =
                await synth.SynthesizeTextToStreamAsync(Text);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}
