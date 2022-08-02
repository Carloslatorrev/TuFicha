namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ciudad")]
    public class Ciudad
    {

        [Key]
        public int IdCiudad { get; set; }

        [StringLength(50)]
        [DisplayName("Nombre Ciudad")]
        public string Ciu_Nombre { get; set; }

        [ForeignKey("Region")]
        [DisplayName("Región")]
        public int? IdRegion { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<CentroMedico> CentroMedico { get; set; }

        
    }
}
