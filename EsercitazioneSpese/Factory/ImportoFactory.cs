using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class ImportoFactory
    {
        public static IRimborso GetImporto(string categoria)
        {
            IRimborso rimborso = null;

            switch (categoria)
            {
                case "Viaggio":
                    rimborso = new Viaggio();
                    break;
                case "Alloggio":
                    rimborso = new Alloggio();
                    break;
                case "Vitto":
                    rimborso = new Vitto();
                    break;
                case "Altro":
                    rimborso = new Altro();
                    break;
                default:
                    Console.WriteLine("La categoria non rientra tra le spese valide");
                    break;
            }

            return rimborso;
        }
    }
}
