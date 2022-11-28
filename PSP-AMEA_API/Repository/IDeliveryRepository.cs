using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public interface IDeliveryRepository
	{
		void CreateDelivery(Delivery delivery);
		void UpdateDelivery(Delivery delivery);
		void DeleteDelivery(Guid deliveryId);
		IEnumerable<Delivery> GetOrderDeliveries(Guid orderId);
		Delivery? GetDelivery(Guid deliveryId);
	}
}
