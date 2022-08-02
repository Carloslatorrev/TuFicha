namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class FichaDocumentos
    {
        [Key]
        public int IdFichaDocumento { get; set; }

        [DisplayName("Ficha Usuario")]
        public int? IdFichaUsuario { get; set; }

        [ForeignKey("Documentos")]
        public int? IdDocumento { get; set; }

        public virtual Documentos Documentos { get; set; }
    }
}
