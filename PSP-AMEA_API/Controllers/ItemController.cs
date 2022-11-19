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

		/// <summary>
		/// Gets information about an item from unique identifier.
		/// </summary>
		/// <param name="id">Unique item identifier</param>
		/// <returns></returns>
		/// <response code="200">Information about item was returned.</response>
		/// <response code="204">Item with specified identifier was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[HttpGet("{id}")]
		public ActionResult<Item> GetItem(Guid id)
		{
			var item = _itemRepository.GetItem(id);

			return item == null ? NoContent() : Ok(item);
		}

		/// <summary>
		/// Replaces existing information about an item.
		/// </summary>
		/// <param name="id">Unique item identifier</param>
		/// <param name="itemDto">New information about the item</param>
		/// <returns></returns>
		/// <response code="200">Item information was replaced and new information sent back.</response>
		/// <response code="404">Information with specified identifier does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
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

		/// <summary>
		/// Deletes existing information about item.
		/// </summary>
		/// <param name="id">Unique item identifier</param>
		/// <returns></returns>
		/// <response code="200">Information was deleted successfully.</response>
		/// <response code="404">Information with specified identifier does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{id}")]
		public ActionResult DeleteItem(Guid id)
		{
			_itemRepository.DeleteItem(id);

			return Ok();
		}

		/// <summary>
		/// Gets a list of review identifiers.
		/// </summary>
		/// <param name="id">Unique item identifier</param>
		/// <returns></returns>
		/// <response code="200">List with identifiers was returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}/Review")]
		public ActionResult<IEnumerable<Review>> GetItemReviewIds(Guid id)
		{
			return Ok(_reviewRepository.GetItemReviews(id));
		}

		/// <summary>
		/// Creates a new review for the specified item.
		/// </summary>
		/// <param name="id">Unique item identifier</param>
		/// <param name="reviewDto">Review information</param>
		/// <returns></returns>
		/// <response code="201">Review was created successfully and returned back.</response>
		/// <response code="409">Review from specified user for the specified item already exists.</response>
		[ProducesResponseType(201)]
		[ProducesResponseType(409)]
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

		/// <summary>
		/// Gets specified item review.
		/// </summary>
		/// <param name="itemId">Unique item identifier</param>
		/// <param name="userId">Unique user identifier</param>
		/// <returns></returns>
		/// <response code="200">Review was found and returned back.</response>
		/// <response code="204">Review for that item does not exist from the specified user identifier.</response>
		/// <response code="404">Item with specified identifier does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		[HttpGet("{itemId}/Review/{userId}")]
		public ActionResult<Review> GetItemReview(Guid itemId, Guid userId)
		{
			var review = _reviewRepository.GetReview(itemId, userId);

			return review == null ? NoContent() : Ok(review);
		}

		/// <summary>
		/// Replaces specified item review.
		/// </summary>
		/// <param name="itemId">Unique item identifier</param>
		/// <param name="userId">Unique user identifier</param>
		/// <param name="reviewDto">New review information</param>
		/// /// <returns></returns>
		/// <response code="200">Review information replaced and returned back.</response>
		/// <response code="404">Review with specified item and user identifiers does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
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

		/// <summary>
		/// Deletes specified item review.
		/// </summary>
		/// <param name="itemId">Unique item identifier</param>
		/// <param name="userId">Unique user identifier</param>
		/// <returns></returns>
		/// <response code="200">Review was successfully deleted.</response>
		/// <response code="404">Review with specified item and user identifiers does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{itemId}/Review/{userId}")]
		public ActionResult DeleteItemReview(Guid itemId, Guid userId)
		{
			_reviewRepository.DeleteReview(itemId, userId);

			return Ok();
		}
	}
}
