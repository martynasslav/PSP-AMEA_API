using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
    public class UpdateDiscountItemDto
    {
        [Required]
        public Guid ItemId { get; set; }
    }
}
