using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		/// <summary>
		/// Gets information about an employee from specified employee identifier.
		/// </summary>
		/// <param name="id">Unique employee identifier</param>
		/// <returns></returns>
		/// <response code="200">Information about an employee returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}", Name = "GetEmployee")]
		public Employee GetEmployee(Guid id)
		{
			return new Employee();
		}
	}
}
