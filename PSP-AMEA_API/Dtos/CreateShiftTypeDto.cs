using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class CreateShiftTypeDto
    {
        [Required]
        public string Name { get; set; } = "Name";
        [Required]
        public Guid TenantId { get; set; }
    }
}
