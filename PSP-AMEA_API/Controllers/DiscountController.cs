using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
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
        /// <summary>
        /// Gets information about all available discounts.
        /// </summary>
        /// <response code="200">Discounts information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetDiscounts")]
        public IEnumerable<Discount> GetAllDiscounts()
        {
            return _discounts;
        }

        /// <summary>
        /// Gets information about an discount from specified discount ID.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = "GetDiscount")]
        public Discount? GetDiscount(Guid id)
        {
            return _discounts.Find(d => d.Id == id);
        }

        /// <summary>
        /// Creates new discount.
        /// </summary>
        /// <response code="201">Discount created.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateDiscount")]
        public ActionResult<Discount> CreateDiscount(Discount discount)
        {
            discount.Id = Guid.NewGuid();
            discount.LoyaltyTierId = Guid.NewGuid();
            discount.TenantId = Guid.NewGuid();

            _discounts.Add(discount);

            return Ok(discount);
        }

        /// <summary>
        /// Updates discount's percentage value.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <param name="discountPercentage">New percentage value</param>
        /// <response code="200">Discount percentage updated.</response>
        [ProducesResponseType(200)]
        [HttpPatch("{id}/DiscountPercentage", Name = "UpdateDiscountPercentage")]
        public ActionResult<Discount> UpdateDiscountPercentage(Guid id, int discountPercentage)
        {
            var discount = GetDiscount(id);

            if(discount == null)
            {
                return NotFound();
            }

            discount.DiscountPercentage = discountPercentage;
            return Ok(discount);
        }

        /// <summary>
        /// Updates discount's validation dates.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <param name="validFrom">New discount duration start</param>
        /// <param name="validTo">New discount duration end</param>
        /// <response code="200">Discount duration updated.</response>
        [ProducesResponseType(200)]
        [HttpPatch("{id}", Name = "UpdateDiscountDuration")]
        public ActionResult<Discount> UpdateDiscountDuration(Guid id, DateTime validFrom, DateTime validTo)
        {
            var discount = GetDiscount(id);

            if (discount == null)
            {
                return NotFound();
            }

            discount.ValidFrom = validFrom;
            discount.ValidTo = validTo;
            return Ok(discount);
        }

        /// <summary>
        /// Deletes a discount.
        /// </summary>
        /// <param name="id">Unique discount ID</param>
        /// <response code="200">Discount successfully deleted.</response>
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public ActionResult<Discount> DeleteDiscount(Guid id)
        {
            var discount = GetDiscount(id);

            if (discount == null) 
            {
                return NotFound();
            }

            _discounts.Remove(discount); 
            return Ok();
        }

        private static List<Discount> _discounts = new()
        {
                new Discount()
                {
                    Id = Guid.NewGuid(),
                    IsLoyalty = false,
                    ValidFrom = DateTime.Today,
                    ValidTo = DateTime.Today.AddDays(7),
                    Name = "Discount1",
                    DiscountPercentage = 15,
                    CashbackPercentage = 0,
                    CashbackValidFor = 0,
                    TenantId = Guid.NewGuid()
                },
                new Discount()
                {
                    Id = Guid.NewGuid(),
                    IsLoyalty = true,
                    LoyaltyTierId = Guid.NewGuid(),
                    ValidFrom = DateTime.Today,
                    ValidTo = DateTime.Today.AddDays(14),
                    Name = "Discount2",
                    DiscountPercentage = 25,
                    CashbackPercentage = 0,
                    CashbackValidFor = 0,
                    TenantId = Guid.NewGuid()
                }
            };
        }
    }