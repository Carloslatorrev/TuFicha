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
    public class ProfesionalSaludController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public ProfesionalSaludController()
        {
        }

        public ProfesionalSaludController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        // GET: ProfesionalSaluds
        public ActionResult Index()
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

            return View(db.ProfesionalSalud.ToList());
        }

        // GET: ProfesionalSaluds/Details/5
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
            ProfesionalSalud profesionalSalud = db.ProfesionalSalud.Find(id);
            if (profesionalSalud == null)
            {
                return HttpNotFound();
            }
            return View(profesionalSalud);
        }

        // GET: ProfesionalSaluds/Create
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
                ViewBag.Rut = "111111111-3";
                ViewBag.Edad = "26 años";
            }

            return View();
        }

        // POST: ProfesionalSaluds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfesional,Pro_Nombre,Pro_Apellido,Pro_RUT,Pro_Profesion,Especialidad")] ProfesionalSalud profesionalSalud)
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
                db.ProfesionalSalud.Add(profesionalSalud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesionalSalud);
        }

        // GET: ProfesionalSaluds/Edit/5
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
            ProfesionalSalud profesionalSalud = db.ProfesionalSalud.Find(id);
            if (profesionalSalud == null)
            {
                return HttpNotFound();
            }
            return View(profesionalSalud);
        }

        // POST: ProfesionalSaluds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfesional,Pro_Nombre,Pro_Apellido,Pro_RUT,Pro_Profesion,Especialidad")] ProfesionalSalud profesionalSalud)
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
                db.Entry(profesionalSalud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesionalSalud);
        }

        // GET: ProfesionalSaluds/Delete/5
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
            ProfesionalSalud profesionalSalud = db.ProfesionalSalud.Find(id);
            if (profesionalSalud == null)
            {
                return HttpNotFound();
            }
            return View(profesionalSalud);
        }

        // POST: ProfesionalSaluds/Delete/5
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

            ProfesionalSalud profesionalSalud = db.ProfesionalSalud.Find(id);
            db.ProfesionalSalud.Remove(profesionalSalud);
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
