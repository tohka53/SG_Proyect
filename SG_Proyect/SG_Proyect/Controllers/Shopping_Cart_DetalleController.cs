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
    public class Shopping_Cart_DetalleController : Controller
    {
        private Sistemas_GestionEntities db = new Sistemas_GestionEntities();

        // GET: Shopping_Cart_Detalle
        public ActionResult Index()
        {
            var shopping_Cart_Detalle = db.Shopping_Cart_Detalle.Include(s => s.Detalle_Prodducto).Include(s => s.Estado).Include(s => s.Shopping_Cart);
            return View(shopping_Cart_Detalle.ToList());
        }

        // GET: Shopping_Cart_Detalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart_Detalle shopping_Cart_Detalle = db.Shopping_Cart_Detalle.Find(id);
            if (shopping_Cart_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Cart_Detalle);
        }

        // GET: Shopping_Cart_Detalle/Create
        public ActionResult Create()
        {
            ViewBag.id_lista_producto = new SelectList(db.Detalle_Prodducto, "id_detalle_producto", "id_detalle_producto");
            ViewBag.id_estado = new SelectList(db.Estadoes, "id_estado", "descripcion");
            ViewBag.id_shopping_cart = new SelectList(db.Shopping_Cart, "id_shoppingcart", "id_shoppingcart");
            return View();
        }

        // POST: Shopping_Cart_Detalle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_shoppingcart_detalle,id_shopping_cart,id_lista_producto,id_estado")] Shopping_Cart_Detalle shopping_Cart_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Shopping_Cart_Detalle.Add(shopping_Cart_Detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_lista_producto = new SelectList(db.Detalle_Prodducto, "id_detalle_producto", "id_detalle_producto", shopping_Cart_Detalle.id_lista_producto);
            ViewBag.id_estado = new SelectList(db.Estadoes, "id_estado", "descripcion", shopping_Cart_Detalle.id_estado);
            ViewBag.id_shopping_cart = new SelectList(db.Shopping_Cart, "id_shoppingcart", "id_shoppingcart", shopping_Cart_Detalle.id_shopping_cart);
            return View(shopping_Cart_Detalle);
        }

        // GET: Shopping_Cart_Detalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart_Detalle shopping_Cart_Detalle = db.Shopping_Cart_Detalle.Find(id);
            if (shopping_Cart_Detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_lista_producto = new SelectList(db.Detalle_Prodducto, "id_detalle_producto", "id_detalle_producto", shopping_Cart_Detalle.id_lista_producto);
            ViewBag.id_estado = new SelectList(db.Estadoes, "id_estado", "descripcion", shopping_Cart_Detalle.id_estado);
            ViewBag.id_shopping_cart = new SelectList(db.Shopping_Cart, "id_shoppingcart", "id_shoppingcart", shopping_Cart_Detalle.id_shopping_cart);
            return View(shopping_Cart_Detalle);
        }

        // POST: Shopping_Cart_Detalle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_shoppingcart_detalle,id_shopping_cart,id_lista_producto,id_estado")] Shopping_Cart_Detalle shopping_Cart_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping_Cart_Detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_lista_producto = new SelectList(db.Detalle_Prodducto, "id_detalle_producto", "id_detalle_producto", shopping_Cart_Detalle.id_lista_producto);
            ViewBag.id_estado = new SelectList(db.Estadoes, "id_estado", "descripcion", shopping_Cart_Detalle.id_estado);
            ViewBag.id_shopping_cart = new SelectList(db.Shopping_Cart, "id_shoppingcart", "id_shoppingcart", shopping_Cart_Detalle.id_shopping_cart);
            return View(shopping_Cart_Detalle);
        }

        // GET: Shopping_Cart_Detalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart_Detalle shopping_Cart_Detalle = db.Shopping_Cart_Detalle.Find(id);
            if (shopping_Cart_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Cart_Detalle);
        }

        // POST: Shopping_Cart_Detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopping_Cart_Detalle shopping_Cart_Detalle = db.Shopping_Cart_Detalle.Find(id);
            db.Shopping_Cart_Detalle.Remove(shopping_Cart_Detalle);
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
