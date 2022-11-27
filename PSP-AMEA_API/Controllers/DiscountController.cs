using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IDiscountItemRepository _discountItemRepository;

        public DiscountController(IDiscountRepository discountRepository, IDiscountItemRepository discountItemRepository)
        {
            _discountRepository = discountRepository;
            _discountItemRepository = discountItemRepository;
        }

        /// <summary>
        /// Gets information about all available discounts.
        /// </summary>
        /// <param name="offset"> The first item to return</param>
        /// <param name="limit"> The number of entries to return </param>
        /// <param name="tenantId" example="3fa85f64-5717-4562-b3fc-2c963f66afa6"> </param>
        /// <response code="200">Discounts information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetDiscounts")]
        public IEnumerable<Discount> GetAllDiscounts(int offset = 0, int limit = 20, Guid? tenantId = null)
        {
            List<Discount> discounts = (List<Discount>)_discountRepository.GetAllDiscounts();

            return limit > discounts.Count ? discounts.GetRange(offset, discounts.Count) : discounts.GetRange(offset, limit);
        }

        /// <summary>
        /// Gets a list of discount ids.
        /// </summary>
        /// <param name="offset"> The first item to return</param>
        /// <param name="limit"> The number of entries to return </param>
        /// <param name="tenantId" example="3fa85f64-5717-4562-b3fc-2c963f66afa6"> </param>
        /// <response code="200">Discount ids returned.</response>
        [ProducesResponseType(200)]
        [HttpGet("v1/Discount/Ids", Name = "GetAllDiscountIds")]
        public ActionResult<IEnumerable<Guid>> GetAllDiscountIds(int offset = 0, int limit = 20, Guid? tenantId = null)
        {
            List<Guid> discounts = (List<Guid>)_discountRepository.GetDiscountIds();

            return Ok(limit > discounts.Count ? discounts.GetRange(offset, discounts.Count) : discounts.GetRange(offset, limit));
        }

        /// <summary>
        /// Gets information about a discount from specified discount ID.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount information returned.</response>
        /// <response code="204">Discount information not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("{id}", Name = "GetDiscount")]
        public ActionResult<Discount> GetDiscount(Guid id)
        {
            var discount = _discountRepository.GetDiscountById(id);

            if (discount == null)
            {
                return NoContent();
            }

            return discount;
        }

        /// <summary>
        /// Creates a new discount.
        /// </summary>
        /// <response code="201">Discount created.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateDiscount")]
        public ActionResult<Discount> CreateDiscount(CreateDiscountDto dto)
        {
            var discount = _discountRepository.CreateDiscount(dto);

            return CreatedAtAction("GetDiscount", new { id = discount.Id }, discount);
        }

        /// <summary>
        /// Updates discount's information.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Updated discount information updated.</response>
        /// <response code="404">There is no such discount.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}", Name = "UpdateDiscount")]
        public ActionResult<Discount> UpdateDiscount(Guid id, CreateDiscountDto dto)
        {
            var discount = _discountRepository.GetDiscountById(id); ;

            if (discount == null)
            {
                return NotFound();
            }

            Discount updatedDiscount = new()
            {
                Id = id,
                IsLoyalty = dto.IsLoyalty,
                ValidFrom = dto.ValidFrom,
                ValidTo = dto.ValidTo,
                Name = dto.Name,
                DiscountPercenatge = dto.DiscountPercenatge,
                CashbackPercenatge = dto.CashbackPercenatge,
                CashbackValidFor = dto.CashbackValidFor,
                TenantId = dto.TenantId
            };

            _discountRepository.UpdateDiscount(updatedDiscount);

            return Ok();
        }

        /// <summary>
        /// Deletes a discount.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount successfully deleted.</response>
        /// <response code="404">There is no such discount.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public ActionResult<Discount> DeleteDiscount(Guid id)
        {
            var discount = _discountRepository.GetDiscountById(id);

            if (discount == null)
            {
                return NotFound();
            }

            _discountRepository.DeleteDiscount(discount);

            return Ok();
        }

        /// <summary>
        /// Gets information about a discount item from specified discount ID.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount item information returned.</response>
        /// <response code="404">Discount item not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("/DiscountItem{id}", Name = "GetDiscountItemByDiscountId")]
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
        [HttpPost("/DiscountItem{id}", Name = "AssignDiscount")]
        public ActionResult<DiscountItem> AssignDiscount(DiscountItemDto dto)
        {
            var discountItem = _discountItemRepository.CreateDiscountItem(dto);

            return CreatedAtAction("GetDiscountItemByDiscountId", new { id = discountItem.DisountId }, discountItem);
        }

        /// <summary>
        /// Updates discount item's information.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount item's information updated.</response>
        /// <response code="404">Discount item not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("/DiscountItem{id}", Name = "UpdateDiscountItem")]
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
        [HttpDelete("/DiscountItem{id}")]
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