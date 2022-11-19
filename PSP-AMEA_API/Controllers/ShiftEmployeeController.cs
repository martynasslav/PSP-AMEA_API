using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;
using System.Xml;

namespace PSP_AMEA_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ShiftEmployeeController : ControllerBase
    {
        private readonly IShiftEmployeeRepository _shiftEmployeeRepository;

        public ShiftEmployeeController(IShiftEmployeeRepository shiftEmployeeRepository)
        {
            _shiftEmployeeRepository = shiftEmployeeRepository;
        }

        /// <summary>
        /// Gets information about all shift employees
        /// </summary>
        /// <response code="200">Shift employees information returned</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetShiftEmployees")]
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
        [HttpGet("{id}",Name = "GetShiftEmployeeByShiftId")]
        public ActionResult<ShiftEmployee> GetShiftEmployeeByShiftId(Guid id)
        {
            var shiftEmployee = _shiftEmployeeRepository.GetShiftEmployeeByShiftId(id);

            if(shiftEmployee == null) 
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
        [HttpPost(Name = "AssignShiftEmployee")]
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
        [HttpPut("{id}", Name = "UpdateShiftEmployee")]
        public ActionResult<ShiftEmployee> UpdateShiftEmployee(Guid id, UpdateShiftEmployeeDto dto)
        {
            var shiftEmployee = _shiftEmployeeRepository.GetShiftEmployeeByShiftId(id);

            if(shiftEmployee == null)
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
        [HttpDelete("{id}")]
        public ActionResult<ShiftEmployee> DeleteShiftEmployee(Guid id)
        {
            var shiftEmployee = _shiftEmployeeRepository.GetShiftEmployeeByShiftId(id);

            if(shiftEmployee == null)
            {
                return NotFound();
            }

            _shiftEmployeeRepository.DeleteShiftEmployee(shiftEmployee);

            return Ok();
        }
    }
}
