using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManager.Data;
using RestaurantManager.Data.DTOs;
using RestaurantManager.Models;
using RestaurantManager.Services;

namespace RestaurantManager.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private readonly IRestaurantRepository repository;

		public ItemsController(IRestaurantRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IList<Item>> GetItems()
		{
			return await repository.AllItemsAsync();
		}

		[HttpGet("itemId={itemId}")]
		public async Task<Item> GetItems(Guid itemId)
		{
			return await repository.GetItemAsync(itemId);
		}

		[HttpPost("Add")]
		public async Task AddItem(AddOrEditItem model)
		{
			await repository.AddAsync(new Item
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
			});
			await repository.SaveChangesAsync();
		}

		[HttpPatch("Edit/itemId={itemId}")]
		public async Task EditItem(Guid itemId, AddOrEditItem model)
		{
			var itemToUpdate = await repository.GetItemAsync(itemId);
			itemToUpdate.Description = model.Description;
			itemToUpdate.Price = model.Price;
			itemToUpdate.Name = model.Name;
			await repository.EditAsync(itemToUpdate);
			await repository.SaveChangesAsync();
		}

		[HttpDelete("Delete/itemId={itemId}")]
		public async Task DeleteItem(Guid itemId)
		{
			var itemToDelete = await repository.GetItemAsync(itemId);
			await repository.DeleteAsync(itemToDelete);
			await repository.SaveChangesAsync();
		}
	}
}
