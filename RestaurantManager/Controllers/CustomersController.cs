using CustomersManager.Data;
using CustomersManager.Models;
using Microsoft.AspNetCore.Mvc;
using RestaurantManager.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersManager.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly IRestaurantRepository repository;

		public CustomersController(IRestaurantRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IList<Customer>> Index()
		{
			return await repository.AllCustomersAsync();
		}

		[HttpPost("Add")]
		public async Task Add(CustomerAddOrUpdate model)
		{
			await repository.AddAsync(new Customer
			{
				Email = model.Email,
				Name = model.Name,
				PhoneNumber = model.PhoneNumber,
			});
			await repository.SaveChangesAsync();
		}

		[HttpDelete("Delete")]
		public async Task Delete(CustomerDelete model)
		{
			var customerToDelete = await repository.GetCustomerAsync(model.CustomerId);
			await repository.DeleteAsync(customerToDelete);
			await repository.SaveChangesAsync();
		}

		[HttpPatch("Edit")]
		public async Task Edit(CustomerAddOrUpdate model)
		{
			var customerToUpdate = await repository.GetCustomerAsync(model.CustomerId);
			customerToUpdate.PhoneNumber = model.PhoneNumber;
			customerToUpdate.Name = model.Name;
			customerToUpdate.Email = model.Email;
			await repository.EditAsync(customerToUpdate);
			await repository.SaveChangesAsync();
		}

	}
}
