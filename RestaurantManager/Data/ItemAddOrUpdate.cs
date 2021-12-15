﻿using System;

namespace ItemsManager.Data
{
	public class ItemAddOrUpdate
	{
		public Guid ItemId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

	}
}
