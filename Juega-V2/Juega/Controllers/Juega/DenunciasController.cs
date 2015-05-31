using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;

namespace Juega.Controllers.Juega
{
    public class DenunciasController : JuegaController
    {
        // GET: Denuncias
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
                var denuncias = _db.Denuncia.ToList();
                var lista = new List<DenunciasModelo>();

                foreach (var d in denuncias)
                {

                    var dm = new DenunciasModelo();

                    if (d.Cancha != null)
                    {
                        dm.IdCancha = d.IdCancha.ToString();
                        dm.Cancha = d.Cancha.Nombre;
                    }
                     
   
                    if (d.Usuario != null)
                    {
                        dm.IdEquipo = d.IdUsuario.ToString();
                        dm.Usuario = d.Usuario.Nombre;
                    }

                    if (d.Equipo != null)
                    {
                        dm.IdEquipo = d.IdEquipo.ToString();
                        dm.Equipo = d.Equipo.Nombre;
                    }

                    lista.Add(dm);
                   
                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }

        }

        //update
        public JsonResult Update(Denuncia denuncia)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                //if (ExisteRegistro(denuncia.IdDenuncia, -1))
                //  return Resultado_Advertencia("Ya existe un complejo con el mismo nombre.");

                _db.Entry(denuncia).State = EntityState.Modified;
                _db.SaveChanges();

                return Resultado_Correcto(denuncia, "La Denuncia ha sido actualizado.");
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }







    }
}