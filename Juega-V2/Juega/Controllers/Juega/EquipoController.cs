using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;

namespace Juega.Controllers.Juega
{
    [Authorize(Roles = Utilidades.Roles.AdminEquipo)]
    public class EquipoController : JuegaController
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: CrearEquipo
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Usuario);
            return View(equipo.ToList());
        }

        public JuegaJson GetAll()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                _db.Configuration.ProxyCreationEnabled = false;
                var lista = _db.Equipo.ToList();

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [HttpPost]
        public JuegaJson Create(Equipo equipo)
        {
            try
            {

                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (ExisteRegistro(equipo.Nombre, -1))
                    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Equipo.Add(equipo);
                _db.SaveChanges();

                return Resultado_Correcto(equipo, "El registro ha sido creado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        [HttpPost]
        public JuegaJson Update(Equipo equipo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();


                if (ExisteRegistro(equipo.Nombre, equipo.IdEquipo))
                    return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(equipo).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(equipo, "El registro ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        [HttpPost]
        public JuegaJson Delete(Equipo equipo)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (equipo == null)
                    return Resultado_Advertencia("El registro no es valido.");

                var complejo = _db.Equipo.FirstOrDefault(x => x.IdEquipo == equipo.IdEquipo);

                if (complejo == null)
                    return Resultado_Advertencia("No se encontro ningun registro.");

                //var canchas = _db.Cancha.Select(x => x.IdComplejoDeportivo == complejo.IdComplejoDeportivo && x.Activo == true).ToList();

                //  if (canchas != null && canchas.Count() > 0)
                //      return Resultado_Advertencia("Este compejo deportivo tiene canchas registradas, debe eliminar las canchas para continuar.");


                _db.Equipo.Remove(complejo);
                _db.SaveChanges();

                return Resultado_Correcto(equipo, "El registro ha sido eliminado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }

        private bool ExisteRegistro(string nombre, long IdExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var complejo = _db.Equipo.FirstOrDefault(x => x.Nombre == nombre &&
                                                                x.IdEquipo != IdExcluir
                                                                );

            return complejo != null;
        }
    }
}