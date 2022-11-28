using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public interface ICartRepository
	{
		void CreateCart(Cart cart);
		IEnumerable<Cart> GetOrderCarts(Guid orderId);
		Cart? GetCart(Guid orderId, Guid itemId);
		void UpdateCart(Cart cart);
		void DeleteCart(Guid orderId, Guid itemId);
	}
}
