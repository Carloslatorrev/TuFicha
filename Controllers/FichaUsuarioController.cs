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
    public class FichaUsuarioController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public FichaUsuarioController()
        {
        }

        public FichaUsuarioController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        // GET: FichaUsuario
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
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            return View(db.FichaUsuario.Where(x => x.UserId == usuario.Id).ToList());
        }

        // GET: FichaUsuario/Details/5
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
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays) / 365).ToString("0");
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
            FichaUsuario fichaUsuario = db.FichaUsuario.Find(id);
            if (fichaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(fichaUsuario);
        }

        // GET: FichaUsuario/Create
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
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays)/365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            return View();
        }

        // POST: FichaUsuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFichaUsuario,FU_Nombre,Descripcion")] FichaUsuario fichaUsuario)
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
                string email = "";
                ApplicationUser usuario = new ApplicationUser();
                email = User.Identity.Name;
                usuario = UserManager.FindByEmail(email);
                fichaUsuario.UserId = usuario.Id;
                fichaUsuario.FU_FechaCreacion = DateTime.Now.ToString();
                db.FichaUsuario.Add(fichaUsuario);
                db.SaveChanges();
                FichaDocumentos fichaDocumentos = new FichaDocumentos()
                {
                    IdFichaUsuario = fichaUsuario.IdFichaUsuario
                };

                return RedirectToAction("Create","FichaDocumentos", fichaDocumentos);
            }

            return View(fichaUsuario);
        }

        // GET: FichaUsuario/Edit/5
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
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays) / 365).ToString("0");
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
            FichaUsuario fichaUsuario = db.FichaUsuario.Find(id);
            if (fichaUsuario == null)
            {
                return HttpNotFound();
            }
            List<Documentos> documentosList = db.FichaDocumentos.Where(x => x.IdFichaUsuario == fichaUsuario.IdFichaUsuario).Select(x => x.Documentos).ToList();
            DocumentoFichaModelView documentoFicha = new DocumentoFichaModelView() { 
                documentos = documentosList
            };
            fichaUsuario.documentoFicha = documentoFicha;

            return View(fichaUsuario);
        }

        // POST: FichaUsuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFichaUsuario,FU_Nombre,FU_FechaCreacion,Descripcion")] FichaUsuario fichaUsuario)
        {
            string email = "";
            ApplicationUser usuario = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email = User.Identity.Name;
                usuario = UserManager.FindByEmail(email);
                ViewBag.Nombre = usuario.Nombre + " " + usuario.Apellidos;
                ViewBag.Rut = usuario.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }


            if (ModelState.IsValid)
            {
                db.Entry(fichaUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Documentos> documentosList = db.FichaDocumentos.Where(x => x.IdFichaUsuario == fichaUsuario.IdFichaUsuario).Select(x => x.Documentos).ToList();
            DocumentoFichaModelView documentoFicha = new DocumentoFichaModelView()
            {
                documentos = documentosList
            };
            fichaUsuario.documentoFicha = documentoFicha;

            return View(fichaUsuario);
        }

        // GET: FichaUsuario/Delete/5
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
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays) / 365).ToString("0");
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
            FichaUsuario fichaUsuario = db.FichaUsuario.Find(id);
            if (fichaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(fichaUsuario);
        }

        // POST: FichaUsuario/Delete/5
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
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays) / 365).ToString("0");
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }


            FichaUsuario fichaUsuario = db.FichaUsuario.Find(id);
            List<FichaDocumentos> fichaDocumentos = db.FichaDocumentos.Where(x => x.IdFichaUsuario == id).ToList();
            List<LinkUsuario> linkUsuarios = db.LinkUsuario.Where(x => x.IdFichaUsuario == id).ToList();
            foreach (var item in fichaDocumentos)
            {
                db.FichaDocumentos.Remove(item);
                db.SaveChanges();
            }

            foreach (var item in linkUsuarios)
            {
                db.LinkUsuario.Remove(item);
                db.SaveChanges();
            }

            db.FichaUsuario.Remove(fichaUsuario);
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
