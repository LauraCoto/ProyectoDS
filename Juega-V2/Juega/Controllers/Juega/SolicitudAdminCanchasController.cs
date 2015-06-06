using Juega.Models.Juega;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juega.Controllers.Juega
{
    [Authorize(Roles = Utilidades.Roles.AdminSistema)]
    public class SolicitudAdminCanchasController : JuegaController
    {
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
                _db.Configuration.LazyLoadingEnabled = false;

                var solicitudes = _db.Usuario_Solicitud_AdminCancha.Where(x => x.Activo == true &&
                                                                     x.TipoEstado == Utilidades.TipoEstado.Pendiente)
                                                                     .ToList();

                var lista = new List<SolicitudAdminCanchaModel>();

                foreach (var s in solicitudes)
                {
                    var model = new SolicitudAdminCanchaModel();
                    model.FechaCreo = s.FechaCreo.HasValue ? s.FechaCreo.Value.GetDateTimeFormats()[20] + " " + s.FechaCreo.Value.GetDateTimeFormats()[35] : "";
                    model.IdSolicitud = s.IdUsuario_Solicitud_AdminCancha;
                    model.IdUsuario = s.IdUsuario.HasValue ? Convert.ToInt64(s.IdUsuario) : -1;
                    model.Usuario = s.Usuario.Nombre + s.Usuario.Apellido;

                    lista.Add(model);
                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Aceptar(SolicitudAdminCanchaModel model)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                var solicitud = _db.Usuario_Solicitud_AdminCancha.FirstOrDefault(x => x.IdUsuario_Solicitud_AdminCancha == model.IdSolicitud);

                if (solicitud == null)
                    return Resultado_Advertencia("No se pudo obtener la informacion de la solicitud.");

                solicitud.TipoEstado = Utilidades.TipoEstado.Aprobado;
                _db.Entry(solicitud).State = EntityState.Modified;

                //Enviar correo
                _db.SaveChanges();

                return Resultado_Correcto(model, "La solicitud ha sido actualizada como aprobada.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Rechazar(SolicitudAdminCanchaModel model)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                var solicitud = _db.Usuario_Solicitud_AdminCancha.FirstOrDefault(x => x.IdUsuario_Solicitud_AdminCancha == model.IdSolicitud);

                if (solicitud == null)
                    return Resultado_Advertencia("No se pudo obtener la informacion de la solicitud.");

                solicitud.TipoEstado = Utilidades.TipoEstado.Rechazado;
                _db.Entry(solicitud).State = EntityState.Modified;

                //Enviar correo
                _db.SaveChanges();

                return Resultado_Correcto(model, "La solicitud ha sido actualizada como rechazada.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }
    }
}