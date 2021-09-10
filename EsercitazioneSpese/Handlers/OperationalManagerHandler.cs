using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class OperationalManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa request)
        {
            //Operational Manager: da 401€ fino a 1000€
            if (request.Importo > 400 && request.Importo <= 1000)
            {
                return "Operational Manager";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
