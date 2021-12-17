using RestaurantManager;

namespace RestaurantManager.Data.DTOs
{
	public class AddOrEditOrder
	{
		public decimal Total { get; set; }
		public decimal TotalTax { get; set; }
		public Status Status { get; set; }
	}
}
