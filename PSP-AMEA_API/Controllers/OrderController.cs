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

		/// <summary>
		/// Get all order identifiers.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">List of order identifiers was returned.</response>
		[ProducesResponseType(200)]
		[HttpGet]
		public ActionResult<IEnumerable<Guid>> GetOrderIds()
		{
			return Ok(_orderRepository.GetOrderIds());
		}

		/// <summary>
		/// Creates a new order.
		/// </summary>
		/// <returns></returns>
		/// <response code="201">Order was created and returned.</response>
		[ProducesResponseType(201)]
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

		/// <summary>
		/// Gets order information.
		/// </summary>
		/// <param name="id">Unique order identifier</param>
		/// <returns></returns>
		/// <response code="200">Order was found and returned.</response>
		/// <response code="204">Order was found not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(204)]
		[HttpGet("{id}")]
		public ActionResult<Order> GetOrder(Guid id)
		{
			var order = _orderRepository.GetOrder(id);

			return order == null ? NoContent() : Ok(order);
		}

		/// <summary>
		/// Replaces existing information about an order.
		/// </summary>
		/// <param name="id">Unique order identifier</param>
		/// <param name="orderDto">New information about the order</param>
		/// <returns></returns>
		/// <response code="200">Order information was replaced and new information sent back.</response>
		/// <response code="404">Information with specified identifier does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
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

		/// <summary>
		/// Deletes existing information about an order.
		/// </summary>
		/// <param name="id">Unique order identifier</param>
		/// <returns></returns>
		/// <response code="200">Information was deleted successfully.</response>
		/// <response code="404">Information with specified identifier does not exist.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{id}")]
		public ActionResult DeleteOrder(Guid id)
		{
			_orderRepository.DeleteOrder(id);

			return Ok();
		}

		/// <summary>
		/// Gets list of item identifiers in the order cart.
		/// </summary>
		/// <param name="id">Unique order identifier</param>
		/// <returns></returns>
		/// <response code="200">List of item identifiers was returned.</response>
		/// <response code="404">Order was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpGet("{id}/Cart")]
		public ActionResult<IEnumerable<Guid>> GetOrderCartIds(Guid id)
		{
			return Ok(_cartRepository.GetOrderCartIds(id));
		}

		/// <summary>
		/// Creates inforamtion about an item in the order cart.
		/// </summary>
		/// <param name="id">Unique order identifier</param>
		/// <returns></returns>
		/// <response code="201">Cart information was created and returned.</response>
		/// <response code="404">Order was not found.</response>
		[ProducesResponseType(201)]
		[ProducesResponseType(404)]
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

		/// <summary>
		/// Gets information about an item in the order cart.
		/// </summary>
		/// <param name="orderId">Unique order identifier</param>
		/// <param name="itemId">Unique item identifier</param>
		/// <returns></returns>
		/// <response code="200">Cart information was found and returned.</response>
		/// <response code="404">Cart with order and item identifier combination was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpGet("{orderId}/Cart/{itemId}")]
		public ActionResult<Cart> GetOrderCart(Guid orderId, Guid itemId)
		{
			var cart = _cartRepository.GetCart(orderId, itemId);

			return cart == null ? NoContent() : Ok(cart);
		}

		/// <summary>
		/// Replace existing cart information.
		/// </summary>
		/// <param name="orderId">Unique order identifier</param>
		/// <param name="itemId">Unique item identifier</param>
		/// <param name="cartDto">New cart information</param>
		/// <returns></returns>
		/// <response code="200">Cart information was replaced and returned.</response>
		/// <response code="404">Cart with order and item identifier combination was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
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

		/// <summary>
		/// Delete existing cart information.
		/// </summary>
		/// <param name="orderId">Unique order identifier</param>
		/// <param name="itemId">Unique item identifier</param>
		/// <returns></returns>
		/// <response code="200">Cart information was deleted.</response>
		/// <response code="404">Cart with order and item identifier combination was not found.</response>
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{orderId}/Cart/{itemId}")]
		public ActionResult DeleteOrderCart(Guid orderId, Guid itemId)
		{
			_cartRepository.DeleteCart(orderId, itemId);

			return Ok();
		}

		/// <summary>
		/// Gets all payment identifiers for the specified order.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">List of identifiers was returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}/Payment")]
		public ActionResult<IEnumerable<Guid>> GetOrderPaymentIds(Guid id)
		{
			return Ok(_paymentRepository.GetOrderPaymentIds(id));
		}

		/// <summary>
		/// Creates a new payment of the order.
		/// </summary>
		/// <returns></returns>
		/// <response code="201">Order payment was created and returned.</response>
		/// <response code="404">Order was not found.</response>
		[ProducesResponseType(201)]
		[ProducesResponseType(404)]
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

		/// <summary>
		/// Gets all delivery identifiers for the specified order.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">List of identifiers was returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}/Delivery")]
		public ActionResult<IEnumerable<Guid>> GetOrderDeliveryIds(Guid id)
		{
			return Ok(_deliveryRepository.GetOrderDeliveryIds(id));
		}

		/// <summary>
		/// Creates a new delivery for the order.
		/// </summary>
		/// <returns></returns>
		/// <response code="201">Order delivery was created and returned.</response>
		/// <response code="404">Order was not found.</response>
		[ProducesResponseType(201)]
		[ProducesResponseType(404)]
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