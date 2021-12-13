using CustomersManager.Models;
using ItemsManager.Models;
using OrderDetailsManager.Models;
using OrdersManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManager.Services
{
	public interface IRestaurantRepository
	{
		Task AddAsync(Customer customer);
		Task AddAsync(Item item);
		Task AddAsync(Order order);
		Task AddAsync(OrderDetails orderDetails);
		Task<IList<Customer>> AllCustomersAsync();
		Task<IList<Item>> AllItemsAsync();
		Task<IList<OrderDetails>> AllOrderDetailsAsync();
		Task<IList<Order>> AllOrdersAsync();
		Task DeleteAsync(Customer customer);
		Task DeleteAsync(Item item);
		Task DeleteAsync(Order order);
		Task DeleteAsync(OrderDetails orderDetails);
		Task EditAsync(Customer customer);
		Task EditAsync(Item item);
		Task EditAsync(Order order);
		Task EditAsync(OrderDetails orderDetails);
		Task<Customer> GetCustomerAsync(Guid customerId);
		Task<Item> GetItemAsync(Guid itemId);
		Task<Order> GetOrderAsync(Guid orderId);
		Task<OrderDetails> GetOrderDetailsAsync(Guid orderDetailsId);
		Task SaveChangesAsync();
	}
}