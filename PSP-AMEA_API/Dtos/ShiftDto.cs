namespace PSP_AMEA_API.Dtos
{
    public class ShiftItemDto
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public TimeOnly StartsAt { get; set; }
        public TimeOnly EndsAt { get; set; }
        public Guid Type { get; set; }
        public Guid TenantId { get; set; }
    }
}
