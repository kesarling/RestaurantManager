﻿using System;

namespace CustomersManager.Data
{
	public class CustomerAddOrUpdate
	{
		public Guid CustomerId { get; set; } = Guid.NewGuid();

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }

	}
}