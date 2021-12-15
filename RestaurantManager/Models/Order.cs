using RestaurantManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersManager.Models
{
	public class Order
	{
		[Key]
		public Guid OrderId { get; set; } = Guid.NewGuid();

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderNumber { get; set; }

		public decimal Total { get; set; }

		public decimal TotalTax { get; set; }

		public Status Status { get; set; }
	}
}
