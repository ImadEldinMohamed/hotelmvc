using hotelmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotelmvc.Controllers
{

    [Authorize(Roles = "admin")]

    public class ServiziController : Controller
    {
        // GET: Servizi
        public ActionResult Index()
        {
            return View(DB.getservizi());
        }

        [HttpGet]
        public ActionResult CreateServizi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateServizi(Servizi c)
        {
            if (ModelState.IsValid)
            {
                DB.Creaservizio(c.data,c.descrizione,c.quantita,c.prezzo,c.IDprenotazione);
                return RedirectToAction("Index", "Servizi");
            }
            else { return View(); }
        }

    }
}