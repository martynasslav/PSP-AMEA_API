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
		private readonly IOrderRepository _orderRepository;
		private readonly ICartRepository _cartRepository;
		private readonly IPaymentRepository _paymentRepository;
		private readonly IDeliveryRepository _deliveryRepository;

		public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository, IPaymentRepository paymentRepository, IDeliveryRepository deliveryRepository)
		{
			this._orderRepository = orderRepository;
			this._cartRepository = cartRepository;
			this._paymentRepository = paymentRepository;
			this._deliveryRepository = deliveryRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Guid>> GetOrderIds()
		{
			return Ok(_orderRepository.GetOrderIds());
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

			_orderRepository.CreateOrder(order);

			return Ok(order);
		}

		[HttpGet("{id}")]
		public ActionResult<Order> GetOrder(Guid id)
		{
			var order = _orderRepository.GetOrder(id);

			return order == null ? NoContent() : Ok(order);
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

			_orderRepository.UpdateOrder(order);

			return Ok(order);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteOrder(Guid id)
		{
			_orderRepository.DeleteOrder(id);

			return Ok();
		}

		[HttpGet("{id}/Cart")]
		public ActionResult<IEnumerable<Guid>> GetOrderCartIds(Guid id)
		{
			return Ok(_cartRepository.GetOrderCartIds(id));
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

			_cartRepository.CreateCart(cart);

			return Ok(cart);
		}

		[HttpGet("{orderId}/Cart/{itemId}")]
		public ActionResult<Cart> GetOrderCart(Guid orderId, Guid itemId)
		{
			var cart = _cartRepository.GetCart(orderId, itemId);

			return cart == null ? NoContent() : Ok(cart);
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

			_cartRepository.UpdateCart(cart);

			return Ok(cart);
		}

		[HttpDelete("{orderId}/Cart/{itemId}")]
		public ActionResult DeleteOrderCart(Guid orderId, Guid itemId)
		{
			_cartRepository.DeleteCart(orderId, itemId);

			return Ok();
		}

		[HttpGet("{id}/Payment")]
		public ActionResult<IEnumerable<Guid>> GetOrderPaymentIds(Guid id)
		{
			return Ok(_paymentRepository.GetOrderPaymentIds(id));
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

			_paymentRepository.CreatePayment(payment);

			return Ok(payment);
		}

		[HttpGet("{id}/Delivery")]
		public ActionResult<IEnumerable<Guid>> GetOrderDeliveryIds(Guid id)
		{
			return Ok(_deliveryRepository.GetOrderDeliveryIds(id));
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

			_deliveryRepository.CreateDelivery(delivery);

			return Ok(delivery);
		}
	}
}