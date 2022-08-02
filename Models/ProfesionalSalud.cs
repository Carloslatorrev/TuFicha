namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfesionalSalud")]
    public class ProfesionalSalud
    {

        [Key]
        public int IdProfesional { get; set; }

        [StringLength(150)]
        [DisplayName("Nombre Profesional")]
        public string Pro_Nombre { get; set; }

        [StringLength(150)]
        [DisplayName("Apellido Profesional")]
        public string Pro_Apellido { get; set; }

        [StringLength(150)]
        [DisplayName("Rut Profesional")]
        public string Pro_RUT { get; set; }

        [MaxLength(150)]
        [DisplayName("Profesión")]
        public string Pro_Profesion { get; set; }

        [StringLength(150)]
        [DisplayName("Especialidad (Si corresponde)")]
        public string Especialidad { get; set; }

        
        public virtual ICollection<Documentos> Documentos { get; set; }
    }
}
