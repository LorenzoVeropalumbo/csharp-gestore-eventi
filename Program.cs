
ProgrammaEventi programmaEventi = RegistraProgrammaEventi();
Console.Write("Inserisci il numero di eventi da inserire: ");
int numeroEventi = Convert.ToInt32(Console.ReadLine());
int i = 0;

bool mainloop = true;
while (mainloop)
{
    try
    {
        Evento evento = RegistraEvento(programmaEventi,ref i);
        // Funzioni per chiedere e disdire prenotazioni
        //Console.WriteLine(evento.ToString());
        //ChiediPrenotazioni(evento);
        //ChiediDiDisdire(evento);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    if(i == numeroEventi)
    {
        Console.WriteLine();
        Console.WriteLine("Il numero di evento nel programma è: {0}", numeroEventi);
        Console.WriteLine("Ecco il tuo programma eventi:");
        Console.WriteLine(programmaEventi.StampaTuttiGliEventi());
        Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
        string? dateRicerca = Console.ReadLine();
        List<Evento> RicercaEventi = programmaEventi.CercaEventoConData(Convert.ToDateTime(dateRicerca));
        Console.WriteLine(programmaEventi.StampaEventiLista(RicercaEventi));
        mainloop = false;
    }
}

Console.Write("Inserisci il numero di conferenze da inserire: ");
int numeroEventi1 = Convert.ToInt32(Console.ReadLine());
int j = 0;

bool mainloop1 = true;
while (mainloop1)
{
    try
    {
        Evento conferenza = RegistraConferenza(programmaEventi, ref j);

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    if (j == numeroEventi1)
    {
        Console.WriteLine("--- BONUS -----");
        Console.WriteLine();
        Console.WriteLine("Aggiungiamo anche una conferenza!");
        Console.WriteLine("Il numero di conferenze nel programma è: {0}", numeroEventi);
        Console.WriteLine("Ecco il tuo programma conferenze:");
        Console.WriteLine(programmaEventi.StampaTuttiGliEventi());
        Console.Write("Inserisci una data per sapere che conferenze ci saranno (gg/mm/yyyy): ");
        string? dateRicerca = Console.ReadLine();
        List<Evento> RicercaEventi = programmaEventi.CercaEventoConData(Convert.ToDateTime(dateRicerca));
        Console.WriteLine(programmaEventi.StampaEventiLista(RicercaEventi));
        mainloop = false;
    }
}







//METODI
ProgrammaEventi RegistraProgrammaEventi()
{
    Console.Write("Inserisci il nome del tuo programma Eventi: ");
    string? titolo = Console.ReadLine();

    ProgrammaEventi programmaEventi = new ProgrammaEventi(titolo);
    return programmaEventi;
}

Evento RegistraEvento(ProgrammaEventi programmaEventi,ref int i)
{
    Console.WriteLine();
    Console.Write("Inserisci il nome del {0}° evento: ", i+1);
    string? titolo = Console.ReadLine();

    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
    string? date = Console.ReadLine();

    Console.Write("Inserisci il numero di posti totali: ");
    int posti = Convert.ToInt32(Console.ReadLine());

    Evento evento = new Evento(titolo, Convert.ToDateTime(date), posti);
    programmaEventi.AggiungiEvento(evento);
    i++;
    Console.WriteLine();
    return evento;
    
}

Evento RegistraConferenza(ProgrammaEventi programmaEventi, ref int j)
{
    Console.WriteLine();
    Console.Write("Inserisci il nome della {0}° conferenza: ", j + 1);
    string? titolo = Console.ReadLine();

    Console.Write("Inserisci la data della conferenza (gg/mm/yyyy): ");
    string? date = Console.ReadLine();

    Console.Write("Inserisci il numero di posti per la conferenza: ");
    int posti = Convert.ToInt32(Console.ReadLine());

    Console.Write("Inserisci il relatore della conferenza: ");
    string? relatore = Console.ReadLine();

    Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
    double prezzo = Convert.ToDouble(Console.ReadLine());

    Evento evento = new Conferenza(titolo, Convert.ToDateTime(date), posti, relatore, prezzo);

    programmaEventi.AggiungiEvento(evento);
    j++;
    Console.WriteLine();
    return evento;

}

void ChiediPrenotazioni(Evento evento)
{
    Console.Write("Quanti posti desideri prenotare? ");
    int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());
    evento.PrenotaPosti(evento, postiDaPrenotare);
    StampaPosti(evento);
}

void StampaPosti(Evento evento)
{
    Console.WriteLine();
    Console.WriteLine("Numero di posti prenotati = {0}", evento.NumeroPostiPrenotati);
    Console.WriteLine("Numero di posti disponibili = {0}", evento.NumeroPostiDiponibili);
    Console.WriteLine();
}

void ChiediDiDisdire(Evento evento)
{
    Console.Write("Voui disdire dei posti (si/no)?");
    string vuoiDisdire = Console.ReadLine();
    if (vuoiDisdire == "si")
    {
        Console.Write("Indica il numero di posti da disdire: ");
        int postiDaDisdire = Convert.ToInt32(Console.ReadLine());
        evento.DisdiciPosti(evento, postiDaDisdire);
        StampaPosti(evento);
    }
    else if (vuoiDisdire == "no")
    {
        Console.Write("Ok va bene!");
        StampaPosti(evento);
    }
    else
    {
        throw new Exception("inserisci un valore valido");
    }
}
