using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private static List<Order> s_Orders = new List<Order>();
		private static List<Cart> s_Carts = new List<Cart>();

		[HttpGet]
		public IEnumerable<Guid> GetOrderIds()
		{
			return s_Orders.Select(o => o.Id);
		}

		[HttpPost]
		public void CreateOrder([FromBody] Order order)
		{
			s_Orders.Add(order);
		}

		[HttpGet("{id}")]
		public Order GetOrderById(Guid id)
		{
			return s_Orders.First(o => o.Id == id);
		}

		[HttpPut("{id}")]
		public Order EditOrderById(Guid id, [FromBody] Order order)
		{
			var idx = s_Orders.FindIndex(o => o.Id == id);
			s_Orders[idx] = order;

			return s_Orders[idx];
		}

		[HttpDelete("{id}")]
		public void DeleteOrderById(Guid id)
		{
			s_Orders = s_Orders.Where(o => o.Id != id).ToList();
		}

		[HttpGet("{id}/Cart")]
		public IEnumerable<Guid> GetOrderCartIds(Guid id)
		{
			return s_Carts.Where(c => c.OrderId == id).Select(c => c.ItemId);
		}

		[HttpGet("{orderId}/Cart/{itemId}")]
		public Cart GetOrderCartById(Guid orderId, Guid itemId)
		{
			return s_Carts.First(c => c.OrderId == orderId && c.ItemId == itemId);
		}

		[HttpDelete("{orderId}/Cart/{itemId}")]
		public void DeleteOrderCartById(Guid orderId, Guid itemId)
		{
			s_Carts = s_Carts.Where(c => c.OrderId != orderId && c.ItemId != itemId).ToList();
		}

		[HttpGet("{id}/Payment")]
		public IEnumerable<Guid> GetOrderPaymentIds(Guid id)
		{
			throw new NotImplementedException();
		}

		[HttpGet("{orderId}/Payment/{paymentId}")]
		public Payment GetOrderPaymentById(Guid orderId, Guid paymentId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{orderId}/Payment/{paymentId}")]
		public void DeleteOrderPaymentById(Guid orderId, Guid paymentId)
		{
			throw new NotImplementedException();
		}

		[HttpGet("{id}/Delivery")]
		public IEnumerable<Guid> GetOrderDeliveryIds(Guid id)
		{
			throw new NotImplementedException(); 
		}

		[HttpGet("{orderId}/Delivery/{deliveryId}")]
		public Delivery GetOrderDeliveryById(Guid orderId, Guid deliveryId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{orderId}/Delivery/{deliveryId}")]
		public void DeleteOrderDeliveryById(Guid orderId, Guid deliveryId)
		{
			throw new NotImplementedException();
		}
	}
}