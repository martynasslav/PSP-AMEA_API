using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public interface IOrderRepository
	{
		void CreateOrder(Order order);
		Order GetOrder(Guid id);
		IEnumerable<Guid> GetOrderIds();
		void UpdateOrder(Order order);
		void DeleteOrder(Guid id);
	}
}
