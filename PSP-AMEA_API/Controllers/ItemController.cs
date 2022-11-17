using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private static List<Item> m_items = new List<Item>();

		[HttpGet]
		public IEnumerable<Guid> GetItemIds()
		{
			return m_items.Select(i => i.Id);
		}

		[HttpPost]
		public void CreateItem([FromBody] Item item)
		{
			m_items.Add(item);
		}

		[HttpGet("{id}")]
		public Item GetItemById(Guid id)
		{
			return m_items.Where(i => i.Id == id).First();
		}

		[HttpPut("{id}")]
		public void EditItem(Guid id, [FromBody] Item item)
		{
			var items = m_items.Where(i => i.Id == id).ToList();

			items.ForEach(i => i = item);
		}

		[HttpDelete("{id}")]
		public void DeleteItem(Guid id)
		{
			m_items = m_items.Where(i => i.Id != id).ToList();
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
