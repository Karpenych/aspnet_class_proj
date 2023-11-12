using System.ComponentModel.DataAnnotations;

namespace lr4.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [Phone(ErrorMessage = "Некорректный телефон")]
        public string? Phone { get; set; }
    }
}
