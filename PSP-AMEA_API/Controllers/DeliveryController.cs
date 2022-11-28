using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class DeliveryController : ControllerBase
	{
		private readonly IDeliveryRepository _deliveryRepository;

		public DeliveryController(IDeliveryRepository deliveryRepository)
		{
			this._deliveryRepository = deliveryRepository;
		}

		/// <summary>
		/// Gets information about order delivery from unique identifier.
		/// </summary>
		/// <param name="id">Unique delivery information identifier</param>
		/// <returns></returns>
		/// <response code="200">Information about order delivery was returned.</response>
		/// <response code="204">Delivery information with specified identifier was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[HttpGet("{id}")]
		public ActionResult<Delivery> GetDelivery(Guid id)
		{
			var delivery = _deliveryRepository.GetDelivery(id);

			return delivery == null ? NoContent() : Ok(delivery);
		}

		/// <summary>
		/// Replaces existing order delivery information.
		/// </summary>
		/// <param name="id">Unique delivery information identifier</param>
		/// <param name="deliveryDto">New order delivery information</param>
		/// <returns></returns>
		/// <response code="200">Information about delivery was replaced and new information sent back.</response>
		/// <response code="404">Information with specified identifier does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(204)] 
		[HttpPut("{id}")]
		public ActionResult<Delivery> EditDelivery(Guid id, [FromBody] DeliveryEditDto deliveryDto)
		{
			var delivery = new Delivery() {
				Id = id,
				OrderId = deliveryDto.OrderId,
				Address = deliveryDto.Address,
				PostCode = deliveryDto.PostCode,
				Details = deliveryDto.Details
			};

			_deliveryRepository.UpdateDelivery(delivery);

			return delivery;
		}

		/// <summary>
		/// Deletes existing information about order delivery.
		/// </summary>
		/// <param name="id">Unique delivery information identifier</param>
		/// <returns></returns>
		/// <response code="200">Information was deleted successfully.</response>
		/// <response code="404">Information with specified identifier does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{id}")]
		public ActionResult DeleteDelivery(Guid id)
		{
			_deliveryRepository.DeleteDelivery(id);

			return Ok();
		}
	}
}
