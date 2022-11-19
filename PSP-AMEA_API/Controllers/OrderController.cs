using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderRepository orderRepository = new OrderRepository();
		private readonly ICartRepository cartRepository = new CartRepository();
		private readonly IPaymentRepository paymentRepository = new PaymentRepository();
		private readonly IDeliveryRepository deliveryRepository = new DeliveryRepository();

		[HttpGet]
		public ActionResult<IEnumerable<Guid>> GetOrderIds()
		{
			return Ok(orderRepository.GetOrderIds());
		}

		[HttpPost]
		public ActionResult<Order> CreateOrder([FromBody] OrderDto orderDto)
		{
			var order = new Order() {
				Id = Guid.NewGuid(),
				CustomerId = orderDto.CustomerId,
				EmployeeId = orderDto.EmployeeId,
				TenantId = orderDto.TenantId,
				Total = orderDto.Total,
				Tip = orderDto.Tip,
				DeliveryType = orderDto.DeliveryType,
				Date = orderDto.Date
			};

			orderRepository.CreateOrder(order);

			return Ok(order);
		}

		[HttpGet("{id}")]
		public ActionResult<Order> GetOrder(Guid id)
		{
			return Ok(orderRepository.GetOrder(id));
		}

		[HttpPut("{id}")]
		public ActionResult<Order> EditOrder(Guid id, [FromBody] OrderDto orderDto)
		{
			var order = new Order() {
				Id = id,
				CustomerId = orderDto.CustomerId,
				EmployeeId = orderDto.EmployeeId,
				TenantId = orderDto.TenantId,
				Total = orderDto.Total,
				Tip = orderDto.Tip,
				DeliveryType = orderDto.DeliveryType,
				Date = orderDto.Date
			};

			orderRepository.UpdateOrder(order);

			return Ok(order);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteOrder(Guid id)
		{
			orderRepository.DeleteOrder(id);

			return Ok();
		}

		[HttpGet("{id}/Cart")]
		public ActionResult<IEnumerable<Guid>> GetOrderCartIds(Guid id)
		{
			return Ok(cartRepository.GetOrderCartIds(id));
		}

		[HttpPost("{id}/Cart")]
		public ActionResult<Cart> CreateOrderCart(Guid id, [FromBody] CartCreationDto cartDto)
		{
			var cart = new Cart() {
				ItemId = cartDto.ItemId,
				OrderId = id,
				Quantity = cartDto.Quantity,
				Discount = cartDto.Discount,
				Description = cartDto.Description
			};

			cartRepository.CreateCart(cart);

			return Ok(cart);
		}

		[HttpGet("{orderId}/Cart/{itemId}")]
		public ActionResult<Cart> GetOrderCart(Guid orderId, Guid itemId)
		{
			return Ok(cartRepository.GetCart(orderId, itemId));
		}

		[HttpPut("{orderId}/Cart/{itemId}")]
		public ActionResult<Cart> EditOrderCart(Guid orderId, Guid itemId, [FromBody] CartEditDto cartDto)
		{
			var cart = new Cart() {
				ItemId = itemId,
				OrderId = orderId,
				Quantity = cartDto.Quantity,
				Discount = cartDto.Discount,
				Description = cartDto.Description
			};

			cartRepository.UpdateCart(cart);

			return Ok(cart);
		}

		[HttpDelete("{orderId}/Cart/{itemId}")]
		public ActionResult DeleteOrderCart(Guid orderId, Guid itemId)
		{
			cartRepository.DeleteCart(orderId, itemId);

			return Ok();
		}

		[HttpGet("{id}/Payment")]
		public ActionResult<IEnumerable<Guid>> GetOrderPaymentIds(Guid id)
		{
			return Ok(paymentRepository.GetOrderPaymentIds(id));
		}

		[HttpPost("{id}/Payment")]
		public ActionResult<Payment> CreateOrderPayment(Guid id, [FromBody] PaymentCreationDto paymentDto)
		{
			var payment = new Payment() {
				Id = Guid.NewGuid(),
				OrderId = id,
				Provider = paymentDto.Provider,
				Status = paymentDto.Status
			};

			paymentRepository.CreatePayment(payment);

			return Ok(payment);
		}

		[HttpGet("{id}/Delivery")]
		public ActionResult<IEnumerable<Guid>> GetOrderDeliveryIds(Guid id)
		{
			return Ok(deliveryRepository.GetOrderDeliveryIds(id));
		}

		[HttpPost("{id}/Delivery")]
		public ActionResult<Delivery> CreateOrderDelivery(Guid id, [FromBody] DeliveryCreationDto deliveryDto)
		{
			var delivery = new Delivery() {
				Id = Guid.NewGuid(),
				OrderId = id,
				Address = deliveryDto.Address,
				PostCode = deliveryDto.PostCode,
				Details = deliveryDto.Details
			};

			deliveryRepository.CreateDelivery(delivery);

			return Ok(delivery);
		}
	}
}