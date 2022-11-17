using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		[HttpPost]
		public Cart CreateCart([FromBody] Cart cart)
		{
			return cart;
		}

		[HttpPut]
		public Cart EditCart([FromBody] Cart cart)
		{
			throw new NotImplementedException();
		}
	}
}
