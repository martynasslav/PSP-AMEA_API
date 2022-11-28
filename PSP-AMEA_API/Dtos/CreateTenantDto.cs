using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class CreateTenantDto
    {
        [Required]
        public string Name { get; set; } = "Name";
        [Required]
        public DateTime ActiveFrom { get; set; }
        [Required]
        public DateTime ActiveTo { get; set; }
    }
}
