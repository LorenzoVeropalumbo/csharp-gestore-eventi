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
   
  
   

    // Variabili per il costruttore
    private string _titolo;
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
    private DateTime _data;
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
    private int _numeroDiPosti;
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
    public void PrenotaPosti(int postiDaPrenotare)
    {
        if(DateTime.Now.CompareTo(Data) > 0)
        {
            throw new Exception("l' evento è scaduto");
        }
        else if (NumeroDiPosti < postiDaPrenotare)
        {
            throw new Exception("numero di posti della sala insufficente");
        }
        else if (NumeroPostiDiponibili < postiDaPrenotare)
        {
            throw new Exception("numero di posti disponibile insufficente");
        }
        else
        {
            NumeroPostiPrenotati += postiDaPrenotare;
            NumeroPostiDiponibili -= postiDaPrenotare;
        }
    }

    public void DisdiciPosti(int postiDaDisdire)
    {
        if (NumeroPostiPrenotati < postiDaDisdire)
        {
            throw new Exception("numero di posti da disdire insufficente");
        }
        else if (DateTime.Now.CompareTo(Data) > 0)
        {
            throw new Exception("l' evento è scaduto");
        }
        else
        {
            NumeroPostiPrenotati -= postiDaDisdire;
            NumeroPostiDiponibili += postiDaDisdire;
        }
    }

    public override string ToString()
    {
        return this.Data.ToString("dd/MM/yyyy") + " - " + this.Titolo;
    }
}
