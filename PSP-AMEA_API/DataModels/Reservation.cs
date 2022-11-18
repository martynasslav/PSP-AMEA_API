using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.DataModels
{
    public class Reservation
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = "Description";
        public Guid LocationId { get; set; }
    }
}
