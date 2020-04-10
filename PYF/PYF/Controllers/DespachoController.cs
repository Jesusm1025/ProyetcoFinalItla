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
    public class DespachoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Despacho
        public ActionResult Index()
        {
            return View(db.Despachos.ToList());
        }

        // GET: Despacho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despacho despacho = db.Despachos.Find(id);
            if (despacho == null)
            {
                return HttpNotFound();
            }
            return View(despacho);
        }

        // GET: Despacho/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Despacho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DespachoId,fecha")] Despacho despacho)
        {
            if (ModelState.IsValid)
            {
                db.Despachos.Add(despacho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(despacho);
        }

        // GET: Despacho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despacho despacho = db.Despachos.Find(id);
            if (despacho == null)
            {
                return HttpNotFound();
            }
            return View(despacho);
        }

        // POST: Despacho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DespachoId,fecha")] Despacho despacho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despacho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(despacho);
        }

        // GET: Despacho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despacho despacho = db.Despachos.Find(id);
            if (despacho == null)
            {
                return HttpNotFound();
            }
            return View(despacho);
        }

        // POST: Despacho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despacho despacho = db.Despachos.Find(id);
            db.Despachos.Remove(despacho);
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
