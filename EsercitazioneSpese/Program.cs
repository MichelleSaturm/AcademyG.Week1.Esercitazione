using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EsercitazioneSpese
{
    class Program
    {
        public static List<Spesa> listaSpese = new();
        public static IEnumerable<Spesa> approvate;
        public static IEnumerable<Spesa> nonApprovate;
        static void Main(string[] args)
        {
            Console.WriteLine("=== ACADEMY G WEEK 1 - ESERCITAZIONE ===");

            //EVENT CREAZIONE E LETTURA FILE
            #region EVENT CREAZIONE E LETTURA FILE

            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"C:\Users\princ\OneDrive\Desktop\AcademyG.Esercitazione\AcademyG.Week1.Esercitazione\EsercitazioneSpese";
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.EnableRaisingEvents = true;

            fsw.Created += Fsw_Created;

            Console.WriteLine("Creazione del file per l'approvazione delle spese in corso.\n" +
                "Attendere per cortesia.");
            Console.WriteLine("Una volta terminata la lettura, premere y per andare avanti.");
            while (Console.Read() != 'y') ;
            #endregion

            //CHAIN OF RESPONSIBILITY
            #region ChainOfResponsibility

            var manager = new ManagerHandler();
            var operationalManager = new OperationalManagerHandler();
            var ceo = new CeoHandler();

            //Manager >     Operational Manager >       CEO 
            manager.SetNext(operationalManager).SetNext(ceo);

            foreach (var s in listaSpese)
            {
                Console.WriteLine(new String('-', 55));
                Console.WriteLine($"DETTAGLI:\n" +
                    $"{s.Details()}");
                Console.WriteLine();

                var result = manager.Handle(s);

                if (result != null)
                {
                    Console.WriteLine($"Livello di approvazione: {result}");
                    s.LvlApprov = result;
                    s.Approvata = true;
                }
                else
                {
                    Console.WriteLine($"Livello di approvazione: LA SPESA NON E' STATA APPROVATA!");
                    s.LvlApprov = null;
                    s.Approvata = false;
                }
            }


            #endregion

            //FACTORY PER APPROVAZIONE
            #region FACTORY PER APPROVAZIONE

            //LINQ PER SPESE APPROVATE E NON
            approvate = listaSpese.Where(item => item.Approvata == true);
            nonApprovate = listaSpese.Where(item => item.Approvata == false);
            foreach (var s in approvate)
            {
                string categoria = s.Categoria;
                IRimborso tipoRimborso;

                tipoRimborso = ImportoFactory.GetImporto(categoria);

                s.ImportoRimborsato = tipoRimborso.CalcolaRimborso(s);

            }

            #endregion

            //SALVATAGGIO SU FILE
            #region SALVA SU FILE

            try
            {
                if (!Directory.Exists(@"C:\Users\princ\OneDrive\Desktop\AcademyG.Esercitazione\AcademyG.Week1.Esercitazione\EsercitazioneSpese"))
                {
                    Directory.CreateDirectory(@"C:\Users\princ\OneDrive\Desktop\AcademyG.Esercitazione\AcademyG.Week1.Esercitazione\EsercitazioneSpese");
                }

                StreamWriter writer = File.CreateText(@"C:\Users\princ\OneDrive\Desktop\AcademyG.Esercitazione\AcademyG.Week1.Esercitazione\EsercitazioneSpese\spese_elaborate.txt");

                foreach (var s in approvate)
                {
                    writer.WriteLine(s.GetDettagliApprovazione());
                }

                foreach (var item in nonApprovate)
                {
                    writer.WriteLine(item.GetDettagliApprovazione());
                }
                writer.Flush();
                writer.Close();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"\t\tI/O ERROR: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t\tERROR: {ex.Message}");
            }
            #endregion
        }



        private static void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(new String('-', 55));
            Console.WriteLine($"Il file {e.Name} è stato creato con successo.");
            Console.WriteLine(new String('=', 95));
            //Spesa s = new Spesa();
            StreamReader reader = File.OpenText(e.FullPath);

            reader.ReadLine();
            var row = reader.ReadLine();
            while (row != null)
            {
                string[] dati = row.Split('\t');
                DateTime.TryParse(dati[0], out DateTime data);
                string categoria = dati[1];
                string desc = dati[2];
                decimal.TryParse(dati[3], out decimal importo);

                Spesa spes = new Spesa
                {
                    Data = data,
                    Categoria = categoria,
                    Descrizione = desc,
                    Importo = importo,
                };

                listaSpese.Add(spes);
                row = reader.ReadLine();
                Console.WriteLine(spes.ToString());
            }
            Console.WriteLine(new String('=', 95));
        }
    }
}
