using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shop.Models
{
	public class User
	{
		public int Id { get; set; }

		[AllowNull]
		public string? Name { get; set; }

        [AllowNull]
        public string? Surname { get; set; }

        [AllowNull]
        public string? Address { get; set; }

        [AllowNull]
        public string? Phone { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}
}
