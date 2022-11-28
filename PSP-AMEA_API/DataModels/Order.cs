namespace PSP_AMEA_API.DataModels
{
	public class Order
	{
		public Guid Id { get; set; }
		public Guid CustomerId { get; set; }
		public Guid EmployeeId { get; set; }
		public Guid TenantId { get; set; }
		public decimal Total { get; set; }
		public decimal Tip { get; set; }
		public string DeliveryType { get; set; } = "DeliveryType";
		public DateTime Date { get; set; }
	}
}
