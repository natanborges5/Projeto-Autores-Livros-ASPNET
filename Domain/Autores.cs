
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Autores
    {
        public Guid Id { get; set; }
        public String nome { get; set; }
        public String sobrenome { get; set; }
        public String Email { get; set; }
        public DateTime dataAniversario { get; set; }
        public List<Livros> Livros { get; set; }

    }
}
