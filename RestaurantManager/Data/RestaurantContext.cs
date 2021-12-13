using CustomersManager.Models;
using ItemsManager.Models;
using Microsoft.EntityFrameworkCore;
using OrderDetailsManager.Models;
using OrdersManager.Models;

namespace RestaurantManager.Data
{
	public class RestaurantContext : DbContext
	{
		public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
		{ }

		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Item> Items { get; set; }
	}
}
