using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Juega.BDD;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Juega.Controllers.Juega
{
    public class EquipoController : JuegaController
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: Equipoes
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Usuario);
            return View(equipo.ToList());
        }

        // GET: Equipoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipoes/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEquipo,Nombre,Valoracion,TipoEstado,FotoPrincipal,FechaCreo,FechaElimino,Activo,IdUsuario")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {

                var usuarioLogin = ObtenerUsuario_Juega();


                var usuariodb = db.Usuario.FirstOrDefault(x => x.IdUsuario == usuarioLogin.IdUsuario);

                if (usuariodb != null)
                {
                    usuariodb.EsAdminEquipo = true;
                    db.Entry(usuariodb).State = EntityState.Modified;
                }
                db.Equipo.Add(equipo);

                var context = new ApplicationDbContext();
                var usuarioSeguridad = context.Users.FirstOrDefault(x => x.Id == usuariodb.IdUsuarioSeguridad);
                var rolSeguridad = context.Roles.FirstOrDefault(x => x.Name == Utilidades.Roles.AdminEquipo);

                //if (usuario == null)
                //    return Resultado_Advertencia("El usuario al que intenta configurar no existe.");

                //if (rol == null)
                //    return Resultado_Advertencia("El rol al que intenta configurar no existe.");

                var identityRol = new IdentityUserRole();
                identityRol.RoleId = rolSeguridad.Id;
                identityRol.UserId = usuarioSeguridad.Id;

                //model.Rol = rol.Name;
                //model.Usuario = usuario.UserName;

                usuarioSeguridad.Roles.Add(identityRol);
                context.SaveChanges();

                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Dashboard_v2", "Dashboard");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", equipo.IdUsuario);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", equipo.IdUsuario);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEquipo,Nombre,Valoracion,TipoEstado,FotoPrincipal,FechaCreo,FechaElimino,Activo,IdUsuario")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", equipo.IdUsuario);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Equipo equipo = db.Equipo.Find(id);
            db.Equipo.Remove(equipo);
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
