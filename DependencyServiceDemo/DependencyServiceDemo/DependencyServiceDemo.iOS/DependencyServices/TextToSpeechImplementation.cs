using System;
using System.Collections.Generic;
using System.Text;
using AVFoundation;
using DependencyServiceDemo.DependencyServices;
using DependencyServiceDemo.iOS.DependencyServices;
using Xamarin.Forms;

[assembly:Dependency(typeof(TextToSpeechImplementation))]
namespace DependencyServiceDemo.iOS.DependencyServices
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public void Speak(string Text)
        {
            var speechSynthetizer =
                new AVSpeechSynthesizer();
            var speechUtterance =
                new AVSpeechUtterance(Text)
                {
                    Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                    Voice = AVSpeechSynthesisVoice.FromLanguage("es-MX"),
                    Volume = 0.5f,
                    PitchMultiplier = 1.0f
                };
            speechSynthetizer.SpeakUtterance(speechUtterance);
        }
    }
}
