using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TuFicha.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(150)]
        [DisplayName("Nombres")]
        public string Nombre { get; set; }

        [StringLength(150)]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [StringLength(150)]
        [DisplayName("RUT")]
        public string Rut { get; set; }

        
        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Género")]
        [StringLength(150)]
        public string Genero { get; set; }

        [ForeignKey("Ciudad")]
        public int? IdCiudad { get; set; }
        public virtual Ciudad Ciudad { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AppDbContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<CentroMedico> CentroMedico { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<FichaDocumentos> FichaDocumentos { get; set; }
        public virtual DbSet<FichaUsuario> FichaUsuario { get; set; }
        public virtual DbSet<LinkUsuario> LinkUsuario { get; set; }
        public virtual DbSet<ProfesionalSalud> ProfesionalSalud { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<UserDocumento> UserDocumento { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}