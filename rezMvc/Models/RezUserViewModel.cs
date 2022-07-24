using rezMvc.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rezMvc.Models
{
    public class RezUserViewModel
    {
        public int Id { get; set; } = 0;
       
        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Parola")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Parola Tekrar")]
        [PasswordCheck]
        public string PasswordCheck { get; set; }
        public string PasswordMasked { get { return "***"; } }
    }
}
