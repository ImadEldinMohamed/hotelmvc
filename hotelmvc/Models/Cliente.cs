using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelmvc.Models
{
    public class Cliente
    {
        public int IDcliente{ get; set; }

        public string CF { get; set; }

        public string cognome { get; set; }
        public string nome { get; set; }

        public string citta { get; set; }

        public string provincia { get; set; }

        public string email { get; set; }

        public string cellulare { get; set;}

        public string telefono { get; set; }

        public Cliente() { }

        public Cliente( string CF, string cognome, string nome, string citta, string provincia, string email, string cellulare, string telefono)
        {
      
            this.CF = CF;
            this.cognome = cognome;
            this.nome = nome;
            this.citta = citta;
            this.provincia = provincia;
            this.email = email;
            this.cellulare = cellulare;
            this.telefono = telefono;
        }
    }
}