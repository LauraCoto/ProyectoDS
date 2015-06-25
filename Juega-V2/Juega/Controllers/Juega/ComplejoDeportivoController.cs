using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using System.Drawing;
using com.mosso.cloudfiles.domain;
using System.Configuration;

namespace Juega.Controllers.Juega
{

    [Authorize(Roles = Utilidades.Roles.AdminCancha)]
    public class ComplejoDeportivoController : JuegaController
    {
        public ActionResult Inicio()
        {
            return View();
        }

        [Authorize(Roles = Utilidades.Roles.AdminCancha)]
        public JuegaJson GetAll()
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                var IdUsuarioLogin = Obtener_ID_Usuario_Juega();

                var complejos = _db.ComplejoDeportivo.Where(x => x.Activo == true
                                                           && x.IdUsuario == IdUsuarioLogin
                                                          ).OrderBy(z => z.FechaCreo)
                                                          .ToList();

                var lista = new List<ComplejoModel>();
                foreach (var item in complejos)
                {
                    var c = new ComplejoModel();

                    c.Coodernadas = item.Coodernadas;
                    c.Direccion = item.Direccion;
                    c.FotoPrincipal = item.FotoPrincipal;
                    c.IdComplejoDeportivo = item.IdComplejoDeportivo;
                    c.Nombre = item.Nombre;
                    c.Telefonos = item.Telefonos;
                    c.CantCanchas = item.Cancha.Count;

                    lista.Add(c);

                }

                return Resultado_Correcto(lista);
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }
        }


        public ActionResult GuardarVW(string id)
        {

            var viewModel = new ComplejoModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                ViewBag.Accion = "Crear";
                return View(viewModel);
            }
            else
            {
                var nid = long.Parse(id);
                var item = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo");

                viewModel.Coodernadas = item.Coodernadas;
                viewModel.Direccion = item.Direccion;
                viewModel.FotoPrincipal = item.FotoPrincipal;
                viewModel.IdComplejoDeportivo = item.IdComplejoDeportivo;
                viewModel.Telefonos = item.Telefonos;
                viewModel.Nombre = item.Nombre;
                ViewBag.Accion = "Guardar Cambios";

                return View(viewModel);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(ComplejoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    MostrarAdvertencia("Debe completar todos los datos obligatorios");

                var usuarioLogin = ObtenerUsuario_Juega();

                usuarioLogin.EsAdminCancha = true;

                if (ExisteRegistro(model.Nombre, model.IdComplejoDeportivo))
                    return MostrarAdvertencia("Ya tiene agregado un complejo con el mismo nombre.");

                var urlbdd = model.FotoPrincipal;
                if (model.Attachment != null)
                {

                    var rackIsOnline = ConfigurationManager.AppSettings["RACK_ONLINE"].ToString();

                    if (rackIsOnline == "1")
                    {
                        var username = ConfigurationManager.AppSettings["RACK_USER"].ToString();
                        var api_key = ConfigurationManager.AppSettings["RACK_API_KEY"].ToString();
                        var chosenContainer = ConfigurationManager.AppSettings["RACK_CONTAINER_Complejos"].ToString();
                        var chosenContainer_Server = ConfigurationManager.AppSettings["RACK_CONTAINER_Complejos_SVR"].ToString();
                        var UrlStorage = ConfigurationManager.AppSettings["RACK_URL_STORAGE"].ToString();
                        var UrlAuth = ConfigurationManager.AppSettings["RACK_URL_AUTH"].ToString();

                        var userCreds = new UserCredentials(new Uri(UrlAuth), username, api_key, null, null);
                        var connection = new com.mosso.cloudfiles.Connection(userCreds);

                        var imgPath = model.Attachment.FileName;
                        var extension = System.IO.Path.GetExtension(imgPath);
                        var name = System.IO.Path.GetFileNameWithoutExtension(imgPath);
                        var tempName = System.IO.Path.GetRandomFileName() + extension;

                        connection.PutStorageItem(chosenContainer, model.Attachment.InputStream, tempName);
                        urlbdd = chosenContainer_Server + tempName;
                    }
                    else
                    {
                        var extension = Path.GetExtension(model.Attachment.FileName);
                        urlbdd = "/Content/Images/Upload/Complejos/" + Guid.NewGuid().ToString();
                        var urlServidor = Server.MapPath(urlbdd);
                        var foto = Bitmap.FromStream(model.Attachment.InputStream) as Bitmap;

                        if (foto != null)
                            foto.Save(urlServidor);
                    }
                }

                if (model.IdComplejoDeportivo <= 0)
                {
                    var complejo = new ComplejoDeportivo();
                    complejo.Activo = true;
                    complejo.Coodernadas = model.Coodernadas;
                    complejo.Direccion = model.Direccion;
                    complejo.FechaCreo = DateTime.Now;
                    complejo.FotoPrincipal = urlbdd;
                    complejo.Usuario = usuarioLogin;
                    complejo.Nombre = model.Nombre;
                    complejo.Telefonos = model.Telefonos;

                    _db.ComplejoDeportivo.Add(complejo);

                }
                else
                {
                    var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == model.IdComplejoDeportivo);
                    if (complejo == null)
                        return MostrarAdvertencia("No se pudo obtener la informacion del complejo");

                    complejo.Coodernadas = model.Coodernadas;
                    complejo.Direccion = model.Direccion;
                    complejo.FotoPrincipal = urlbdd;
                    complejo.Nombre = model.Nombre;
                    complejo.Telefonos = model.Telefonos;

                    _db.Entry(complejo).State = EntityState.Modified;
                }


                _db.Entry(usuarioLogin).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                return MostrarError(ex.Message, "Ocurrio un error guardar el complejo deportivo.");
            }
        }

        public ActionResult EliminarVw(string id)
        {

            var viewModel = new ComplejoModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo a eliminar.");
            }
            else
            {
                var nid = long.Parse(id);
                var item = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == nid);

                if (item == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo.");

                viewModel.Coodernadas = item.Coodernadas;
                viewModel.Direccion = item.Direccion;
                viewModel.FotoPrincipal = item.FotoPrincipal;
                viewModel.IdComplejoDeportivo = item.IdComplejoDeportivo;
                viewModel.Telefonos = item.Telefonos;
                viewModel.Nombre = item.Nombre;
                viewModel.CantCanchas = item.Cancha.Count;

                return View(viewModel);

            }
        }

        [HttpPost]
        public ActionResult Eliminar(ComplejoModel model)
        {
            try
            {


                if (model.IdComplejoDeportivo <= 0)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo a eliminar");


                var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.IdComplejoDeportivo == model.IdComplejoDeportivo);

                if (complejo == null)
                    return MostrarAdvertencia("No se pudo cargar la informacion del complejo deportivo a eliminar");

                //var canchas = _db.Cancha.Select(x => x.IdComplejoDeportivo == complejo.IdComplejoDeportivo && x.Activo == true).ToList();

                if (complejo.Cancha.Count > 0)
                    return MostrarAdvertencia("Este compejo deportivo tiene canchas registradas, debe eliminar las canchas para continuar.");

                complejo.Activo = false;
                complejo.FechaElimino = DateTime.Now;

                _db.Entry(complejo).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Inicio");
            }
            catch (Exception e)
            {
                return MostrarError(e.Message, "Ocurrio un error eliminar el complejo deportivo.");
            }
        }

        private bool ExisteRegistro(string nombre, long IdExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var complejo = _db.ComplejoDeportivo.FirstOrDefault(x => x.Nombre == nombre &&
                                                                x.IdComplejoDeportivo != IdExcluir
                                                                );

            return complejo != null;
        }
    }
}