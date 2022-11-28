using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository repository;

		public EmployeeController(IEmployeeRepository repository)
        {
			this.repository = repository;
        }

		/// <summary>
		/// Gets information about all employees.
		/// </summary>
		/// <param name="offset">Index offset for the object list.</param>
		/// <param name="limit">Number of objects to return.</param>
		/// <param name="tenantId">Optional filtering by tenant id.</param>
		/// <response code="200">Information about employees returned.</response>
		[ProducesResponseType(200)]
		[HttpGet]
		public IEnumerable<EmployeeDto> GetEmployees(int offset = 0, int limit = 20, Guid? tenantId = null)
		{
			var employees = repository.GetEmployees().Select(employee => employee.AsDto());

			if (tenantId != null)
			{
				employees = employees.Where(e => e.TenantId == tenantId);
			}

			return employees.Skip(offset).Take(limit);
		}

		/// <summary>
		/// Gets information about an employee from specified employee identifier.
		/// </summary>
		/// <param name="id">Unique employee identifier</param>
		/// <returns></returns>
		/// <response code="200">Information about an employee returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}", Name = "GetEmployee")]
		public ActionResult<EmployeeDto> GetEmployee(Guid id)
		{
			var employee = repository.GetEmployee(id);
			if(employee == null)
            {
				return NotFound();
            }
			return employee.AsDto();
		}

		/// <summary>
		/// Create an employee.
		/// </summary>
		/// <param name="employeeDto">Employee</param>
		/// <returns></returns>
		/// <response code="200">Employee created.</response>
		[HttpPost]
		public ActionResult<EmployeeDto> CreateEmployee(CreateEmployeeDto employeeDto)
        {
			Employee employee = new()
            {
				FirstName = employeeDto.FirstName,
				LastName = employeeDto.LastName,
				Id = Guid.NewGuid(),
				PersonalCode = employeeDto.PersonalCode,
				Email = employeeDto.Email,
				PositionId = employeeDto.PositionId,
            };

			repository.CreateEmployee(employee);

			return CreatedAtAction(nameof(GetEmployee), new {id = employee.Id}, employee.AsDto());
        }

		/// <summary>
		/// Update an employee.
		/// </summary>
		/// <param name="id">Employee ID</param>
		/// <param name="employeeDto">Employee</param>
		/// <returns></returns>
		/// <response code="200">Employee updated.</response>
		[HttpPut("{id}")]
		public ActionResult UpdateEmployee(Guid id, UpdateEmployeeDto employeeDto)
        {
			var existingEmployee = repository.GetEmployee(id);

			if(existingEmployee is null)
            {
				return NotFound();
            }

			Employee updatedEmployee = new()
            {
				Id = id,
				FirstName = employeeDto.FirstName,
				LastName= employeeDto.LastName,
				Email = employeeDto.Email,
				PositionId= employeeDto.PositionId,
            };

			repository.UpdateEmployee(updatedEmployee);

			return NoContent();
        }

		/// <summary>
		/// Delete an employee.
		/// </summary>
		/// <param name="id">Employee ID</param>
		/// <returns></returns>
		/// <response code="200">Employee deleted.</response>
		[HttpDelete("{id}")]
		public ActionResult DeleteEmployee (Guid id)
        {
			var existingEmployee = repository.GetEmployee(id);

			if (existingEmployee is null)
			{
				return NotFound();
			}

			repository.DeleteEmployee(id);

			return NoContent();
		}
	}
}
