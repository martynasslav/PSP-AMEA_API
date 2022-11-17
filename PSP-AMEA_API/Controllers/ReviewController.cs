using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		[HttpPost]
		public Review CreateReview([FromBody] Review review)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		public Review EditReview([FromBody] Review review)
		{
			throw new NotImplementedException();
		}
	}
}
