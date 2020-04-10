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
    public class TipoDeAccionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoDeAccion
        public ActionResult Index()
        {
            return View(db.TipoDeAcciones.ToList());
        }

        // GET: TipoDeAccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAccion tipoDeAccion = db.TipoDeAcciones.Find(id);
            if (tipoDeAccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeAccion);
        }

        // GET: TipoDeAccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeAccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDeAccionId,Accion")] TipoDeAccion tipoDeAccion)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeAcciones.Add(tipoDeAccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeAccion);
        }

        // GET: TipoDeAccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAccion tipoDeAccion = db.TipoDeAcciones.Find(id);
            if (tipoDeAccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeAccion);
        }

        // POST: TipoDeAccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDeAccionId,Accion")] TipoDeAccion tipoDeAccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeAccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeAccion);
        }

        // GET: TipoDeAccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAccion tipoDeAccion = db.TipoDeAcciones.Find(id);
            if (tipoDeAccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeAccion);
        }

        // POST: TipoDeAccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeAccion tipoDeAccion = db.TipoDeAcciones.Find(id);
            db.TipoDeAcciones.Remove(tipoDeAccion);
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
