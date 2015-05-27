using Juega.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{

    public enum StatusAcceso
    {
        Logeado = 0,
        IniciarSesion = -1,
        AccesoDenegado = -2,
    }

    public class Resultado
    {
        public object data;
        public object Mensaje;
        public string Error;
        public string Alerta;
        public string Infos;
    }

    public class JuegaJson : JsonResult
    {
        public JuegaJson(object _data, JsonRequestBehavior _jsonRequestBehavior)
        {
            this.Data = _data;
            this.JsonRequestBehavior = _jsonRequestBehavior;
        }

        public JuegaJson(object _data)
        {
            this.Data = _data;
            this.JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet;
        }

    }

    public class JuegaController : Controller
    {
        internal JuegaEntities _db = new JuegaEntities();
        internal StatusAcceso status;

        public JuegaController()
        {

        }

        internal JuegaJson Resultado_Devolver(object data, string mensaje = "", string error = "N",string alerta="N")
        {
            var r = new Resultado();
            r.data = data;
            r.Error = error;
            r.Alerta = alerta;
            r.Mensaje = mensaje;

            var json = new JuegaJson(r);
            return json;
        }

        internal JuegaJson Resultado_Exception(Exception e)
        {
            var r = new Resultado();

            r.data = null;
            r.Error = "S";
            r.Alerta = "N";
            r.Mensaje = e.Message;

            var json = new JuegaJson(r);
            return json;
        }


        internal JuegaJson Resultado_Error(string mensaje)
        {
            var r = new Resultado();

            r.data = "";
            r.Error = "S";
            r.Alerta = "N";
            r.Mensaje = mensaje;

            var json = new JuegaJson(r);
            return json;
        }


        internal JuegaJson Resultado_Correcto(object data, string mensaje = "")
        {
            var r = new Resultado();

            r.data = data;
            r.Error = "N";
            r.Alerta = "N";
            r.Mensaje = mensaje;

            var json = new JuegaJson(r);
            return json;
        }

        internal JuegaJson Resultado_Advertencia(string mensaje = "")
        {
            var r = new Resultado();

            r.data = null;
            r.Error = "N";
            r.Alerta = "S";
            r.Mensaje = mensaje;

            var json = new JuegaJson(r);
            return json;
        }


        internal bool UsuarioAutenticado()
        {
            var autenticado = Request.IsAuthenticated;

            status = autenticado ? StatusAcceso.Logeado : StatusAcceso.IniciarSesion;

            return autenticado;
        }

        internal bool TieneAcceso()
        {
            if (!UsuarioAutenticado())
                return false;

            return true;

        }

        internal JuegaJson Resultado_No_Acceso()
        {
            var r = new Resultado();

            r.data = status;
            r.Error = "S";
            r.Alerta = "N";

            if (status == StatusAcceso.AccesoDenegado)
                r.Mensaje = "No tiene acceso para usar esta funcionalidad.";

            if (status == StatusAcceso.IniciarSesion)
                r.Mensaje = "Debe iniciar sesion  para poder usar esta funcionalidad.";

            var json = new JuegaJson(r);
            return json;
        }



        internal System.Web.Security.MembershipUser ObtenerUsuario_MemberShip()
        {
            var usuario = System.Web.Security.Membership.GetUser(User.Identity.Name);
            return usuario;
        }


        internal Usuario ObtenerUsuario_Juega()
        {
            var memberShip = ObtenerUsuario_MemberShip();

            if (memberShip != null)
                return null;

            var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == 1);

            return usuario;

        }


    }
}