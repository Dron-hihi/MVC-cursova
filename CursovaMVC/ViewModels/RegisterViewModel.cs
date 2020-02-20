using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.ViewModels
{

    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "You Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "You First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "You Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "You Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$",
        ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        [Display(Name = "You Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "You Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }

}
