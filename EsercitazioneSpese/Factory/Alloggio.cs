using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class Alloggio : IRimborso
    {
        public decimal CalcolaRimborso(Spesa s)
        {
            //Alloggio: 100% dell'importo
            return s.Importo;
        }
    }
}
