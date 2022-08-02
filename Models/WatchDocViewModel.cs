using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuFicha.Models
{
    public class WatchDocViewModel
    {
        public ApplicationUser user { get; set; }
        public List<FichaDocumentos> documentos { get; set; }
    }
}