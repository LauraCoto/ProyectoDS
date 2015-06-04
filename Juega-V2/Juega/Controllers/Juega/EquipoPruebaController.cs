using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.IO;
using Juega.BDD;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;



namespace Juega.Controllers.Juega
{
    public class EquipoPruebaController : JuegaController
    {
        private JuegaEntities db = new JuegaEntities();

        // GET: EquipoPrueba
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Usuario);
            return View(equipo.ToList());
        }

        // GET: EquipoPrueba/Details/5
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

        // GET: EquipoPrueba/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad");
            return View();
        }

        // POST: EquipoPrueba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEquipo,Nombre,Valoracion,TipoEstado,FotoPrincipal,FechaCreo,FechaElimino,Activo,IdUsuario")] Equipo equipo, HttpPostedFileBase image)
        {

            if (image != null)
            {
                //attach the uploaded image to the object before saving to Database
                equipo.FotoPrincipal= image.ContentLength;
                equipo.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(equipo.ImageData, 0, image.ContentLength);

                //Save image to file
                var filename = image.FileName;
                var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
                var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                string savedFileName = Path.Combine(filePathOriginal, filename);
                image.SaveAs(savedFileName);

                //Read image back from file and create thumbnail from it
                var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
                using (var srcImage = Image.FromFile(imageFile))
                using (var newImage = new Bitmap(100, 100))
                using (var graphics = Graphics.FromImage(newImage))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100));
                    newImage.Save(stream, ImageFormat.Png);
                    var thumbNew = File(stream.ToArray(), "image/png");
                    equipo.ArtworkThumbnail = thumbNew.FileContents;
                }

                db.Equipo.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuarioSeguridad", equipo.IdUsuario);
            
            return View(equipo);
        }

        // GET: EquipoPrueba/Edit/5
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

        // POST: EquipoPrueba/Edit/5
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

        // GET: EquipoPrueba/Delete/5
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

        // POST: EquipoPrueba/Delete/5
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

        public FileContentResult GetThumbnailImage(int artworkId)
        {
            Equipo art = db.Equipo.FirstOrDefault(p => p.IdEquipo == artworkId);
            if (art != null)
            {
                return File(art.ArtworkThumbnail, art.ImageMimeType.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
