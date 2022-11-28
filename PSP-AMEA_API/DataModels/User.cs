namespace PSP_AMEA_API.DataModels
{
    public class User
    {
		public Guid Id { get; set; }
		public string Username { get; set; } = "Username";
		public string Password { get; set; } = "Password";
		public Guid EmoployeeId { get; set; }
		public Guid CustomerId { get; set; }
	}
}
