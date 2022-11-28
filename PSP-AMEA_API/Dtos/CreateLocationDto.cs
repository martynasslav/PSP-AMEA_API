using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class CreateLocationDto
    {
        [Required]
        public Guid TenantId { get; set; }
        [Required]
        public string Address { get; set; } = "Address";
        [Required]
        public DateTime WorkingFrom { get; set; }
        [Required]
        public DateTime WorkingTo { get; set; }
    }
}
