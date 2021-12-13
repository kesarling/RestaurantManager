using System;

namespace OrdersManager.Data
{
	public class OrderAddOrUpdate
	{
		public Guid OrderId { get; set; } = Guid.NewGuid();

		public decimal Total { get; set; }

		public decimal TotalTax { get; set; }
	}
}
