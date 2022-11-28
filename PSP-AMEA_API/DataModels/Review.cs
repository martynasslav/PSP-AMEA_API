namespace PSP_AMEA_API.DataModels
{
	public class Review
	{
		public string Description { get; set; } = string.Empty;
		public int Rating { get; set; }
		public string Photo { get; set; } = string.Empty;
		public Guid ItemId { get; set; }
		public Guid UserId { get; set; }
	}
}
