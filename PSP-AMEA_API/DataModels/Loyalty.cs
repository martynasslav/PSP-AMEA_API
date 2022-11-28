namespace PSP_AMEA_API.DataModels
{
    public class Loyalty
    {
		public Guid Id { get; set; }
		public string Name { get; set; } = "Loyalty Program";
		public string Description { get; set; } = "Description";
		public Guid TenantId { get; set; }
	}
}
