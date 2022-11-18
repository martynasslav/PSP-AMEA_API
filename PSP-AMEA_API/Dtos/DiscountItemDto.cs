using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class DiscountItemDto
    {
        [Required]
        public Guid DisountId { get; set; }
        [Required]
        public Guid ItemId { get; set; }
    }
}
