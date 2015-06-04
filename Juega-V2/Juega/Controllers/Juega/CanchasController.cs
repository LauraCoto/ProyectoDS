using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;

namespace Juega.Controllers.Juega
{
    [Authorize(Roles = Utilidades.Roles.AdminCancha)]
    public class CanchasController : JuegaController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public JuegaJson GetAll_Model()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                // _db.Configuration.ProxyCreationEnabled = false;
                var canchas = _db.Cancha.Where(x => x.Activo == true).OrderBy(c => c.IdComplejoDeportivo).OrderBy(z => z.FechaCreo).ToList();

                var lista = new List<CanchaModel>();
                foreach (var item in canchas)
                {
                    var c = new CanchaModel();
                    c.Ancho = item.Ancho != null ? Convert.ToInt32(item.Ancho) : 0;
                    c.Largo = item.Largo != null ? Convert.ToInt32(item.Largo) : 0;
                    c.Espectadores = item.NumEspectadores != null ? Convert.ToInt32(item.NumEspectadores) : 0;

                    c.IdCancha = item.IdCancha;
                    c.Nombre = item.Nombre.ToString();

                    if (item.ComplejoDeportivo != null)
                        c.Complejo = item.ComplejoDeportivo.Nombre;

                    lista.Add(c);

                }

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

                cancha.Usuario = ObtenerUsuario_Juega();
                cancha.Activo = true;
                cancha.FechaCreo = DateTime.Now;
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
        public ActionResult Crear(CanchaModel model)
        {

            try
            {
                if (ExisteRegistro(model.Nombre, model.IdCancha))
                    return MostrarAdvertencia("Ya existe una cancha con el mismo nombre.");

                var cancha = new Cancha();

                if (model.IdComplejo > 0)
                    cancha.IdComplejoDeportivo = Convert.ToInt64(model.IdComplejo);

                cancha.Nombre = model.Nombre;
                cancha.Largo = model.Largo;
                cancha.Ancho = model.Ancho;
                cancha.NumEspectadores = model.Espectadores;
                cancha.Valoracion = 0;
                cancha.TipoEstado = Utilidades.TipoEstado.Pendiente;
                cancha.Usuario = ObtenerUsuario_Juega();
                cancha.Activo = true;
                cancha.FechaCreo = DateTime.Now;
                _db.Cancha.Add(cancha);
                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return MostrarError(e.Message, "Ocurrio un error al crear la cancha.");
            }
        }

        [HttpPost]
        public JsonResult Update(Cancha cancha)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (ExisteRegistro(cancha.Nombre, cancha.IdCancha))
                    return Resultado_Advertencia("Ya existe una cancha con el mismo nombre.");

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
        public JsonResult Delete(Cancha canchaEliminar)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (canchaEliminar == null)
                    return Resultado_Advertencia("El registro no es valido.");

                var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == canchaEliminar.IdCancha);

                if (cancha == null)
                    return Resultado_Advertencia("No se encontro ningun registro.");

                _db.Cancha.Remove(cancha);
                _db.SaveChanges();

                return Resultado_Correcto(cancha, "El registro ha sido eliminado.");

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