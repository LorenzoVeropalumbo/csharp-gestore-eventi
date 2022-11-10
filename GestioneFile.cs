using System;
using System.IO;

static class GestioneFile
{
    public static void ExportFile(string Filename, ProgrammaEventi programmaEventi)
    {
        StreamWriter fileDaScrivere = File.CreateText("C:\\Users\\loren\\source\\repos\\.Net-course\\csharp-gestore-eventi\\" + Filename +".csv");
        fileDaScrivere.WriteLine("Lista Eventi");
        fileDaScrivere.WriteLine();

        string testo = programmaEventi.StampaTuttiGliEventi();

        fileDaScrivere.WriteLine(testo);

        fileDaScrivere.Close();
    }

    public static void ImportFile(string Filename, ProgrammaEventi programmaEventi)
    {
        StreamReader stream = File.OpenText("C:\\Users\\loren\\source\\repos\\.Net-course\\csharp-gestore-eventi\\ListaEventi.csv");
        stream.ReadLine();
        while (!stream.EndOfStream)
        {
            string line = stream.ReadLine();
            string[] info = line.Split(",");
            if (info.Length == 4)
            {
                if (info[0] == "")
                {
                    throw new csharpGenstioneEventiExeption("il nome non è valido");
                }
                string titolo = info[0];              

                if (!DateTime.TryParse(info[1], out DateTime time))
                {
                    throw new csharpGenstioneEventiExeption("inserisci un valore valido");
                }
                DateTime data = Convert.ToDateTime(info[1]);

                if (!Int32.TryParse(info[2], out int post))
                {
                    throw new csharpGenstioneEventiExeption("inserisci un valore valido");
                }
                int posti = Convert.ToInt32(info[2]);
                
                if (!Int32.TryParse(info[3], out int postpre))
                {
                    throw new csharpGenstioneEventiExeption("inserisci un valore valido");
                }
                int postiPrenotati = Convert.ToInt32(info[3]);
                
                Evento evento = new Evento(titolo, data, posti);
                evento.PrenotaPosti(postiPrenotati);
                programmaEventi.AggiungiEvento(evento);
            }
        }
        stream.Close();
    }
}