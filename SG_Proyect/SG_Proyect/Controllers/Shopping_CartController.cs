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
    public class Shopping_CartController : Controller
    {
        private Sistemas_GestionEntities db = new Sistemas_GestionEntities();

        // GET: Shopping_Cart
        public ActionResult Index()
        {
            var shopping_Cart = db.Shopping_Cart.Include(s => s.Cliente).Include(s => s.Estado1).Include(s => s.Metodo_Pago);
            return View(shopping_Cart.ToList());
        }

        // GET: Shopping_Cart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart shopping_Cart = db.Shopping_Cart.Find(id);
            if (shopping_Cart == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre_cliente");
            ViewBag.estado = new SelectList(db.Estadoes, "id_estado", "descripcion");
            ViewBag.metodo_pag = new SelectList(db.Metodo_Pago, "id_metodo_pago", "descripcion");
            return View();
        }

        // POST: Shopping_Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_shoppingcart,id_cliente,date,estado,metodo_pag,monto_total")] Shopping_Cart shopping_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Shopping_Cart.Add(shopping_Cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre_cliente", shopping_Cart.id_cliente);
            ViewBag.estado = new SelectList(db.Estadoes, "id_estado", "descripcion", shopping_Cart.estado);
            ViewBag.metodo_pag = new SelectList(db.Metodo_Pago, "id_metodo_pago", "descripcion", shopping_Cart.metodo_pag);
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart shopping_Cart = db.Shopping_Cart.Find(id);
            if (shopping_Cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre_cliente", shopping_Cart.id_cliente);
            ViewBag.estado = new SelectList(db.Estadoes, "id_estado", "descripcion", shopping_Cart.estado);
            ViewBag.metodo_pag = new SelectList(db.Metodo_Pago, "id_metodo_pago", "descripcion", shopping_Cart.metodo_pag);
            return View(shopping_Cart);
        }

        // POST: Shopping_Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_shoppingcart,id_cliente,date,estado,metodo_pag,monto_total")] Shopping_Cart shopping_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping_Cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre_cliente", shopping_Cart.id_cliente);
            ViewBag.estado = new SelectList(db.Estadoes, "id_estado", "descripcion", shopping_Cart.estado);
            ViewBag.metodo_pag = new SelectList(db.Metodo_Pago, "id_metodo_pago", "descripcion", shopping_Cart.metodo_pag);
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart shopping_Cart = db.Shopping_Cart.Find(id);
            if (shopping_Cart == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Cart);
        }

        // POST: Shopping_Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopping_Cart shopping_Cart = db.Shopping_Cart.Find(id);
            db.Shopping_Cart.Remove(shopping_Cart);
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
