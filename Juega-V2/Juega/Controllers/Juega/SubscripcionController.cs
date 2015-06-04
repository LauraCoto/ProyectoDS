using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    public class SubscripcionController : Controller
    {
        // GET: Subscripcion
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Equipo()
        {
            return RedirectToAction("Create", "CrearEquipo");
        }
    }
}