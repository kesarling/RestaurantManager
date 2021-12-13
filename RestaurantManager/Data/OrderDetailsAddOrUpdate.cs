using CustomersManager.Models;
using ItemsManager.Models;
using OrdersManager.Models;
using System;

namespace OrderDetailsManager.Data
{
	public class OrderDetailsAddOrUpdate
	{
		public Guid OrderDetailsId { get; set; }

		public Guid OrderId { get; set; }

		public Guid ItemId { get; set; }

		public Guid CustomerId { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public decimal Tax { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
