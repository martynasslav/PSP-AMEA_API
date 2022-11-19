using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public class PaymentRepository : IPaymentRepository
	{
		private readonly List<Payment> payments = new();

		public void CreatePayment(Payment payment)
		{
			payments.Add(payment);
		}

		public void DeletePayment(Guid paymentId)
		{
			payments.RemoveAll(p => p.Id == paymentId);
		}

		public IEnumerable<Guid> GetOrderPaymentIds(Guid orderId)
		{
			return payments.Where(p => p.OrderId == orderId).Select(p => p.Id);
		}

		public Payment GetPaymentById(Guid paymentId)
		{
			return payments.First(p => p.Id == paymentId);
		}

		public void UpdatePayment(Payment payment)
		{
			var idx = payments.FindIndex(p => p.Id == payment.Id);
			payments[idx] = payment;
		}
	}
}
