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
		private readonly IPaymentRepository _paymentRepository;

		public PaymentController(IPaymentRepository paymentRepository)
		{
			this._paymentRepository = paymentRepository;
		}

		[HttpGet("{id}")]
		public ActionResult<Payment> GetPayment(Guid id)
		{
			var payment = _paymentRepository.GetPaymentById(id);

			return payment == null ? NoContent() : Ok(payment);
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

			_paymentRepository.UpdatePayment(payment);

			return Ok(payment);
		}

		[HttpDelete("{id}")]
		public ActionResult DeletePayment(Guid id)
		{
			_paymentRepository.DeletePayment(id);

			return Ok();
		}
	}
}
