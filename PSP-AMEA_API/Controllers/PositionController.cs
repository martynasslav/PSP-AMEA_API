using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionRepository repository;

        public PositionController(IPositionRepository repository)
        {
            this.repository = repository;
        }

		[ProducesResponseType(200)]
		[HttpGet]
		public IEnumerable<PositionDto> GetPositions(int offset = 0, int limit = 20, Guid? tenantId = null)
		{
			var positions = repository.GetPositions().Select(position => position.AsDto());

			return positions.Skip(offset).Take(limit);
		}

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
