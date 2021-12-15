﻿using System;

namespace OrdersManager.Data
{
	public class OrderAddOrUpdate
	{
		public Guid OrderId { get; set; }

		public decimal Total { get; set; }

		public decimal TotalTax { get; set; }

		public Status Status { get; set; }
	}
}
