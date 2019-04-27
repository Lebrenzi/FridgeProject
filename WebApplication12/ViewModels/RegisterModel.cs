using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication12.ViewModels
{
    public class RegisterModel
    {   
        [Required(ErrorMessage ="Login required")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pass")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Pass incorrect")]
        public string ConfirmPassword { get; set; }
    }
}
