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
		public void EditItem(Guid id, [FromBody] Item item)
		{
			var items = s_items.Where(i => i.Id == id).ToList();

			items.ForEach(i => i = item);
		}

		[HttpDelete("{id}")]
		public void DeleteItem(Guid id)
		{
			s_items = s_items.Where(i => i.Id != id).ToList();
		}

		[HttpGet("{id}/review")]
		public IEnumerable<Review> GetItemReviewIds(Guid id)
		{
			throw new NotImplementedException();
		}

		[HttpPost("{id}/review")]
		public void CreateItemReview(Guid id, [FromBody] Review review)
		{
			throw new NotImplementedException();
		}

		[HttpGet("{itemId}/review/{reviewId}")]
		public Review GetItemReviewById(Guid itemId, Guid reviewId)
		{
			throw new NotImplementedException();
		}

		[HttpPut("{itemId}/review/{reviewId}")]
		public Review EditItemReview(Guid itemId, Guid reviewId, [FromBody] Review review)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{itemId}/review/{reviewId}")]
		public void DeleteItemReview(Guid itemId, Guid reviewId)
		{
			throw new NotImplementedException();
		}
	}
}
