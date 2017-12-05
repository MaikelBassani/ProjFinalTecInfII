using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Product
    {
        public int id { set; get; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string nome { set; get; }
        [Required]
        [Display(Name = "Quantidade")]
        public int quant { set; get; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Preço")]
        public string  preco{ set; get; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Descrição")]
        public string descricao { set; get; }
    }
}