using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class DiscountItemDto
    {
        [Required]
        public Guid ItemId { get; set; }
    }
}
