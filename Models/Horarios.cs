using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TuFicha.Models
{
    [Table("Horarios")]
    public class Horarios
    {
        [Key]
        public int IdHorario { get; set; }

        [DisplayName("Horas")]
        [Display(Name ="Horas")]
        public double horas { get; set; }
    }
}