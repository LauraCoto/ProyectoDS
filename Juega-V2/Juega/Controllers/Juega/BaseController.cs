﻿using Juega.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.Utilidades;
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
        public string Info;
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

        internal ActionResult MostrarError(string mensaje, string titulo = "Error")
        {
            ViewBag.Titulo = titulo;
            ViewBag.Mensaje = mensaje;
            ViewBag.Saludo = "Ha ocurrio un ";
            ViewBag.TextClass = "text-warning";
            ViewBag.TextBigTitle = "Error";
            return View("Error");
        }

        internal ActionResult MostrarAdvertencia(string mensaje, string titulo = "Advertencia")
        {
            ViewBag.Titulo = titulo;
            ViewBag.Mensaje = mensaje;
            ViewBag.Saludo = "No se preocupes es solo una ";
            ViewBag.TextClass = "text-warning";
            ViewBag.TextBigTitle = "Alerta";
            return View("Error");
        }


        internal JuegaJson Resultado_Devolver(object data, string mensaje = "", string error = "N", string alerta = "N", string info = "N")
        {
            var r = new Resultado();
            r.data = data;
            r.Error = error;
            r.Alerta = alerta;
            r.Info = info;
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
            r.Info = "N";
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
            r.Info = "N";
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
            r.Info = mensaje.Trim().Length <= 0 ? "N" : "S";
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
            r.Info = "N";
            r.Mensaje = mensaje;

            var json = new JuegaJson(r);
            return json;
        }


        internal bool UsuarioAutenticado()
        {
            var autenticado = Request.IsAuthenticated;

            // var usu = ObtenerUsuario_MemberShip();

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
            r.Info = "N";

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

            var UsersContext = new ApplicationDbContext();
            var user = UsersContext.Users.ToList().Find(x => x.Email == User.Identity.Name);

            var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuarioSeguridad == user.Id);

            return usuario;

        }


        internal long Obtener_ID_Usuario_Juega()
        {

            var UsersContext = new ApplicationDbContext();
            var user = UsersContext.Users.ToList().Find(x => x.Email == User.Identity.Name);

            var ID = _db.Usuario.FirstOrDefault(x => x.IdUsuarioSeguridad == user.Id).IdUsuario;

            return ID;

        }

    }
}