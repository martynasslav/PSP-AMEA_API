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

		/// <summary>
		/// Gets order payment information.
		/// </summary>
		/// <param name="id">Unique payment identifier</param>
		/// <returns></returns>
		/// <response code="200">Information about order payment was returned.</response>
		/// <response code="204">Payment information was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[HttpGet("{id}")]
		public ActionResult<Payment> GetPayment(Guid id)
		{
			var payment = _paymentRepository.GetPaymentById(id);

			return payment == null ? NoContent() : Ok(payment);
		}

		/// <summary>
		/// Replaces existing payment information.
		/// </summary>
		/// <param name="id">Unique payment identifier</param>
		/// <returns></returns>
		/// <response code="200">Information about order payment was replaced and returned.</response>
		/// <response code="404">Payment information was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
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

		/// <summary>
		/// Deletes existing payment information.
		/// </summary>
		/// <param name="id">Unique payment identifier</param>
		/// <returns></returns>
		/// <response code="200">Information about order payment was deleted successfully.</response>
		/// <response code="404">Payment information was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{id}")]
		public ActionResult DeletePayment(Guid id)
		{
			_paymentRepository.DeletePayment(id);

			return Ok();
		}
	}
}
