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
    public class CentroMedicoController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public CentroMedicoController()
        {
        }

        public CentroMedicoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        // GET: CentroMedico
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

            var centroMedico = db.CentroMedico.Include(c => c.Ciudad);
            return View(centroMedico.ToList());
        }

        // GET: CentroMedico/Details/5
        public ActionResult Details(int? id)
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroMedico centroMedico = db.CentroMedico.Find(id);
            if (centroMedico == null)
            {
                return HttpNotFound();
            }
            return View(centroMedico);
        }

        // GET: CentroMedico/Create
        public ActionResult Create()
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

            ViewBag.Id_Ciudad = new SelectList(db.Ciudad, "IdCiudad", "Ciu_Nombre");
            return View();
        }

        // POST: CentroMedico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCentroMedico,CM_Nombre,Id_Ciudad,TipoCentro")] CentroMedico centroMedico)
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

            if (ModelState.IsValid)
            {
                centroMedico.FechaCreacion = DateTime.Now;
                db.CentroMedico.Add(centroMedico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Ciudad = new SelectList(db.Ciudad, "IdCiudad", "Ciu_Nombre", centroMedico.Id_Ciudad);
            return View(centroMedico);
        }

        // GET: CentroMedico/Edit/5
        public ActionResult Edit(int? id)
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroMedico centroMedico = db.CentroMedico.Find(id);
            if (centroMedico == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Ciudad = new SelectList(db.Ciudad, "IdCiudad", "Ciu_Nombre", centroMedico.Id_Ciudad);
            return View(centroMedico);
        }

        // POST: CentroMedico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCentroMedico,CM_Nombre,Id_Ciudad,TipoCentro,FechaCreacion")] CentroMedico centroMedico)
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

            if (ModelState.IsValid)
            {
                db.Entry(centroMedico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Ciudad = new SelectList(db.Ciudad, "IdCiudad", "Ciu_Nombre", centroMedico.Id_Ciudad);
            return View(centroMedico);
        }

        // GET: CentroMedico/Delete/5
        public ActionResult Delete(int? id)
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroMedico centroMedico = db.CentroMedico.Find(id);
            if (centroMedico == null)
            {
                return HttpNotFound();
            }
            return View(centroMedico);
        }

        // POST: CentroMedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

            CentroMedico centroMedico = db.CentroMedico.Find(id);
            db.CentroMedico.Remove(centroMedico);
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
