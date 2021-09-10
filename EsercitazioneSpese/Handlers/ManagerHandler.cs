using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class ManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa request)
        {
            //Manager: spese fino a 400€
            if (request.Importo <= 400)
            {
                return "Manager";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
