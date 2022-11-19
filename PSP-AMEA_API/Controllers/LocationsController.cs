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
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsRepository _locationsRepository;

        public LocationsController(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        /// <summary>
        /// Gets information about all available locations.
        /// </summary>
        /// <response code="200">Locations information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetLocations")]
        public IEnumerable<Locations> GetAllLocations()
        {
            return _locationsRepository.GetAllLocations();
        }

        /// <summary>
        /// Gets information about a location from specified location ID.
        /// </summary>
        /// <param name="id">Unique location ID</param>
        /// <response code="200">Location information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = "GetLocation")]
        public ActionResult<Locations> GetLocation(Guid id)
        {
            var location = _locationsRepository.GetLocationById(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <response code="201">Location created.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateLocation")]
        public ActionResult<Locations> CreateLocations(CreateLocationsDto dto)
        {
            var location = _locationsRepository.CreateLocations(dto);
            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        /// <summary>
        /// Updates location's information.
        /// </summary>
        /// <param name="id">Unique location ID</param>
        /// <response code="200">Location information updated.</response>
        [ProducesResponseType(200)]
        [HttpPut("{id}", Name = "UpdateLocation")]
        public ActionResult<Locations> UpdateLocations(Guid id, CreateLocationsDto dto)
        {
            var location = GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }
            Locations updatedLocation = new()
            { Id = id, TenantId = dto.TenantId, Address = dto.Address, WorkingFrom = dto.WorkingFrom, WorkingTo = dto.WorkingTo };

            _locationsRepository.UpdateLocations(updatedLocation);

            return Ok();
        }

        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <param name="id">Unique location ID</param>
        /// <response code="200">Location successfully deleted.</response>
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public ActionResult<Locations> DeleteLocations(Guid id)
        {
            var location = _locationsRepository.GetLocationById(id);

            if (location == null)
            {
                return NotFound();
            }

            _locationsRepository.DeleteLocations(location);

            return Ok();
        }
    }
}