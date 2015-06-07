using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    [Authorize]
    public class EspectadorController : JuegaController
    {

        public ActionResult Complejos()
        {
            return View();
        }

        public JuegaJson GetAll_Complejos()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                var complejos = _db.ComplejoDeportivo.Where(x => x.Activo == true
                                                          ).OrderBy(z => z.FechaCreo)
                                                          .ToList();

                var lista = new List<ComplejoModel>();
                foreach (var item in complejos)
                {
                    var c = new ComplejoModel();

                    c.Coodernadas = item.Coodernadas;
                    c.Direccion = item.Direccion;
                    c.FotoPrincipal = item.FotoPrincipal;
                    c.IdComplejoDeportivo = item.IdComplejoDeportivo;
                    c.Nombre = item.Nombre;
                    c.Telefonos = item.Telefonos;
                    c.CantCanchas = item.Cancha.Count;

                    lista.Add(c);
                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        public ActionResult Canchas(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id) || id == "-1")
                    return MostrarAdvertencia("El complejo deportivo seleccionado es incorrecto.");

                var nid = long.Parse(id);
                var canchas = _db.Cancha.Where(x => x.Activo == true && x.IdComplejoDeportivo == nid).OrderBy(z => z.FechaCreo).ToList();

                var lista = new List<CanchaModel>();
                foreach (var item in canchas)
                {
                    var c = new CanchaModel();
                    c.Ancho = item.Ancho != null ? Convert.ToInt32(item.Ancho) : 0;
                    c.Largo = item.Largo != null ? Convert.ToInt32(item.Largo) : 0;
                    c.Espectadores = item.NumEspectadores != null ? Convert.ToInt32(item.NumEspectadores) : 0;

                    c.IdCancha = item.IdCancha;
                    c.Nombre = item.Nombre.ToString();

                    if (item.ComplejoDeportivo != null)
                        c.Complejo = item.ComplejoDeportivo.Nombre;

                    lista.Add(c);

                    ViewBag.NombreComplejo = c.Complejo;
                }

                return View(lista);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);
            }
        }

        public JuegaJson GetAll_Canchas(string id)// El Id de complejo
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (string.IsNullOrEmpty(id) || id == "-1")
                    return Resultado_Advertencia("El complejo deportivo seleccionado es incorrecto.");

                var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                var nid = long.Parse(id);
                var canchas = _db.Cancha.Where(x => x.Activo == true && x.IdComplejoDeportivo == nid).OrderBy(z => z.FechaCreo).ToList();

                var lista = new List<CanchaModel>();
                foreach (var item in canchas)
                {
                    var c = new CanchaModel();
                    c.Ancho = item.Ancho != null ? Convert.ToInt32(item.Ancho) : 0;
                    c.Largo = item.Largo != null ? Convert.ToInt32(item.Largo) : 0;
                    c.Espectadores = item.NumEspectadores != null ? Convert.ToInt32(item.NumEspectadores) : 0;

                    c.IdCancha = item.IdCancha;
                    c.Nombre = item.Nombre.ToString();

                    if (item.ComplejoDeportivo != null)
                        c.Complejo = item.ComplejoDeportivo.Nombre;

                    lista.Add(c);

                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }



        public ActionResult Equipos()
        {
            return View();
        }


        public JuegaJson GetAll_Equipos()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                var equipos = _db.Equipo.Where(x => x.Activo == true).OrderBy(z => z.FechaCreo).ToList();

                var lista = new List<EquiposModel>();
                foreach (var item in equipos)
                {
                    var c = new EquiposModel();
                    c.FotoPrincipal = item.FotoPrincipal;
                    c.IdEquipo = item.IdEquipo;
                    c.Nombre = item.Nombre;
                    c.Valoracion = Convert.ToInt32(item.Valoracion.HasValue ? item.Valoracion : 0);

                    lista.Add(c);
                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        public ActionResult Jugadores(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id) || id == "-1")
                    return MostrarAdvertencia("El equipo seleccionado es incorrecto.");

                var nid = long.Parse(id);
                var jugadores = _db.Equipo_Jugador.Where(x => x.Activo == true && x.IdEquipo == nid).OrderBy(z => z.FechaCreo).ToList();

                var lista = new List<JugadorModel>();
                foreach (var item in jugadores)
                {
                    var usuario = item.Usuario;

                    var j = new JugadorModel();
                    j.IdJugador = usuario.IdUsuario.ToString();
                    j.Apellido = usuario.Apellido;
                    j.Nombre = usuario.Nombre;
                    j.Correo = usuario.Correo;
                    j.Descripcion = usuario.Descripcion;
                    j.Edad = "0";
                    j.Valoracion = Convert.ToInt32(usuario.Valoracion.HasValue ? usuario.Valoracion : 0);

                    if (usuario.FechaNacimiento.HasValue)
                        j.Edad = Convert.ToString(DateTime.Now.Year - usuario.FechaNacimiento.Value.Year);

                    var equipos = usuario.Equipo_Jugador.Where(u => u.Activo == true);
                    if (equipos != null)
                        j.NumEquipos = equipos.Count();

                   
                    lista.Add(j);
                }

                return View(lista);
            }

            catch (Exception e)
            {
                return MostrarError(e.Message);
            }

        }

        public JuegaJson GetAll_Jugadores(string id) // el id de Equipo
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                if (string.IsNullOrEmpty(id) || id == "-1")
                    return Resultado_Advertencia("El equipo seleccionado es incorrecto.");

                var IdUsuarioLogin = Obtener_ID_Usuario_Juega();
                var nid = long.Parse(id);
                var jugadores = _db.Equipo_Jugador.Where(x => x.Activo == true && x.IdEquipo == nid).OrderBy(z => z.FechaCreo).ToList();

                var lista = new List<JugadorModel>();
                foreach (var item in jugadores)
                {
                    var usuario = item.Usuario;

                    var j = new JugadorModel();
                    j.Apellido = usuario.Apellido;
                    j.Nombre = usuario.Nombre;
                    j.Correo = usuario.Correo;
                    j.Descripcion = usuario.Descripcion;
                    j.Edad = "0";
                    j.Valoracion = Convert.ToInt32(usuario.Valoracion.HasValue ? usuario.Valoracion : 0);

                    if (usuario.FechaNacimiento.HasValue)
                        j.Edad = Convert.ToString(DateTime.Now.Year - usuario.FechaNacimiento.Value.Year);

                    var equipos = usuario.Equipo_Jugador.Where(u => u.Activo == true);
                    if (equipos != null)
                        j.NumEquipos = equipos.Count();

                    lista.Add(j);
                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
    }
}