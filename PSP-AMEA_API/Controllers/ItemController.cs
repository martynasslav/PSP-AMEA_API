using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private readonly IItemRepository _itemRepository;
		private readonly IReviewRepository _reviewRepository;

		public ItemController(IItemRepository itemRepository, IReviewRepository reviewRepository)
		{
			this._itemRepository = itemRepository;
			this._reviewRepository = reviewRepository;
		}

		[HttpGet("{id}")]
		public ActionResult<Item> GetItem(Guid id)
		{
			var item = _itemRepository.GetItem(id);

			return item == null ? NoContent() : Ok(item);
		}

		[HttpPut("{id}")]
		public ActionResult<Item> EditItem(Guid id, [FromBody] ItemEditDto itemDto)
		{
			var item = new Item() {
				Id = id,
				Title = itemDto.Title,
				Category = itemDto.Category,
				Price = itemDto.Price,
				Description = itemDto.Description,
				Brand = itemDto.Brand,
				Photo = itemDto.Photo,
				TenantId = itemDto.TenantId
			};

			_itemRepository.UpdateItem(item);

			return Ok(item);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteItem(Guid id)
		{
			_itemRepository.DeleteItem(id);

			return Ok();
		}

		[HttpGet("{id}/Review")]
		public ActionResult<IEnumerable<Review>> GetItemReviewIds(Guid id)
		{
			return Ok(_reviewRepository.GetItemReviews(id));
		}

		[HttpPost("{id}/Review")]
		public ActionResult<Review> CreateItemReview(Guid id, [FromBody] ReviewCreationDto reviewDto)
		{
			var review = new Review() {
				Description = reviewDto.Description,
				Rating = reviewDto.Rating,
				Photo = reviewDto.Photo,
				ItemId = id,
				UserId = reviewDto.UserId
			};

			_reviewRepository.CreateReview(review);

			return Ok(review);
		}

		[HttpGet("{itemId}/Review/{userId}")]
		public ActionResult<Review> GetItemReview(Guid itemId, Guid userId)
		{
			var review = _reviewRepository.GetReview(itemId, userId);

			return review == null ? NoContent() : Ok(review);
		}

		[HttpPut("{itemId}/Review/{userId}")]
		public ActionResult<Review> EditItemReview(Guid itemId, Guid userId, [FromBody] ReviewEditDto reviewDto)
		{
			var review = new Review() {
				Description = reviewDto.Description,
				Rating = reviewDto.Rating,
				Photo = reviewDto.Photo,
				ItemId = itemId,
				UserId = userId
			};

			_reviewRepository.UpdateReview(review);

			return Ok(review);
		}

		[HttpDelete("{itemId}/Review/{userId}")]
		public ActionResult DeleteItemReview(Guid itemId, Guid userId)
		{
			_reviewRepository.DeleteReview(itemId, userId);

			return Ok();
		}
	}
}
