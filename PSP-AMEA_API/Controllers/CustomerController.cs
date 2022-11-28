using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class CustomerController : Controller
    {
        private readonly ICustomerRepository repository;

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

		/// <summary>
		/// Gets information about all customers.
		/// </summary>
		/// <param name="offset">Index offset for the object list.</param>
		/// <param name="limit">Number of objects to return.</param>
		/// <param name="tenantId">Optional filtering by tenant id.</param>
		/// <response code="200">Information about customers returned.</response>
		[ProducesResponseType(200)]
		[HttpGet]
		public IEnumerable<CustomerDto> GetCustomers(int offset = 0, int limit = 20, Guid? tenantId = null)
		{
			var employees = repository.GetCustomers().Select(customer => customer.AsDto());

			if (tenantId != null)
			{
				employees = employees.Where(e => e.TenantId == tenantId);
			}

			return employees.Skip(offset).Take(limit);
		}

		/// <summary>
		/// Gets information a customer.
		/// </summary>
		/// <param name="id">Customer id.</param>
		/// <response code="200">Information about customer returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}", Name = "GetCustomer")]
		public ActionResult<CustomerDto> GetCustomer(Guid id)
		{
			var customer = repository.GetCustomer(id);
			if (customer == null)
			{
				return NotFound();
			}
			return customer.AsDto();
		}

		/// <summary>
		/// Creates a customer.
		/// </summary>
		/// <param name="customerDto">Customer dto.</param>
		/// <response code="200">Customer created.</response>
		[HttpPost]
		public ActionResult<CustomerDto> CreateCustomer(CreateCustomerDto customerDto)
		{
			Customer customer = new()
			{
				FirstName = customerDto.FirstName,
				LastName = customerDto.LastName,
				Id = Guid.NewGuid(),
				TenantId = customerDto.TenantId
			};

			repository.CreateCustomer(customer);

			return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer.AsDto());
		}

		/// <summary>
		/// Upadtes a customer.
		/// </summary>
		/// <param name="id">Customer id.</param>
		/// <param name="customerDto">Customer dto.</param>
		/// <response code="200">Customer updated.</response>
		[HttpPut("{id}")]
		public ActionResult UpdateEmployee(Guid id, UpdateCustomerDto customerDto)
		{
			var existingCustomer = repository.GetCustomer(id);

			if (existingCustomer is null)
			{
				return NotFound();
			}

			Customer updatedCustomer = new()
			{
				Id = id,
				FirstName = customerDto.FirstName,
				LastName = customerDto.LastName,
				TenantId = customerDto.TenantId
			};

			repository.UpdateCustomer(updatedCustomer);

			return Ok();
		}

		/// <summary>
		/// Delete a customer.
		/// </summary>
		/// <param name="id">Customer id.</param>
		/// <response code="200">Customer deleted.</response>
		[HttpDelete("{id}")]
		public ActionResult DeleteCustomer(Guid id)
		{
			var existingCustomer = repository.GetCustomer(id);

			if (existingCustomer is null)
			{
				return NotFound();
			}

			repository.DeleteCustomer(id);

			return Ok();
		}
	}
}
