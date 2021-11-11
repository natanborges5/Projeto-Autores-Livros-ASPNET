using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CriarLivroViewModel
    {
        [Required(ErrorMessage = "Titulo é um campo obrigátorio")]
        public string titulo { get; set; }
        [Required(ErrorMessage = "Isbn é um campo obrigátorio")]
        public string isbn { get; set; }
        [Required(ErrorMessage = "Ano é um campo obrigátorio")]
        public DateTime ano { get; set; }
        public int autorId { get; set; }

        public List<Autores> Autores { get; set; }
    }
}
