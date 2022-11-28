namespace PSP_AMEA_API.DataModels
{
	public class Item
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = "Title";
		public string Category { get; set; } = "Category";
		public decimal Price { get; set; } = 10.01m;
		public string Description { get; set; } = "Description";
		public string Brand { get; set; } = "Brand";
		public string Photo { get; set; } = "Photo";
		public Guid TenantId { get; set; }
	}
}
