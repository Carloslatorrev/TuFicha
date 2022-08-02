using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuFicha.Models;

namespace TuFicha.Controllers
{
    [Authorize]
    public class DocumentosController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public DocumentosController()
        {
        }

        public DocumentosController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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


        // GET: Documentos
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


            List<FichaUsuario> fichaUsuario = db.FichaUsuario.Where(x => x.UserId == usuario.Id).ToList();

            List<FichaDocumentos> fichaDocumentos = new List<FichaDocumentos>();

            var documentos = new List<Documentos>();

            foreach (var item in fichaUsuario)
            {
                fichaDocumentos.Add(db.FichaDocumentos.Where(x => x.IdFichaUsuario == item.IdFichaUsuario).FirstOrDefault());
            }

            foreach (var item in fichaDocumentos)
            {
                documentos.Add(db.Documentos.Where(x => x.IdDocumento == item.IdFichaUsuario).FirstOrDefault());
            }

            
            return View(documentos.ToList());
        }

        // GET: Documentos/Details/5
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
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            return View(documentos);
        }

        // GET: Documentos/Create
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

            ViewBag.IdCentroMedico = new SelectList(db.CentroMedico, "IdCentroMedico", "CM_Nombre");
            ViewBag.IdProfesional = new SelectList(db.ProfesionalSalud, "IdProfesional", "Pro_Nombre");
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "TD_Nombre");
            return View();
        }

        // POST: Documentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDocumento,Doc_Nombre,Doc_Descripcion,IdProfesional,IdCentroMedico,IdTipoDocumento,archivo")] Documentos documentos)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (DateTime.Now - usuario2.FechaNacimiento).TotalHours;
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
                try
                {
                    string fileExt = Path.GetExtension(documentos.archivo.FileName);
                    documentos.Extension = fileExt;
                    string rutaCentral = Server.MapPath("~/");
                    string nombreArchivo = Path.GetFileNameWithoutExtension(documentos.archivo.FileName);
                    string nombreFinal = String.Format("Files/{0}_{1}{2}", usuario.Id, nombreArchivo, fileExt);
                    string rutaCompleta = Path.Combine(rutaCentral, nombreFinal);
                    documentos.archivo.SaveAs(rutaCompleta);
                    string rutaToWatch = "https://localhost:44348/" + nombreFinal;
                    documentos.ruta = rutaToWatch;
                    documentos.Doc_FechaCreacion = DateTime.Now;
                    db.Documentos.Add(documentos);
                    db.SaveChanges();
                    UserDocumento userDocumento = new UserDocumento()
                    {
                        IdDocumento = documentos.IdDocumento,
                        UserId = usuario.Id
                    };
                    db.UserDocumento.Add(userDocumento);
                    db.SaveChanges();      

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }

            ViewBag.IdCentroMedico = new SelectList(db.CentroMedico, "IdCentroMedico", "CM_Nombre", documentos.IdCentroMedico);
            ViewBag.IdProfesional = new SelectList(db.ProfesionalSalud, "IdProfesional", "Pro_Nombre", documentos.IdProfesional);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "TD_Nombre", documentos.IdTipoDocumento);
            return View(documentos);
        }

        // GET: Documentos/Edit/5
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
                ViewBag.Edad = (DateTime.Now - usuario2.FechaNacimiento).TotalHours;
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
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCentroMedico = new SelectList(db.CentroMedico, "IdCentroMedico", "CM_Nombre", documentos.IdCentroMedico);
            ViewBag.IdProfesional = new SelectList(db.ProfesionalSalud, "IdProfesional", "Pro_Nombre", documentos.IdProfesional);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "TD_Nombre", documentos.IdTipoDocumento);
            return View(documentos);
        }

        // POST: Documentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDocumento,Doc_Nombre,Doc_FechaCreacion,Extension,Doc_Descripcion,IdProfesional,IdCentroMedico,IdTipoDocumento")] Documentos documentos)
        {
            string email2 = "";
            ApplicationUser usuario2 = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email2 = User.Identity.Name;
                usuario2 = UserManager.FindByEmail(email2);
                ViewBag.Nombre = usuario2.Nombre + " " + usuario2.Apellidos;
                ViewBag.Rut = usuario2.Rut;
                ViewBag.Edad = (DateTime.Now - usuario2.FechaNacimiento).TotalHours;
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            if (ModelState.IsValid)
            {
                db.Entry(documentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCentroMedico = new SelectList(db.CentroMedico, "IdCentroMedico", "CM_Nombre", documentos.IdCentroMedico);
            ViewBag.IdProfesional = new SelectList(db.ProfesionalSalud, "IdProfesional", "Pro_Nombre", documentos.IdProfesional);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "TD_Nombre", documentos.IdTipoDocumento);
            return View(documentos);
        }

        // GET: Documentos/Delete/5
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
                ViewBag.Edad = (DateTime.Now - usuario2.FechaNacimiento).TotalHours;
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
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            return View(documentos);
        }

        // POST: Documentos/Delete/5
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
                ViewBag.Edad = (DateTime.Now - usuario2.FechaNacimiento).TotalHours;
            }
            else
            {
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            Documentos documentos = db.Documentos.Find(id);
            db.Documentos.Remove(documentos);
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
