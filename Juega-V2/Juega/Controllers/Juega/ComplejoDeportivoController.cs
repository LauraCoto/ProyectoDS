using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Juega.BDD;

namespace Juega.Controllers.Juega
{
    public class ComplejoDeportivoController : BaseController
    {



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            try
            {

                //var usuario = ObtenerUsuario_MemberShip();

                if (!TieneAcceso())
                    return Json(status, JsonRequestBehavior.AllowGet);


                _db.Configuration.ProxyCreationEnabled = false;

                var lista = _db.ComplejoDeportivo.ToList(); 

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message,JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Create(ComplejoDeportivo complejoDeportivo)
        {
            if (ModelState.IsValid)
            {
                _db.ComplejoDeportivo.Add(complejoDeportivo);
                _db.SaveChanges();
                return Json(complejoDeportivo, JsonRequestBehavior.AllowGet);
            }
            

            return Json(complejoDeportivo, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Update(ComplejoDeportivo complejoDeportivo)
        {
            if (!ModelState.IsValid)
                return Json("Actualizado correctarmente", JsonRequestBehavior.AllowGet);

            _db.Entry(complejoDeportivo).State = EntityState.Modified;

            _db.SaveChanges();

            return Json(complejoDeportivo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                if (id == null)
                    return Json("El registro no es valido.", JsonRequestBehavior.AllowGet);

                var nId = int.Parse(id);
                var carrera = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == nId);

                if (carrera == null)
                    return Json("No se encontro ningun registro.", JsonRequestBehavior.AllowGet);

                _db.ComplejoDeportivo.Remove(carrera);
                _db.SaveChanges();

                return Json("Eliminado correctarmente", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error:" + ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}