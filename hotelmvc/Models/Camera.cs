using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotelmvc.Models
{
   
    public class Camera
    {
        public int IDcamera { get; set; }

        public string descrizione { get; set; }

        public bool singola { get; set; }

        public bool doppia { get; set; }

        public Camera() { }

        public Camera( string descrizione, bool singola, bool doppia)
        {
          
            this.descrizione = descrizione;
            this.singola = singola;
            this.doppia = doppia;
        }
    }
}