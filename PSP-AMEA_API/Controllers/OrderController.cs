using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private static List<Order> s_Orders = new List<Order>();

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
	}
}