using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Juega.Controllers.Juega
{
    [Authorize(Roles=Utilidades.Roles.Espectador)]
    public class Usuario_Solicitud_EquipoController : JuegaController
    {
        public ActionResult Index()
        {
            try
            {
                var usuario = ObtenerUsuario_Juega();
                var equipos = _db.Equipo.Where(x => x.Activo == true ).OrderBy(z => z.FechaCreo).ToList();

                //var lista = new List<EquiposModel>();
                var lista = new List<EquipoModelSubscripcion>();
                foreach (var item in equipos)
                {
                    var c = new EquipoModelSubscripcion();
                    c.FotoPrincipal = item.FotoPrincipal;
                    c.IdEquipo = item.IdEquipo;
                    c.Nombre = item.Nombre;

                    var solicitud = item.Usuario_Solicitud_Equipo.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);

                    if (solicitud == null)
                        c.Estado = "";
                    else
                    {
                        if (solicitud.TipoEstado == Utilidades.TipoEstado.Pendiente)
                            c.Estado = "Pendiente";

                        if (solicitud.TipoEstado == Utilidades.TipoEstado.Rechazado)
                            c.Estado = "Rechazado";

                        if (solicitud.TipoEstado == Utilidades.TipoEstado.Aprobado)
                            c.Estado = "Aprobado";
                    }
                    c.Valoracion = Convert.ToInt32(item.Valoracion.HasValue ? item.Valoracion : 0);

                    lista.Add(c);
                }

                return View(lista);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);
            }
        }

        public ActionResult CrearSolicitud(string id)
        {
            try
            {
                if(string.IsNullOrEmpty(id))
                {
                    return MostrarAdvertencia("Seleccione un equipo Correcto.");
                }

                var nid = long.Parse(id);
                var usuarioLogin = ObtenerUsuario_Juega();
                var solicitud = _db.Usuario_Solicitud_Equipo.FirstOrDefault(x => x.Activo == true && 
                                                                            x.IdUsuario == usuarioLogin.IdUsuario &&
                                                                            x.IdEquipo == nid
                                                                            );


                ViewBag.Usuario = usuarioLogin.Nombre + " " + usuarioLogin.Apellido;
                ViewBag.Mensaje = "Se ha creado una solicitud para el equipo seleccionado.";

                if (solicitud != null)
                {
                    if (solicitud.TipoEstado == Utilidades.TipoEstado.Pendiente)
                        ViewBag.Mensaje = "Ya tiene una solicitud pendiente para este equipo.";
                    else if (solicitud.TipoEstado == Utilidades.TipoEstado.Rechazado)
                        ViewBag.Mensaje = "Su solicitud para este equipo ha sido rechazada.";
                    else
                        ViewBag.Mensaje = "Ya tiene una solicitud aprobada.";

                    return View();
                }

                solicitud = new BDD.Usuario_Solicitud_Equipo();
                solicitud.Activo = true;
                solicitud.FechaCreo = DateTime.Now;
                solicitud.IdUsuario = usuarioLogin.IdUsuario;
                solicitud.TipoEstado = Utilidades.TipoEstado.Pendiente;
                solicitud.Usuario = usuarioLogin;
                solicitud.IdEquipo = nid;

                _db.Usuario_Solicitud_Equipo.Add(solicitud);
                _db.SaveChanges();


                return View();
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);
            }
        }

        [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
        public ActionResult Inicio()
        {
            var usuarioLogin = ObtenerUsuario_Juega();
            try
            {
                var solicitudes = _db.Usuario_Solicitud_Equipo.Where(x => x.Activo == true && 
                                                                     x.TipoEstado == Utilidades.TipoEstado.Pendiente)
                                                                     .ToList();

                var lista = new List<SolicitudUsuarioEquipo>();

                foreach (var s in solicitudes)
                {
                    if (s.Equipo.IdUsuario != usuarioLogin.IdUsuario)
                        continue;

                    var model = new SolicitudUsuarioEquipo();
                    model.IdSolicitud = s.IdUsuario_Solicitud_Equipo;
                    model.Usuario = s.Usuario.Nombre + s.Usuario.Apellido;
                    model.EquipoNombre = s.Equipo.Nombre;

                    lista.Add(model);
                }

                return View(lista);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);
            }
        }

        [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
        public ActionResult Aceptar(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return MostrarAdvertencia("Solicitud es incorrecta.");

                var nid = long.Parse(id);
                var solicitud = _db.Usuario_Solicitud_Equipo.FirstOrDefault(x => x.IdUsuario_Solicitud_Equipo == nid);

                if (solicitud == null)
                    return Resultado_Advertencia("No se pudo obtener la informacion de la solicitud.");


                //Definir usuario como jugador
                var usuarioSolicito = solicitud.Usuario;
                var usersContext = new ApplicationDbContext();
                var usuarioSeg = usersContext.Users.FirstOrDefault(x => x.Id == usuarioSolicito.IdUsuarioSeguridad);
                var rol = usersContext.Roles.FirstOrDefault(x => x.Name == Utilidades.Roles.Jugador);

                var identityRol = usuarioSeg.Roles.FirstOrDefault(x => x.RoleId == rol.Id && x.UserId == usuarioSeg.Id);
                if (identityRol == null)
                {
                    identityRol = new IdentityUserRole();
                    identityRol.RoleId = rol.Id;
                    identityRol.UserId = usuarioSeg.Id;

                    usuarioSeg.Roles.Add(identityRol);
                    usersContext.SaveChanges();
                }

                usuarioSolicito.EsJugador = true;
                solicitud.TipoEstado = Utilidades.TipoEstado.Aprobado;

                _db.Entry(usuarioSolicito).State = EntityState.Modified;
                _db.Entry(solicitud).State = EntityState.Modified;

                var jugadorEquipo = new Equipo_Jugador();
                jugadorEquipo.Activo = true;
                jugadorEquipo.FechaCreo = DateTime.Now;
                jugadorEquipo.FechaDesde = DateTime.Now;
                jugadorEquipo.IdEquipo = solicitud.IdEquipo;
                jugadorEquipo.IdUsuario = usuarioSolicito.IdUsuario;
                jugadorEquipo.TipoEstado = Utilidades.TipoEstado.Disponible;

                _db.Equipo_Jugador.Add(jugadorEquipo);
               
                //Enviar correo
                _db.SaveChanges();

                //return View("Inicio");
                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
        public ActionResult Rechazar(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return MostrarAdvertencia("Solicitud es incorrecta.");

                var nid = long.Parse(id);
                var solicitud = _db.Usuario_Solicitud_Equipo.FirstOrDefault(x => x.IdUsuario_Solicitud_Equipo == nid);

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
