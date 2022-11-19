using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> reservations = new()
        {
            new Reservation() {OrderId = Guid.NewGuid(), Date = DateTime.Now.AddDays(1), Description = "Description1"},
            new Reservation() {OrderId = Guid.NewGuid(), Date = DateTime.Now.AddDays(2), Description = "Description2"},
            new Reservation() {OrderId = Guid.NewGuid(), Date = DateTime.Now.AddDays(3), Description = "Description3"}
        };

        public Reservation CreateReservation(ReservationDto dto)
        {
            var reservation = new Reservation() {CustomerId = dto.CustomerId, OrderId = dto.OrderId, Date = dto.Date, Description = dto.Description, LocationId = dto.LocationId };
            reservations.Add(reservation);
            return reservation;
        }

        public void UpdateReservation(Reservation reservation)
        {
            var id = reservations.FindIndex(r => r.OrderId == reservation.OrderId);
            reservations[id] = reservation;
        }

        public void DeleteReservation(Reservation reservation)
        {
            reservations.Remove(reservation);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return reservations;
        }

        public Reservation GetReservationByOrderId(Guid id)
        {
            return reservations.Find(r => r.OrderId == id);
        }
    }
}
