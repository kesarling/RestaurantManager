using ItemsManager.Data;
using ItemsManager.Models;
using Microsoft.AspNetCore.Mvc;
using RestaurantManager.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItemsManager.Controllers
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
		public async Task<IList<Item>> Index()
		{
			return await repository.AllItemsAsync();
		}

		[HttpPost("Add")]
		public async Task Add(ItemAddOrUpdate model)
		{
			await repository.AddAsync(new Item
			{
				Name = model.Name,
				Description = model.Description,
			});
			await repository.SaveChangesAsync();
		}

		[HttpDelete("Delete")]
		public async Task Delete(ItemDelete model)
		{
			var itemToDelete = await repository.GetItemAsync(model.ItemId);
			await repository.DeleteAsync(itemToDelete);
			await repository.SaveChangesAsync();
		}

		[HttpPatch("Edit")]
		public async Task Edit(ItemAddOrUpdate model)
		{
			var itemToUpdate = await repository.GetItemAsync(model.ItemId);
			itemToUpdate.Name = model.Name;
			itemToUpdate.Description = model.Description;
			await repository.EditAsync(itemToUpdate);
			await repository.SaveChangesAsync();
		}

	}
}
