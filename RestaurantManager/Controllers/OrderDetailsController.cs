using Microsoft.AspNetCore.Mvc;
using OrderDetailsManager.Data;
using OrderDetailsManager.Models;
using RestaurantManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderDetailsManager.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly IRestaurantRepository repository;

		public OrderDetailsController(IRestaurantRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IList<OrderDetails>> Index()
		{
			return await repository.AllOrderDetailsAsync();
		}

		[HttpPost("Add")]
		public async Task Add(OrderDetailsAddOrUpdate model)
		{
			await repository.AddAsync(new OrderDetails
			{
				Price = model.Price,
				DateCreated = model.DateCreated,
				Tax = model.Tax,
				Description = model.Description,
				Customer = await repository.GetCustomerAsync(model.CustomerId),
				Order = await repository.GetOrderAsync(model.OrderId),
				Item = await repository.GetItemAsync(model.ItemId),
				
			});
			await repository.SaveChangesAsync();
		}

		[HttpDelete("Delete")]
		public async Task Delete(OrderDetailsDelete model)
		{
			var orderToDelete = await repository.GetOrderAsync(model.OrderDetailsId);
			await repository.DeleteAsync(orderToDelete);
			await repository.SaveChangesAsync();
		}

		[HttpPatch("Edit")]
		public async Task Edit(OrderDetailsAddOrUpdate model)
		{
			var orderDetailsToUpdate = await repository.GetOrderDetailsAsync(model.OrderDetailsId);
			orderDetailsToUpdate.Price = model.Price;
			orderDetailsToUpdate.DateCreated = model.DateCreated;
			orderDetailsToUpdate.Tax = model.Tax;
			orderDetailsToUpdate.Description = model.Description;
			orderDetailsToUpdate.Customer = await repository.GetCustomerAsync(model.CustomerId);
			orderDetailsToUpdate.Order = await repository.GetOrderAsync(model.OrderId);
			orderDetailsToUpdate.Item = await repository.GetItemAsync(model.ItemId);

			await repository.EditAsync(orderDetailsToUpdate);
			await repository.SaveChangesAsync();
		}

	}
}
