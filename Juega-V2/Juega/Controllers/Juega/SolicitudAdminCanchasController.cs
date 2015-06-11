using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Juega.Controllers.Juega
{
    [Authorize]
    public class SolicitudAdminCanchasController : JuegaController
    {

        [Authorize(Roles = Utilidades.Roles.Espectador)]
        public ActionResult CrearSolicitud()
        {
            try
            {
                var usuarioLogin = ObtenerUsuario_Juega();
                var solicitud = _db.Usuario_Solicitud_AdminCancha.FirstOrDefault(x => x.Activo == true && x.IdUsuario == usuarioLogin.IdUsuario);


                ViewBag.Usuario = usuarioLogin.Nombre + " " + usuarioLogin.Apellido;
                ViewBag.Mensaje = "Se ha creado una solicitud para registrarte como administrador de canchas.";

                if (solicitud != null)
                {
                    if (solicitud.TipoEstado == Utilidades.TipoEstado.Pendiente)
                        ViewBag.Mensaje = "Ya tiene una solicitud de administrador canchas pendiente de aprobacion.";
                    else
                        ViewBag.Mensaje = "Ya tiene una solicitud de administrador canchas aprobada.";

                    return View();
                }

                solicitud = new BDD.Usuario_Solicitud_AdminCancha();
                solicitud.Activo = true;
                solicitud.FechaCreo = DateTime.Now;
                solicitud.IdUsuario = usuarioLogin.IdUsuario;
                solicitud.TipoEstado = Utilidades.TipoEstado.Pendiente;
                solicitud.Usuario = usuarioLogin;
                _db.Usuario_Solicitud_AdminCancha.Add(solicitud);
                _db.SaveChanges();


                return View();
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);
            }
        }

        [Authorize(Roles = Utilidades.Roles.AdminSistema)]
        public ActionResult Inicio()
        {
            try
            {
                var solicitudes = _db.Usuario_Solicitud_AdminCancha.Where(x => x.Activo == true &&
                                                                     x.TipoEstado == Utilidades.TipoEstado.Pendiente)
                                                                     .ToList();

                var lista = new List<SolicitudAdminCanchaModel>();

                foreach (var s in solicitudes)
                {
                    var model = new SolicitudAdminCanchaModel();
                    model.IdSolicitud = s.IdUsuario_Solicitud_AdminCancha;
                    model.Usuario = s.Usuario.Nombre + s.Usuario.Apellido;

                    lista.Add(model);
                }

                return View(lista);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);
            }
        }

          
        [Authorize(Roles = Utilidades.Roles.AdminSistema)]
        public ActionResult Aceptar(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return MostrarAdvertencia("Solicitud es incorrecta.");

                var nid = long.Parse(id);
                var solicitud = _db.Usuario_Solicitud_AdminCancha.FirstOrDefault(x => x.IdUsuario_Solicitud_AdminCancha == nid);

                if (solicitud == null)
                    return Resultado_Advertencia("No se pudo obtener la informacion de la solicitud.");


                //Definir usuario como administrador de canchas
                var usuarioSolicito = solicitud.Usuario;
                var usersContext = new ApplicationDbContext();
                var usuarioSeg = usersContext.Users.FirstOrDefault(x => x.Id == usuarioSolicito.IdUsuarioSeguridad);
                var rol = usersContext.Roles.FirstOrDefault(x => x.Name == Utilidades.Roles.AdminCancha);

                var identityRol = usuarioSeg.Roles.FirstOrDefault(x => x.RoleId == rol.Id && x.UserId == usuarioSeg.Id);
                if (identityRol == null)
                {
                    identityRol = new IdentityUserRole();
                    identityRol.RoleId = rol.Id;
                    identityRol.UserId = usuarioSeg.Id;

                    usuarioSeg.Roles.Add(identityRol);
                    usersContext.SaveChanges();
                }

                usuarioSolicito.EsAdminCancha = true;
                solicitud.TipoEstado = Utilidades.TipoEstado.Aprobado;

                _db.Entry(usuarioSolicito).State = EntityState.Modified;
                _db.Entry(solicitud).State = EntityState.Modified;

                //Enviar correo
                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
          
        [Authorize(Roles = Utilidades.Roles.AdminSistema)]
        public ActionResult Rechazar(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return MostrarAdvertencia("Solicitud es incorrecta.");

                var nid = long.Parse(id);
                var solicitud = _db.Usuario_Solicitud_AdminCancha.FirstOrDefault(x => x.IdUsuario_Solicitud_AdminCancha == nid);

                if (solicitud == null)
                    return Resultado_Advertencia("No se pudo obtener la informacion de la solicitud.");

                solicitud.TipoEstado = Utilidades.TipoEstado.Rechazado;
                _db.Entry(solicitud).State = EntityState.Modified;

                //Enviar correo
                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);
            }
        }
    }
}