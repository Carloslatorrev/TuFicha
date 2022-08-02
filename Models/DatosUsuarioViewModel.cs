using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuFicha.Models
{
    public class DatosUsuarioViewModel
    {

        public List<FichaUsuario> fichaUsuario {get; set;}
        public List<UserDocumento> documentosUsuario { get; set; }


    }
}