using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Juega.Controllers.Juega
{

    [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
    public class EquiposController : JuegaController
    {  
        public ActionResult Inicio()
        {
            return View();
        } 
         
        public ActionResult GuardarVW(string id)
        {

            var viewModel = new EquiposModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                ViewBag.Accion = "Crear";
                return View(viewModel);
            }
            else
            {
                var nid = long.Parse(id);
                var item = _db.Equipo.FirstOrDefault(x => x.IdEquipo == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del equipo");

                viewModel.Nombre = item.Nombre;
                viewModel.IdEquipo = item.IdEquipo;
                viewModel.FotoPrincipal = item.FotoPrincipal;
                ViewBag.Accion = "Guardar Cambios";

                return View(viewModel);

            }
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(EquiposModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    MostrarAdvertencia("Debe completar todos los datos obligatorios");

                var usuarioLogin = ObtenerUsuario_Juega();

                usuarioLogin.EsAdminEquipo = true;

                if (ExisteRegistro(model.Nombre, model.IdEquipo))
                    return MostrarAdvertencia("Ya existe un equipo con el mismo nombre.");

                if (model.IdEquipo <= 0)
                {
                    var equipo = new Equipo();
                    equipo.Activo = true;
                    equipo.FechaCreo = DateTime.Now;
                    equipo.FotoPrincipal = model.FotoPrincipal;
                    equipo.Usuario = usuarioLogin;
                    equipo.Nombre = model.Nombre;

                    _db.Equipo.Add(equipo);

                }
                else
                {
                    var equipo = _db.Equipo.FirstOrDefault(x => x.IdEquipo == model.IdEquipo);
                    if (equipo == null)
                        return MostrarAdvertencia("No se pudo obtener la informacion del equipo");

                    equipo.FotoPrincipal = model.FotoPrincipal;
                    equipo.Nombre = model.Nombre;

                    _db.Entry(equipo).State = EntityState.Modified;
                }


                _db.Entry(usuarioLogin).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                return MostrarError(ex.Message, "Ocurrio un error guardar el complejo deportivo.");
            }
        }
         
        public ActionResult EliminarVw(string id)
        {

            var viewModel = new EquiposModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                return MostrarAdvertencia("No se pudo cargar la informacion del equipo a eliminar.");
            }
            else
            {
                var nid = long.Parse(id);
                var item = _db.Equipo.FirstOrDefault(x => x.IdEquipo == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo.");

                viewModel.FotoPrincipal = item.FotoPrincipal;
                viewModel.IdEquipo = item.IdEquipo;
                viewModel.Nombre = item.Nombre;

                return View(viewModel);

            }
        }
         
        [HttpPost]
        public ActionResult Eliminar(EquiposModel model)
        {
            try
            {


                if (model.IdEquipo <= 0)
                    return MostrarAdvertencia("No se pudo cargar la informacion del equipo a eliminar");


                var equipo = _db.Equipo.FirstOrDefault(x => x.IdEquipo == model.IdEquipo);

                if (equipo == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo a eliminar");

                equipo.Activo = false;
                equipo.FechaElimino = DateTime.Now;

                _db.Entry(equipo).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return MostrarError(e.Message, "Ocurrio un error eliminar el equipo.");
            }
        }

        private bool ExisteRegistro(string nombre, long IdExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var equipo = _db.Equipo.FirstOrDefault(x => x.Nombre == nombre &&
                                                                x.IdEquipo != IdExcluir
                                                                );

            return equipo != null;
        }
    }
}