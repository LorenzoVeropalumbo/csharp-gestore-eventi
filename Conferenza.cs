public class Conferenza : Evento
{
    public Conferenza(string titolo, DateTime data, int numeroDiPosti, string relatore, Double prezzo) : base(titolo, data, numeroDiPosti)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }

    public string Relatore { get; set; }
    public Double Prezzo { get; set; }

    public override string ToString()
    {
        return this.Data.ToString("dd/MM/yyyy") + " - " + this.Titolo + " - " + this.Relatore + " - " + this.Prezzo.ToString("0.00") + " euro";
    }
}