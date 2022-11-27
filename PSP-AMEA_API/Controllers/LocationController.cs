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
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

		/// <summary>
		/// Gets information about all available locations.
		/// </summary>
		/// <param name="offset">Amount of entries to skip</param>
		/// <param name="limit">Maximum amount of entries to get</param>
		/// <param name="tenantId">Optional filtering by tenant id.</param>
		/// <response code="200">Locations information returned</response>
		[ProducesResponseType(200)]
        [HttpGet(Name = "GetLocations")]
        public IEnumerable<Location> GetAllLocations(int offset = 0, int limit = 20, Guid? tenantId = null)
        {
            var locations = _locationRepository.GetAllLocations();

            if (tenantId != null)
            {
                locations = locations.Where(l => l.TenantId == tenantId);
            }

            return locations.Skip(offset).Take(limit);
        }

        /// <summary>
        /// Gets information about a location from specified location ID.
        /// </summary>
        /// <param name="id">Unique location ID</param>
        /// <response code="200">Location information returned.</response>
        /// <response code="204">Location with specified ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("{id}", Name = "GetLocation")]
        public ActionResult<Location> GetLocation(Guid id)
        {
            var location = _locationRepository.GetLocationById(id);

            if (location == null)
            {
                return NoContent();
            }

            return location;
        }

        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <response code="201">Location created.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateLocation")]
        public ActionResult<Location> CreateLocation(CreateLocationDto dto)
        {
            var location = _locationRepository.CreateLocation(dto);
            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        /// <summary>
        /// Updates location's information.
        /// </summary>
        /// <param name="id">Unique location ID</param>
        /// <response code="200">Location information updated.</response>
        /// <response code="404">Location with specified ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}", Name = "UpdateLocation")]
        public ActionResult<Location> UpdateLocation(Guid id, CreateLocationDto dto)
        {
            var location = GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }
            Location updatedLocation = new()
            { Id = id, TenantId = dto.TenantId, Address = dto.Address, WorkingFrom = dto.WorkingFrom, WorkingTo = dto.WorkingTo };

            _locationRepository.UpdateLocation(updatedLocation);

            return Ok();
        }

        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <param name="id">Unique location ID</param>
        /// <response code="200">Location successfully deleted.</response>
        /// <response code="404">Location with specified ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public ActionResult<Location> DeleteLocation(Guid id)
        {
            var location = _locationRepository.GetLocationById(id);

            if (location == null)
            {
                return NotFound();
            }

            _locationRepository.DeleteLocation(location);

            return Ok();
        }
    }
}