using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.DataModels
{
	public class Employee
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; } = "FirstName";
		public string LastName { get; set; } = "LastName";
		public string PersonalCode { get; set; } = "PersonalCode";
		public string Email { get; set; } = "myEmail@mail.com";
		public Guid TenantId { get; set; }
		public Guid PositionId { get; set; }
	}
}
