using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
	public class PaymentCreationDto
	{
		[Required]
		public string Provider { get; set; } = "Provider";
		[Required]
		public string Status { get; set; } = "Status";
	}
}
