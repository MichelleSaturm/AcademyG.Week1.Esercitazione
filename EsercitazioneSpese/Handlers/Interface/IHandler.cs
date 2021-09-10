using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public interface IHandler
    {
        IHandler SetNext(IHandler next);
        string Handle(Spesa request);
    }
}
