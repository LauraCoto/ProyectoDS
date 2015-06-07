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

    [Authorize]
    public class ComplejoDeportivoController : JuegaController
    {

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        public ActionResult Inicio()
        {
            return View();
        }

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        public JuegaJson GetAll()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                var complejos = _db.ComplejoDeportivo.Where(x => x.Activo == true
                                                           && x.IdUsuario == IdUsuarioLogin
                                                          ).OrderBy(z => z.FechaCreo)
                                                          .ToList();

                var lista = new List<ComplejoModel>();
                foreach (var item in complejos)
                {
                    var c = new ComplejoModel();

                    c.Coodernadas = item.Coodernadas;
                    c.Direccion = item.Direccion;
                    c.FotoPrincipal = item.FotoPrincipal;
                    c.IdComplejoDeportivo = item.IdComplejoDeportivo;
                    c.Nombre = item.Nombre;
                    c.Telefonos = item.Telefonos;
                    c.CantCanchas = item.Cancha.Count;

                    lista.Add(c);

                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
         


        [Authorize(Roles = Utilidades.Roles.Espectador)]
        public ActionResult GuardarVW(string id)
        {

            var viewModel = new ComplejoModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                ViewBag.Accion = "Crear";
                return View(viewModel);
            }
            else
            {
                var nid = long.Parse(id);
                var item = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo");

                viewModel.Coodernadas = item.Coodernadas;
                viewModel.Direccion = item.Direccion;
                viewModel.FotoPrincipal = item.FotoPrincipal;
                viewModel.IdComplejoDeportivo = item.IdComplejoDeportivo;
                viewModel.Telefonos = item.Telefonos;
                viewModel.Nombre = item.Nombre;
                ViewBag.Accion = "Guardar Cambios";

                return View(viewModel);

            }
        }

        [Authorize(Roles = Utilidades.Roles.Espectador)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(ComplejoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    MostrarAdvertencia("Debe completar todos los datos obligatorios");

                var usuarioLogin = ObtenerUsuario_Juega();
               
                usuarioLogin.EsAdminCancha = true;

                if (ExisteRegistro(model.Nombre, model.IdComplejoDeportivo))
                    return MostrarAdvertencia("Ya tiene agregado un complejo con el mismo nombre.");

                if (model.IdComplejoDeportivo <= 0)
                {
                    var complejo = new ComplejoDeportivo();
                    complejo.Activo = true;
                    complejo.Coodernadas = model.Coodernadas;
                    complejo.Direccion = model.Direccion;
                    complejo.FechaCreo = DateTime.Now;
                    complejo.FotoPrincipal = model.FotoPrincipal;
                    complejo.Usuario = usuarioLogin;
                    complejo.Nombre = model.Nombre;
                    complejo.Telefonos = model.Telefonos;

                    _db.ComplejoDeportivo.Add(complejo);

                }
                else
                {
                    var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == model.IdComplejoDeportivo);
                    if (complejo == null)
                        return MostrarAdvertencia("No se pudo obtener la informacion del complejo");

                    complejo.Coodernadas = model.Coodernadas;
                    complejo.Direccion = model.Direccion;
                    complejo.FotoPrincipal = model.FotoPrincipal;
                    complejo.Nombre = model.Nombre;
                    complejo.Telefonos = model.Telefonos;

                    _db.Entry(complejo).State = EntityState.Modified;
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

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        public ActionResult EliminarVw(string id)
        {

            var viewModel = new ComplejoModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo a eliminar.");
            }
            else
            {
                var nid = long.Parse(id);
                var item = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo.");

                viewModel.Coodernadas = item.Coodernadas;
                viewModel.Direccion = item.Direccion;
                viewModel.FotoPrincipal = item.FotoPrincipal;
                viewModel.IdComplejoDeportivo = item.IdComplejoDeportivo;
                viewModel.Telefonos = item.Telefonos;
                viewModel.Nombre = item.Nombre;
                viewModel.CantCanchas = item.Cancha.Count;

                return View(viewModel);

            }
        }

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        [HttpPost]
        public ActionResult Eliminar(ComplejoModel model)
        {
            try
            {


                if (model.IdComplejoDeportivo <= 0)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo a eliminar");


                var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == model.IdComplejoDeportivo);

                if (complejo == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo a eliminar");

                //var canchas = _db.Cancha.Select(x => x.IdComplejoDeportivo == complejo.IdComplejoDeportivo && x.Activo == true).ToList();

                if (complejo.Cancha.Count > 0)
                    return MostrarAdvertencia("Este compejo deportivo tiene canchas registradas, debe eliminar las canchas para continuar.");

                complejo.Activo = false;
                complejo.FechaElimino = DateTime.Now;

                _db.Entry(complejo).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return MostrarError(e.Message, "Ocurrio un error eliminar el complejo deportivo.");
            }
        }

        private bool ExisteRegistro(string nombre, long IdExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.Nombre == nombre &&
                                                                x.IdComplejoDeportivo != IdExcluir
                                                                );

            return complejo != null;
        }
    }
}