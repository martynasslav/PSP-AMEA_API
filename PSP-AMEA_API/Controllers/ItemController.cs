using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private static List<Item> s_items = new List<Item>();

		[HttpGet]
		public IEnumerable<Guid> GetItemIds()
		{
			return s_items.Select(i => i.Id);
		}

		[HttpPost]
		public void CreateItem([FromBody] Item item)
		{
			s_items.Add(item);
		}

		[HttpGet("{id}")]
		public Item GetItemById(Guid id)
		{
			return s_items.First(i => i.Id == id);
		}

		[HttpPut("{id}")]
		public Item EditItem(Guid id, [FromBody] Item item)
		{
			var idx = s_items.FindIndex(i => i.Id == id);
			s_items[idx] = item;

			return s_items[idx];
		}

		[HttpDelete("{id}")]
		public void DeleteItem(Guid id)
		{
			s_items = s_items.Where(i => i.Id != id).ToList();
		}

		[HttpGet("{id}/Review")]
		public IEnumerable<Review> GetItemReviewIds(Guid id)
		{
			throw new NotImplementedException();
		}

		[HttpGet("{itemId}/Review/{reviewId}")]
		public Review GetItemReviewById(Guid itemId, Guid reviewId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{itemId}/Review/{reviewId}")]
		public void DeleteItemReview(Guid itemId, Guid reviewId)
		{
			throw new NotImplementedException();
		}
	}
}
