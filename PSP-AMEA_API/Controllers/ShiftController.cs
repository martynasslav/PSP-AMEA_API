using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        /// <summary>
        /// Gets information about all shifts.
        /// </summary>
        /// <response code="200">Shifts information returned</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetAllShifts")]
        public IEnumerable<Shift> GetAllShifts()
        {
            return _shiftRepository.GetAllShifts();
        }

        /// <summary>
        /// Gets information about specific shift from ID.
        /// </summary>
        /// <param name="id">Unique shift ID</param>
        /// <response code="200">Shift information returned</response>
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = "GetShift")]
        public ActionResult<Shift> GetShift(Guid id)
        {
            var shift = _shiftRepository.GetShiftById(id);

            if (shift == null)
            {
                return NotFound();
            }

            return shift;
        }

        /// <summary>
        /// Creates a new shift.
        /// </summary>
        /// <response code="201">Shift created</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateShift")]
        public ActionResult<Shift> CreateShift(CreateShiftDto dto)
        {
            var shift = _shiftRepository.CreateShift(dto);

            return CreatedAtAction("GetShift", new { id = shift.Id }, shift);
        }

        /// <summary>
        /// Updates shift's information.
        /// </summary>
        /// <param name="id">Unique shift ID</param>
        /// <response code="200">Shift information updated</response>
        [ProducesResponseType(200)]
        [HttpPut("{id}", Name = "UpdateShift")]
        public ActionResult<Shift> UpdateShift(Guid id, CreateShiftDto dto)
        {
            var shift = GetShift(id);

            if(shift == null)
            {
                return NotFound();
            }

            Shift updatedShift = new()
            {
                Id = id,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                StartsAt = dto.StartsAt,
                EndsAt = dto.EndsAt,
                Type = dto.Type,
                TenantId = dto.TenantId
            };

            _shiftRepository.UpdateShift(updatedShift);

            return Ok();
        }

        /// <summary>
        /// Deletes a shift.
        /// </summary>
        /// <param name="id">Unqiue shift ID</param>
        /// <response code="200">Shift successfully deleted</response>
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public ActionResult<Shift> DeleteShift(Guid id)
        {
            var shift = _shiftRepository.GetShiftById(id);

            if(shift == null)
            {
                return NotFound();
            }

            _shiftRepository.DeleteShift(shift);

            return Ok();
        }
    }
}
