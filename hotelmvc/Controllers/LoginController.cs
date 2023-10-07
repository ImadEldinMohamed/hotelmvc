using hotelmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hotelmvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utente u)
        {
            Utente user = DB.GetUtentebyusername(u.username);
            if (user.username != null)
            {
                if (user.password == u.password)
                {
                    FormsAuthentication.SetAuthCookie(u.username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Password sbagliata";
                    return View();
                }

            }
            else
            {
                ViewBag.ErrorMessage = "L'Username inserito non esiste";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}