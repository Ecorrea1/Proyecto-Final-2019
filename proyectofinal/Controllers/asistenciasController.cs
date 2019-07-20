using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyectofinal;

namespace proyectofinal.Controllers
{
    public class asistenciasController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: asistencias
        public ActionResult Index()
        {
            var asistencia = db.asistencia.Include(a => a.AspNetUsers);
            return View(asistencia.ToList());
        }

        // GET: asistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: asistencias/Create
        public ActionResult Create()
        {
            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: asistencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idasistencia,chofer,disponible,fecha")] asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.asistencia.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email", asistencia.chofer);
            return View(asistencia);
        }

        // GET: asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email", asistencia.chofer);
            return View(asistencia);
        }

        // POST: asistencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idasistencia,chofer,disponible,fecha")] asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email", asistencia.chofer);
            return View(asistencia);
        }

        // GET: asistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asistencia asistencia = db.asistencia.Find(id);
            db.asistencia.Remove(asistencia);
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
