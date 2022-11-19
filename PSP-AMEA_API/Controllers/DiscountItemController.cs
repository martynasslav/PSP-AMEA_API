using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiscountItemController : ControllerBase
    {
        private readonly IDiscountItemRepository _discountItemRepository;

        public DiscountItemController(IDiscountItemRepository discountItemRepository)
        {
            _discountItemRepository = discountItemRepository;
        }

        /// <summary>
        /// Gets information about all available discount items.
        /// </summary>
        /// <response code="200">Discount items information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetDiscountItems")]
        public IEnumerable<DiscountItem> GetDiscountItems()
        {
            return _discountItemRepository.GetAllDiscountItems();
        }

        /// <summary>
        /// Gets information about a discount item from specified discount ID.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount item information returned.</response>
        /// <response code="404">Discount item not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}", Name = "GetDiscountItemByDiscountId")]
        public ActionResult<DiscountItem> GetDiscountItemByDiscountId(Guid id)
        {
            var discountItem = _discountItemRepository.GetDiscountItemByDiscountId(id);

            if (discountItem == null)
            {
                return NoContent();
            }

            return discountItem;
        }

        /// <summary>
        /// Assign product to a discount.
        /// </summary>
        /// <response code="201">Discount successfully assigned to item.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "AssignDiscount")]
        public ActionResult<DiscountItem> AssignDiscount(DiscountItemDto dto)
        {
            var discountItem = _discountItemRepository.CreateDiscountItem(dto);

            return CreatedAtAction("GetDiscountItemByDiscountId", new { id = discountItem.DisountId}, discountItem);
        }

        /// <summary>
        /// Updates discount item's information.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount item's information updated.</response>
        /// <response code="404">Discount item not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}", Name = "UpdateDiscountItem")]
        public ActionResult<DiscountItem> UpdateDiscountItem(Guid id, UpdateDiscountItemDto dto)
        {
            var discountItem = _discountItemRepository.GetDiscountItemByDiscountId(id);

            if (discountItem == null)
            {
                return NotFound();
            }
            DiscountItem updatedDiscountItem = new()
            {
                DisountId = id,
                ItemId = dto.ItemId
            };

            _discountItemRepository.UpdateDiscountItem(updatedDiscountItem);

            return Ok();
        }

        /// <summary>
        /// Deletes a discount item.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount item successfully deleted.</response>
        /// <response code="404">Discount item not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public ActionResult<DiscountItem> DeleteDiscountItem(Guid id)
        {
            var discountItem = _discountItemRepository.GetDiscountItemByDiscountId(id);

            if (discountItem == null)
            {
                return NotFound();
            }

            _discountItemRepository.DeleteDiscountItem(discountItem);

            return Ok();
        }
    }
}
