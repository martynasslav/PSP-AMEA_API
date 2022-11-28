using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
	public class ItemEditDto
	{
		[Required]
		public string Title { get; set; } = string.Empty;
		[Required]
		public string Category { get; set; } = string.Empty;
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string Description { get; set; } = string.Empty;
		[Required]
		public string Brand { get; set; } = string.Empty;
		[Required]
		public string Photo { get; set; } = string.Empty;
		[Required]
		public Guid TenantId { get; set; }
	}
}
