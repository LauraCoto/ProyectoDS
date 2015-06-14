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
                model.Valoracion = Convert.ToInt32(jugador.Valoracion.HasValue ? jugador.Valoracion : 0);
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
                            cu.Valoracion =  c.Valoracion._ToDecimal ();

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
                            var eu=new EquiposUsuarioModel();
                            eu.Activo =e.Equipo.Activo._ToBoolean ();
                            eu.IdEquipo = e.Equipo.IdEquipo;
                            eu.Nombre = e.Equipo.Nombre;
                            eu.FotoPrincipal =e.Equipo.FotoPrincipal;
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

        private RatingJugadorModel ObtenerValoracionJugador(long IdJugador)
        {

            var valoracion = new RatingJugadorModel();

            var UsuarioLogueado = ObtenerUsuario_Juega();
            valoracion.IdJugador = IdJugador;
            var ValoracionUsuarioLogueado = _db.Usuario_Valoracion.FirstOrDefault(x => x.IdUsuarioValora == UsuarioLogueado.IdUsuario);
            var QueryValoraciones = _db.Usuario_Valoracion.Where(x => x.IdUsuarioValorado == IdJugador && x.Activo == true);
            var listaValoraciones = new List<BDD.Usuario_Valoracion>();

            if (QueryValoraciones._IsValid())
                listaValoraciones = QueryValoraciones.ToList();

            //Valoracion del jugador logueado
            if (ValoracionUsuarioLogueado != null)
            {
                valoracion.Valor = ValoracionUsuarioLogueado.Valoracion._ToInt();
                valoracion.Comentario = ValoracionUsuarioLogueado.Comentario;
                valoracion.FechaValoro = ValoracionUsuarioLogueado.FechaCreo._ToDateTime();
                valoracion.IdValoracion = ValoracionUsuarioLogueado.IdUsuario_Valoracion;
            }

            //Estadisticas de todos los jugador
            if (listaValoraciones != null)
            {
                var totalReviewsCount = listaValoraciones.Count(); //cuantos han comentado
                var totalRateValues = listaValoraciones.Sum(x => x.Valoracion)._ToDecimal(); //que valor han dado

                var Start5Count = listaValoraciones.Count(x => x.Valoracion == 5);
                var Start4Count = listaValoraciones.Count(x => x.Valoracion == 4);
                var Start3Count = listaValoraciones.Count(x => x.Valoracion == 3);
                var Start2Count = listaValoraciones.Count(x => x.Valoracion == 2);
                var Start1Count = listaValoraciones.Count(x => x.Valoracion == 1);

                valoracion.CantidadValoraciones = totalReviewsCount._ToDecimal();

                var div = Convert.ToDecimal((totalReviewsCount <= 0 ? 1 : totalReviewsCount));
                valoracion.PromedioValoraciones = Decimal.Round(totalRateValues._ToDecimal() / div, 2, MidpointRounding.AwayFromZero); ;

                valoracion.Start5Count = Start5Count;
                valoracion.Start4Count = Start4Count;
                valoracion.Start3Count = Start3Count;
                valoracion.Start2Count = Start2Count;
                valoracion.Start1Count = Start1Count;

                valoracion.Start5Avg = Decimal.Round(((Start5Count / div) * 100), 2, MidpointRounding.AwayFromZero);
                valoracion.Start4Avg = Decimal.Round((Start4Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start3Avg = Decimal.Round((Start3Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start2Avg = Decimal.Round((Start2Count / div) * 100, 2, MidpointRounding.AwayFromZero);
                valoracion.Start1Avg = Decimal.Round((Start1Count / div) * 100, 2, MidpointRounding.AwayFromZero);

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
                var nid = id._ToLong();
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
                    return MostrarAdvertencia("No se pudo actualizar la informacion del jugador");

                var urlbdd = model.FotoPrincipal;
                if(model.Attachment != null)
                {
                    string extension = Path.GetExtension(model.Attachment.FileName);

                    var myUniqueFileName = string.Format(@"{0}" + extension, Guid.NewGuid());
                    urlbdd = "/Content/Images/Usuario/" + myUniqueFileName;
                    string urlServidor = Server.MapPath(urlbdd);

                    var foto = Bitmap.FromStream(model.Attachment.InputStream) as Bitmap;

                    if (foto != null)
                        foto.Save(urlServidor);
                }
                
                usuario.Nombre = model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.FotoPrincipal = urlbdd;
                usuario.Telefonos = usuario.Telefonos;
                usuario.Descripcion = model.Descripcion;

                if (model.FechaNacimiento != null && model.FechaNacimiento.Year > 1900)
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
