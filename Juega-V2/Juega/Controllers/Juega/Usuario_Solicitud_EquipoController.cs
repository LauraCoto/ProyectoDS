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
    //Descripcion:
    //Enviar Solicitud a un Equipo!
    public class Usuario_Solicitud_EquipoController : JuegaController
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: Usuario_Solicitud_Equipo
        public ActionResult Index()
        {
            var usuario_Solicitud_Equipo = db.Usuario_Solicitud_Equipo.Include(u => u.Equipo).Include(u => u.Usuario);
            return View(usuario_Solicitud_Equipo.ToList());
        }

        // GET: Usuario_Solicitud_Equipo/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Solicitud_Equipo usuario_Solicitud_Equipo = db.Usuario_Solicitud_Equipo.Find(id);
            if (usuario_Solicitud_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(usuario_Solicitud_Equipo);
        }

        // GET: Usuario_Solicitud_Equipo/Create
        public ActionResult Create()
        {
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "Nombre");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            return View();
        }

        // POST: Usuario_Solicitud_Equipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario_Solicitud_Equipo,TipoEstado,FechaCreo,FechaElimino,Activo,IdUsuario,IdEquipo")] Usuario_Solicitud_Equipo usuario_Solicitud_Equipo)
        {
            if (ModelState.IsValid)
            {
                var usuarioLogin = ObtenerUsuario_Juega();
                var usuariodb = db.Usuario.FirstOrDefault(x => x.IdUsuario == usuarioLogin.IdUsuario);

                usuario_Solicitud_Equipo.IdUsuario = usuariodb.IdUsuario;
                usuario_Solicitud_Equipo.FechaCreo = DateTime.Now;
                usuario_Solicitud_Equipo.TipoEstado = "Pendiente";
                db.Usuario_Solicitud_Equipo.Add(usuario_Solicitud_Equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "Nombre", usuario_Solicitud_Equipo.IdEquipo);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario_Solicitud_Equipo.IdUsuario);
            return View(usuario_Solicitud_Equipo);
        }

        // GET: Usuario_Solicitud_Equipo/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Solicitud_Equipo usuario_Solicitud_Equipo = db.Usuario_Solicitud_Equipo.Find(id);
            if (usuario_Solicitud_Equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "Nombre", usuario_Solicitud_Equipo.IdEquipo);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario_Solicitud_Equipo.IdUsuario);
            return View(usuario_Solicitud_Equipo);
        }

        // POST: Usuario_Solicitud_Equipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario_Solicitud_Equipo,TipoEstado,FechaCreo,FechaElimino,Activo,IdUsuario,IdEquipo")] Usuario_Solicitud_Equipo usuario_Solicitud_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario_Solicitud_Equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "Nombre", usuario_Solicitud_Equipo.IdEquipo);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", usuario_Solicitud_Equipo.IdUsuario);
            return View(usuario_Solicitud_Equipo);
        }

        // GET: Usuario_Solicitud_Equipo/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_Solicitud_Equipo usuario_Solicitud_Equipo = db.Usuario_Solicitud_Equipo.Find(id);
            if (usuario_Solicitud_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(usuario_Solicitud_Equipo);
        }

        // POST: Usuario_Solicitud_Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Usuario_Solicitud_Equipo usuario_Solicitud_Equipo = db.Usuario_Solicitud_Equipo.Find(id);
            db.Usuario_Solicitud_Equipo.Remove(usuario_Solicitud_Equipo);
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
