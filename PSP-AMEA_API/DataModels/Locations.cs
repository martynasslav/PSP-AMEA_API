using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.DataModels
{
    public class Locations
    {
        public Guid LocationId { get; set; }
        public Guid TenantId { get; set; }
        public string Address { get; set; } = "Address";
        public TimeOnly WorkingFrom { get; set; }
        public TimeOnly WorkingTo { get; set; }
    }
}
