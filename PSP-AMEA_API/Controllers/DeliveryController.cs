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

		[HttpGet("{id}")]
		public ActionResult<Delivery> GetDelivery(Guid id)
		{
			return Ok(_deliveryRepository.GetDelivery(id));
		}

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

		[HttpDelete("{id}")]
		public ActionResult DeleteDelivery(Guid id)
		{
			_deliveryRepository.DeleteDelivery(id);

			return Ok();
		}
	}
}
