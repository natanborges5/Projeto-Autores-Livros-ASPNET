using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Controllers.Resources
{
    public class LivrosRequest
    {
        public string titulo { get; set; }
        public string isbn { get; set; }
        public DateTime ano { get; set; }
    }
}
