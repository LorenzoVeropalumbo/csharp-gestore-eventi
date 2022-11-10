
using System.Security.Cryptography.X509Certificates;
bool WorkingProgram = true;

while (WorkingProgram)
{
    Console.WriteLine("Inserisci un opzione");
    Console.WriteLine("1) Milestone 1");
    Console.WriteLine("2) Milestone 3");
    Console.WriteLine("3) Milestone bonus");
    int response = Convert.ToInt32(Console.ReadLine());

    switch (response)
    {
        case 1:
            Milestone1();
            break;
        case 2:
            Milestone3();
            break;
        case 3:
            MilestoneBonus();
            break;
        default:
            break;
    }

}

void Milestone1()
{
    bool mainloop = true;
    while (mainloop)
    {
        try
        {
            int i = 0;
            Evento evento = RegistraEvento(null, i);
            Console.WriteLine(evento.ToString());
            ChiediPrenotazioni(evento);
            ChiediDiDisdire(evento);
            mainloop = false;
        }
        catch(csharpGenstioneEventiExeption e)
        {
            Console.WriteLine(e.Message);
        }
    }

}

void Milestone3()
{
    int i = 0;
    ProgrammaEventi programmaEventi = RegistraProgrammaEventi();
    int numeroEventi = ChiedoEventiNumero("eventi");
    // Funzioni per chiedere e disdire prenotazioni
    bool mainloop = true;
    while (mainloop)
    {
        try
        {            
            if (i >= numeroEventi)
            {
                Console.WriteLine();
                Console.WriteLine("Il numero di evento nel programma è: {0}", numeroEventi);
                Console.WriteLine("Ecco il tuo programma eventi:");
                Console.WriteLine(programmaEventi.StampaTuttiGliEventi());
                Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
                string? dateRicerca = Console.ReadLine();
                if (!DateTime.TryParse(dateRicerca, out DateTime time))
                {
                    throw new csharpGenstioneEventiExeption("inserisci una data valida");
                }
                List<Evento> RicercaEventi = programmaEventi.CercaEventoConData(Convert.ToDateTime(dateRicerca));
                Console.WriteLine(programmaEventi.StampaEventiLista(RicercaEventi));
                mainloop = false;
            
            }
            else
            {
                Evento evento = RegistraEvento(programmaEventi, i);
                i++;
            }
        }
        catch (csharpGenstioneEventiExeption e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
}

void MilestoneBonus()
{
    ProgrammaEventi programmaEventi = RegistraProgrammaEventi();
    int i = 0;
    int numeroEventi = ChiedoEventiNumero("conferenze");
 
    bool mainloop = true;
    while (mainloop)
    {
        try
        {   
            
            if (i >= numeroEventi)
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
                i++;
            }
            else
            {
                Evento evento = RegistraConferenza(programmaEventi, i);
                i++;
            }

        }
        catch (csharpGenstioneEventiExeption e)
        {
            Console.WriteLine(e.Message);
        }
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

Evento RegistraEvento(ProgrammaEventi programmaEventi,int i)
{
    Console.WriteLine();
    Console.Write("Inserisci il nome del {0}° evento: ", i+1);
    string? titolo = Console.ReadLine();

    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
    string? date = Console.ReadLine();
    if (!DateTime.TryParse(date, out DateTime time))
    {
        throw new csharpGenstioneEventiExeption("inserisci un valore valido");
    }

    Console.Write("Inserisci il numero di posti totali: ");
    int posti = Convert.ToInt32(Console.ReadLine());

    Evento evento = new Evento(titolo, Convert.ToDateTime(date), posti);

    if (programmaEventi != null)
    {
        programmaEventi.AggiungiEvento(evento);         
    }

    Console.WriteLine();
    return evento;  
}

Evento RegistraConferenza(ProgrammaEventi programmaEventi, int i)
{
    Console.WriteLine();
    Console.Write("Inserisci il nome della {0}° conferenza: ", i + 1);
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
    Console.WriteLine();
    return evento;

}

void ChiediPrenotazioni(Evento evento)
{
    Console.Write("Quanti posti desideri prenotare? ");
    int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());
    evento.PrenotaPosti(postiDaPrenotare);
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
        evento.DisdiciPosti(postiDaDisdire);
        StampaPosti(evento);
    }
    else if (vuoiDisdire == "no")
    {
        Console.Write("Ok va bene!");
        StampaPosti(evento);
    }
    else
    {
        throw new csharpGenstioneEventiExeption("inserisci un valore valido");
    }
}

int ChiedoEventiNumero(string tipo)
{
    int numeroEventi = 0;
    bool firstloop = true;
    while (firstloop)
    {
        try
        {
            Console.Write("Inserisci il numero di {0} da inserire: ", tipo);
            if (!Int32.TryParse(Console.ReadLine(), out int result))
            {
                throw new csharpGenstioneEventiExeption("inserire un numero valido");
            }
            else
            {
                numeroEventi = result;
                firstloop = false;
            }
        }
        catch (csharpGenstioneEventiExeption e)
        {
            Console.WriteLine(e.Message);
        }
    }

    return numeroEventi;
}
