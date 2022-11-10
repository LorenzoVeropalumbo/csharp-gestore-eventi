public class Conferenza : Evento
{
    public Conferenza(string titolo, DateTime data, int numeroDiPosti, string relatore, Double prezzo) : base(titolo, data, numeroDiPosti)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }

    private string _relatore;
    public string Relatore {
        get 
        {
            return _relatore;
        }
        set{
            if (value == "")
            {
                throw new csharpGenstioneEventiExeption("inserisci un nome valido");
            }
            else
            {
                _relatore = value;
            }
        } 
    }

    private double _prezzo;
    public Double Prezzo {
        get
        {
            return _prezzo;
        }
        set
        {
            if (value < 0)
            {
                throw new csharpGenstioneEventiExeption("inserisci un prezzo valido");
            }
            else
            {
                _prezzo = value;
            }
        }

    }

    public override string ToString()
    {
        return this.Data.ToString("dd/MM/yyyy") + " - " + this.Titolo + " - " + this.Relatore + " - " + this.Prezzo.ToString("0.00") + " euro";
    }
}