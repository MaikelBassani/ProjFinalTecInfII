using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Pet
    {
        public int id { set; get;}
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string nome {set;get;}
        [Required]
        [StringLength(255)]
        [Display(Name = "Raça")]
        public string raca { set; get; }
        public string cor { set; get; }
        public Species Especie { get; set; }
        [Display(Name = "Especie")]
        public int EspecieId { get; set; }
        public Customer cliente { get; set; }
        [Display(Name = "Dono")]
        public int ClienteId { get; set; }
    }
}