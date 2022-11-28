using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
	public class ReviewEditDto
	{
		[Required]
		public string Description { get; set; } = string.Empty;
		[Required]
		public int Rating { get; set; }
		[Required]
		public string Photo { get; set; } = string.Empty;
	}
}
