using hotelmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotelmvc.Controllers
{

    [Authorize(Roles = "admin")]

    public class PrenotazioneController : Controller
    {
        // GET: Prenotazione
        public ActionResult Index()
        {
            return View(DB.getprenotazioni());
        }

        [HttpGet]
        public ActionResult CreatePrenotazione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePrenotazione(Prenotazione c)
        {
            if (ModelState.IsValid)
            {
                DB.CreaPrenotazione(c.dataprenotazione,c.annoprenotazione,c.iniziosoggiorno,c.finesoggiorno,c.caparra,c.tariffa,c.mezzapensione,c.pensione,c.colazioneinclusa,c.IDcliente,c.IDprenotazione);
                return RedirectToAction("Index", "Prenotazione");
            }
            else { return View(); }
        }

        [HttpGet]
        public ActionResult editprenotazione(int IDprenotazione)
        {
            Prenotazione prenotazione = DB.getprenotazioneId(IDprenotazione);
            return View(prenotazione);
        }

        [HttpPost]
        public ActionResult editprenotazione(Prenotazione c)
        {

            if (ModelState.IsValid)
            {
                DB.modificaPrenotazione(c.IDprenotazione,c.dataprenotazione,c.annoprenotazione,c.iniziosoggiorno,c.finesoggiorno,c.caparra,c.tariffa,c.mezzapensione,c.pensione,c.colazioneinclusa,c.IDcliente,c.IDcamera);
                return RedirectToAction("Index", "prenotazione");
            }
            else return View(c);
        }

    }

}