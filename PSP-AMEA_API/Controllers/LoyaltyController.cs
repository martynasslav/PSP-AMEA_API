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

        [HttpGet]
        public IEnumerable<LoyaltyDto> GetLoyalties()
        {
            var loyalty = repository.GetAllLoyaltyPrograms().Select(loyalty => loyalty.AsDto());
            return loyalty;
        }

        [HttpPost]
        public ActionResult<Loyalty> CreateLoyalty(Loyalty loyalty)
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

        [HttpPut("{id}")]
        public ActionResult<Loyalty> UpdateLoyalty(Guid id, Loyalty loyalty)
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
