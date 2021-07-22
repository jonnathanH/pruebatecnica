using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using registrodepersonal;

namespace registrodepersonal.Controllers
{
    public class tblareatrabajoesController : Controller
    {
        private EmpresaEntities2 db = new EmpresaEntities2();

        // GET: tblareatrabajoes
        public ActionResult Index()
        {
            return View(db.tblareatrabajo.ToList());
        }

        // GET: tblareatrabajoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblareatrabajo tblareatrabajo = db.tblareatrabajo.Find(id);
            if (tblareatrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tblareatrabajo);
        }

        // GET: tblareatrabajoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblareatrabajoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDArea,NombreArea,IDJefeArea")] tblareatrabajo tblareatrabajo)
        {
            if (ModelState.IsValid)
            {
                db.tblareatrabajo.Add(tblareatrabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblareatrabajo);
        }

        // GET: tblareatrabajoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblareatrabajo tblareatrabajo = db.tblareatrabajo.Find(id);
            if (tblareatrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tblareatrabajo);
        }

        // POST: tblareatrabajoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDArea,NombreArea,IDJefeArea")] tblareatrabajo tblareatrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblareatrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblareatrabajo);
        }

        // GET: tblareatrabajoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblareatrabajo tblareatrabajo = db.tblareatrabajo.Find(id);
            if (tblareatrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tblareatrabajo);
        }

        // POST: tblareatrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblareatrabajo tblareatrabajo = db.tblareatrabajo.Find(id);
            db.tblareatrabajo.Remove(tblareatrabajo);
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
