using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.DataModels
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string VATCode { get; set; } = "VATCode";
        public string Address { get; set; } = "Address";
        public DateTime CreatedAt { get; set; }
        public DateTime DueTo { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; } = "Name";
        public Guid TenantId { get; set; }
    }
}