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
    public class LinkUsuarioController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public LinkUsuarioController()
        {
        }

        public LinkUsuarioController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        // GET: LinkUsuarios
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

            var linkUsuario = db.LinkUsuario.Where(x => x.UserId == usuario.Id).Include(l => l.FichaUsuario);
            return View(linkUsuario.ToList());
        }

        // GET: LinkUsuarios/Details/5
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
            LinkUsuario linkUsuario = db.LinkUsuario.Find(id);
            if (linkUsuario == null)
            {
                return HttpNotFound();
            }
            return View(linkUsuario);
        }

        // GET: LinkUsuarios/Create
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

            ViewBag.IdHorario = new SelectList(db.Horarios, "IdHorario", "horas");
            ViewBag.IdFichaUsuario = new SelectList(db.FichaUsuario, "IdFichaUsuario", "FU_Nombre");

            LinkUsuario linkUsuario = new LinkUsuario()
            {
                Codigo = RandomString(6)
            };

            return View(linkUsuario);
        }

        // POST: LinkUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLink,Codigo,IdFichaUsuario,IdHorario")] LinkUsuario linkUsuario)
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
                Horarios horarios = db.Horarios.Find(linkUsuario.IdHorario);
                linkUsuario.LU_FechaCreacion = DateTime.Now;
                linkUsuario.horas = Int32.Parse(horarios.horas.ToString());
                linkUsuario.FechaVencimiento = DateTime.Now.AddHours(horarios.horas);
                linkUsuario.UserId = usuario2.Id;

                db.LinkUsuario.Add(linkUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFichaUsuario = new SelectList(db.FichaUsuario, "IdFichaUsuario", "FU_Nombre", linkUsuario.IdFichaUsuario);
            return View(linkUsuario);
        }

        // GET: LinkUsuarios/Edit/5
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
            LinkUsuario linkUsuario = db.LinkUsuario.Find(id);
            if (linkUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFichaUsuario = new SelectList(db.FichaUsuario, "IdFichaUsuario", "FU_Nombre", linkUsuario.IdFichaUsuario);
            return View(linkUsuario);
        }

        // POST: LinkUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLink,Codigo,horas,FechaVencimiento,LU_FechaCreacion,IdFichaUsuario")] LinkUsuario linkUsuario)
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
                db.Entry(linkUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFichaUsuario = new SelectList(db.FichaUsuario, "IdFichaUsuario", "FU_Nombre", linkUsuario.IdFichaUsuario);
            return View(linkUsuario);
        }

        // GET: LinkUsuarios/Delete/5
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
            LinkUsuario linkUsuario = db.LinkUsuario.Find(id);
            if (linkUsuario == null)
            {
                return HttpNotFound();
            }
            return View(linkUsuario);
        }

        // POST: LinkUsuarios/Delete/5
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

            LinkUsuario linkUsuario = db.LinkUsuario.Find(id);
            db.LinkUsuario.Remove(linkUsuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult InsertCodigo()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult WatchDocs(string codigo)
        {
            LinkUsuario linkUsuario = db.LinkUsuario.Where(x => x.Codigo == codigo && x.FechaVencimiento > DateTime.Now).FirstOrDefault();
            if (linkUsuario != null)
            {
                ApplicationUser usuario2 = usuario2 = UserManager.FindById(linkUsuario.FichaUsuario.UserId);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario2.FechaNacimiento).TotalDays) / 365).ToString("0");
                

                List<FichaDocumentos> fichaDocumentos = db.FichaDocumentos.Where(x => x.IdFichaUsuario == linkUsuario.IdFichaUsuario).ToList();
                WatchDocViewModel model = new WatchDocViewModel()
                {
                    user = usuario2,
                    documentos = fichaDocumentos
                };
                return View(model);
            }


            return View("Error");
        }



        //++++++++ OTROS ********

        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopkrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
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
