using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PF.Models;

namespace PF.Controllers
{
    public class UdMsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UdMs
        public ActionResult Index()
        {
            return View(db.UdMs.ToList());
        }

        // GET: UdMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UdM udM = db.UdMs.Find(id);
            if (udM == null)
            {
                return HttpNotFound();
            }
            return View(udM);
        }

        // GET: UdMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UdMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UdmId,UnidadBase,UnidadVenta,UnidadCompra")] UdM udM)
        {
            if (ModelState.IsValid)
            {
                db.UdMs.Add(udM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(udM);
        }

        // GET: UdMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UdM udM = db.UdMs.Find(id);
            if (udM == null)
            {
                return HttpNotFound();
            }
            return View(udM);
        }

        // POST: UdMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UdmId,UnidadBase,UnidadVenta,UnidadCompra")] UdM udM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(udM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(udM);
        }

        // GET: UdMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UdM udM = db.UdMs.Find(id);
            if (udM == null)
            {
                return HttpNotFound();
            }
            return View(udM);
        }

        // POST: UdMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UdM udM = db.UdMs.Find(id);
            db.UdMs.Remove(udM);
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
