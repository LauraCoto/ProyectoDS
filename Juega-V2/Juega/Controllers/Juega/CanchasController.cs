using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;

namespace Juega.Controllers.Juega
{
    [Authorize(Roles = "adm_cancha")]
    public class CanchasController : JuegaController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JuegaJson GetAll()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                _db.Configuration.ProxyCreationEnabled = false;
                var lista = _db.Cancha.ToList();

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JsonResult Create(Cancha cancha)
        {

            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (ExisteRegistro(cancha.Nombre, -1))
                    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Cancha.Add(cancha);
                _db.SaveChanges();

                return Resultado_Correcto(cancha, "El registro ha sido creado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JsonResult Update(Cancha cancha)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (ExisteRegistro(cancha.Nombre, -1))
                    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(cancha).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(cancha, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var nId = int.Parse(id);
                var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == nId);

                if (cancha == null)
                    return Resultado_Error("No se encontro ningun registro.");

                _db.Cancha.Remove(cancha);
                _db.SaveChanges();

                return Resultado_Correcto(id, "El registro ha sido eliminado.");

            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        private bool ExisteRegistro(string nombre, long IdExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var registro = _db.Cancha.FirstOrDefault(x => x.Nombre == nombre &&
                                                                x.IdCancha != IdExcluir
                                                                );

            return registro != null;
        }

    }
}