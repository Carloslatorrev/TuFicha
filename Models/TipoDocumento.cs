namespace TuFicha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoDocumento")]
    public class TipoDocumento
    {

        [Key]
        public int IdTipoDocumento { get; set; }

        [StringLength(150)]
        [DisplayName("Nombre Tipo Documento")]
        public string TD_Nombre { get; set; }
        [DisplayName("Fecha de Creacón")]
        public DateTime? TD_FechaCreacion { get; set; }

        [DisplayName("Es Examén")]
        public bool IsExamen { get; set; }
        [DisplayName("Es Diagnóstico")]
        public bool IsDiagnostico { get; set; }
        [DisplayName("Es Licencia")]
        public bool IsLicencia { get; set; }
        [DisplayName("Otros")]
        public bool IsOtro { get; set; }

        public virtual ICollection<Documentos> Documentos { get; set; }
    }
}
