using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    public class PerfilController : JuegaController
    {


        public ActionResult Jugador(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion para poder visualizar este perfil.");

                var model = new UsuarioModel();
                var nid = long.Parse(id);
                var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == nid);

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


        public ActionResult Equipo(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion para poder visualizar este perfil.");

                var model = new EquiposModel();
                var nid = long.Parse(id);
                var usuario = _db.Equipo.FirstOrDefault(x => x.IdEquipo == nid);
                model.Nombre = usuario.Nombre;
                model.Valoracion = Convert.ToInt32(usuario.Valoracion.HasValue ? usuario.Valoracion : 0);

                return View(model);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);

            }
        }

        //View para editar perfil 
        public ActionResult Usuario()
        {
               return View();
        }

        public JuegaJson Editar_Perfil()
        {
            
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();
                 var UsuarioLogin = ObtenerUsuario_Juega();
                 var modelo = new EditarModel();
                 modelo.IdUsuario = UsuarioLogin.IdUsuario;
                 modelo.Nombre = UsuarioLogin.Nombre;
                 modelo.Apellido = UsuarioLogin.Apellido;
                 modelo.Descripcion = UsuarioLogin.Descripcion;
                 modelo.FechaNacimiento = UsuarioLogin.FechaNacimiento.ToString();
                 modelo.FotoPrincipal = UsuarioLogin.FotoPrincipal;
                return Resultado_Correcto(modelo);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }

        }

         




    }
}