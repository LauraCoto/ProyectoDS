﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;

namespace Juega.Controllers.Juega
{
    [Authorize(Roles = Utilidades.Roles.AdminCancha)]
    public class CanchasController : JuegaController
    {
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult Inicio()
        {
            return View();
        }

        public JuegaJson GetAll_Model()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();
                 

                 var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                 var canchas = _db.Cancha.Where(x => x.Activo == true && x.IdUsuario == IdUsuarioLogin).OrderBy(c => c.IdComplejoDeportivo).OrderBy(z => z.FechaCreo).ToList();

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

        public ActionResult GuardarVw(string id)
        {
            var viewModel = new CanchaModel();


            var IdUsuarioLogin = Obtener_ID_Usuario_Juega();
            var complejos = _db.ComplejoDeportivo.Where(x => x.Activo == true
                                                     && x.IdUsuario == IdUsuarioLogin
                                                    ).OrderBy(z => z.FechaCreo)
                                                    .ToList();

            var lista = new List<ComplejoModel>();
            foreach (var item in complejos)
            {
                var c = new ComplejoModel();

                c.IdComplejoDeportivo = item.IdComplejoDeportivo;
                c.Nombre = item.Nombre;

                lista.Add(c);

            }

            ViewBag.IdComplejo = new SelectList(lista, "IdComplejoDeportivo", "Nombre", viewModel.IdComplejo);

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                ViewBag.Accion = "Crear";
                return View(viewModel);
            }
            else
            {

                var nid = long.Parse(id);
                var item = _db.Cancha.FirstOrDefault(x => x.IdCancha == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion de la cancha.");

                viewModel.Ancho = item.Ancho != null ? Convert.ToInt32(item.Ancho) : 0;
                viewModel.Largo = item.Largo != null ? Convert.ToInt32(item.Largo) : 0;
                viewModel.Espectadores = item.NumEspectadores != null ? Convert.ToInt32(item.NumEspectadores) : 0;
                viewModel.IdCancha = item.IdCancha;
                viewModel.Nombre = item.Nombre;

                if (item.ComplejoDeportivo != null)
                {
                    viewModel.Complejo = item.ComplejoDeportivo.Nombre;
                    viewModel.IdComplejo = item.IdComplejoDeportivo != null ? Convert.ToInt64(item.IdComplejoDeportivo) : 0;
                }

                ViewBag.Accion = "Guardar Cambios";

                return View(viewModel);

            }
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(CanchaModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                    return MostrarAdvertencia("Debe completar todos los datos obligatorios.");

                if (ExisteRegistro(model.Nombre, model.IdCancha))
                    return MostrarAdvertencia("Ya existe una cancha con el mismo nombre.");

                if (model.IdCancha <= 0)
                {
                    var cancha = new Cancha();

                    if (model.IdComplejo > 0)
                        cancha.IdComplejoDeportivo = Convert.ToInt64(model.IdComplejo);

                    cancha.Nombre = model.Nombre;
                    cancha.Largo = model.Largo;
                    cancha.Ancho = model.Ancho;
                    cancha.NumEspectadores = model.Espectadores;
                    cancha.Valoracion = 0;
                    cancha.TipoEstado = Utilidades.TipoEstado.Pendiente;
                    cancha.Usuario = ObtenerUsuario_Juega();
                    cancha.Activo = true;
                    cancha.FechaCreo = DateTime.Now;
                    _db.Cancha.Add(cancha);
                }
                else
                {
                    var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == model.IdCancha);
                    if (cancha == null)
                        return MostrarAdvertencia("No se pudo obtener la informacion de la cancha.");

                    cancha.Nombre = model.Nombre;
                    cancha.Largo = model.Largo;
                    cancha.Ancho = model.Ancho;
                    cancha.NumEspectadores = model.Espectadores;

                    _db.Entry(cancha).State = EntityState.Modified;
                }

                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return MostrarError(e.Message, "Ocurrio un error al crear la cancha.");
            }
        }

       

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        public ActionResult EliminarVw(string id)
        {

            var viewModel = new CanchaModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                return MostrarAdvertencia("No se pudo cargar la informacion de la cancha que desea eliminar.");
            }
            else
            {

                var nid = long.Parse(id);
                var item = _db.Cancha.FirstOrDefault(x => x.IdCancha == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion de la cancha que desea eliminar.");

                viewModel.Ancho = item.Ancho != null ? Convert.ToInt32(item.Ancho) : 0;
                viewModel.Largo = item.Largo != null ? Convert.ToInt32(item.Largo) : 0;
                viewModel.Espectadores = item.NumEspectadores != null ? Convert.ToInt32(item.NumEspectadores) : 0;
                viewModel.IdCancha = item.IdCancha;
                viewModel.Nombre = item.Nombre; 

                if (item.ComplejoDeportivo != null)
                {
                    viewModel.Complejo = item.ComplejoDeportivo.Nombre;
                    viewModel.IdComplejo = item.IdComplejoDeportivo != null ? Convert.ToInt64(item.IdComplejoDeportivo) : 0;
                } 

                return View(viewModel); 

            }
        }

        public ActionResult Eliminar(CanchaModel model)
        {
            try
            { 

                if (model.IdCancha <= 0)
                    return MostrarAdvertencia("No se pudo cargar la informacion de la cancha que desea eliminar.");

                var cancha = _db.Cancha.FirstOrDefault(x => x.IdCancha == model.IdCancha);

                if (cancha == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion de la cancha que desea eliminar.");

                cancha.Activo = false;
                cancha.FechaElimino = DateTime.Now;

                _db.Entry(cancha).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return MostrarError(e.Message, "Ocurrio un error eliminar la cancha.");
            }
        }
         
        private bool ExisteRegistro(string nombre, long idExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var registro = _db.Cancha.FirstOrDefault(x => x.Nombre == nombre &&
                                                                x.IdCancha != idExcluir
                                                                );

            return registro != null;
        }

    }
}