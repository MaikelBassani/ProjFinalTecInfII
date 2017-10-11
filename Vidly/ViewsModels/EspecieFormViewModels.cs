using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewsModels
{
    public class EspecieFormViewModels
    {
        public  Species Especie { get; set; }
        public string Title
        {
            get
            {
                if (Especie != null && Especie.id != 0)
                    return "Editar especie";

                return "Nova especie";
            }
        }
    }
}