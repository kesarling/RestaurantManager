using Microsoft.AspNetCore.Mvc;
using OrdersManager.Data;
using OrdersManager.Models;
using RestaurantManager.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManager.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IRestaurantRepository repository;

		public OrdersController(IRestaurantRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IList<Order>> Index()
		{
			return await repository.AllOrdersAsync();
		}

		[HttpPost("Add")]
		public async Task Add(OrderAddOrUpdate model)
		{
			await repository.AddAsync(new Order
			{
				Total = model.Total,
				TotalTax = model.TotalTax,
			});
			await repository.SaveChangesAsync();
		}

		[HttpDelete("Delete")]
		public async Task Delete(OrderDelete model)
		{
			var orderToDelete = await repository.GetOrderAsync(model.OrderId);
			await repository.DeleteAsync(orderToDelete);
			await repository.SaveChangesAsync();
		}

		[HttpPatch("Edit")]
		public async Task Edit(OrderAddOrUpdate model)
		{
			var orderToUpdate = await repository.GetOrderAsync(model.OrderId);
			orderToUpdate.Total = model.Total;
			orderToUpdate.TotalTax = model.TotalTax;
			await repository.EditAsync(orderToUpdate);
			await repository.SaveChangesAsync();
		}
	}
}
