using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
	public class Order
	{
		[BindNever]
		public int id { get; set; }

		[Display(Name = "Введите имя")]
		[StringLength(50, MinimumLength = 1)]
		[Required(ErrorMessage = "Имя не может быть пустым")]
		public string name { get; set; }

		[Display(Name = "Введите фамилию")]
		[StringLength(50, MinimumLength = 1)]
		[Required(ErrorMessage = "Фамилия не может быть пустой!")]
		public string surname { get; set; }

		[Display(Name = "Введите адрес")]
		[StringLength(100, MinimumLength = 1)]
		[Required(ErrorMessage = "Адрес не может быть пустым!")]
		public string adress { get; set; }

		[Display(Name = "Введите номер телефона")]
		[DataType(DataType.PhoneNumber)]
		[StringLength(12, MinimumLength = 10)]
		[Required(ErrorMessage = "Номер телефона не может быть пустым!")]
		public string phone { get; set; }

		[Display(Name = "Введите адрес электронной почты")]
		[DataType(DataType.EmailAddress)]
		[StringLength(50, MinimumLength = 10)]
		[Required(ErrorMessage = "Адрес электронной почты не может быть пустым!")]
		public string email { get; set; }

		[BindNever]
		public DateTime orderTime { get; set; }

		[ValidateNever]
		public List<OrderDetail> orderDetails { get; set; }
	}
}
