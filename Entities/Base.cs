using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
