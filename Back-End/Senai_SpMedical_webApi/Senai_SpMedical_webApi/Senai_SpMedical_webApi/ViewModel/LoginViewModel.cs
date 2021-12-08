using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SpMedical_webApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatória!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatória!")]
        public string Senha { get; set; }
    }
}
