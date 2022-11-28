namespace PSP_AMEA_API.Repository
{
    public class UserDto
    {
		public Guid Id { get; set; }
		public string Username { get; set; } = "Username";
		public string Password { get; set; } = "Password";
		public Guid EmoployeeId { get; set; }
		public Guid CustomerId { get; set; }

	}
}
