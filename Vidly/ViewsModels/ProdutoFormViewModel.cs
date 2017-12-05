using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewsModels
{
    public class ProdutoFormViewModel
    {
        public Product Produto { get; set; }
        public string Title
        {
            get
            {
                if (Produto != null && Produto.id != 0)
                    return "Editar produto";

                return "Novo produto";
            }
        }
    }
}