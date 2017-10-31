using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewsModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.id != 0)
                    return "Editar Cliente";

                return "Novo Cliente";
            }
        }
    }
}