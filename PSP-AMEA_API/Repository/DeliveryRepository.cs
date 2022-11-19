using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public class DeliveryRepository : IDeliveryRepository
	{
		private static readonly List<Delivery> deliveries = new();

		public void CreateDelivery(Delivery delivery)
		{
			deliveries.Add(delivery);
		}

		public void DeleteDelivery(Guid deliveryId)
		{
			deliveries.RemoveAll(d => d.Id == deliveryId);
		}

		public Delivery GetDelivery(Guid deliveryId)
		{
			return deliveries.First(d => d.Id == deliveryId);
		}

		public IEnumerable<Guid> GetOrderDeliveryIds(Guid orderId)
		{
			return deliveries.Where(d => d.OrderId == orderId).Select(d => d.Id);
		}

		public void UpdateDelivery(Delivery delivery)
		{
			var idx = deliveries.FindIndex(d => d.Id == delivery.Id);
			deliveries[idx] = delivery;
		}
	}
}
