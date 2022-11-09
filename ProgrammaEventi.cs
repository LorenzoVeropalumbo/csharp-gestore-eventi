public class ProgrammaEventi
{
    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        eventi = new List<Evento>();
    }

    public string Titolo {get;set;}
    protected List<Evento> eventi { get;set;}

    public void AggiungiEvento(Evento evento)
    {
        eventi.Add(evento);
    }

    public List<Evento> CercaEventoConData(DateTime date)
    {
        List<Evento> eventidelgiorno = new List<Evento>();

        foreach (Evento evento in eventi)
        {
            if(evento.Data.CompareTo(date) == 0)
            {
                eventidelgiorno.Add(evento);
            }
        }

        return eventidelgiorno;
    }

    public string StampaEventiLista(List<Evento> eventiDaStampare)
    {
        string strigaDaTornare = "";
        foreach (Evento evento in eventiDaStampare)
        {
            strigaDaTornare = evento.ToString() + "\n";
        }

        return strigaDaTornare;
    }

    public void RimuoviTuttiGliEventi()
    {
        eventi.Clear();
    }

    public string StampaTuttiGliEventi()
    {
        string strigaDaTornare = this.Titolo + "\n";

        string Eventi = StampaEventiLista(eventi);

        return strigaDaTornare + Eventi;
    }
}
