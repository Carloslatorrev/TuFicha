using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuFicha.Models;

namespace TuFicha.Controllers
{
    [Authorize]
    public class UserDocumentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserDocumento
        public ActionResult Index()
        {
            var userDocumento = db.UserDocumento.Include(u => u.Documentos);
            return View(userDocumento.ToList());
        }

        // GET: UserDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDocumento userDocumento = db.UserDocumento.Find(id);
            if (userDocumento == null)
            {
                return HttpNotFound();
            }
            return View(userDocumento);
        }

        // GET: UserDocumento/Create
        public ActionResult Create()
        {
            ViewBag.IdDocumento = new SelectList(db.Documentos, "IdDocumento", "Doc_Nombre");
            return View();
        }

        // POST: UserDocumento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUserDocumento,IdDocumento")] UserDocumento userDocumento)
        {
            if (ModelState.IsValid)
            {
                db.UserDocumento.Add(userDocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDocumento = new SelectList(db.Documentos, "IdDocumento", "Doc_Nombre", userDocumento.IdDocumento);
            return View(userDocumento);
        }

        // GET: UserDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDocumento userDocumento = db.UserDocumento.Find(id);
            if (userDocumento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDocumento = new SelectList(db.Documentos, "IdDocumento", "Doc_Nombre", userDocumento.IdDocumento);
            return View(userDocumento);
        }

        // POST: UserDocumento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUserDocumento,IdDocumento")] UserDocumento userDocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDocumento = new SelectList(db.Documentos, "IdDocumento", "Doc_Nombre", userDocumento.IdDocumento);
            return View(userDocumento);
        }

        // GET: UserDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDocumento userDocumento = db.UserDocumento.Find(id);
            if (userDocumento == null)
            {
                return HttpNotFound();
            }
            return View(userDocumento);
        }

        // POST: UserDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDocumento userDocumento = db.UserDocumento.Find(id);
            db.UserDocumento.Remove(userDocumento);
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
