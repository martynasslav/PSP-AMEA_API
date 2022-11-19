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
    public class TenantController : ControllerBase
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantController(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        /// <summary>
        /// Gets information about all available tenants.
        /// </summary>
        /// <response code="200">Tenants information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet(Name = "GetTenants")]
        public IEnumerable<Tenant> GetAllTenants()
        {
            return _tenantRepository.GetAllTenants();
        }

        /// <summary>
        /// Gets information about a tenant from specified tenant ID.
        /// </summary>
        /// <param name="id">Unique tenant ID</param>
        /// <response code="200">Tenant information returned.</response>
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = "GetTenant")]
        public ActionResult<Tenant> GetTenant(Guid id)
        {
            var tenant = _tenantRepository.GetTenantById(id);

            if (tenant == null)
            {
                return NotFound();
            }

            return tenant;
        }

        /// <summary>
        /// Creates a new tenant.
        /// </summary>
        /// <response code="201">Tenant created.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateTenant")]
        public ActionResult<Tenant> CreateTenant(CreateTenantDto dto)
        {
            var tenant = _tenantRepository.CreateTenant(dto);
            return CreatedAtAction("GetTenant", new {id = tenant.Id}, tenant);
        }

        /// <summary>
        /// Updates tenant's information.
        /// </summary>
        /// <param name="id">Unique tenant ID</param>
        /// <response code="200">Tenant information updated.</response>
        [ProducesResponseType(200)]
        [HttpPut("{id}", Name = "UpdateTenant")]
        public ActionResult<Tenant> UpdateTenant(Guid id, CreateTenantDto dto)
        {
            var tenant = GetTenant(id);

            if (tenant == null)
            {
                return NotFound();
            }
            Tenant updatedTenant = new()
            {Id = id, Name = dto.Name, ActiveFrom = dto.ActiveFrom, ActiveTo = dto.ActiveTo};

            _tenantRepository.UpdateTenant(updatedTenant);

            return Ok();
        }

        /// <summary>
        /// Deletes a tenant.
        /// </summary>
        /// <param name="id">Unique tenant ID</param>
        /// <response code="200">Tenant successfully deleted.</response>
        [ProducesResponseType(200)]
        [HttpDelete("{id}")]
        public ActionResult<Tenant> DeleteTenant(Guid id)
        {
            var tenant = _tenantRepository.GetTenantById(id);

            if (tenant == null)
            {
                return NotFound();
            }

            _tenantRepository.DeleteTenant(tenant);

            return Ok();
        }
    }
}