using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaViajeros.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Pequeño sistema de control de migración";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Información de contacto";

            return View();
        }
    }
}