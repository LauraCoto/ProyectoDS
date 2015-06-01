using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;

namespace Juega.Controllers
{
    public class ComplejoController : Controller
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: Complejo
        public ActionResult Index()
        {
            var complejoDeportivo = db.ComplejoDeportivo.Include(c => c.Usuario);
            return View(complejoDeportivo.ToList());
        }

        // GET: Complejo/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplejoDeportivo complejoDeportivo = db.ComplejoDeportivo.Find(id);
            if (complejoDeportivo == null)
            {
                return HttpNotFound();
            }
            return View(complejoDeportivo);
        }

        // GET: Complejo/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            return View();
        }

        // POST: Complejo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComplejoDeportivo,Nombre,Direccion,Telefonos,Coodernadas,FotoPrincipal,FechaCreo,FechaElimino,Activo,IdUsuario")] ComplejoDeportivo complejoDeportivo)
        {
            if (ModelState.IsValid)
            {
                db.ComplejoDeportivo.Add(complejoDeportivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", complejoDeportivo.IdUsuario);
            return View(complejoDeportivo);
        }

        // GET: Complejo/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplejoDeportivo complejoDeportivo = db.ComplejoDeportivo.Find(id);
            if (complejoDeportivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", complejoDeportivo.IdUsuario);
            return View(complejoDeportivo);
        }

        // POST: Complejo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComplejoDeportivo,Nombre,Direccion,Telefonos,Coodernadas,FotoPrincipal,FechaCreo,FechaElimino,Activo,IdUsuario")] ComplejoDeportivo complejoDeportivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complejoDeportivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", complejoDeportivo.IdUsuario);
            return View(complejoDeportivo);
        }

        // GET: Complejo/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplejoDeportivo complejoDeportivo = db.ComplejoDeportivo.Find(id);
            if (complejoDeportivo == null)
            {
                return HttpNotFound();
            }
            return View(complejoDeportivo);
        }

        // POST: Complejo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ComplejoDeportivo complejoDeportivo = db.ComplejoDeportivo.Find(id);
            db.ComplejoDeportivo.Remove(complejoDeportivo);
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
