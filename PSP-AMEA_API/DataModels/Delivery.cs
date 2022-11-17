namespace PSP_AMEA_API.DataModels
{
	public class Delivery
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public string Address { get; set; } = "Address";
		public string PostCode { get; set; } = "PostCode";
		public string Details { get; set; } = "Details";
	}
}
