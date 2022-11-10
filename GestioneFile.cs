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
        StreamWriter fileDaScrivere = File.CreateText("C:\\Users\\loren\\source\\repos\\.Net-course\\csharp-gestore-eventi\\report.csv");
        StreamReader stream = File.OpenText("C:\\Users\\loren\\source\\repos\\.Net-course\\csharp-gestore-eventi\\ListaEventi.csv");
        
        stream.ReadLine();
        while (!stream.EndOfStream)
        {
            bool IsError = false;
            string line = stream.ReadLine();
            string[] info = line.Split(",");
            string[] errori = new string[info.Length];
            string errore = "";
            if (info.Length == 4)
            {
                string titolo = "";
                if (info[0] == "")
                {
                    IsError = true;
                    errore += "hai inserito un titolo sbagliato - ";
                    errori[0] = info[0];
                }
                else
                {
                    titolo = info[0];
                }

                DateTime data = new DateTime();
                if (!DateTime.TryParse(info[1], out DateTime time))
                {
                    IsError = true;
                    errore += "hai inserito una data sbagliata - ";
                    errori[1] = info[1];
                }
                else 
                {
                    data = Convert.ToDateTime(info[1]);
                }

                int posti = 0;
                if (!Int32.TryParse(info[2], out int post))
                {
                    IsError = true;
                    errore += "hai inserito un numero posti sbagliato - ";
                    errori[2] = info[2];
                }
                else
                {
                    posti = Convert.ToInt32(info[2]);
                }

                int postiPrenotati = 0;
                if (!Int32.TryParse(info[3], out int postpre))
                {
                    IsError = true;
                    errore += "hai inserito un numero posti penotati sbagliato - ";
                    errori[3] = info[3];
                }
                else
                {
                    postiPrenotati = Convert.ToInt32(info[3]);       
                }
                
                
                if (IsError)
                {
                    fileDaScrivere.WriteLine("questo evento è sbagliato ->\n" +
                        "\t Titolo: {0} \n" + "\t Data: {1} \n" + "\t Numero Posti: {2} \n" + "\t Numero Posti Prenotati: {3} \n" + "Errore: {4}", errori[0], errori[1], errori[2], errori[3], errore);
                }
                else
                {
                    Evento evento = new Evento(titolo, data, posti);
                    evento.PrenotaPosti(postiPrenotati);
                    programmaEventi.AggiungiEvento(evento);
                }

            }
        }
        stream.Close();
        fileDaScrivere.Close();
    }
}