namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CentroMedico")]
    public class CentroMedico
    {
    

        [Key]
        public int IdCentroMedico { get; set; }

        [StringLength(150)]
        [DisplayName("Nombre Centro")]
        public string CM_Nombre { get; set; }

        [ForeignKey("Ciudad")]
        [DisplayName("Ciudad")]
        public int? Id_Ciudad { get; set; }
        public virtual Ciudad Ciudad { get; set; }

        [StringLength(150)]
        [DisplayName("Tipo Centro")]
        public string TipoCentro { get; set; }

        [DisplayName("Fecha Creación")]
        public DateTime? FechaCreacion { get; set; }

      
        public virtual ICollection<Documentos> Documentos { get; set; }
    }
}
