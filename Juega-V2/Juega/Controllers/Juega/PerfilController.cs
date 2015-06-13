﻿using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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


        public ActionResult Cancha(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion para poder visualizar este perfil.");

                var model = new CanchaModel();
                var nid = long.Parse(id);
                var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == nid);


                model.Ancho = Convert.ToInt32(cancha.Ancho.HasValue ? cancha.Ancho : 0);
                model.Largo = Convert.ToInt32(cancha.Largo.HasValue ? cancha.Largo : 0);


                model.Nombre = cancha.Nombre;
                model.Espectadores = Convert.ToInt32(cancha.NumEspectadores.HasValue ? cancha.NumEspectadores : 0);

                model.Valoracion = Convert.ToInt32(cancha.Valoracion.HasValue ? cancha.Valoracion : 0);


                return View(model);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);

            }
        }

        public ActionResult Usuario()
        {

            try
            {
                if (!TieneAcceso())
                    return MostrarAdvertencia("Debe iniciar sesion.");

                var UsuarioLogin = ObtenerUsuario_Juega();
                var modelo = new EditarPerfil_Modelo();
                modelo.IdUsuario = UsuarioLogin.IdUsuario;
                modelo.Nombre = UsuarioLogin.Nombre;
                modelo.Apellido = UsuarioLogin.Apellido;
                modelo.Descripcion = UsuarioLogin.Descripcion;

                if (UsuarioLogin.FechaNacimiento.HasValue)
                    modelo.FechaNacimiento = (DateTime)UsuarioLogin.FechaNacimiento;

                modelo.FotoPrincipal = UsuarioLogin.FotoPrincipal;

                return View(modelo);
            }
            catch (Exception e)
            {
                return MostrarError("Ocurrio un error:" + e.Message);
            }
        }

        [HttpPost]
        public ActionResult Editar_Perfil(EditarPerfil_Modelo model)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion.");

                var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == model.IdUsuario);

                if (usuario == null)
                    return MostrarAdvertencia("No se pudo actualizar la informacion del usuario");

                usuario.Nombre = model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.FotoPrincipal = model.FotoPrincipal;
                usuario.Telefonos = usuario.Telefonos;
                usuario.Descripcion = model.Descripcion;

                if (model.FechaNacimiento != null && model.FechaNacimiento.Year > 1900)
                    usuario.FechaNacimiento = model.FechaNacimiento;

                _db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Usuario2");
            }
            catch (Exception e)
            {
                return MostrarError("Error al actualizar el perfil: " + e.Message);
            }
        }

    }
}
