using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public class DeliveryRepository : IDeliveryRepository
	{
		private readonly List<Delivery> deliveries = new();

		public void CreateDelivery(Delivery delivery)
		{
			deliveries.Add(delivery);
		}

		public void DeleteDelivery(Guid deliveryId)
		{
			int idx;

			try
			{
				idx = deliveries.FindIndex(d => d.Id == deliveryId);
			}
			catch (ArgumentOutOfRangeException)
			{
				throw;
			}

			deliveries.RemoveAt(idx);
		}

		public Delivery? GetDelivery(Guid deliveryId)
		{
			return deliveries.SingleOrDefault(d => d.Id == deliveryId);
		}

		public IEnumerable<Guid> GetOrderDeliveryIds(Guid orderId)
		{
			return deliveries.Where(d => d.OrderId == orderId).Select(d => d.Id);
		}

		public void UpdateDelivery(Delivery delivery)
		{
			int idx;

			try
			{
				idx = deliveries.FindIndex(d => d.Id == delivery.Id);
			}
			catch(ArgumentOutOfRangeException)
			{
				throw;
			}

			deliveries[idx] = delivery;
		}
	}
}
