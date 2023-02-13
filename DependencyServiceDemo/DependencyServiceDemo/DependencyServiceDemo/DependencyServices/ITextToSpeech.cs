using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyServiceDemo.DependencyServices
{
    public interface ITextToSpeech
    {
        void Speak(string Text);
    }
}
