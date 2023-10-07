using hotelmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotelmvc.Controllers
{
    [Authorize(Roles = "admin")]
    public class CameraController : Controller
    {
        // GET: Camera
        public ActionResult Index()
        {
            return View(DB.getcamere());
        }
        [HttpGet]
        public ActionResult CreateCamera()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCamera(Camera c)
        {
            if (ModelState.IsValid)
            {
                DB.Creacamera(c.descrizione,c.singola,c.doppia);
                return RedirectToAction("Index", "Camera");
            }
            else { return View(); }
        }


        [HttpGet]
        public ActionResult editcamera(int IDcamera)
        {
            Camera camera = DB.getcameraId(IDcamera);
            return View(camera);
        }

        [HttpPost]
        public ActionResult editcamera(Camera c)
        {

            if (ModelState.IsValid)
            {
                DB.modificaCamera(c.IDcamera,c.descrizione,c.singola,c.doppia);
                return RedirectToAction("Index", "Camera");
            }
            else return View(c);
        }


        [HttpGet]
        public ActionResult deletecamera(int IDcamera)
        {
            DB.Remuovicamera(IDcamera);
            return RedirectToAction("Index", "Camera");
        }

    }
}