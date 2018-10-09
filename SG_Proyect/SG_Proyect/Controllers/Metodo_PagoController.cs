using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SG_Proyect.Models;

namespace SG_Proyect.Controllers
{
    public class Metodo_PagoController : Controller
    {
        private Sistemas_GestionEntities db = new Sistemas_GestionEntities();

        // GET: Metodo_Pago
        public ActionResult Index()
        {
            return View(db.Metodo_Pago.ToList());
        }

        // GET: Metodo_Pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodo_Pago metodo_Pago = db.Metodo_Pago.Find(id);
            if (metodo_Pago == null)
            {
                return HttpNotFound();
            }
            return View(metodo_Pago);
        }

        // GET: Metodo_Pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Metodo_Pago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_metodo_pago,descripcion")] Metodo_Pago metodo_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Metodo_Pago.Add(metodo_Pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metodo_Pago);
        }

        // GET: Metodo_Pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodo_Pago metodo_Pago = db.Metodo_Pago.Find(id);
            if (metodo_Pago == null)
            {
                return HttpNotFound();
            }
            return View(metodo_Pago);
        }

        // POST: Metodo_Pago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_metodo_pago,descripcion")] Metodo_Pago metodo_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodo_Pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metodo_Pago);
        }

        // GET: Metodo_Pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodo_Pago metodo_Pago = db.Metodo_Pago.Find(id);
            if (metodo_Pago == null)
            {
                return HttpNotFound();
            }
            return View(metodo_Pago);
        }

        // POST: Metodo_Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Metodo_Pago metodo_Pago = db.Metodo_Pago.Find(id);
            db.Metodo_Pago.Remove(metodo_Pago);
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
