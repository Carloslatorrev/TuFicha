using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TuFicha.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CentroMedico>()
                .Property(e => e.CM_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<CentroMedico>()
                .Property(e => e.TipoCentro)
                .IsUnicode(false);

            modelBuilder.Entity<Ciudad>()
                .Property(e => e.Ciu_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciudad>()
                .HasMany(e => e.CentroMedico)
                .WithOptional(e => e.Ciudad)
                .HasForeignKey(e => e.Id_Ciudad);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.Doc_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.Extension)
                .IsUnicode(false);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.Doc_Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<FichaUsuario>()
                .Property(e => e.FU_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<FichaUsuario>()
                .Property(e => e.FU_FechaCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<FichaUsuario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<LinkUsuario>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<ProfesionalSalud>()
                .Property(e => e.Pro_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ProfesionalSalud>()
                .Property(e => e.Pro_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<ProfesionalSalud>()
                .Property(e => e.Pro_RUT)
                .IsUnicode(false);

            modelBuilder.Entity<ProfesionalSalud>()
                .Property(e => e.Especialidad)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.Reg_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .HasOptional(e => e.Ciudad)
                .WithRequired(e => e.Region);

            modelBuilder.Entity<TipoDocumento>()
                .Property(e => e.TD_Nombre)
                .IsUnicode(false);
        }
    }
}
