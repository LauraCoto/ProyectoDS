using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using System.Data.Entity;

namespace Juega.Controllers.Juega
{
    public class UsuarioSolicitudJugadorController : JuegaController
    {
        // GET: UsuarioSolicitudJugador
        public ActionResult Index()
        {
            return View();
        }
        
        public JuegaJson GetAll()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                _db.Configuration.ProxyCreationEnabled = false;
                var lista = _db.Usuario_Solicitud_Equipo.Where(x => x.TipoEstado == "Pendiente").ToList(); 

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Create(Usuario_Solicitud_Equipo complejoDeportivo)
        {
            try
            {

                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                //if (ExisteRegistro(complejoDeportivo.Nombre, -1))
                //    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Usuario_Solicitud_Equipo.Add(complejoDeportivo);
                _db.SaveChanges();

                return Resultado_Correcto(complejoDeportivo, "El registro ha sido creado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [HttpPost]
        public JuegaJson Aceptado(Usuario_Solicitud_Equipo complejoDeportivo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                //if (ExisteRegistro(complejoDeportivo.Nombre, complejoDeportivo.IdComplejoDeportivo))
                //    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(complejoDeportivo).State = EntityState.Modified;
                complejoDeportivo.TipoEstado = "Aceptado";
                _db.SaveChanges();
                

                return Resultado_Correcto(complejoDeportivo, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [HttpPost]
        public JuegaJson Rechazado(Usuario_Solicitud_Equipo complejoDeportivo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                //if (ExisteRegistro(complejoDeportivo.Nombre, complejoDeportivo.IdComplejoDeportivo))
                //    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(complejoDeportivo).State = EntityState.Modified;
                complejoDeportivo.TipoEstado = "Rechazado";
                _db.SaveChanges();


                return Resultado_Correcto(complejoDeportivo, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
        //[HttpPost]
        //public JuegaJson Delete(Usuario_Solicitud_Equipo complejoDeportivo)
        //{
        //    try
        //    {
        //        if (!TieneAcceso())
        //            return Resultado_No_Acceso();

        //        if (complejoDeportivo == null)
        //            return Resultado_Advertencia("El registro no es valido.");

        //        var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == complejoDeportivo.IdComplejoDeportivo);

        //        if (complejo == null)
        //            return Resultado_Advertencia("No se encontro ningun registro.");

        //        var canchas = _db.Cancha.Select(x => x.IdComplejoDeportivo == complejo.IdComplejoDeportivo && x.Activo == true).ToList();

        //        //  if (canchas != null && canchas.Count() > 0)
        //        //      return Resultado_Advertencia("Este compejo deportivo tiene canchas registradas, debe eliminar las canchas para continuar.");


        //        _db.ComplejoDeportivo.Remove(complejo);
        //        _db.SaveChanges();

        //        return Resultado_Correcto(complejoDeportivo, "El registro ha sido eliminado.");
        //    }
        //    catch (Exception e)
        //    {
        //        return Resultado_Exception(e);
        //    }
        //}

        //private bool ExisteRegistro(string nombre, long IdExcluir)
        //{
        //    if (nombre.Trim() == "")
        //        return false;

        //    var complejo = _db.Usuario_Solicitud_Equipo.FirstOrDefault(x => x.Nombre == nombre &&
        //                                                        x.IdComplejoDeportivo != IdExcluir
        //                                                        );

        //    return complejo != null;
        //}

    }
}