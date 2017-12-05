using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "CPF")]
        public string cpf { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Endereco")]
        public string endereco { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [Required]
        [Display(Name = "Nº Casa")]
        public int num_casa { get; set; }

    }

    
}