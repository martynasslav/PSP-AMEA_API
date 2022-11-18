using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ShiftTypeController : ControllerBase
    {
        private readonly IShiftTypeRepository _shiftTypeRepository;

        public ShiftTypeController(IShiftTypeRepository shiftTypeRepository) 
        {
            _shiftTypeRepository= shiftTypeRepository;
        }

        /// <summary>
        /// Gets information about all shift types.
        /// </summary>
        /// <response code="200">Shift types information returned</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetAllShiftTypes")]
        public IEnumerable<ShiftType> GetAllShiftTypes()
        {
            return _shiftTypeRepository.GetAllShiftTypes();
        }

        /// <summary>
        /// Gets information about specific shift type from ID.
        /// </summary>
        /// <param name="id">Unique shift type ID</param>
        /// <response code="200">Shift type information returned</response>
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = "GetShiftType")]
        public ActionResult<ShiftType> GetShiftType(Guid id)
        {
            var shiftType = _shiftTypeRepository.GetShiftTypeById(id);

            if (shiftType == null)
            {
                return NotFound();
            }

            return shiftType;
        }

        /// <summary>
        /// Creates a new shift type.
        /// </summary>
        /// <response code="201">Shift type created</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateShiftType")]
        public ActionResult<ShiftType> CreateShiftType(CreateShiftTypeDto dto)
        {
            var shiftType = _shiftTypeRepository.CreateShiftType(dto);

            return CreatedAtAction("GetShiftType", new { id = shiftType.Id }, shiftType);
        }

        /// <summary>
        /// Updates shift type's information.
        /// </summary>
        /// <param name="id">Unique shift type ID</param>
        /// <response code="200">Shift type information updated</response>
        [ProducesResponseType(200)]
        [HttpPut("{id}", Name = "UpdateShiftType")]
        public ActionResult<ShiftType> UpdateShift(Guid id, CreateShiftTypeDto dto)
        {
            var shiftType = GetShiftType(id);

            if (shiftType == null)
            {
                return NotFound();
            }

            ShiftType updatedShiftType = new()
            {
                Id = id,
                Name = dto.Name,
                TenantId = dto.TenantId
            };

            _shiftTypeRepository.UpdateShiftType(updatedShiftType);

            return Ok();
        }

        /// <summary>
        /// Deletes a shift type.
        /// </summary>
        /// <param name="id">Unqiue shift type ID</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public ActionResult<ShiftType> DeleteShiftType(Guid id)
        {
            var shiftType = _shiftTypeRepository.GetShiftTypeById(id);

            if (shiftType == null)
            {
                return NotFound();
            }

            _shiftTypeRepository.DeleteShiftType(shiftType);

            return Ok();
        }

    }
}
