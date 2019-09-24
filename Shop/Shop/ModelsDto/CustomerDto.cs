using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ModelsDto
{
    public class CustomerDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
