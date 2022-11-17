using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		[HttpPost]
		public Payment CreatePayment([FromBody] Payment payment)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		public Payment EditPayment([FromBody] Payment payment)
		{
			throw new NotImplementedException();
		}
	}
}
