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
    public class salidabusController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: salidabus
        public ActionResult Index()
        {
            var salidabus = db.salidabus.Include(s => s.AspNetUsers).Include(s => s.AspNetUsers1).Include(s => s.bus1).Include(s => s.ciudad).Include(s => s.ciudad1).Include(s => s.pasaje);
            return View(salidabus.ToList());
        }

        // GET: salidabus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salidabus salidabus = db.salidabus.Find(id);
            if (salidabus == null)
            {
                return HttpNotFound();
            }
            return View(salidabus);
        }

        // GET: salidabus/Create
        public ActionResult Create()
        {
            ViewBag.auxiliar = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.bus = new SelectList(db.bus, "Idbus", "pantente");
            ViewBag.destino = new SelectList(db.ciudad, "Idciudad", "ciudad1");
            ViewBag.origen = new SelectList(db.ciudad, "Idciudad", "ciudad1");
            ViewBag.Idsalida = new SelectList(db.pasaje, "Idpasaje", "nombrepasajero");
            return View();
        }

        // POST: salidabus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idsalida,chofer,auxiliar,bus,fecha_salida,destino,origen")] salidabus salidabus)
        {
            if (ModelState.IsValid)
            {
                db.salidabus.Add(salidabus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.auxiliar = new SelectList(db.AspNetUsers, "Id", "Email", salidabus.auxiliar);
            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email", salidabus.chofer);
            ViewBag.bus = new SelectList(db.bus, "Idbus", "pantente", salidabus.bus);
            ViewBag.destino = new SelectList(db.ciudad, "Idciudad", "ciudad1", salidabus.destino);
            ViewBag.origen = new SelectList(db.ciudad, "Idciudad", "ciudad1", salidabus.origen);
            ViewBag.Idsalida = new SelectList(db.pasaje, "Idpasaje", "nombrepasajero", salidabus.Idsalida);
            return View(salidabus);
        }

        // GET: salidabus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salidabus salidabus = db.salidabus.Find(id);
            if (salidabus == null)
            {
                return HttpNotFound();
            }
            ViewBag.auxiliar = new SelectList(db.AspNetUsers, "Id", "Email", salidabus.auxiliar);
            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email", salidabus.chofer);
            ViewBag.bus = new SelectList(db.bus, "Idbus", "pantente", salidabus.bus);
            ViewBag.destino = new SelectList(db.ciudad, "Idciudad", "ciudad1", salidabus.destino);
            ViewBag.origen = new SelectList(db.ciudad, "Idciudad", "ciudad1", salidabus.origen);
            ViewBag.Idsalida = new SelectList(db.pasaje, "Idpasaje", "nombrepasajero", salidabus.Idsalida);
            return View(salidabus);
        }

        // POST: salidabus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idsalida,chofer,auxiliar,bus,fecha_salida,destino,origen")] salidabus salidabus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidabus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.auxiliar = new SelectList(db.AspNetUsers, "Id", "Email", salidabus.auxiliar);
            ViewBag.chofer = new SelectList(db.AspNetUsers, "Id", "Email", salidabus.chofer);
            ViewBag.bus = new SelectList(db.bus, "Idbus", "pantente", salidabus.bus);
            ViewBag.destino = new SelectList(db.ciudad, "Idciudad", "ciudad1", salidabus.destino);
            ViewBag.origen = new SelectList(db.ciudad, "Idciudad", "ciudad1", salidabus.origen);
            ViewBag.Idsalida = new SelectList(db.pasaje, "Idpasaje", "nombrepasajero", salidabus.Idsalida);
            return View(salidabus);
        }

        // GET: salidabus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salidabus salidabus = db.salidabus.Find(id);
            if (salidabus == null)
            {
                return HttpNotFound();
            }
            return View(salidabus);
        }

        // POST: salidabus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salidabus salidabus = db.salidabus.Find(id);
            db.salidabus.Remove(salidabus);
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
