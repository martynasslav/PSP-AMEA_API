namespace PSP_AMEA_API.DataModels
{
    public class ShiftType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "Name";
        public Guid TenantId { get; set; }
    }
}
