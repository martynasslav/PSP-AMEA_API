using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class DeliveryController : ControllerBase
	{
		[HttpPost]
		public Delivery CreateDelivery([FromBody] Delivery delivery)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		public Delivery EditDelivery([FromBody] Delivery delivery)
		{
			throw new NotImplementedException();
		}
	}
}
