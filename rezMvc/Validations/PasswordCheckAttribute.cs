using rezMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rezMvc.Validations
{
    public class PasswordCheckAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string passwordCh = value.ToString();
            string password = ((RezUserViewModel)validationContext.ObjectInstance).Password;
            if(password!=passwordCh)
            {
                return new ValidationResult("parolar aynı değil");
            }
            return ValidationResult.Success;
        }
    }
}
