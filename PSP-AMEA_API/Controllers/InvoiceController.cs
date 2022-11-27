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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

		/// <summary>
		/// Gets information about all available invoices.
		/// </summary>
		/// <param name="offset">Amount of entries to skip</param>
		/// <param name="limit">Maximum amount of entries to get</param>
		/// <param name="tenantId">Optional filtering by tenant id.</param>
		/// <response code="200">Invoices information returned.</response>
		[ProducesResponseType(200)]
        [HttpGet(Name = "GetInvoices")]
        public IEnumerable<Invoice> GetAllInvoices(int offset = 0, int limit = 20, Guid? tenantId = null)
        {
            var invoices = _invoiceRepository.GetAllInvoices();

            if (tenantId != null)
            {
                invoices = invoices.Where(i => i.TenantId == tenantId);
            }

            return invoices.Skip(offset).Take(limit);
        }

        /// <summary>
        /// Gets information about an invoice from specified Invoice ID.
        /// </summary>
        /// <param name="id">Unique invoice ID</param>
        /// <response code="200">Invoice information returned.</response>
        /// <response code="204">Invoice with specified ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("{id}", Name = "GetInvoice")]
        public ActionResult<Invoice> GetInvoice(Guid id)
        {
            var invoice = _invoiceRepository.GetInvoiceById(id);
            if (invoice == null)
            {
                return NoContent();
            }
            return invoice;
        }

        /// <summary>
        /// Creates a new invoice.
        /// </summary>
        /// <response code="201">invoice created.</response>
        [ProducesResponseType(201)]
        [HttpPost(Name = "CreateInvoice")]
        public ActionResult<Invoice> CreateInvoice(CreateInvoiceDto dto)
        {
            var invoice = _invoiceRepository.CreateInvoice(dto);
            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }

        /// <summary>
        /// Updates invoice's information.
        /// </summary>
        /// <param name="id">Unique invoice ID</param>
        /// <response code="200">Invoice information updated.</response>
        /// <response code="404">Invoice with specified ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}", Name = "UpdateInvoice")]
        public ActionResult<Invoice> UpdateInvoice(Guid id, CreateInvoiceDto dto)
        {
            var invoice = GetInvoice(id);

            if (invoice == null)
            {
                return NotFound();
            }
            Invoice updatedInvoice = new()
            {Id = id, OrderId = dto.OrderId, VATCode = dto.VATCode, Address = dto.Address, CreatedAt = dto.CreatedAt, DueTo = dto.DueTo, Amount = dto.Amount, Name = dto.Name, TenantId = dto.TenantId};

            _invoiceRepository.UpdateInvoice(updatedInvoice);

            return Ok();
        }

        /// <summary>
        /// Deletes an invoice.
        /// </summary>
        /// <param name="id">Unique invoice ID</param>
        /// <response code="200">Invoice successfully deleted.</response>
        /// <response code="404">Invoice with specified ID not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public ActionResult<Invoice> DeleteInvoice(Guid id)
        {
            var invoice = _invoiceRepository.GetInvoiceById(id);

            if (invoice == null)
            {
                return NotFound();
            }

            _invoiceRepository.DeleteInvoice(invoice);

            return Ok();
        }
    }
}