using Microsoft.VisualBasic;

public class Evento
{
    //  Evento Constructor
    public Evento(string titolo, DateTime data, int numeroDiPosti)
    {
        Titolo = titolo;
        Data = data;
        NumeroDiPosti = numeroDiPosti;
        NumeroPostiPrenotati = 0;
        NumeroPostiDiponibili = numeroDiPosti;
    }

    // Variabili per le properties
    private string _titolo;
    private DateTime _data;
    private int _numeroDiPosti;

    // Variabili per il costruttore
    public string Titolo { 
        get
        {
            return _titolo;
        } 
        set
        {
            if (value == "")
            {
                throw new Exception("devi inserire un titolo valido");
            }
            else
            {
                _titolo = value;
            }
        } 
    }
    public DateTime Data { 
        get 
        {
            return _data;
        } 
        set
        {
            if (DateTime.Now.CompareTo(value) > 0)
            {
                throw new Exception("devi inserire una data corretta");
            }
            else
            {
                _data = value;
            }
        } 
    }
    public int NumeroDiPosti { 
        get
        {
            return _numeroDiPosti;
        }
        private set
        {
            if (value <= 0)
            {
                throw new Exception("devi inserire un valore valido");
            }
            else
            {
                _numeroDiPosti = value;
            }
        }
    }
    public int NumeroPostiPrenotati { get; private set; }
    public int NumeroPostiDiponibili { get; set; }

    // FUNZIONI
    public void PrenotaPosti(Evento evento, int postiDaPrenotare)
    {
        if(DateTime.Now.CompareTo(evento.Data) > 0)
        {
            throw new Exception("l' evento è scaduto");
        }
        else if (evento.NumeroDiPosti < postiDaPrenotare)
        {
            throw new Exception("numero di posti della sala insufficente");
        }
        else if (evento.NumeroPostiDiponibili < postiDaPrenotare)
        {
            throw new Exception("numero di posti disponibile insufficente");
        }
        else
        {
            evento.NumeroPostiPrenotati += postiDaPrenotare;
            evento.NumeroPostiDiponibili -= postiDaPrenotare;
        }
    }

    public void DisdiciPosti(Evento evento, int postiDaDisdire)
    {
        if (evento.NumeroPostiPrenotati < postiDaDisdire)
        {
            throw new Exception("numero di posti da disdire insufficente");
        }
        else if (DateTime.Now.CompareTo(evento.Data) > 0)
        {
            throw new Exception("l' evento è scaduto");
        }
        else
        {
            evento.NumeroPostiPrenotati -= postiDaDisdire;
            evento.NumeroPostiDiponibili += postiDaDisdire;
        }
    }

    public override string ToString()
    {
        return this.Data.ToString("dd/MM/yyyy") + " - " + this.Titolo;
    }
}
