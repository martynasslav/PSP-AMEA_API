using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP_AMEA_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Gets information about all available reservations.
        /// </summary>
        /// <response code="200">Reservations information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetReservations")]
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        /// <summary>
        /// Gets information about a reservation from specified Order ID.
        /// </summary>
        /// <param name="id">Unique reservation ID</param>
        /// <response code="200">Reservation information returned.</response>
        /// <response code="204">Reservation with specified Order ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("{id}", Name = "GetReservation")]
        public ActionResult<Reservation> GetReservation(Guid id)
        {
            var reservation = _reservationRepository.GetReservationByOrderId(id);

            if (reservation == null)
            {
                return NoContent();
            }

            return reservation;
        }

        /// <summary>
        /// Creates a new reservation.
        /// </summary>
        /// <response code="201">Reservation created.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateReservation")]
        public ActionResult<Reservation> CreateReservation(ReservationDto dto)
        {
            var reservation = _reservationRepository.CreateReservation(dto);
            return CreatedAtAction("GetReservation", new { id = reservation.OrderId }, reservation);
        }

        /// <summary>
        /// Updates reservation's information.
        /// </summary>
        /// <param name="id">Unique Order ID</param>
        /// <response code="200">Reservation information updated.</response>
        /// <response code="404">Reservation with specified Order ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}", Name = "UpdateReservation")]
        public ActionResult<Reservation> UpdateReservation(Guid id, ReservationDto dto)
        {
            var reservation = GetReservation(id);

            if (reservation == null)
            {
                return NotFound();
            }
            Reservation updatedReservation = new()
            {CustomerId = dto.CustomerId, OrderId = id, Date = dto.Date, Description = dto.Description, LocationId = dto.LocationId};

            _reservationRepository.UpdateReservation(updatedReservation);

            return Ok();
        }

        /// <summary>
        /// Cancel a reservation.
        /// </summary>
        /// <param name="id">Unique order ID</param>
        /// <response code="200">Reservation successfully cancelled.</response>
        /// <response code="404">Reservation with specified Order ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public ActionResult<Reservation> DeleteReservation(Guid id)
        {
            var reservation = _reservationRepository.GetReservationByOrderId(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _reservationRepository.DeleteReservation(reservation);

            return Ok();
        }
    }
}