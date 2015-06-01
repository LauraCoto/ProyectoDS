﻿using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    public class Perfil_UsuarioController : JuegaController
    {
        // GET: Perfil_Usuario
        public ActionResult Index(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (id == null || id == "")
                {
                    return Resultado_Advertencia("Usuario no existe");
                }

                _db.Configuration.ProxyCreationEnabled = false;
                var nid = int.Parse(id);
                var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == nid);

                var UsuarioModel = new UsuarioModel();

                UsuarioModel.Apellido = usuario.Apellido;
                UsuarioModel.Nombre = usuario.Nombre;
                UsuarioModel.Correo = usuario.Correo;
                UsuarioModel.Telefono = usuario.Telefonos;
                if (usuario.FechaNacimiento != null)
                    UsuarioModel.Fecha_Nac = usuario.FechaNacimiento.Value.ToShortDateString();

                return Resultado_Correcto(UsuarioModel);


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