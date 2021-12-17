using Microsoft.AspNetCore.Mvc;
using RestaurantManager.Models;
using RestaurantManager.Data.DTOs;
using RestaurantManager.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManager.Controllers
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

		[HttpGet("orderId={orderId}")]
		public async Task<Order> GetOrder(Guid orderId)
		{
			return await repository.GetOrderAsync(orderId);
		}

		[HttpPost("Add")]
		public async Task Add(AddOrEditOrder model)
		{
			await repository.AddAsync(new Order
			{
				Total = model.Total,
				TotalTax = model.TotalTax,
				Status = Status.pending,
			});
			await repository.SaveChangesAsync();
		}

		[HttpDelete("Cancel/orderId={orderId}")]
		public async Task Cancel(Guid orderId)
		{
			var orderToCancel = await repository.GetOrderAsync(orderId);
			await repository.CancelAsync(orderToCancel);
			await repository.SaveChangesAsync();
		}

		[HttpPatch("Edit/orderId={orderId}")]
		public async Task Edit(Guid orderId, AddOrEditOrder model)
		{
			var orderToUpdate = await repository.GetOrderAsync(orderId);
			orderToUpdate.Total = model.Total;
			orderToUpdate.TotalTax = model.TotalTax;
			orderToUpdate.Status = model.Status;
			await repository.EditAsync(orderToUpdate);
			await repository.SaveChangesAsync();
		}
	}
}
