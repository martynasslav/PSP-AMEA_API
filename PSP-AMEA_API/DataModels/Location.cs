using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.DataModels
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Address { get; set; } = "Address";
        public DateTime WorkingFrom { get; set; }
        public DateTime WorkingTo { get; set; }
    }
}
