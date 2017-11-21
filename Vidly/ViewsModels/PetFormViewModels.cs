using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewsModels
{
    public class PetFormViewModels
    {
        public Pet Pet { get; set; }
        public IEnumerable<Species> Especie { get; set; }
        public IEnumerable<Customer> cliente { get; set; }
        public string Title
        {
            get
            {
                if (Pet != null && Pet.id != 0)
                    return "Editar pet";

                return "Novo pet";
            }
        }
    }
}