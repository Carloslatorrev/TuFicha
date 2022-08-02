using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
    public class TipoDocumentoController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public TipoDocumentoController()
        {
        }

        public TipoDocumentoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: TipoDocumento
        public ActionResult Index()
        {
            string email = "";
            ApplicationUser usuario = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email = User.Identity.Name;
                usuario = UserManager.FindByEmail(email);
                ViewBag.Nombre = usuario.Nombre + " " + usuario.Apellidos;
                ViewBag.Rut = usuario.Rut;
                ViewBag.Edad = "16";
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            return View(db.TipoDocumento.ToList());
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            return View();
        }

        // POST: TipoDocumento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoDocumento,TD_Nombre,TD_FechaCreacion,IsExamen,IsDiagnostico,IsLicencia,IsOtro")] TipoDocumento tipoDocumento)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            if (ModelState.IsValid)
            {
                db.TipoDocumento.Add(tipoDocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoDocumento,TD_Nombre,TD_FechaCreacion,IsExamen,IsDiagnostico,IsLicencia,IsOtro")] TipoDocumento tipoDocumento)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            if (ModelState.IsValid)
            {
                db.Entry(tipoDocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            db.TipoDocumento.Remove(tipoDocumento);
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
