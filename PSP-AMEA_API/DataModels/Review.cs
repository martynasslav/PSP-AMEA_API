namespace PSP_AMEA_API.DataModels
{
	public class Review
	{
		public string Description { get; set; } = "Description";
		public int Rating { get; set; } = 5;
		public string Photo { get; set; } = "Photo";
		public Guid ItemId { get; set; }
		public Guid UserId { get; set; }
	}
}
