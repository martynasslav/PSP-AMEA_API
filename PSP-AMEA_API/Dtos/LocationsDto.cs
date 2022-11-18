namespace PSP_AMEA_API.Dtos
{
    public class LocationsDto
    {
        public Guid LocationId { get; set; }
        public Guid TenantId { get; set; }
        public string Address { get; set; } = "Address";
        public TimeOnly WorkingFrom { get; set; }
        public TimeOnly WorkingTo { get; set; }
    }
}
