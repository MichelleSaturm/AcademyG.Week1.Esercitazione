using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class CeoHandler : AbstractHandler
    {
        public override string Handle(Spesa request)
        {
            //CEO: sopra i 1000€
            if (request.Importo > 1000 && request.Importo <= 2500)
            {
                return "CEO";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
