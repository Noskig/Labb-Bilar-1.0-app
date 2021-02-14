using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_Bilar_1._0.Models
{
    public class Tillverkare
    {
        public int Id { get; set; }

        [Required]
        public string Namn { get; set; }
    }
}