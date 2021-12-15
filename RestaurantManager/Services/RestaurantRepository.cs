using CustomersManager.Models;
using ItemsManager.Models;
using Microsoft.EntityFrameworkCore;
using OrderDetailsManager.Models;
using OrdersManager;
using OrdersManager.Models;
using RestaurantManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManager.Services
{
	public class RestaurantRepository : IRestaurantRepository
	{
		private readonly RestaurantContext context;

		public RestaurantRepository(RestaurantContext context)
		{
			this.context = context;
		}

		//Orders
		public async Task<IList<Order>> AllOrdersAsync() => await Task.Run(async () =>
		{
			var orders = await context.Orders.ToListAsync();
			return orders;
		});

		public async Task<Order> GetOrderAsync(Guid orderId) => await Task.Run(async () =>
		{
			return await context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
		});

		public async Task AddAsync(Order order) => await Task.Run(() =>
		{
			context.Orders.Add(order);
		});

		public async Task CancelAsync(Order order) => await Task.Run(() =>
		{
			order.Status = Status.cancelled;
			context.Orders.Update(order);
		});

		public async Task EditAsync(Order order) => await Task.Run(() =>
		{
			context.Orders.Update(order);
		});

		//Items
		public async Task<IList<Item>> AllItemsAsync() => await Task.Run(async () =>
		{
			var items = await context.Items.ToListAsync();
			return items;
		});

		public async Task<Item> GetItemAsync(Guid itemId) => await Task.Run(async () =>
		{
			return await context.Items.FirstOrDefaultAsync(o => o.ItemId == itemId);
		});

		public async Task AddAsync(Item item) => await Task.Run(() =>
		{
			context.Items.Add(item);
		});

		public async Task DeleteAsync(Item item) => await Task.Run(() =>
		{
			context.Items.Remove(item);
		});

		public async Task EditAsync(Item item) => await Task.Run(() =>
		{
			context.Items.Update(item);
		});

		//Customers
		public async Task<IList<Customer>> AllCustomersAsync() => await Task.Run(async () =>
		{
			var items = await context.Customers.ToListAsync();
			return items;
		});

		public async Task<Customer> GetCustomerAsync(Guid customerId) => await Task.Run(async () =>
		{
			return await context.Customers.FirstOrDefaultAsync(o => o.CustomerId == customerId);
		});

		public async Task AddAsync(Customer customer) => await Task.Run(() =>
		{
			context.Customers.Add(customer);
		});

		public async Task DeleteAsync(Customer customer) => await Task.Run(() =>
		{
			context.Customers.Remove(customer);
		});

		public async Task EditAsync(Customer customer) => await Task.Run(() =>
		{
			context.Customers.Update(customer);
		});


		//OrderDetails
		public async Task<IList<OrderDetails>> AllOrderDetailsAsync() => await Task.Run(async () =>
		{
			var orderDetails = await context.OrderDetails.ToListAsync();
			return orderDetails;
		});

		public async Task<OrderDetails> GetOrderDetailsAsync(Guid orderDetailsId) => await Task.Run(async () =>
		{
			return await context.OrderDetails.FirstOrDefaultAsync(o => o.OrderDetailsId == orderDetailsId);
		});

		public async Task AddAsync(OrderDetails orderDetails) => await Task.Run(() =>
		{
			context.OrderDetails.Add(orderDetails);
		});

		public async Task DeleteAsync(OrderDetails orderDetails) => await Task.Run(() =>
		{
			context.OrderDetails.Remove(orderDetails);
		});

		public async Task EditAsync(OrderDetails orderDetails) => await Task.Run(() =>
		{
			context.OrderDetails.Update(orderDetails);
		});



		public async Task SaveChangesAsync() =>
			await Task.Run(async () => await context.SaveChangesAsync());
	}
}
