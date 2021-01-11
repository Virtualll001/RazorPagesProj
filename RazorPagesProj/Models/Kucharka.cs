using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProj.Models
{
    public class Kucharka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Jméno receptu")]
        public string Jmeno { get; set; }
        public string Ingredience { get; set; }
        [Required]
        [Display(Name = "Pracovní postup")]
        public string Recept { get; set; }
    }
}
