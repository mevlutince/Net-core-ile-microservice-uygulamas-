using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.web.Models
{
    public class SigninInput
    {
        [Required]
        [Display(Name ="E-posta adresiniz")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şİfreniz")]
        public string Password { get; set; }


        [Display(Name = "Beni hatırla")]
        public bool IsRemember { get; set; }
    }
}
