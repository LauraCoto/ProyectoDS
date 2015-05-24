using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;

namespace Juega.Controllers.Juega
{
    public class CanchasController : Controller
    {
        private JuegaEntities _db=new JuegaEntities();

        public ActionResult Index()
        {
            return View();
        }


        
        public ActionResult GetAll()
        {
            if (!Request.IsAuthenticated)
            {
               return Json(Mensajes.L600, JsonRequestBehavior.AllowGet);
            }

            _db.Configuration.ProxyCreationEnabled = false;
            var lista = _db.Cancha.ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Cancha cancha)
        {
            _db.Cancha.Add(cancha);
            _db.SaveChanges();
            return Json(cancha, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Cancha cancha)
        {
            _db.Entry(cancha).State=EntityState.Modified;
            _db.SaveChanges();
            return Json(cancha, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var nId = int.Parse(id);
            var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == nId);
            _db.Cancha.Remove(cancha);
            _db.SaveChanges();

            return Json(cancha, JsonRequestBehavior.AllowGet);
        }
    }
}