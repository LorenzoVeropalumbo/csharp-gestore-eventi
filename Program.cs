
ProgrammaEventi programmaEventi = RegistraProgrammaEventi();
Console.Write("Inserisci il numero di posti totali: ");
int numeroEventi = Convert.ToInt32(Console.ReadLine());
int i = 0;

bool loop = true;
while (loop)
{
    try
    {
        Evento evento = RegistraEvento(programmaEventi,ref i);
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
        loop = false;
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
    Console.Write("Inserisci il nome {0}° dell'evento: ", i+1);
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