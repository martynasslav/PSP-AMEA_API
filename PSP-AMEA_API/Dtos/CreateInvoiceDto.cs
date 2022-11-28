using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class CreateInvoiceDto
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public string VATCode { get; set; } = "VATCode";
        [Required]
        public string Address { get; set; } = "Address";
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime DueTo { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Name { get; set; } = "Name";
        [Required]
        public Guid TenantId { get; set; }
    }
}
