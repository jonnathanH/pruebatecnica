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
    public class tbltrabajadoresController : Controller
    {
        private EmpresaEntities2 db = new EmpresaEntities2();

        // GET: tbltrabajadores
        public ActionResult Index()
        {
            return View(db.tbltrabajadores.ToList());
        }

        // GET: tbltrabajadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbltrabajadores tbltrabajadores = db.tbltrabajadores.Find(id);
            if (tbltrabajadores == null)
            {
                return HttpNotFound();
            }
            return View(tbltrabajadores);
        }

        // GET: tbltrabajadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbltrabajadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEmpresarial,Nombres,Apellidsos,Direccion,Telefono,Fechadeingraso,Sexo,Area")] tbltrabajadores tbltrabajadores)
        {
            if (ModelState.IsValid)
            {
                db.tbltrabajadores.Add(tbltrabajadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbltrabajadores);
        }

        // GET: tbltrabajadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbltrabajadores tbltrabajadores = db.tbltrabajadores.Find(id);
            if (tbltrabajadores == null)
            {
                return HttpNotFound();
            }
            return View(tbltrabajadores);
        }

        // POST: tbltrabajadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEmpresarial,Nombres,Apellidsos,Direccion,Telefono,Fechadeingraso,Sexo,Area")] tbltrabajadores tbltrabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbltrabajadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbltrabajadores);
        }

        // GET: tbltrabajadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbltrabajadores tbltrabajadores = db.tbltrabajadores.Find(id);
            if (tbltrabajadores == null)
            {
                return HttpNotFound();
            }
            return View(tbltrabajadores);
        }

        // POST: tbltrabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbltrabajadores tbltrabajadores = db.tbltrabajadores.Find(id);
            db.tbltrabajadores.Remove(tbltrabajadores);
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
