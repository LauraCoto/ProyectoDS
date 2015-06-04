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

                    lista.Add(c);

                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        [HttpGet]
        public JsonResult ObtenerComplejos()
        {
            try
            {

                var complejos = from u in _db.ComplejoDeportivo
                                select new { Description = u.Nombre, ID = u.IdComplejoDeportivo }
                            ;

                return Json(new { complejos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Description = "", ID = "" }, JsonRequestBehavior.AllowGet);
            }
        }


        [Authorize(Roles = Utilidades.Roles.Espectador)]
        public ActionResult Crear(string id)
        {

            var viewModel = new ComplejoModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                ViewBag.Accion = "Crear";
                return View(viewModel);
            }
            else
            {
                var nid=long.Parse (id);
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

                var usuarioLogin = ObtenerUsuario_Juega();
                usuarioLogin.EsAdminEquipo = true;

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

                //Definir usuario como tecnico
                var UsersContext = new ApplicationDbContext();
                if (!User.IsInRole(Utilidades.Roles.AdminCancha))
                {
                    var usuarioSeg = UsersContext.Users.FirstOrDefault(x => x.Id == usuarioLogin.IdUsuarioSeguridad);
                    var rol = UsersContext.Roles.FirstOrDefault(x => x.Name == Utilidades.Roles.AdminCancha);

                    var identityRol = new IdentityUserRole();
                    identityRol.RoleId = rol.Id;
                    identityRol.UserId = usuarioSeg.Id;

                    usuarioSeg.Roles.Add(identityRol);
                    UsersContext.SaveChanges();

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
        [HttpPost]
        public JuegaJson Create(ComplejoDeportivo complejoDeportivo)
        {
            try
            {

                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (ExisteRegistro(complejoDeportivo.Nombre, -1))
                    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.ComplejoDeportivo.Add(complejoDeportivo);
                _db.SaveChanges();

                return Resultado_Correcto(complejoDeportivo, "El registro ha sido creado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        [HttpPost]
        public JuegaJson Update(ComplejoDeportivo complejoDeportivo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                if (ExisteRegistro(complejoDeportivo.Nombre, complejoDeportivo.IdComplejoDeportivo))
                    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(complejoDeportivo).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(complejoDeportivo, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        [HttpPost]
        public JuegaJson Delete(ComplejoDeportivo complejoDeportivo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (complejoDeportivo == null)
                    return Resultado_Advertencia("El registro no es valido.");

                var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == complejoDeportivo.IdComplejoDeportivo);

                if (complejo == null)
                    return Resultado_Advertencia("No se encontro ningun registro.");

                var canchas = _db.Cancha.Select(x => x.IdComplejoDeportivo == complejo.IdComplejoDeportivo && x.Activo == true).ToList();

                //  if (canchas != null && canchas.Count() > 0)
                //      return Resultado_Advertencia("Este compejo deportivo tiene canchas registradas, debe eliminar las canchas para continuar.");


                _db.ComplejoDeportivo.Remove(complejo);
                _db.SaveChanges();

                return Resultado_Correcto(complejoDeportivo, "El registro ha sido eliminado.");
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

            var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.Nombre == nombre &&
                                                                x.IdComplejoDeportivo != IdExcluir
                                                                );

            return complejo != null;
        }
    }
}