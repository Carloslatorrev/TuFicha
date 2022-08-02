using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuFicha.Models
{
    public class DocumentoFichaModelView
    {
        [Required]
        public int IdFichaUsuario { get; set; }

        public List<Documentos> documentos { get; set; }

        //[Required]
        //public IEnumerable<int> IdDocumentos { get; set; }
    }
}