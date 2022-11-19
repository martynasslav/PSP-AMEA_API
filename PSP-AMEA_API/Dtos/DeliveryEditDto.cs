using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
	public class DeliveryEditDto
	{
		[Required]
		public Guid OrderId { get; set; }
		[Required]
		public string Address { get; set; } = "Address";
		[Required]
		public string PostCode { get; set; } = "PostCode";
		[Required]
		public string Details { get; set; } = "Details";
	}
}
