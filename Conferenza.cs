public class Conferenza : Evento
{
    public Conferenza(string titolo, DateTime data, int numeroDiPosti) : base(titolo, data, numeroDiPosti)
    {

    }

    public string Relatore { get; set; }
    public Double Prezzo { get; set; }
}