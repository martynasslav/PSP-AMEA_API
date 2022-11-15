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
		[HttpGet("{id}", Name = "GetEmployee")]
		public Employee GetEmployee(Guid id)
		{
			return new Employee();
		}
		
	}
}
