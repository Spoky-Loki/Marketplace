using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Не указан Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
		public string ConfirmPassword { get; set; }
	}
}
