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
    public class FichaDocumentosController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public FichaDocumentosController()
        {
        }

        public FichaDocumentosController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        // GET: FichaDocumentos
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

            var fichaDocumentos = db.FichaDocumentos.Include(f => f.Documentos);
            return View(fichaDocumentos.ToList());
        }

        // GET: FichaDocumentos/Details/5
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
            FichaDocumentos fichaDocumentos = db.FichaDocumentos.Find(id);
            if (fichaDocumentos == null)
            {
                return HttpNotFound();
            }
            return View(fichaDocumentos);
        }

        // GET: FichaDocumentos/Create
        [HttpGet]
        public ActionResult Create(FichaDocumentos fichaDocumentos)
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

            DocumentoFichaModelView documentoFichaModelView = new DocumentoFichaModelView() {
                documentos = db.Documentos.ToList(),
                IdFichaUsuario = fichaDocumentos.IdFichaUsuario.Value
            };

            ViewBag.IdDocumento = new SelectList(db.Documentos, "IdDocumento", "Doc_Nombre");

            return View(documentoFichaModelView);
        }

        // POST: FichaDocumentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFichaUsuario")] DocumentoFichaModelView fichaDocumentos, IEnumerable<int> IdDocumentos)
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
                foreach (var item in IdDocumentos)
                {
                    FichaDocumentos fichaDocumentos1 = new FichaDocumentos()
                    {
                        IdFichaUsuario = fichaDocumentos.IdFichaUsuario,
                        IdDocumento = item
                    };
                    db.FichaDocumentos.Add(fichaDocumentos1);
                    db.SaveChanges();
                }

                
                return RedirectToAction("Index","Home");
            }

            
            return View(fichaDocumentos);
        }

        // GET: FichaDocumentos/Edit/5
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
            FichaDocumentos fichaDocumentos = db.FichaDocumentos.Find(id);
            if (fichaDocumentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDocumento = new SelectList(db.Documentos, "IdDocumento", "Doc_Nombre", fichaDocumentos.IdDocumento);
            return View(fichaDocumentos);
        }

        // POST: FichaDocumentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFichaDocumento,IdFichaUsuario,IdDocumento")] FichaDocumentos fichaDocumentos)
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
                db.Entry(fichaDocumentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDocumento = new SelectList(db.Documentos, "IdDocumento", "Doc_Nombre", fichaDocumentos.IdDocumento);
            return View(fichaDocumentos);
        }

        // GET: FichaDocumentos/Delete/5
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
            FichaDocumentos fichaDocumentos = db.FichaDocumentos.Find(id);
            if (fichaDocumentos == null)
            {
                return HttpNotFound();
            }
            return View(fichaDocumentos);
        }

        // POST: FichaDocumentos/Delete/5
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

            FichaDocumentos fichaDocumentos = db.FichaDocumentos.Find(id);
            db.FichaDocumentos.Remove(fichaDocumentos);
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
