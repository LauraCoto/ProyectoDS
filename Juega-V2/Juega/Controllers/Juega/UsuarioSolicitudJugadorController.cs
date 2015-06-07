using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using System.Data.Entity;
using Juega.Utilidades;
using Juega.Models.Juega;

namespace Juega.Controllers.Juega
{
    public class UsuarioSolicitudJugadorController : JuegaController
    {
        //Descripcion: El tecnico puede aceptar o rechazar las solicitudes y filtra por Pendiente.
        // GET: UsuarioSolicitudJugador
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
                var lista = _db.Usuario_Solicitud_Equipo.Where(x => x.TipoEstado == "Pendiente").ToList(); 
                //var lista = _db.Usuario_Solicitud_Equipo.Where(x => x.TipoEstado == "Pendiente" && x.IdUsuario == User.Identity.Name).ToList(); 

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        //Recupero todos los equipo
        public ActionResult GetAllEquipo()
        {
            try
            {
                var equipo = _db.Equipo.Where(x => x.Activo == true).OrderBy(z => z.FechaCreo).ToList();
                
                //var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                var lista = new List<EquipoModel>();

                foreach (var item in equipo)
                {
                    var e = new EquipoModel();
                    
                    e.IdEquipo = item.IdEquipo;
                    
                    e.Nombre = item.Nombre.ToString();

                    lista.Add(e);
                }

                return Resultado_Correcto(lista);

            }
            catch (Exception ex)
            {
                return Resultado_Exception(ex);
            }
        }

        public JuegaJson GetAllUsuarioEquipo()
        {
            try
            {
                var equipo = _db.Equipo.Where(x => x.Activo == true).OrderBy(z => z.FechaCreo).ToList();
                var lista = new List<EquipoModel>();

                var UsersContext = new ApplicationDbContext();
                var users = UsersContext.Users.ToList();

                //var lista = new List<Usuario_Rol>();
                foreach (var item in equipo)
                {
                    foreach (var u in users)
                    {
                        //var user = users.Find(x => x.Id == item.Usuario.IdUsuarioSeguridad);

                        //if (user == null)
                        //    continue;

                        var model = new EquipoModel(item.IdEquipo, item.Nombre, u.Id, u.UserName);
                        lista.Add(model);
                    }
                }

                return Resultado_Correcto(lista);

            }
            catch (Exception ex)
            {
                return Resultado_Exception(ex);
            }
        }

        public JuegaJson GetAllUsers()
        {
            try
            {
                var UsersContext = new ApplicationDbContext();
                var users = UsersContext.Users.ToList();

                var lista = new List<Usuario_Rol>();
                foreach (var r in UsersContext.Roles.ToList())
                {
                    foreach (var u in r.Users)
                    {
                        var user = users.Find(x => x.Id == u.UserId);

                        if (user == null)
                            continue;

                        var model = new Usuario_Rol(r.Id, r.Name, user.Id, user.UserName);
                        lista.Add(model);
                    }
                }

                return Resultado_Correcto(lista);

            }
            catch (Exception ex)
            {
                return Resultado_Exception(ex);
            }
        }

        



        [HttpPost]
        public JuegaJson Create(Usuario_Solicitud_Equipo complejoDeportivo)
        {
            try
            {

                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                //if (ExisteRegistro(complejoDeportivo.Nombre, -1))
                //    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Usuario_Solicitud_Equipo.Add(complejoDeportivo);
                _db.SaveChanges();

                return Resultado_Correcto(complejoDeportivo, "El registro ha sido creado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [HttpPost]
        public JuegaJson Aceptado(Usuario_Solicitud_Equipo complejoDeportivo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                //if (ExisteRegistro(complejoDeportivo.Nombre, complejoDeportivo.IdComplejoDeportivo))
                //    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(complejoDeportivo).State = EntityState.Modified;
                //complejoDeportivo.TipoEstado = "Aceptado";
                complejoDeportivo.TipoEstado = TipoEstado.Aprobado;
                _db.SaveChanges();
                

                return Resultado_Correcto(complejoDeportivo, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [HttpPost]
        public JuegaJson Rechazado(Usuario_Solicitud_Equipo complejoDeportivo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                //if (ExisteRegistro(complejoDeportivo.Nombre, complejoDeportivo.IdComplejoDeportivo))
                //    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(complejoDeportivo).State = EntityState.Modified;
                //complejoDeportivo.TipoEstado = "Rechazado";
                complejoDeportivo.TipoEstado = TipoEstado.Rechazado;
                _db.SaveChanges();


                return Resultado_Correcto(complejoDeportivo, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
    }
}