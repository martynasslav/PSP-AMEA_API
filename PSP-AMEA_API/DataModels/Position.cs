using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.DataModels
{
	public class Position
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = "Name";
		public Guid TenantId { get; set; }
	}
}
