using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.Utilidades;

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
                var nid = id._ToLong();
                var jugador = _db.Usuario.FirstOrDefault(x => x.IdUsuario == nid);

                model.Apellido = jugador.Apellido;

                model.Correo = jugador.Correo;
                model.Descripcion = jugador.Descripcion;
                model.Edad = "";

                if (jugador.FechaNacimiento.HasValue)
                    model.Edad = Convert.ToString(DateTime.Now.Year - jugador.FechaNacimiento.Value.Year);

                model.Nombre = jugador.Nombre;
                model.Valoracion = jugador.Valoracion._ToDecimal();
                model.InfoValoraciones = ObtenerValoracionJugador(nid);
                model.ListaComentarios = new List<ComentariosUsuarioModel>();
                model.ListaEquipos = new List<EquiposUsuarioModel>();

                //Comentarios realizados al jugador
                var comentariosXJugador = jugador.Usuario_Valoracion;
                if (comentariosXJugador != null)
                {
                    var listaComentarios = comentariosXJugador.ToList();
                    if (listaComentarios != null)
                    {
                        model.NumComentarios = listaComentarios.Count();
                        foreach (var c in comentariosXJugador)
                        {
                            var cu = new ComentariosUsuarioModel();
                            cu.Comentario = c.Comentario;
                            cu.FotoPrincipal = c.Usuario1.FotoPrincipal;
                            cu.Tiempo = "dia";
                            cu.Titulo = c.Titulo;
                            cu.UsuarioComento = c.Usuario.Nombre + " " + c.Usuario.Apellido;
                            cu.Valoracion = c.Valoracion._ToDecimal();

                            model.ListaComentarios.Add(cu);
                        }
                    }
                }

                //Equipos del jugador
                var equiposXJugador = jugador.Equipo_Jugador;
                if (equiposXJugador != null)
                {
                    var listaEquipos = equiposXJugador.ToList();
                    if (listaEquipos != null)
                    {
                        model.NumEquipos = listaEquipos.Count();
                        foreach (var e in equiposXJugador)
                        {
                            var eu = new EquiposUsuarioModel();
                            eu.Activo = e.Equipo.Activo._ToBoolean();
                            eu.IdEquipo = e.Equipo.IdEquipo;
                            eu.Nombre = e.Equipo.Nombre;
                            eu.FotoPrincipal = e.Equipo.FotoPrincipal;
                            model.ListaEquipos.Add(eu);
                        }
                    }
                }

                return View(model);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);

            }
        }

        private RatingJugadorModel ObtenerValoracionJugador(long idJugador)
        {

            var valoracion = new RatingJugadorModel();
            valoracion.IdJugador = idJugador;

            var usuarioLogueado = ObtenerUsuario_Juega();
           
            var valoracionUsuarioLogueado = _db.Usuario_Valoracion.FirstOrDefault(x => x.IdUsuarioValora == usuarioLogueado.IdUsuario);
            var queryValoraciones = _db.Usuario_Valoracion.Where(x => x.IdUsuarioValorado == idJugador && x.Activo == true);
            var listaValoraciones = new List<BDD.Usuario_Valoracion>();

            if (queryValoraciones._IsValid())
                listaValoraciones = queryValoraciones.ToList();

            //Valoracion del jugador logueado
            if (valoracionUsuarioLogueado != null)
            {
                valoracion.Titulo = valoracionUsuarioLogueado.Titulo;
                valoracion.Valor = valoracionUsuarioLogueado.Valoracion._ToInt();
                valoracion.Comentario = valoracionUsuarioLogueado.Comentario;
                valoracion.FechaValoro = valoracionUsuarioLogueado.FechaCreo._ToDateTime();
                valoracion.IdValoracion = valoracionUsuarioLogueado.IdUsuario_Valoracion;
            }

            //Estadisticas de todos los jugador
            if (listaValoraciones != null)
            {
                var totalReviewsCount = listaValoraciones.Count(); //cuantos han comentado
                var totalRateValues = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado

                var start5Count = listaValoraciones.Count(x => x.Valoracion == 5);
                var start4Count = listaValoraciones.Count(x => x.Valoracion == 4);
                var start3Count = listaValoraciones.Count(x => x.Valoracion == 3);
                var start2Count = listaValoraciones.Count(x => x.Valoracion == 2);
                var start1Count = listaValoraciones.Count(x => x.Valoracion == 1);

                valoracion.CantidadValoraciones = totalReviewsCount._ToDecimal();

                var div = Convert.ToDecimal((totalReviewsCount <= 0 ? 1 : totalReviewsCount));
                valoracion.PromedioValoraciones = Decimal.Round(totalRateValues._ToDecimal() / div, 2, MidpointRounding.AwayFromZero); ;

                valoracion.Start5Count = start5Count;
                valoracion.Start4Count = start4Count;
                valoracion.Start3Count = start3Count;
                valoracion.Start2Count = start2Count;
                valoracion.Start1Count = start1Count;

                valoracion.Start5Avg = Decimal.Round(((start5Count / div) * 100), 2, MidpointRounding.AwayFromZero);
                valoracion.Start4Avg = Decimal.Round((start4Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start3Avg = Decimal.Round((start3Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start2Avg = Decimal.Round((start2Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start1Avg = Decimal.Round((start1Count / div) * 100, 2, MidpointRounding.AwayFromZero);

            }

            return valoracion;
        }

        public ActionResult Equipo(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion para poder visualizar este perfil.");

                var model = new EquiposModel();
                var nid = id._ToLong();
                var equipo = _db.Equipo.FirstOrDefault(x => x.IdEquipo == nid);
                model.Nombre = equipo.Nombre;
                model.Valoracion = equipo.Valoracion._ToDecimal(); 
                model.InfoValoraciones = ObtenerValoracionEquipo(nid);
                model.ListaComentarios = new List<ComentariosUsuarioModel>();
                model.ListaJugadores = new List<EquiposJugadoresModel>();

                //Comentarios realizados  al equipo
                var comentariosXEquipos = equipo.Equipo_Valoracion;
                if (comentariosXEquipos != null)
                {
                    var listaComentarios = comentariosXEquipos.ToList();
                    if (listaComentarios != null)
                    {   foreach (var c in comentariosXEquipos)
                        {
                            var cu = new ComentariosUsuarioModel();
                            cu.Comentario = c.Comentario;
                            cu.FotoPrincipal = c.Usuario.FotoPrincipal;
                            cu.Tiempo = "dia";
                            cu.Titulo = c.Titulo;
                            cu.UsuarioComento = c.Usuario.Nombre + " " + c.Usuario.Apellido;
                            cu.Valoracion = c.Valoracion._ToDecimal();

                            model.ListaComentarios.Add(cu);
                        }
                    }
                }


                //Lista de jugadores del equipo
                //Equipos del jugador
                var equiposXJugador = equipo.Equipo_Jugador;
                if (equiposXJugador != null)
                {
                    var listaEquipos = equiposXJugador.ToList();
                    if (listaEquipos != null)
                    {
                        foreach (var e in equiposXJugador)
                        {
                            var eu = new EquiposJugadoresModel();
                            eu.Activo = e.Equipo.Activo._ToBoolean();
                            eu.IdJugador = e.Usuario.IdUsuario;
                            eu.Nombre = e.Equipo.Nombre;
                            eu.FotoPrincipal = e.Equipo.FotoPrincipal;
                            model.ListaJugadores.Add(eu);
                        }
                    }
                }

                return View(model);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);

            }
        }

        private RatingEquipoModel ObtenerValoracionEquipo(long idEquipo)
        {

            var valoracion = new RatingEquipoModel();

            var usuarioLogueado = ObtenerUsuario_Juega();
            valoracion.IdEquipo = idEquipo;
            var valoracionUsuarioLogueado = _db.Equipo_Valoracion.FirstOrDefault(x => x.IdUsuarioValoro == usuarioLogueado.IdUsuario);
            var queryValoraciones = _db.Equipo_Valoracion.Where(x => x.IdEquipoValorado == idEquipo && x.Activo == true);
            var listaValoraciones = new List<BDD.Equipo_Valoracion>();

            if (queryValoraciones._IsValid())
                listaValoraciones = queryValoraciones.ToList();

            //Valoracion del jugador logueado
            if (valoracionUsuarioLogueado != null)
            {
                valoracion.Titulo = valoracionUsuarioLogueado.Titulo;
                valoracion.Valor = valoracionUsuarioLogueado.Valoracion._ToInt();
                valoracion.Comentario = valoracionUsuarioLogueado.Comentario;
                valoracion.FechaValoro = valoracionUsuarioLogueado.FechaCreo._ToDateTime();
               
                valoracion.IdValoracion = valoracionUsuarioLogueado.IdEquipo_Valoracion;
            }

            //Estadisticas de todos los jugador
            if (listaValoraciones != null)
            {
                var totalReviewsCount = listaValoraciones.Count(); //cuantos han comentado
                var totalRateValues = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado

                var start5Count = listaValoraciones.Count(x => x.Valoracion == 5);
                var start4Count = listaValoraciones.Count(x => x.Valoracion == 4);
                var start3Count = listaValoraciones.Count(x => x.Valoracion == 3);
                var start2Count = listaValoraciones.Count(x => x.Valoracion == 2);
                var start1Count = listaValoraciones.Count(x => x.Valoracion == 1);

                valoracion.CantidadValoraciones = totalReviewsCount._ToDecimal();

                var div = Convert.ToDecimal((totalReviewsCount <= 0 ? 1 : totalReviewsCount));
                valoracion.PromedioValoraciones = decimal.Round(totalRateValues._ToDecimal() / div, 2, MidpointRounding.AwayFromZero); ;

                valoracion.Start5Count = start5Count;
                valoracion.Start4Count = start4Count;
                valoracion.Start3Count = start3Count;
                valoracion.Start2Count = start2Count;
                valoracion.Start1Count = start1Count;

                valoracion.Start5Avg = decimal.Round(((start5Count / div) * 100), 2, MidpointRounding.AwayFromZero);
                valoracion.Start4Avg = decimal.Round((start4Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start3Avg = decimal.Round((start3Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start2Avg = decimal.Round((start2Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start1Avg = decimal.Round((start1Count / div) * 100, 2, MidpointRounding.AwayFromZero);

            }

            return valoracion;
        }

        public ActionResult Cancha(string id)
        {
            try
            {
                if (!TieneAcceso())
                    return MostrarError("Debe iniciar sesion para poder visualizar este perfil.");

                var model = new CanchaModel();
                var nid = id._ToLong();
                var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == nid);

                model.Ancho = cancha.Ancho._ToInt();
                model.Largo = cancha.Largo._ToInt();
                model.Nombre = cancha.Nombre;
                model.Espectadores = cancha.NumEspectadores._ToInt();
                model.Valoracion = cancha.Valoracion._ToInt();
                model.InfoValoraciones = ObtenerValoracionCancha(nid);
                model.ListaComentarios = new List<ComentariosUsuarioModel>();

                //Comentarios realizados a la cancha
                var comentariosXCancha = cancha.Cancha_Valoracion;
                if (comentariosXCancha != null)
                {
                    var listaComentarios = comentariosXCancha.ToList();
                    if (listaComentarios != null)
                    {
                        foreach (var c in comentariosXCancha)
                        {
                            var cu = new ComentariosUsuarioModel();
                            cu.Comentario = c.Comentario;
                            cu.FotoPrincipal = c.Usuario.FotoPrincipal;
                            cu.Tiempo = "dia";
                            cu.Titulo = c.Titulo;
                            cu.UsuarioComento = c.Usuario.Nombre + " " + c.Usuario.Apellido;
                            cu.Valoracion = c.Valoracion._ToDecimal();
                            model.ListaComentarios.Add(cu);
                        }
                    }
                }

                return View(model);
            }
            catch (Exception e)
            {
                return MostrarError(e.Message);

            }
        }


        private RatingCanchaModel ObtenerValoracionCancha(long idCancha)
        {

            var valoracion = new RatingCanchaModel();

            var usuarioLogueado = ObtenerUsuario_Juega();
            valoracion.IdCancha = idCancha;
            var valoracionUsuarioLogueado = _db.Cancha_Valoracion.FirstOrDefault(x => x.IdUsuarioValoro == usuarioLogueado.IdUsuario);
            var queryValoraciones = _db.Cancha_Valoracion.Where(x => x.IdCanchaValorado == idCancha && x.Activo == true);
            var listaValoraciones = new List<BDD.Cancha_Valoracion>();

            if (queryValoraciones._IsValid())
                listaValoraciones = queryValoraciones.ToList();

            //Valoracion del jugador logueado
            if (valoracionUsuarioLogueado != null)
            {
                valoracion.Valor = valoracionUsuarioLogueado.Valoracion._ToInt();
                valoracion.Comentario = valoracionUsuarioLogueado.Comentario;
                valoracion.FechaValoro = valoracionUsuarioLogueado.FechaCreo._ToDateTime();
                valoracion.IdValoracion = valoracionUsuarioLogueado.IdCancha_Valoracion;
            }

            //Estadisticas de todos los jugador
            if (listaValoraciones != null)
            {
                var totalReviewsCount = listaValoraciones.Count(); //cuantos han comentado
                var totalRateValues = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado

                var start5Count = listaValoraciones.Count(x => x.Valoracion == 5);
                var start4Count = listaValoraciones.Count(x => x.Valoracion == 4);
                var start3Count = listaValoraciones.Count(x => x.Valoracion == 3);
                var start2Count = listaValoraciones.Count(x => x.Valoracion == 2);
                var start1Count = listaValoraciones.Count(x => x.Valoracion == 1);

                valoracion.CantidadValoraciones = totalReviewsCount._ToDecimal();

                var div = Convert.ToDecimal((totalReviewsCount <= 0 ? 1 : totalReviewsCount));
                valoracion.PromedioValoraciones = decimal.Round(totalRateValues._ToDecimal() / div, 2, MidpointRounding.AwayFromZero); ;

                valoracion.Start5Count = start5Count;
                valoracion.Start4Count = start4Count;
                valoracion.Start3Count = start3Count;
                valoracion.Start2Count = start2Count;
                valoracion.Start1Count = start1Count;

                valoracion.Start5Avg = decimal.Round(((start5Count / div) * 100), 2, MidpointRounding.AwayFromZero);
                valoracion.Start4Avg = decimal.Round((start4Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start3Avg = decimal.Round((start3Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start2Avg = decimal.Round((start2Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start1Avg = decimal.Round((start1Count / div) * 100, 2, MidpointRounding.AwayFromZero);

            }

            return valoracion;
        }
        public ActionResult Usuario()
        {

            try
            {
                if (!TieneAcceso())
                    return MostrarAdvertencia("Debe iniciar sesion.");

                var usuarioLogin = ObtenerUsuario_Juega();
                var modelo = new EditarPerfil_Modelo();
                modelo.IdUsuario = usuarioLogin.IdUsuario;
                modelo.Nombre = usuarioLogin.Nombre;
                modelo.Apellido = usuarioLogin.Apellido;
                modelo.Descripcion = usuarioLogin.Descripcion;

                if (usuarioLogin.FechaNacimiento.HasValue)
                    modelo.FechaNacimiento = (DateTime)usuarioLogin.FechaNacimiento;

                modelo.FotoPrincipal = usuarioLogin.FotoPrincipal;

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
                    return MostrarAdvertencia("No se pudo actualizar la informacion del jugador");

                usuario.Nombre = model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.FotoPrincipal = model.FotoPrincipal;
                usuario.Telefonos = usuario.Telefonos;
                usuario.Descripcion = model.Descripcion;

                if (model.FechaNacimiento.Year > 1900)
                    usuario.FechaNacimiento = model.FechaNacimiento;

                _db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Usuario");
            }
            catch (Exception e)
            {
                return MostrarError("Error al actualizar el perfil: " + e.Message);
            }
        }

    }
}
