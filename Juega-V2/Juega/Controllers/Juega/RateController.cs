using Juega.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.Utilidades;

namespace Juega.Controllers.Juega
{
    public class RateController : JuegaController
    {
        public JsonResult Jugador(long IdJugadorValorando, int rate, string title, string comment)
        {
            try
            {
                var jugador = _db.Usuario.FirstOrDefault(x => x.IdUsuario == IdJugadorValorando);
                if (jugador == null)
                    return Json(new { error = "El jugador que desea evaluar ya no existe.", success = false, id = IdJugadorValorando }, JsonRequestBehavior.AllowGet);

                var usuarioLogueado = ObtenerUsuario_Juega();

                if (usuarioLogueado == null)
                    return Json(new { error = "Tu sesión ha caducado, vuelve a iniciar sesión.", success = false, id = IdJugadorValorando }, JsonRequestBehavior.AllowGet);


                var valoracion = _db.Usuario_Valoracion.FirstOrDefault(x => x.IdUsuarioValora == usuarioLogueado.IdUsuario &&
                                                                             x.IdUsuarioValorado == IdJugadorValorando);

                if (valoracion == null)
                {
                    valoracion = new Usuario_Valoracion();
                    valoracion.FechaCreo = DateTime.Now;
                    valoracion.Activo = true;
                    valoracion.IdUsuarioValora = usuarioLogueado.IdUsuario;
                    valoracion.IdUsuarioValorado = IdJugadorValorando;
                    valoracion.Usuario = jugador;
                    valoracion.Usuario1 = usuarioLogueado;
                    valoracion.Valoracion = rate;
                    valoracion.Comentario = comment;
                    valoracion.Titulo = title;
                    _db.Usuario_Valoracion.Add(valoracion);

                    //Actualizar el campo de promedio de la tabla
                    var queryValoraciones = _db.Usuario_Valoracion.Where(x => x.IdUsuarioValorado == IdJugadorValorando && x.Activo == true);
                    var listaValoraciones = new List<BDD.Usuario_Valoracion>();

                    if (queryValoraciones._IsValid())
                        listaValoraciones = queryValoraciones.ToList();

                    var totalValoraciones = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado
                    var div = Convert.ToDecimal((totalValoraciones <= 0 ? 1 : totalValoraciones));
                    var promedioValoraciones = decimal.Round(totalValoraciones / div, 2, MidpointRounding.AwayFromZero);

                    jugador.Valoracion = promedioValoraciones;

                }
                else
                {
                    //Actualizar el comentario del jugador logueado
                    valoracion.Comentario = comment;
                    valoracion.Valoracion = rate;


                    //Actualizar el campo de promedio de la tabla
                    var queryValoraciones = _db.Usuario_Valoracion.Where(x => x.IdUsuarioValorado == IdJugadorValorando && x.Activo == true);
                    var listaValoraciones = new List<BDD.Usuario_Valoracion>();

                    if (queryValoraciones._IsValid())
                        listaValoraciones = queryValoraciones.ToList();

                    var totalValoraciones = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado
                    var div = Convert.ToDecimal((totalValoraciones <= 0 ? 1 : totalValoraciones));
                    var promedioValoraciones = decimal.Round(totalValoraciones / div, 2, MidpointRounding.AwayFromZero);

                    jugador.Valoracion = promedioValoraciones;


                    _db.Entry(valoracion).State = System.Data.Entity.EntityState.Modified;
                }

                _db.SaveChanges();
                return Json(new { error = "", success = true, id = IdJugadorValorando }, JsonRequestBehavior.AllowGet);
            }

            catch (System.Exception ex)
            {
                return Json(new { error = "Error al guardar valoracion: " + ex.Message, success = false, id = IdJugadorValorando }, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult Equipo(long IdEquipoValorando, int rate, string title, string comment)
        {
            try
            {
                var equipo = _db.Equipo.FirstOrDefault(x => x.IdEquipo == IdEquipoValorando);
                if (equipo == null)
                    return Json(new { error = "El equipo que desea evaluar ya no existe.", success = false, id = IdEquipoValorando }, JsonRequestBehavior.AllowGet);

                var usuarioLogueado = ObtenerUsuario_Juega();

                if (usuarioLogueado == null)
                    return Json(new { error = "Tu sesión ha caducado, vuelve a iniciar sesión.", success = false, id = IdEquipoValorando }, JsonRequestBehavior.AllowGet);


                var valoracion = _db.Equipo_Valoracion.FirstOrDefault(x => x.IdUsuarioValoro == usuarioLogueado.IdUsuario &&
                                                                             x.IdEquipoValorado == IdEquipoValorando);

                if (valoracion == null)
                {
                    valoracion = new Equipo_Valoracion();
                    valoracion.FechaCreo = DateTime.Now;
                    valoracion.Activo = true;
                    valoracion.IdUsuarioValoro = usuarioLogueado.IdUsuario;
                    valoracion.IdEquipoValorado = IdEquipoValorando;
                    valoracion.Usuario = usuarioLogueado;
                    valoracion.Valoracion = rate;
                    valoracion.Comentario = comment;
                    valoracion.Titulo = title;
                    _db.Equipo_Valoracion.Add(valoracion);

                    //Actualizar el campo de promedio de la tabla
                    var queryValoraciones = _db.Equipo_Valoracion.Where(x => x.IdEquipoValorado == IdEquipoValorando && x.Activo == true);
                    var listaValoraciones = new List<BDD.Equipo_Valoracion>();

                    if (queryValoraciones._IsValid())
                        listaValoraciones = queryValoraciones.ToList();

                    var totalValoraciones = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado
                    var div = Convert.ToDecimal((totalValoraciones <= 0 ? 1 : totalValoraciones));
                    var promedioValoraciones = decimal.Round(totalValoraciones / div, 2, MidpointRounding.AwayFromZero);

                    equipo.Valoracion = promedioValoraciones;

                }
                else
                {
                    //Actualizar el comentario del jugador logueado
                    valoracion.Comentario = comment;
                    valoracion.Valoracion = rate;


                    //Actualizar el campo de promedio de la tabla
                    var queryValoraciones = _db.Equipo_Valoracion.Where(x => x.IdEquipoValorado == IdEquipoValorando && x.Activo == true);
                    var listaValoraciones = new List<BDD.Equipo_Valoracion>();

                    if (queryValoraciones._IsValid())
                        listaValoraciones = queryValoraciones.ToList();

                    var totalValoraciones = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado
                    var div = Convert.ToDecimal((totalValoraciones <= 0 ? 1 : totalValoraciones));
                    var promedioValoraciones = decimal.Round(totalValoraciones / div, 2, MidpointRounding.AwayFromZero);

                    equipo.Valoracion = promedioValoraciones;


                    _db.Entry(valoracion).State = System.Data.Entity.EntityState.Modified;
                }

                _db.SaveChanges();
                return Json(new { error = "", success = true, id = IdEquipoValorando }, JsonRequestBehavior.AllowGet);
            }

            catch (System.Exception ex)
            {
                return Json(new { error = "Error al guardar valoracion: " + ex.Message, success = false, id = IdEquipoValorando }, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult Canchas (long IdCanchaValorando, int rate, string title, string comment)
        {
            try
            {
                var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == IdCanchaValorando);
                if (cancha == null)
                    return Json(new { error = "la cancha que desea evaluar ya no existe.", success = false, id = IdCanchaValorando }, JsonRequestBehavior.AllowGet);

                var usuarioLogueado = ObtenerUsuario_Juega();

                if (usuarioLogueado == null)
                    return Json(new { error = "Tu sesión ha caducado, vuelve a iniciar sesión.", success = false, id = IdCanchaValorando }, JsonRequestBehavior.AllowGet);


                var valoracion = _db.Cancha_Valoracion.FirstOrDefault(x => x.IdUsuarioValoro == usuarioLogueado.IdUsuario &&
                                                                             x.IdCanchaValorado == IdCanchaValorando);

                if (valoracion == null)
                {
                    valoracion = new Cancha_Valoracion();
                    valoracion.FechaCreo = DateTime.Now;
                    valoracion.Activo = true;
                    valoracion.IdUsuarioValoro = usuarioLogueado.IdUsuario;
                    valoracion.IdCanchaValorado = IdCanchaValorando;
                    valoracion.Usuario = usuarioLogueado;
                    valoracion.Valoracion = rate;
                    valoracion.Comentario = comment;
                    valoracion.Titulo = title;
                    _db.Cancha_Valoracion.Add(valoracion);

                    //Actualizar el campo de promedio de la tabla
                    var queryValoraciones = _db.Cancha_Valoracion.Where(x => x.IdCanchaValorado == IdCanchaValorando && x.Activo == true);
                    var listaValoraciones = new List<BDD.Cancha_Valoracion>();

                    if (queryValoraciones._IsValid())
                        listaValoraciones = queryValoraciones.ToList();

                    var totalValoraciones = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado
                    var div = Convert.ToDecimal((totalValoraciones <= 0 ? 1 : totalValoraciones));
                    var promedioValoraciones = decimal.Round(totalValoraciones / div, 2, MidpointRounding.AwayFromZero);

                    cancha.Valoracion = promedioValoraciones;

                }
                else
                {
                    //Actualizar el comentario del jugador logueado
                    valoracion.Comentario = comment;
                    valoracion.Valoracion = rate;


                    //Actualizar el campo de promedio de la tabla
                    var queryValoraciones = _db.Cancha_Valoracion.Where(x => x.IdCanchaValorado == IdCanchaValorando && x.Activo == true);
                    var listaValoraciones = new List<BDD.Cancha_Valoracion>();

                    if (queryValoraciones._IsValid())
                        listaValoraciones = queryValoraciones.ToList();

                    var totalValoraciones = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado
                    var div = Convert.ToDecimal((totalValoraciones <= 0 ? 1 : totalValoraciones));
                    var promedioValoraciones = decimal.Round(totalValoraciones / div, 2, MidpointRounding.AwayFromZero);

                    cancha.Valoracion = promedioValoraciones;


                    _db.Entry(valoracion).State = System.Data.Entity.EntityState.Modified;
                }

                _db.SaveChanges();
                return Json(new { error = "", success = true, id = IdCanchaValorando }, JsonRequestBehavior.AllowGet);
            }

            catch (System.Exception ex)
            {
                return Json(new { error = "Error al guardar valoracion: " + ex.Message, success = false, id = IdCanchaValorando }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}