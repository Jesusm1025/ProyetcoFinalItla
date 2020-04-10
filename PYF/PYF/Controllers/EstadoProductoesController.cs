using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PYF.Models;

namespace PYF.Controllers
{
    public class EstadoProductoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EstadoProductoes
        public ActionResult Index()
        {
            return View(db.EstadoProductos.ToList());
        }

        // GET: EstadoProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoProducto estadoProducto = db.EstadoProductos.Find(id);
            if (estadoProducto == null)
            {
                return HttpNotFound();
            }
            return View(estadoProducto);
        }

        // GET: EstadoProductoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoProductoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoProductoId,Estado")] EstadoProducto estadoProducto)
        {
            if (ModelState.IsValid)
            {
                db.EstadoProductos.Add(estadoProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoProducto);
        }

        // GET: EstadoProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoProducto estadoProducto = db.EstadoProductos.Find(id);
            if (estadoProducto == null)
            {
                return HttpNotFound();
            }
            return View(estadoProducto);
        }

        // POST: EstadoProductoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoProductoId,Estado")] EstadoProducto estadoProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoProducto);
        }

        // GET: EstadoProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoProducto estadoProducto = db.EstadoProductos.Find(id);
            if (estadoProducto == null)
            {
                return HttpNotFound();
            }
            return View(estadoProducto);
        }

        // POST: EstadoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoProducto estadoProducto = db.EstadoProductos.Find(id);
            db.EstadoProductos.Remove(estadoProducto);
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
