using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using System.Drawing;

namespace Juega.Controllers.Juega
{

    [Authorize(Roles = Utilidades.Roles.Espectador)]
    public class EquiposController : JuegaController
    {
         [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
        public ActionResult Inicio()
        {
            return View();
        }

        [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
        public JuegaJson GetAll()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                var equipos = _db.Equipo.Where(x => x.Activo == true
                                                           && x.IdUsuario == IdUsuarioLogin
                                                          ).OrderBy(z => z.FechaCreo)
                                                          .ToList();

                var lista = new List<EquiposModel>();
                foreach (var item in equipos)
                {
                    var c = new EquiposModel();

                    c.FotoPrincipal = item.FotoPrincipal;
                    c.IdEquipo = item.IdEquipo;
                    c.Nombre = item.Nombre;

                    lista.Add(c);

                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
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

                var urlbdd = model.FotoPrincipal;
                if(model.Attachment != null)
                {
                    string extension = Path.GetExtension(model.Attachment.FileName);

                    var myUniqueFileName = string.Format(@"{0}" + extension, Guid.NewGuid());
                    urlbdd = "/Content/Images/Upload/Equipos/" + myUniqueFileName;
                    string urlServidor = Server.MapPath(urlbdd);

                    var foto = Bitmap.FromStream(model.Attachment.InputStream) as Bitmap;

                    if (foto != null)
                        foto.Save(urlServidor);
                }

                if (model.IdEquipo <= 0)
                {
                    var equipo = new Equipo(); 

                    equipo.Activo = true;
                    equipo.FechaCreo = DateTime.Now;
                    equipo.FotoPrincipal = urlbdd;
                    equipo.Usuario = usuarioLogin;
                    equipo.Nombre = model.Nombre;
                    equipo.TipoEstado = Utilidades.TipoEstado.Disponible;
                    _db.Equipo.Add(equipo);

                }
                else
                {
                    var equipo = _db.Equipo.FirstOrDefault(x => x.IdEquipo == model.IdEquipo);
                    if (equipo == null)
                        return MostrarAdvertencia("No se pudo obtener la informacion del equipo");

                    equipo.FotoPrincipal = urlbdd;
                    equipo.Nombre = model.Nombre;

                    _db.Entry(equipo).State = EntityState.Modified;
                }


                //Definir jugador como tecnico
                var usersContext = new ApplicationDbContext();
                var usuarioSeg = usersContext.Users.FirstOrDefault(x => x.Id == usuarioLogin.IdUsuarioSeguridad);
                var rol = usersContext.Roles.FirstOrDefault(x => x.Name == Utilidades.Roles.AdminEquipo);

                var identityRol = usuarioSeg.Roles.FirstOrDefault(x => x.RoleId == rol.Id && x.UserId == usuarioSeg.Id);
                if (identityRol == null)
                {
                    identityRol = new IdentityUserRole();
                    identityRol.RoleId = rol.Id;
                    identityRol.UserId = usuarioSeg.Id;

                    usuarioSeg.Roles.Add(identityRol);
                    usersContext.SaveChanges();
                }

                usuarioLogin.EsAdminEquipo = true;
                _db.Entry(usuarioLogin).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                return MostrarError(ex.Message, "Ocurrio un error guardar el complejo deportivo.");
            }
        }

         [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
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
        [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
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
                                                                && x.Activo == true);

            return equipo != null;
        }
    }
}