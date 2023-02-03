using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

		public DbSet<Product> products { get; set; }

		public DbSet<Category> categories { get; set; }

		public DbSet<CartItem> cartItems { get; set; }

		public DbSet<Order> orders { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
