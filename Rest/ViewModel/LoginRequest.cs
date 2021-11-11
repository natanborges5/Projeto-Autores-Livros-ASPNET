using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.ViewModel
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Login é um campo obrigátorio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password é um campo obrigátorio")]
        public string Password { get; set; }

    }
}
