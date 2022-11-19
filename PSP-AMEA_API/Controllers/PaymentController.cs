using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentRepository paymentRepository = new PaymentRepository();

		[HttpGet("{id}")]
		public ActionResult<Payment> GetPayment(Guid id)
		{
			return Ok(paymentRepository.GetPaymentById(id));
		}

		[HttpPut("{id}")]
		public ActionResult<Payment> EditPayment(Guid id, [FromBody] PaymentEditDto paymentDto)
		{
			var payment = new Payment() {
				Id = id,
				OrderId = paymentDto.OrderId,
				Provider = paymentDto.Provider,
				Status = paymentDto.Status
			};

			paymentRepository.UpdatePayment(payment);

			return Ok(payment);
		}

		[HttpDelete("{id}")]
		public ActionResult DeletePayment(Guid id)
		{
			paymentRepository.DeletePayment(id);

			return Ok();
		}
	}
}
