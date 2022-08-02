using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TuFicha.Models;

namespace TuFicha.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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




        public ActionResult Index()
        {
            string email = "";
            List<FichaUsuario> fichaUsuarios = new List<FichaUsuario>();
            List<UserDocumento> userDocumentos = new List<UserDocumento>(); 
            ApplicationUser usuario = new  ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                email = User.Identity.Name;
                usuario = UserManager.FindByEmail(email);
                ViewBag.Nombre = usuario.Nombre + " "+ usuario.Apellidos;
                ViewBag.Rut = usuario.Rut;
                ViewBag.Edad = (((DateTime.Now - usuario.FechaNacimiento).TotalDays) / 365).ToString("0");
                fichaUsuarios = db.FichaUsuario.Where(x => x.UserId == usuario.Id).ToList();
                userDocumentos = db.UserDocumento.Where(x => x.UserId == usuario.Id).ToList();
            }
            else
            {
                fichaUsuarios = null;
                userDocumentos = null;
                ViewBag.Nombre = "Carlos Latorre Vargas";
                ViewBag.Rut = "11111111-3";
                ViewBag.Edad = "26 años";
            }

            DatosUsuarioViewModel datos = new DatosUsuarioViewModel()
            {
                fichaUsuario = fichaUsuarios,
                documentosUsuario = userDocumentos
            };

            return View(datos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}