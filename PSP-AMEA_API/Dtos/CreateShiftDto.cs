using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class CreateShiftDto
    {
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public DateTime StartsAt { get; set; }
        [Required]
        public DateTime EndsAt { get; set; }
        [Required]
        public Guid Type { get; set; }
        [Required]
        public Guid TenantId { get; set; }
    }
}
