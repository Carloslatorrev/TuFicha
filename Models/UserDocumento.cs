namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserDocumento")]
    public class UserDocumento
    {
        [Key]
        public int IdUserDocumento { get; set; }

        [ForeignKey("Documentos")]
        [DisplayName("Documento")]
        public int? IdDocumento { get; set; }
        public virtual Documentos Documentos { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
