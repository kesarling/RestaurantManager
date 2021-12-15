using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("/Order/{orderId}")]
		public async Task<Order> GetOrder(Guid orderId)
		{
			return await repository.GetOrderAsync(orderId);
		}

		[HttpPost("Add")]
		public async Task Add(decimal total, decimal totalTax)
		{
			await repository.AddAsync(new Order
			{
				Total = total,
				TotalTax = totalTax,
				Status = Status.pending,
			});
			await repository.SaveChangesAsync();
		}

		[HttpDelete("Cancel/{orderId}")]
		public async Task Cancel(Guid orderId)
		{
			var orderToCancel = await repository.GetOrderAsync(orderId);
			await repository.CancelAsync(orderToCancel);
			await repository.SaveChangesAsync();
		}

		[HttpPatch("Edit/orderId={orderId}")]
		public async Task Edit(Guid orderId, decimal total, decimal totalTax)
		{
			var orderToUpdate = await repository.GetOrderAsync(orderId);
			orderToUpdate.Total = total;
			orderToUpdate.TotalTax = totalTax;
			await repository.EditAsync(orderToUpdate);
			await repository.SaveChangesAsync();
		}
	}
}
