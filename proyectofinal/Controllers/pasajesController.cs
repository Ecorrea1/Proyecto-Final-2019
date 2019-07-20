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
    public class pasajesController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: pasajes
        public ActionResult Index()
        {
            var pasaje = db.pasaje.Include(p => p.salidabus);
            return View(pasaje.ToList());
        }

        // GET: pasajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasaje pasaje = db.pasaje.Find(id);
            if (pasaje == null)
            {
                return HttpNotFound();
            }
            return View(pasaje);
        }

        // GET: pasajes/Create
        public ActionResult Create()
        {
            ViewBag.Idpasaje = new SelectList(db.salidabus, "Idsalida", "chofer");
            return View();
        }

        // POST: pasajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idpasaje,nombrepasajero,origen,destino,fecha,fechasalida,patente,chofer,precio,auxiliar,asiento")] pasaje pasaje)
        {
            if (ModelState.IsValid)
            {
                db.pasaje.Add(pasaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Idpasaje = new SelectList(db.salidabus, "Idsalida", "chofer", pasaje.Idpasaje);
            return View(pasaje);
        }

        // GET: pasajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasaje pasaje = db.pasaje.Find(id);
            if (pasaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.Idpasaje = new SelectList(db.salidabus, "Idsalida", "chofer", pasaje.Idpasaje);
            return View(pasaje);
        }

        // POST: pasajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idpasaje,nombrepasajero,origen,destino,fecha,fechasalida,patente,chofer,precio,auxiliar,asiento")] pasaje pasaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idpasaje = new SelectList(db.salidabus, "Idsalida", "chofer", pasaje.Idpasaje);
            return View(pasaje);
        }

        // GET: pasajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasaje pasaje = db.pasaje.Find(id);
            if (pasaje == null)
            {
                return HttpNotFound();
            }
            return View(pasaje);
        }

        // POST: pasajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pasaje pasaje = db.pasaje.Find(id);
            db.pasaje.Remove(pasaje);
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
