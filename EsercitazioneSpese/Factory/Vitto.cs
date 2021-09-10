namespace EsercitazioneSpese
{
    public class Vitto : IRimborso
    {
        public decimal CalcolaRimborso(Spesa s)
        {
            //Vitto: 70 % dell'importo
            return (s.Importo * 70) / 100;
        }
    }
}
