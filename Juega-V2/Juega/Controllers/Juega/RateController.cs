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


                }
                else
                {
                    //Actualizar el comentario del jugador logueado
                    valoracion.Comentario = comment;
                    valoracion.Valoracion = rate;


                    //Actualizar el campo de promedio de la tabla
                    var QueryValoraciones = _db.Usuario_Valoracion.Where(x => x.IdUsuarioValorado == IdJugadorValorando && x.Activo == true);
                    var listaValoraciones = new List<BDD.Usuario_Valoracion>();

                    if (QueryValoraciones._IsValid())
                        listaValoraciones = QueryValoraciones.ToList();

                    var TotalValoraciones = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado
                    var div = Convert.ToDecimal((TotalValoraciones <= 0 ? 1 : TotalValoraciones));
                    var PromedioValoraciones = Decimal.Round(TotalValoraciones / div, 2, MidpointRounding.AwayFromZero);

                    jugador.Valoracion = PromedioValoraciones;


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
    }
}