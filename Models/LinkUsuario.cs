namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinkUsuario")]
    public class LinkUsuario
    {
        [Key]
        public int IdLink { get; set; }

        [StringLength(6)]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Horas de habilitación")]
        public int horas { get; set; }

        [DisplayName("Fecha Vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        [DisplayName("Fecha de Creación")]
        public DateTime? LU_FechaCreacion { get; set; }

        [ForeignKey("FichaUsuario")]
        [DisplayName("Ficha Usuario")]
        public int? IdFichaUsuario { get; set; }

        public virtual FichaUsuario FichaUsuario { get; set; }

        public int IdHorario { get; set; }
        public virtual Horarios Horarios { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
