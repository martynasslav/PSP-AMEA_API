namespace PSP_AMEA_API.Dtos
{
    public class LocationDto
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Address { get; set; } = "Address";
        public DateTime WorkingFrom { get; set; }
        public DateTime WorkingTo { get; set; }
    }
}
