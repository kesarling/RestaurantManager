using CustomersManager.Models;
using ItemsManager.Models;
using OrdersManager.Models;
using System;

namespace OrderDetailsManager.Models
{
	public class OrderDetails
	{
		public Guid OrderDetailsId { get; set; } = Guid.NewGuid();

		public Order Order { get; set; }

		public Item Item { get; set; }

		public Customer Customer { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public decimal Tax { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
