using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    public class Perfil_UsuarioController : JuegaController
    {
        public ActionResult Index(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (string.IsNullOrEmpty(id))
                {
                    return Resultado_Advertencia("Usuario no existe");
                }

                _db.Configuration.ProxyCreationEnabled = false;
                var nid = int.Parse(id);
                var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == nid);

                var usuarioModel = new UsuarioModel();

                usuarioModel.Apellido = usuario.Apellido;
                usuarioModel.Nombre = usuario.Nombre;
                usuarioModel.Correo = usuario.Correo;

                //  return Resultado_Correcto(UsuarioModel);
                ViewBag.Usuario = usuarioModel;
                return View(usuarioModel);

            }

            catch (Exception e)
            {
                return Resultado_Exception(e);

            }
        }

        public ActionResult Perfil( string id)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion para poder visualizar este perfil.");

                var model = new UsuarioModel();
                var nid = long.Parse(id);
                var usuario = _db.Usuario.FirstOrDefault(x=> x.IdUsuario == nid);

                model.Apellido = usuario.Apellido;

                model.Correo = usuario.Correo;
                model.Descripcion = usuario.Descripcion;
                model.Edad = "";

                if (usuario.FechaNacimiento.HasValue)
                    model.Edad = Convert.ToString(DateTime.Now.Year - usuario.FechaNacimiento.Value.Year);

                model.Nombre = usuario.Nombre;

                var equipos = usuario.Equipo_Jugador.Where(u => u.Activo == true);
                if (equipos != null)
                    model.NumEquipos = equipos.Count();

                model.Valoracion = Convert.ToInt32(usuario.Valoracion.HasValue ? usuario.Valoracion : 0);

                return View(model);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);

            }
        }

        public JuegaJson Obtener_Perfil_v2()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var model = new UsuarioModel();
                var usuario = ObtenerUsuario_Juega();

                model.Apellido = usuario.Apellido;

                model.Correo = usuario.Correo;
                model.Descripcion = usuario.Descripcion;
                model.Edad = "";
                if (usuario.FechaNacimiento.HasValue)
                    model.Edad = Convert.ToString(DateTime.Now.Year - usuario.FechaNacimiento.Value.Year);
                model.Nombre = usuario.Nombre;

                var equipos = usuario.Equipo_Jugador.Where(u => u.Activo == true);
                if (equipos != null)
                    model.NumEquipos = equipos.Count();

                model.Valoracion = usuario.Usuario_Valoracion.Count();

                return Resultado_Correcto(model);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);

            }

        }

        public JuegaJson Obtener_Perfil()
        {

            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                _db.Configuration.ProxyCreationEnabled = false;
                var usuario = ObtenerUsuario_Juega();
                return Resultado_Correcto(usuario);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);

            }
        }
    }
}