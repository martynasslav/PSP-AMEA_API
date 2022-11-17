namespace PSP_AMEA_API.DataModels
{
	public class Cart
	{
		public Guid ItemId { get; set; }
		public Guid OrderId { get; set; }
		public decimal Quantity { get; set; }
		public decimal Discount { get; set; }
		public string Description { get; set; } = "Description";
	}
}
