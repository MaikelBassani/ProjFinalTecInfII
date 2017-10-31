using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{

    public class Species
    {
        public int id { set; get; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string nome { set; get; }
    }
}