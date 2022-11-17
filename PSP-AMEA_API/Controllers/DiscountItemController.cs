using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiscountItemController : ControllerBase
    {
        /// <summary>
        /// Assign product a discount.
        /// </summary>
        /// <response code="201">Discount successfully assigned to item.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "AssignDiscount")]
        public ActionResult<DiscountItem> AssignDiscount(DiscountItem discountItem)
        {
            discountItem.DisountId = Guid.NewGuid();
            discountItem.ItemId = Guid.NewGuid();

            _discountItems.Add(discountItem);

            return Ok(discountItem);
        }

        /// <summary>
        /// See products and their discounts.
        /// </summary>
        /// <response code="200">Information returned</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetAllDiscountItems")]
        public IEnumerable<DiscountItem> GetAllDiscountItems()
        {
            return _discountItems;
        }

        private static List<DiscountItem> _discountItems = new()
        {
            new DiscountItem
            {
                DisountId = Guid.NewGuid(),
                ItemId = Guid.NewGuid()
            }
        };
    }
}
