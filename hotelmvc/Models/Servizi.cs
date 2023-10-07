using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelmvc.Models
{
    public class Servizi
    {
        public int IDservizio { get; set; }

        public DateTime data { get; set; }

        public string descrizione { get; set; }

        public int quantita { get; set; }   


        public double prezzo { get; set; }  
     

       public int IDprenotazione { get; set; }  

        public Servizi() { }

        public Servizi( DateTime data, string descrizione, int quantita, double prezzo)
        {
         
            this.data = data;
            this.descrizione = descrizione;
            this.quantita = quantita;
            this.prezzo = prezzo;
          
        }
    }
}