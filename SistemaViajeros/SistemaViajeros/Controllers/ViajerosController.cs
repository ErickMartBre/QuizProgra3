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
    public class ViajerosController : Controller
    {
        private SistemaViajerosEntities db = new SistemaViajerosEntities();

        // GET: Viajeros
        public ActionResult Index()
        {
            var viajeros = db.Viajeros.Include(v => v.Usuarios);
            return View(viajeros.ToList());
        }

        // GET: Viajeros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return HttpNotFound();
            }
            return View(viajeros);
        }

        // GET: Viajeros/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre");
            return View();
        }

        // POST: Viajeros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ViajeroID,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Nacionalidad,Genero,UsuarioID")] Viajeros viajeros)
        {
            if (ModelState.IsValid)
            {
                db.Viajeros.Add(viajeros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", viajeros.UsuarioID);
            return View(viajeros);
        }

        // GET: Viajeros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", viajeros.UsuarioID);
            return View(viajeros);
        }

        // POST: Viajeros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ViajeroID,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Nacionalidad,Genero,UsuarioID")] Viajeros viajeros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajeros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", viajeros.UsuarioID);
            return View(viajeros);
        }

        // GET: Viajeros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return HttpNotFound();
            }
            return View(viajeros);
        }

        // POST: Viajeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viajeros viajeros = db.Viajeros.Find(id);
            db.Viajeros.Remove(viajeros);
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
