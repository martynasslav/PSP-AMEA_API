namespace PSP_AMEA_API.DataModels
{
    public class Customer
    {
		public Guid Id { get; set; }
		public string FirstName { get; set; } = "FirstName";
		public string LastName { get; set; } = "LastName";
		public string PhoneNumber { get; set; } = "+370686868";
		public string Email { get; set; } = "myEmail@mail.com";
		public Guid TenantId { get; set; }
	}
}
