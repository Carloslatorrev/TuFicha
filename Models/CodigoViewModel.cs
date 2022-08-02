using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuFicha.Models
{
    public class CodigoViewModel
    {
        [DisplayName("Código")]
        [Display(Name ="Código")]
        public string codigo { get; set; }
    }
}