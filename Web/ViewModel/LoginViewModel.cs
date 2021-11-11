﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login é um campo obrigátorio")]
        [EmailAddress(ErrorMessage = "Email não está em um formato correto")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password é um campo obrigátorio")]
        public string Password { get; set; }
    }
}
