using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class PositionController : Controller
    {
        private readonly IPositionRepository repository;

        public PositionController(IPositionRepository repository)
        {
            this.repository = repository;
        }

		/// <summary>
		/// Gets information about all positions.
		/// </summary>
		/// <param name="offset">Index offset for the object list.</param>
		/// <param name="limit">Number of objects to return.</param>
		/// <response code="200">Information about positions returned.</response>
		[ProducesResponseType(200)]
		[HttpGet]
		public IEnumerable<PositionDto> GetPositions(int offset = 0, int limit = 20)
		{
			var positions = repository.GetPositions().Select(position => position.AsDto());

			return positions.Skip(offset).Take(limit);
		}

		/// <summary>
		/// Gets information about a position.
		/// </summary>
		/// <param name="id">Position id.</param>
		/// <response code="200">Information about position returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}", Name = "GetPosition")]
		public ActionResult<PositionDto> GetPosition(Guid id)
		{
			var position = repository.GetPosition(id);
			if (position == null)
			{
				return NotFound();
			}
			return position.AsDto();
		}

		/// <summary>
		/// Create a position.
		/// </summary>
		/// <param name="positionDto">Position dto.</param>
		/// <response code="200">Position created.</response>
		[HttpPost]
		public ActionResult<PositionDto> CreatePosition(CreatePositionDto positionDto)
		{
			Position position = new()
			{ 
				Id = Guid.NewGuid(),
				Name = positionDto.Name
			};

			repository.CreatePosition(position);

			return CreatedAtAction(nameof(GetPosition), new { id = position.Id }, position.AsDto());
		}
	}
}
