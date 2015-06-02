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
                usuarioModel.Telefono = usuario.Telefonos;
                usuarioModel.id_Usuario = usuario.IdUsuario.ToString();

                if (usuario.FechaNacimiento != null)
                    usuarioModel.Fecha_Nac = usuario.FechaNacimiento.Value.ToShortDateString();

                //return Resultado_Correcto(UsuarioModel);
                ViewBag.Apellido = usuario.Apellido;
                ViewBag.Nombre = usuario.Nombre;
                ViewBag.Descripcion = usuario.Descripcion;

                return View(usuarioModel);

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