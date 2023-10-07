using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelmvc.Models
{
    public class Prenotazione
    {
        public int IDprenotazione { get; set; }

        public DateTime dataprenotazione { get; set; }

        public string annoprenotazione { get; set; }    

        public DateTime iniziosoggiorno { get; set; }

        public DateTime finesoggiorno { get; set; } 

        public double caparra { get; set; } 
        public double tariffa { get; set; }

        public bool mezzapensione { get; set; }

        public bool pensione { get; set; }

        public bool colazioneinclusa { get; set;}

        public int IDcliente { get; set; }

        public int IDcamera { get; set;}

        public Prenotazione() { }

        public Prenotazione ( DateTime dataprenotazione, string annoprenotazione, DateTime iniziosoggiorno, DateTime finesoggiorno, double caparra, double tariffa, bool mezzapensione, bool pensione, bool colazioneinclusa)
        {
           
            this.dataprenotazione = dataprenotazione;
            this.annoprenotazione = annoprenotazione;
            this.iniziosoggiorno = iniziosoggiorno;
            this.finesoggiorno = finesoggiorno;
            this.caparra = caparra;
            this.tariffa = tariffa;
            this.mezzapensione = mezzapensione;
            this.pensione = pensione;
            this.colazioneinclusa = colazioneinclusa;
          
        }
    }
}