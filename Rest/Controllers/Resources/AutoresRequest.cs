using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Controllers.Resources
{
    public class AutoresRequest
    {
        public String nome { get; set; }
        public String sobrenome { get; set; }
        public String Email { get; set; }
        public DateTime dataAniversario { get; set; }
    }
}
