using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class Viaggio : IRimborso
    {
        public decimal CalcolaRimborso(Spesa s)
        {
            //Viaggio: 100% dell'importo + 50€ fisse
            return s.Importo + 50;
        }
    }
}
