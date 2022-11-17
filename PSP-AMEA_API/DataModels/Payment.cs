namespace PSP_AMEA_API.DataModels
{
	public class Payment
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public string Provider { get; set; } = "Provider";
		public string Status { get; set; } = "Status";

	}
}
