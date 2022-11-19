using System.ComponentModel.DataAnnotations;

namespace PSP_AMEA_API.Dtos
{
	public class OrderDto
	{
		[Required]
		public Guid CustomerId { get; set; }
		[Required]
		public Guid EmployeeId { get; set; }
		[Required]
		public Guid TenantId { get; set; }
		[Required]
		public decimal Total { get; set; }
		[Required]
		public decimal Tip { get; set; }
		[Required]
		public string DeliveryType { get; set; } = "DeliveryType";
		[Required]
		public DateTime Date { get; set; }
	}
}
