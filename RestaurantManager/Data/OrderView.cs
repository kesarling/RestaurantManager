using System;

namespace OrdersManager.Data
{
	public class OrderView
	{
		public int OrderNumber { get; set; }

		public decimal Total { get; set; }

		public decimal Tax { get; set; }

		public Status Status { get; set; }
	}
}
