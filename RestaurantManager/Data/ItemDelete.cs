﻿using System;

namespace ItemsManager.Data
{
	public class ItemDelete
	{
		public Guid ItemId { get; set; } = Guid.NewGuid();

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

	}
}
