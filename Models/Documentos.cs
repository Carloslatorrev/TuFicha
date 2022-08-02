namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public class Documentos
    {


        [Key]
        public int IdDocumento { get; set; }

        [StringLength(150)]
        [DisplayName("Nombre Documento")]
        public string Doc_Nombre { get; set; }

        [DisplayName("Fecha Creación")]
        public DateTime? Doc_FechaCreacion { get; set; }

        [StringLength(150)]
        [DisplayName("Extensión")]
        public string Extension { get; set; }

        [DisplayName("Descripción")]
        public string Doc_Descripcion { get; set; }

        [ForeignKey("ProfesionalSalud")]
        [DisplayName("Nombre Profesional")]
        public int? IdProfesional { get; set; }
        public virtual ProfesionalSalud ProfesionalSalud { get; set; }

        [ForeignKey("CentroMedico")]
        [DisplayName("Centro Médico")]
        public int? IdCentroMedico { get; set; }
        public virtual CentroMedico CentroMedico { get; set; }

        [ForeignKey("TipoDocumento")]
        [DisplayName("Tipo Documento")]
        public int? IdTipoDocumento { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

        public string ruta { get; set; }


        public virtual ICollection<FichaDocumentos> FichaDocumentos { get; set; }


        public virtual ICollection<UserDocumento> UserDocumento { get; set; }


        [NotMapped]
        [Required]
        public HttpPostedFileBase archivo { get; set; }
    }
}
