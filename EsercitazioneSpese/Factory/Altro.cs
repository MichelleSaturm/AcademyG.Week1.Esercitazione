using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class Altro : IRimborso
    {
        public decimal CalcolaRimborso(Spesa s)
        {
            //Altro: 10% dell'importo
            return (s.Importo * 10) / 100;
        }
    }
}
