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

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        /// <summary>
        /// Gets information about all available discounts.
        /// </summary>
        /// <response code="200">Discounts information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetDiscounts")]
        public IEnumerable<Discount> GetAllDiscounts()
        {
            return _discountRepository.GetAllDiscounts();
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

            if(discount == null)
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
                Measure = dto.Measure,
                Amount = dto.Amount,
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
    }
}