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
    public class Detalle_ProdductoController : Controller
    {
        private Sistemas_GestionEntities db = new Sistemas_GestionEntities();

        // GET: Detalle_Prodducto
        public ActionResult Index()
        {
            var detalle_Prodducto = db.Detalle_Prodducto.Include(d => d.Producto);
            return View(detalle_Prodducto.ToList());
        }

        // GET: Detalle_Prodducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Prodducto detalle_Prodducto = db.Detalle_Prodducto.Find(id);
            if (detalle_Prodducto == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Prodducto);
        }

        // GET: Detalle_Prodducto/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto");
            return View();
        }

        // POST: Detalle_Prodducto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detalle_producto,id_producto,cantidad,precio_unitario,precio_total")] Detalle_Prodducto detalle_Prodducto)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Prodducto.Add(detalle_Prodducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", detalle_Prodducto.id_producto);
            return View(detalle_Prodducto);
        }

        // GET: Detalle_Prodducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Prodducto detalle_Prodducto = db.Detalle_Prodducto.Find(id);
            if (detalle_Prodducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", detalle_Prodducto.id_producto);
            return View(detalle_Prodducto);
        }

        // POST: Detalle_Prodducto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detalle_producto,id_producto,cantidad,precio_unitario,precio_total")] Detalle_Prodducto detalle_Prodducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Prodducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", detalle_Prodducto.id_producto);
            return View(detalle_Prodducto);
        }

        // GET: Detalle_Prodducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Prodducto detalle_Prodducto = db.Detalle_Prodducto.Find(id);
            if (detalle_Prodducto == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Prodducto);
        }

        // POST: Detalle_Prodducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Prodducto detalle_Prodducto = db.Detalle_Prodducto.Find(id);
            db.Detalle_Prodducto.Remove(detalle_Prodducto);
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
