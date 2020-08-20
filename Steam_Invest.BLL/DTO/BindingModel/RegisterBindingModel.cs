using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Steam_Invest.BLL.DTO.BindingModel
{
    public class RegisterBindingModel
    {
        [Required(ErrorMessage = "Введите электронную почту")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должен содержать {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Поля не совпадают")]
        public string ConfirmPassword { get; set; }

        public string Login { get; set; }
    }
}
