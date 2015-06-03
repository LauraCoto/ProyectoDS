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
        //Descripcion: El tecnico puede aceptar o rechazar las solicitudes y filtra por Pendiente.
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
                //var lista = _db.Usuario_Solicitud_Equipo.Where(x => x.TipoEstado == "Pendiente").ToList(); 
                var lista = _db.Usuario_Solicitud_Equipo.Where(x => x.TipoEstado == "Pendiente").ToList(); 

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        //Recupero todos los equipo
        public ActionResult GetAllEquipo()
        {
            try
            {
                _db.Configuration.ProxyCreationEnabled = false;

                var lista = _db.Equipo.ToList();

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
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
    }
}