using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
	public class PaymentEditDto
	{
		[Required]
		public Guid OrderId { get; set; }
		[Required]
		public string Provider { get; set; } = "Provider";
		[Required]
		public string Status { get; set; } = "Status";
	}
}
