using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaViajeros.Controllers
{
    public class PuntosDeControlsController : Controller
    {
        private SistemaViajerosEntities db = new SistemaViajerosEntities();

        // GET: PuntosDeControls
        public ActionResult Index()
        {
            var puntosDeControl = db.PuntosDeControl.Include(p => p.Usuarios);
            return View(puntosDeControl.ToList());
        }

        // GET: PuntosDeControls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntosDeControl puntosDeControl = db.PuntosDeControl.Find(id);
            if (puntosDeControl == null)
            {
                return HttpNotFound();
            }
            return View(puntosDeControl);
        }

        // GET: PuntosDeControls/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre");
            return View();
        }

        // POST: PuntosDeControls/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PuntoControlID,NombreControl,Ubicacion,Descripcion,UsuarioID")] PuntosDeControl puntosDeControl)
        {
            if (ModelState.IsValid)
            {
                db.PuntosDeControl.Add(puntosDeControl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", puntosDeControl.UsuarioID);
            return View(puntosDeControl);
        }

        // GET: PuntosDeControls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntosDeControl puntosDeControl = db.PuntosDeControl.Find(id);
            if (puntosDeControl == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", puntosDeControl.UsuarioID);
            return View(puntosDeControl);
        }

        // POST: PuntosDeControls/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PuntoControlID,NombreControl,Ubicacion,Descripcion,UsuarioID")] PuntosDeControl puntosDeControl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puntosDeControl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", puntosDeControl.UsuarioID);
            return View(puntosDeControl);
        }

        // GET: PuntosDeControls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntosDeControl puntosDeControl = db.PuntosDeControl.Find(id);
            if (puntosDeControl == null)
            {
                return HttpNotFound();
            }
            return View(puntosDeControl);
        }

        // POST: PuntosDeControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PuntosDeControl puntosDeControl = db.PuntosDeControl.Find(id);
            db.PuntosDeControl.Remove(puntosDeControl);
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
