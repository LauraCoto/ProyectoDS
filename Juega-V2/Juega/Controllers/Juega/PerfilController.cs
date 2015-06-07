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
        

        public ActionResult Jugador( string id)
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
 
        public ActionResult Cancha( string id)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion para poder visualizar este perfil.");

                var model=new CanchaModel();
                var nid = long.Parse(id);
                var cancha=_db.Cancha.FirstOrDefault(x=>x.IdCancha==nid);
                
           
                model.Ancho= Convert.ToInt32( cancha.Ancho.HasValue? cancha.Ancho:0);
                model.Largo= Convert.ToInt32( cancha.Largo.HasValue? cancha.Largo:0);
                              

                model.Nombre=cancha.Nombre;
                model.Espectadores= Convert.ToInt32( cancha.NumEspectadores.HasValue? cancha.NumEspectadores:0);

             model.Valoracion=Convert.ToInt32( cancha.Valoracion.HasValue? cancha.Valoracion:0);
                
              
                return View(model);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);

            }




        }
    }
}