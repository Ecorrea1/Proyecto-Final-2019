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
    public class asientosController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: asientos
        public ActionResult Index()
        {
            var asientos = db.asientos.Include(a => a.bus);
            return View(asientos.ToList());
        }

        // GET: asientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asientos asientos = db.asientos.Find(id);
            if (asientos == null)
            {
                return HttpNotFound();
            }
            return View(asientos);
        }

        // GET: asientos/Create
        public ActionResult Create()
        {
            ViewBag.autobus = new SelectList(db.bus, "Idbus", "pantente");
            return View();
        }

        // POST: asientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idasiento,autobus,asientonumero,estado")] asientos asientos)
        {
            if (ModelState.IsValid)
            {
                db.asientos.Add(asientos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.autobus = new SelectList(db.bus, "Idbus", "pantente", asientos.autobus);
            return View(asientos);
        }

        // GET: asientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asientos asientos = db.asientos.Find(id);
            if (asientos == null)
            {
                return HttpNotFound();
            }
            ViewBag.autobus = new SelectList(db.bus, "Idbus", "pantente", asientos.autobus);
            return View(asientos);
        }

        // POST: asientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idasiento,autobus,asientonumero,estado")] asientos asientos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asientos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.autobus = new SelectList(db.bus, "Idbus", "pantente", asientos.autobus);
            return View(asientos);
        }

        // GET: asientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asientos asientos = db.asientos.Find(id);
            if (asientos == null)
            {
                return HttpNotFound();
            }
            return View(asientos);
        }

        // POST: asientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asientos asientos = db.asientos.Find(id);
            db.asientos.Remove(asientos);
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
