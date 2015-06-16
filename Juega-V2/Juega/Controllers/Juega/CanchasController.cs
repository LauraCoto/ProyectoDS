using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;
using Juega.Utilidades;
using System.IO;
using System.Drawing;
using System.Configuration;
using com.mosso.cloudfiles.domain;

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
                    c.FotoPrincipal = item.FotoPrincipal;
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
                viewModel.FotoPrincipal = item.FotoPrincipal;

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

                if (model.IdComplejo._ToLong() <= 0)
                    return MostrarAdvertencia("Debe seleccionar un complejo deportivo.");

                if (ExisteRegistro(model.Nombre, model.IdComplejo, model.IdCancha))
                    return MostrarAdvertencia("Ya existe una cancha con el mismo nombre.");

                var urlbdd = model.FotoPrincipal;
                if (model.Attachment != null)
                {

                    var rackIsOnline = ConfigurationManager.AppSettings["RACK_ONLINE"].ToString();

                    if (rackIsOnline == "1")
                    {
                        var username = ConfigurationManager.AppSettings["RACK_USER"].ToString();
                        var api_key = ConfigurationManager.AppSettings["RACK_API_KEY"].ToString();
                        var chosenContainer = ConfigurationManager.AppSettings["RACK_CONTAINER_Canchas"].ToString();
                        var chosenContainer_Server = ConfigurationManager.AppSettings["RACK_CONTAINER_Canchas_SVR"].ToString();
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
                        urlbdd = "/Content/Images/Upload/Canchas/" + Guid.NewGuid().ToString();
                        var urlServidor = Server.MapPath(urlbdd);
                        var foto = Bitmap.FromStream(model.Attachment.InputStream) as Bitmap;

                        if (foto != null)
                            foto.Save(urlServidor);
                    }
                }

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
                    cancha.FotoPrincipal = urlbdd;
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
                    cancha.FotoPrincipal = urlbdd;

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


        public ActionResult EliminarVw(string id)
        {

            var viewModel = new CanchaModel();

            if (string.IsNullOrEmpty(id) || id == "-1")
            {
                return MostrarAdvertencia("No se pudo cargar la informacion de la cancha que desea eliminar.");
            }

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

        public ActionResult HorarioVw(string id)
        {
            var viewModel = new CanchaModel();

            if (id._ToLong() <= 0)
                return MostrarAdvertencia("No se pudo cargar la informacion de la cancha.");

            var nid = id._ToLong();
            var item = _db.Cancha.FirstOrDefault(x => x.IdCancha == nid);

            if (item == null)
                return MostrarAdvertencia("No se pudo cargar la informacion de la cancha.");

            viewModel.Ancho = item.Ancho._ToInt();
            viewModel.Largo = item.Largo._ToInt();
            viewModel.Espectadores = item.NumEspectadores._ToInt();
            viewModel.IdCancha = item.IdCancha;
            viewModel.Nombre = item.Nombre;

            if (item.ComplejoDeportivo != null)
            {
                viewModel.Complejo = item.ComplejoDeportivo.Nombre;
                viewModel.IdComplejo = item.IdComplejoDeportivo != null ? Convert.ToInt64(item.IdComplejoDeportivo) : 0;
            }

            return View(viewModel);
        }

        public ActionResult Horario(CanchaModel model)
        {
            return RedirectToAction("Inicio");
        }

        private bool ExisteRegistro(string nombre, long idComplejo, long idExcluir)
        {
            if (nombre.Trim() == "")
                return false;

            var registro = _db.Cancha.FirstOrDefault(x => x.Nombre == nombre &&
                                                          x.IdCancha != idExcluir &&
                                                          x.IdComplejoDeportivo == idComplejo
                                                    );

            return registro != null;
        }

    }
}