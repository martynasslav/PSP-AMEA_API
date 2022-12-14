using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
	public class CartCreationDto
	{
		[Required]
		public Guid ItemId { get; set; }
		[Required]
		public decimal Quantity { get; set; }
		[Required]
		public decimal Discount { get; set; }
		[Required]
		public string Description { get; set; } = "Description";
	}
}
