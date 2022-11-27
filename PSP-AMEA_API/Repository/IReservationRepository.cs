using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;

namespace PSP_AMEA_API.Repository
{
    public interface IReservationRepository
    {
        Reservation CreateReservation(ReservationDto dto);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationByOrderId(Guid id);
        IEnumerable<Reservation> GetReservationByLocationId(Guid id);
    }
}
