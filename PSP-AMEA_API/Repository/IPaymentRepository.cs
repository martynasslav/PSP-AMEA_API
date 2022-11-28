using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public interface IPaymentRepository
	{
		void CreatePayment(Payment payment);
		IEnumerable<Payment> GetOrderPayments(Guid orderId);
		Payment? GetPaymentById(Guid paymentId);
		void UpdatePayment(Payment payment);
		void DeletePayment(Guid paymentId);
	}
}
