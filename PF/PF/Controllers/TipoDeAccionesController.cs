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
    public class TipoDeAccionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoDeAcciones
        public ActionResult Index()
        {
            return View(db.TipoDeAcciones.ToList());
        }

        // GET: TipoDeAcciones/Details/5
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

        // GET: TipoDeAcciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeAcciones/Create
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

        // GET: TipoDeAcciones/Edit/5
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

        // POST: TipoDeAcciones/Edit/5
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

        // GET: TipoDeAcciones/Delete/5
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

        // POST: TipoDeAcciones/Delete/5
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
