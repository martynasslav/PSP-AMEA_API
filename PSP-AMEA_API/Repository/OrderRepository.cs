using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private static readonly List<Order> orders = new();

		public void CreateOrder(Order order)
		{
			orders.Add(order);
		}

		public void UpdateOrder(Order order)
		{
			var idx = orders.FindIndex(o => o.Id == order.Id);
			orders[idx] = order;
		}

		public void DeleteOrder(Guid id)
		{
			orders.RemoveAll(o => o.Id == id);
		}

		public IEnumerable<Guid> GetOrderIds()
		{
			return orders.Select(o => o.Id);
		}

		public Order GetOrder(Guid id)
		{
			return orders.First(o => o.Id == id);
		}
	}
}
