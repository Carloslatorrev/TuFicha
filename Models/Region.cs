namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Region")]
    public class Region
    {
        [Key]
        public int IdRegion { get; set; }

        [StringLength(150)]
        [DisplayName("Reg_Nombre")]
        public string Reg_Nombre { get; set; }

    }
}
