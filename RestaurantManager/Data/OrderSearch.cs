using System;

namespace OrdersManager.Data
{
	public class OrderSearch
	{
		public Guid OrderId { get; set; } = Guid.NewGuid();

		public int OrderNumber { get; set; }
	}
}
