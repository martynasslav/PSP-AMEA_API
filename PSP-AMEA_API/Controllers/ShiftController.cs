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
        private readonly IShiftTypeRepository _shiftTypeRepository;
        private readonly IShiftEmployeeRepository _shiftEmployeeRepository;

        public ShiftController(IShiftRepository shiftRepository, IShiftTypeRepository shiftTypeRepository, IShiftEmployeeRepository shiftEmployeeRepository)
        {
            _shiftRepository = shiftRepository;
            _shiftTypeRepository = shiftTypeRepository;
            _shiftEmployeeRepository = shiftEmployeeRepository;
        }

        /// <summary>
        /// Gets information about all shifts.
        /// </summary>
        /// <param name="tenantId" example="3fa85f64-5717-4562-b3fc-2c963f66afa6"> </param>
        /// <param name="offset"> The first item to return</param>
        /// <param name="limit"> The number of entries to return </param>
        /// <response code="200">Shifts information returned</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetAllShifts")]
        public IEnumerable<Shift> GetAllShifts(int offset = 0, int limit = 20, Guid? tenantId = null)
        {
            List<Shift> shifts = (List<Shift>)_shiftRepository.GetAllShifts();

            return limit > shifts.Count ? shifts.GetRange(offset, shifts.Count) : shifts.GetRange(offset, limit);
        }

        /// <summary>
        /// Gets information about specific shift from ID.
        /// </summary>
        /// <param name="id">Unique shift ID</param>
        /// <response code="200">Shift information returned</response>
        /// <response code="204">Shift information not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("{id}", Name = "GetShift")]
        public ActionResult<Shift> GetShift(Guid id)
        {
            var shift = _shiftRepository.GetShiftById(id);

            if (shift == null)
            {
                return NoContent();
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
        /// <response code="404">There is no such shift.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}", Name = "UpdateShift")]
        public ActionResult<Shift> UpdateShift(Guid id, CreateShiftDto dto)
        {
            var shift = _shiftRepository.GetShiftById(id);

            if (shift == null)
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
        /// <response code="404">There is no such shift.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Gets information about all shift types.
        /// </summary>
        /// <response code="200">Shift types information returned</response>
        [ProducesResponseType(200)]
        [HttpGet("/Type", Name = "GetAllShiftTypes")]
        public IEnumerable<ShiftType> GetAllShiftTypes()
        {
            return _shiftTypeRepository.GetAllShiftTypes();
        }

        /// <summary>
        /// Gets information about specific shift type from ID.
        /// </summary>
        /// <param name="id">Unique shift type ID</param>
        /// <response code="200">Shift type information returned</response>
        /// <response code="204">Shift type information not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("/Type{id}", Name = "GetShiftType")]
        public ActionResult<ShiftType> GetShiftType(Guid id)
        {
            var shiftType = _shiftTypeRepository.GetShiftTypeById(id);

            if (shiftType == null)
            {
                return NoContent();
            }

            return shiftType;
        }

        /// <summary>
        /// Creates a new shift type.
        /// </summary>
        /// <response code="201">Shift type created</response>
        [ProducesResponseType(201)]
        [HttpPost("/Type",Name = "CreateShiftType")]
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
        /// <response code="404">There is no such shift type.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("/Type{id}", Name = "UpdateShiftType")]
        public ActionResult<ShiftType> UpdateShift(Guid id, CreateShiftTypeDto dto)
        {
            var shiftType = _shiftTypeRepository.GetShiftTypeById(id);

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
        /// <response code="200">Shift type deleted.</response>
        /// <response code="404">There is no such shift type.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("/Type{id}")]
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

        /// <summary>
        /// Gets information about all shift employees
        /// </summary>
        /// <response code="200">Shift employees information returned</response>
        [ProducesResponseType(200)]
        [HttpGet("/Employee", Name = "GetShiftEmployees")]
        public IEnumerable<ShiftEmployee> GetAllShiftEmployees()
        {
            return _shiftEmployeeRepository.GetAllShiftEmployees();
        }

        /// <summary>
        /// Get information about a shift employee from specific shift ID.
        /// </summary>
        /// <param name="id">Unqiue shift ID</param>
        /// <response code="200">Shift employee information returned</response>
        /// <response code="204">Shift employee not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("/Employee{id}", Name = "GetShiftEmployeeByShiftId")]
        public ActionResult<ShiftEmployee> GetShiftEmployeeByShiftId(Guid id)
        {
            var shiftEmployee = _shiftEmployeeRepository.GetShiftEmployeeByShiftId(id);

            if (shiftEmployee == null)
            {
                return NoContent();
            }

            return shiftEmployee;
        }

        /// <summary>
        /// Create a shift employee.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="201">Shift employee created</response>
        [ProducesResponseType(201)]
        [HttpPost("/Employee",Name = "AssignShiftEmployee")]
        public ActionResult<ShiftEmployee> AssignShiftEmployee(ShiftEmployeeDto dto)
        {
            var shiftEmployee = _shiftEmployeeRepository.CreateShiftEmployee(dto);

            return CreatedAtAction("GetShiftEmployeeByShiftId", new { id = shiftEmployee.ShiftId }, shiftEmployee);
        }

        /// <summary>
        /// Update a shift employee's information.
        /// </summary>
        /// <param name="id">Unqiue shift ID</param>
        /// <response code="200">Shift employee updated</response>
        /// <response code="404">There is no such shift with this employee.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("/Employee{id}", Name = "UpdateShiftEmployee")]
        public ActionResult<ShiftEmployee> UpdateShiftEmployee(Guid id, UpdateShiftEmployeeDto dto)
        {
            var shiftEmployee = _shiftEmployeeRepository.GetShiftEmployeeByShiftId(id);

            if (shiftEmployee == null)
            {
                return NotFound();
            }

            ShiftEmployee updatedShiftEmployee = new()
            {
                ShiftId = shiftEmployee.ShiftId,
                EmployeeId = dto.EmployeeId
            };

            _shiftEmployeeRepository.UpdateShiftEmployee(updatedShiftEmployee);

            return Ok();
        }

        /// <summary>
        /// Deletes a shift employee.
        /// </summary>
        /// <param name="id">Unqiue shift ID</param>
        /// <response code="200">Shift employee successfully deleted</response>
        /// <response code="404">There is no such shift with this employee.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("/Employee{id}")]
        public ActionResult<ShiftEmployee> DeleteShiftEmployee(Guid id)
        {
            var shiftEmployee = _shiftEmployeeRepository.GetShiftEmployeeByShiftId(id);

            if (shiftEmployee == null)
            {
                return NotFound();
            }

            _shiftEmployeeRepository.DeleteShiftEmployee(shiftEmployee);

            return Ok();
        }
    }
}
