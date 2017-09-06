using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewsModels
{
    public class RandomPetsViewModel
    {
        public Pet Pets { get; set; }
        public List<Customer> Customers { get; set; }
    }
}