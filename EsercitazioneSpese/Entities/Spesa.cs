using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneSpese
{
    public class Spesa
    {
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Descrizione { get; set; }
        public decimal Importo { get; set; }
        public bool Approvata { get; set; }
        public string LvlApprov { get; set; }
        public decimal ImportoRimborsato { get; set; }

        public override string ToString()
        {
            Console.WriteLine("{0,-15}{1,-20}{2,-30}{3,-10}", "Data", "Categoria", "Descrizione", "Importo");
            Console.WriteLine("{0,-15}{1,-20}{2,-30}{3,-10}", Data.ToString("dd-MMM-yyyy"), Categoria, Descrizione, Importo);
            return null;
        }

        public string Details()
        {
            return $"Data: {Data.ToString("dd-MMM-yyyy")}\n" +
                $"Categoria: {Categoria}\n" +
                $"Descrizione: {Descrizione}\n" +
                $"Importo: {Importo}";
        }

        public string GetDettagliApprovazione()
        {
            if (Approvata)
                return $"{Data.ToString("dd-MMM-yyyy")};{Categoria};{Descrizione};APPROVATA;{LvlApprov};Rimborso: {ImportoRimborsato} [su {Importo}]";
            else
                return $"{Data.ToString("dd-MMM-yyyy")};{Categoria};{Descrizione};RESPINTA;-;-";
        }
    }

   
}
