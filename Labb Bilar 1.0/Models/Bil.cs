using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Labb_Bilar_1._0.Models;

namespace Labb_Bilar_1._0.Models
{
    public class Bil
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Skapad år")]
        public int Årsmodell { get; set; }

        [Required]
        public string Motortyp { get; set; }

        public int TillverkareId { get; set; }
        public Tillverkare Tillverkare { get; set; }

        [Required]
        [MaxLength(10)]
        public string Modell { get; set; }


    }
}
