using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Brand : Base
    {
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
