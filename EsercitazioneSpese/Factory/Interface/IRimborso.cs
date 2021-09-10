using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public interface IRimborso
    {
        decimal CalcolaRimborso(Spesa s);
    }
}
