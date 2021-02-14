using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Labb_Bilar_1._0.Models
{
    public class Bilhandlare
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Namn { get; set; }
        [Required]
        public int StadId { get; set; }
        public List<Stad> Städer { get; set; }
        public List<Bil> Bilar { get; set; }
    }
}
