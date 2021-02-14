using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Labb_Bilar_1._0.Models
{
    public class Stad
    {
        public int Id { get; set; }
        [Required]
        public string Namn { get; set; }

    }
}
