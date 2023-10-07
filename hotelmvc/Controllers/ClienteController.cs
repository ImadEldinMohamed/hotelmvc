using hotelmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotelmvc.Controllers
{

    [Authorize(Roles = "admin")]

    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View(DB.getclienti());
        }

        [HttpGet]
        public ActionResult CreateCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCliente(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.Creacliente(c.CF,c.cognome,c.nome,c.citta,c.provincia,c.email,c.cellulare,c.telefono);
                return RedirectToAction("Index", "Cliente");
            }
            else { return View(); }
        }


        [HttpGet]
        public ActionResult editcliente(int IDcliente)
        {
            Cliente cliente = DB.getclienteId(IDcliente);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult editcliente(Cliente c)
        {

            if (ModelState.IsValid)
            {
                DB.modificaCliente(c.IDcliente,c.CF, c.cognome,c.nome,c.citta,c.provincia,c.email,c.cellulare,c.telefono);
                return RedirectToAction("Index", "Cliente");
            }
            else return View(c);
        }


        [HttpGet]
        public ActionResult deletecliente(int IDcliente)
        {
            DB.Remuovicliente(IDcliente);
            return RedirectToAction("Index", "Cliente");
        }
    }
}