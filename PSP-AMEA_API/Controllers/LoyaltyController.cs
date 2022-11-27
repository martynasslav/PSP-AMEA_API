using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyController : ControllerBase
    {
        private readonly ILoyaltyRepository repository;

        public LoyaltyController(ILoyaltyRepository repository)
        {
            this.repository = repository;
        }

		/// <summary>
		/// Gets information about all loyalties.
		/// </summary>
		/// <param name="offset">Index offset for the object list.</param>
		/// <param name="limit">Number of objects to return.</param>
		/// <param name="tenantId">Optional filtering by tenant id.</param>
		/// <response code="200">Information about loyalties returned.</response>
		[HttpGet]
        public IEnumerable<LoyaltyDto> GetLoyalties(int offset = 0, int limit = 20, Guid? tenantId = null)
        {
            var loyalty = repository.GetAllLoyaltyPrograms().Select(loyalty => loyalty.AsDto());

            if (tenantId != null)
            {
                loyalty = loyalty.Where(l => l.TenantId == tenantId);
            }

            return loyalty.Skip(offset).Take(limit);
        }

        /// <summary>
		/// Creates a loyalty program.
		/// </summary>
		/// <param name="loyalty">Loyalty objecxt</param>
		/// <returns></returns>
		/// <response code="200">Loyalty created.</response>
        [HttpPost]
        public ActionResult<LoyaltyDto> CreateLoyalty(Loyalty loyalty)
        {
            Loyalty newLoyalty = new()
            {
                Name = loyalty.Name,
                Id = Guid.NewGuid(),
                TenantId = loyalty.TenantId,
                Description = loyalty.Description,
            };

            repository.CreateLoyaltyProgram(newLoyalty);

            return NoContent();
        }

        /// <summary>
		/// Gets information about an employee from specified employee identifier.
		/// </summary>
		/// <param name="id">Unique loyalty ID</param>
        /// <param name="loyalty">Loyalty object</param>
		/// <returns></returns>
		/// <response code="200">Loyalty updated.</response>
        [HttpPut("{id}")]
        public ActionResult<LoyaltyDto> UpdateLoyalty(Guid id, Loyalty loyalty)
        {
            var existingLoyalty = repository.GetLoyaly(id);

            if (existingLoyalty is null)
            {
                return NotFound();
            }

            Loyalty updatedEmployee = new()
            {
                Id = id,
                Name = loyalty.Name,
                Description = loyalty.Description,
                TenantId = loyalty.TenantId,
            };

            repository.UpdateLoyaltyProgram(updatedEmployee);

            return NoContent();
        }
    }
}
