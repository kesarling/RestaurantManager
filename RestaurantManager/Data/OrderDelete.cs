using System;

namespace OrdersManager.Data
{
	public class OrderDelete
	{
		public Guid OrderId { get; set; } = Guid.NewGuid();
	}
}
