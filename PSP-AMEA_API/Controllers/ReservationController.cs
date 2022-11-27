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
        /// <param name="offset">Amount of entires to skip</param>
        /// <param name="limit">Maximum amount of entries to get</param>
        /// <response code="200">Reservations information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetReservations")]
        public IEnumerable<Reservation> GetAllReservations(int offset = 0, int limit = 20)
        {
            return _reservationRepository.GetAllReservations(offset, limit);
        }

        /// <summary>
        /// Gets information about a reservation from specified Order ID.
        /// </summary>
        /// <param name="id">Unique reservation Order ID</param>
        /// <response code="200">Reservation information returned.</response>
        /// <response code="204">Reservation with specified Order ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("Order/{id}", Name = "GetReservationByOrderId")]
        public ActionResult<Reservation> GetReservationByOrderId(Guid id)
        {
            var reservation = _reservationRepository.GetReservationByOrderId(id);

            if (reservation == null)
            {
                return NoContent();
            }

            return reservation;
        }

        /// <summary>
        /// Gets information about a reservation from specified Location ID.
        /// </summary>
        /// <param name="id">Unique reservation Location ID</param>
        /// <response code="200">Reservation information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet("Location/{id}", Name = "GetReservationByLocationId")]
        public IEnumerable<Reservation> GetReservationByLocationId(Guid id)
        {
            var reservation = _reservationRepository.GetReservationByLocationId(id);
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
            var reservation = GetReservationByOrderId(id);

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