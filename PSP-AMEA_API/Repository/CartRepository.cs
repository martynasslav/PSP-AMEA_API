using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public class CartRepository : ICartRepository
	{
		private readonly List<Cart> carts = new();

		public void CreateCart(Cart cart)
		{
			carts.Add(cart);
		}

		public void UpdateCart(Cart cart)
		{
			var idx = carts.FindIndex(c => c.OrderId == cart.OrderId && c.ItemId == cart.ItemId);
			carts[idx] = cart;
		}

		public Cart? GetCart(Guid orderId, Guid itemId)
		{
			return carts.SingleOrDefault(c => c.OrderId == orderId && c.ItemId == itemId);
		}

		public IEnumerable<Cart> GetOrderCarts(Guid orderId)
		{
			return carts.Where(c => c.OrderId == orderId);
		}

		public void DeleteCart(Guid orderId, Guid itemId)
		{
			carts.RemoveAll(c => c.OrderId == orderId && c.ItemId == itemId);
		}
	}
}
