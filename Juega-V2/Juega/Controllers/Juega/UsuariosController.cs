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
    public class UsuariosController : Controller
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
           
            var usuario = db.Usuario;

            return View(usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,IdUsuarioSeguridad,Nombre,Apellido,Correo,Telefonos,TipoEstado,Valoracion,EsEspectador,EsAdminCancha,EsAdminEquipo,EsJugador,FechaNacimiento,FechaCreo,FechaElimino,Activo,Descripcion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario.IdUsuario);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario.IdUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario.IdUsuario);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario.IdUsuario);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,IdUsuarioSeguridad,Nombre,Apellido,Correo,Telefonos,TipoEstado,Valoracion,EsEspectador,EsAdminCancha,EsAdminEquipo,EsJugador,FechaNacimiento,FechaCreo,FechaElimino,Activo,Descripcion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario.IdUsuario);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario.IdUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
