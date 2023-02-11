using Shop.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shop.ViewModels
{
    public class ProfileViewModel
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? newEmail { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string? newPassword { get; set; }
    }
}
