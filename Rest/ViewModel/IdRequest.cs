using System.ComponentModel.DataAnnotations;

namespace Rest.ViewModel
{
    public class IdRequest
    {
        [Required(ErrorMessage = "Id é um campo obrigátorio")]
        public string Id { get; set; }


    }
}
