namespace PSP_AMEA_API.Repository
{
    public class EmployeeDto
    {
		public Guid Id { get; set; }
		public string FirstName { get; set; } = "FirstName";
		public string LastName { get; set; } = "LastName";
		public string PersonalCode { get; set; } = "PersonalCode";
		public string Email { get; set; } = "myEmail@mail.com";
		public Guid TenantId { get; set; }
		public Guid PositionId { get; set; }
		
	}
}
