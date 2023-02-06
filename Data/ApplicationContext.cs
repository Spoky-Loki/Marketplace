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

		public DbSet<User> users { get; set; }

        public DbSet<Role> roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
