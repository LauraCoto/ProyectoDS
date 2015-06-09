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

    public class respuesta
    {
        public string mensaje;
    }
    public class Usuario_Solicitud_EquipoController : JuegaController
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: Usuario_Solicitud_Equipo
        public ActionResult Index()
        {
            

            var usuario_Solicitud_Equipo = db.Usuario_Solicitud_Equipo.Include(u => u.Equipo).Include(u => u.Usuario);
            return View(usuario_Solicitud_Equipo.ToList());
        }
      
        
        [HttpPost]
        public JuegaJson enviarSolicitud(string id)
        {

            
            try{
               
            var team = int.Parse(id);
            var usuarioLogeado = ObtenerUsuario_Juega();
            if (usuarioLogeado != null)
            {
                var solicitud = new Usuario_Solicitud_Equipo();
                solicitud.Usuario = usuarioLogeado;

                if (seAdmiteSolicitud(usuarioLogeado, team))
                {
                    solicitud.IdEquipo = team;
                    solicitud.TipoEstado = "Pend";
                    solicitud.Activo = true;
                    solicitud.FechaCreo = DateTime.Now;
                    _db.Usuario_Solicitud_Equipo.Add(solicitud);
                    _db.SaveChanges();

                    return Resultado_Devolver(null, "Solicitud Enviada con exito.", "N", "N", "N");
                }
                else
                {
                    return Resultado_Devolver(null, "Ya has Enviado Una SOlicitud", "N", "N", "Error:");

                }
            }
            else
            {
                return Resultado_Devolver(null,"Usuario no registrado","N","N","Error:");
                
            }

           

            }catch(Exception e)
            {
                return Resultado_Devolver(null,"Error Inesperado","","",e.ToString());
            }
            

        }
        public JuegaJson GetAll()
        {
            
            try
            {
                if(!TieneAcceso())
                {
                    return Resultado_No_Acceso();
                }
                else
                {
                    string mensaje;
                    _db.Configuration.ProxyCreationEnabled = false;
                    var lista = _db.Equipo.Where(x=> x.Activo==true).ToList();
                    mensaje = lista.Count.ToString();
                    if (lista.Count ==0)
                        mensaje ="0";
                    return Resultado_Correcto(lista,mensaje);
                }
            }
            catch (Exception e)
            {
                return Resultado_Exception(e);
            }

        }

        // Comprobar si har alguna solicitud del jugador actual para el equipo solicitado.
        private bool seAdmiteSolicitud(Usuario user, int Equipo)
        {
            
            var admitir = _db.Usuario_Solicitud_Equipo.FirstOrDefault(x => x.IdUsuario == user.IdUsuario &&
                                                                x.IdEquipo == Equipo
                                                                );
            if(admitir == null)
               return  true;

                return false;

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
