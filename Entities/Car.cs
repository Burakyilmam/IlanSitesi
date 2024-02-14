using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Car : Base
    {
        public string Color { get; set; }
        public decimal Price { get; set; }
        public double KM { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
