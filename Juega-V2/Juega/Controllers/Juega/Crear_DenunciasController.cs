using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Juega.Models.Juega;

namespace Juega.Controllers.Juega
{
    public class Crear_DenunciasController : JuegaController
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: Crear_Denuncias

        
        public ActionResult CrearDenuncia(string id_denunciar)
        {
            try
            {
                if (!TieneAcceso())
                    return Resultado_No_Acceso();

                if (string.IsNullOrEmpty(id_denunciar))
                {
                    return Resultado_Advertencia("Usuario no existe");
                }

                _db.Configuration.ProxyCreationEnabled = false;
                var nid = int.Parse(id_denunciar);
                var usuario = _db.Usuario.FirstOrDefault(x => x.IdUsuario == nid);

                var usuarioModel = new UsuarioModel();

                usuarioModel.Apellido = usuario.Apellido;
                usuarioModel.Nombre = usuario.Nombre;
              
       
                return View(usuarioModel);

            }

            catch (Exception e)
            {
                return Resultado_Exception(e);

            }
            
        }
        public ActionResult Index()
        {
            var denuncia = db.Denuncia.Include(d => d.Cancha).Include(d => d.Usuario).Include(d => d.Usuario1).Include(d => d.Usuario2).Include(d => d.Equipo);
            return View(denuncia.ToList());
        }

        // GET: Crear_Denuncias/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncia.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            return View(denuncia);
        }

        // GET: Crear_Denuncias/Create
        public ActionResult Create(string id)
        {
            ViewBag.IdCanchaDenunciada = new SelectList(db.Cancha, "IdCancha", "Nombre");
            ViewBag.IdUsuarioDenuncia = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            ViewBag.IdUsuarioDenunciado = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            ViewBag.IdEquipoDenunciado = new SelectList(db.Equipo, "IdEquipo", "Nombre");
            ViewBag.Pendiente = "Pendiente";
            ViewBag.IdUsuarioDenunciado = id;
            return View();
        }

        // POST: Crear_Denuncias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDenuncia,Descripcion,TipoEstado,IdUsuarioDenuncia,IdUsuarioDenunciado,IdCanchaDenunciada,IdEquipoDenunciado,FechaCreo,FechaElimino,Activo,IdUsuario")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                denuncia.IdUsuarioDenuncia= ObtenerUsuario_Juega().IdUsuario; 
                denuncia.TipoEstado = "Pendiente";
                db.Denuncia.Add(denuncia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.IdCanchaDenunciada = new SelectList(db.Cancha, "IdCancha", "Nombre", denuncia.IdCanchaDenunciada);
            ViewBag.IdUsuarioDenuncia = ObtenerUsuario_Juega().IdUsuario; // new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuarioDenuncia);
            ViewBag.IdUsuarioDenunciado = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuarioDenunciado);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuario);
            ViewBag.IdEquipoDenunciado = new SelectList(db.Equipo, "IdEquipo", "Nombre", denuncia.IdEquipoDenunciado);
            return View(denuncia);
        }

        // GET: Crear_Denuncias/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncia.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCanchaDenunciada = new SelectList(db.Cancha, "IdCancha", "Nombre", denuncia.IdCanchaDenunciada);
            ViewBag.IdUsuarioDenuncia = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuarioDenuncia);
            ViewBag.IdUsuarioDenunciado = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuarioDenunciado);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuario);
            ViewBag.IdEquipoDenunciado = new SelectList(db.Equipo, "IdEquipo", "Nombre", denuncia.IdEquipoDenunciado);
            return View(denuncia);
        }

        // POST: Crear_Denuncias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDenuncia,Descripcion,TipoEstado,IdUsuarioDenuncia,IdUsuarioDenunciado,IdCanchaDenunciada,IdEquipoDenunciado,FechaCreo,FechaElimino,Activo,IdUsuario")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(denuncia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCanchaDenunciada = new SelectList(db.Cancha, "IdCancha", "Nombre", denuncia.IdCanchaDenunciada);
            ViewBag.IdUsuarioDenuncia = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuarioDenuncia);
            ViewBag.IdUsuarioDenunciado = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuarioDenunciado);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", denuncia.IdUsuario);
            ViewBag.IdEquipoDenunciado = new SelectList(db.Equipo, "IdEquipo", "Nombre", denuncia.IdEquipoDenunciado);
            return View(denuncia);
        }

        // GET: Crear_Denuncias/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncia.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            return View(denuncia);
        }

        // POST: Crear_Denuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Denuncia denuncia = db.Denuncia.Find(id);
            db.Denuncia.Remove(denuncia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
