namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FichaUsuario")]
    public class FichaUsuario
    {
      

        [Key]
        public int IdFichaUsuario { get; set; }

        [StringLength(150)]
        [DisplayName("Nombre Ficha")]
        public string FU_Nombre { get; set; }

        [StringLength(150)]
        [DisplayName("Fecha Creación")]
        public string FU_FechaCreacion { get; set; }

        [StringLength(150)]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }


        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<LinkUsuario> LinkUsuario { get; set; }


        [NotMapped]
        public DocumentoFichaModelView documentoFicha { get; set; }
    }
}
