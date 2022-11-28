namespace PSP_AMEA_API.Dtos
{
    public class ReservationDto
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = "Description";
        public Guid LocationId { get; set; }
    }
}