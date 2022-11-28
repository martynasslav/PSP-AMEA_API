using Microsoft.AspNetCore.Mvc;
using PSP_AMEA_API.DataModels;
using PSP_AMEA_API.Dtos;
using PSP_AMEA_API.Repository;

namespace PSP_AMEA_API.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class UserController : Controller
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

		/// <summary>
		/// Gets information about all users.
		/// </summary>
		/// <param name="offset">Index offset for the object list.</param>
		/// <param name="limit">Number of objects to return.</param>
		/// <response code="200">Information about users returned.</response>
		[ProducesResponseType(200)]
		[HttpGet]
		public IEnumerable<UserDto> GetUsers(int offset = 0, int limit = 20)
		{
			var users = repository.GetUsers().Select(user => user.AsDto());

			return users.Skip(offset).Take(limit);
		}

		/// <summary>
		/// Gets information about a user.
		/// </summary>
		/// <param name="id">User id.</param>
		/// <response code="200">Information about user returned.</response>
		[ProducesResponseType(200)]
		[HttpGet("{id}", Name = "GetUser")]
		public ActionResult<UserDto> GetUser(Guid id)
		{
			var user = repository.GetUser(id);
			if (user == null)
			{
				return NotFound();
			}
			return user.AsDto();
		}

		/// <summary>
		/// Creates a user.
		/// </summary>
		/// <param name="userDto">User dto.</param>
		/// <response code="200">User created.</response>
		[HttpPost]
		public ActionResult<UserDto> CreateUser(CreateUserDto userDto)
		{
			User user = new()
			{
				Username = userDto.Username,
				Password = userDto.Password,
				Id = Guid.NewGuid(),
			};

			repository.CreateUser(user);

			return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user.AsDto());
		}

		/// <summary>
		/// Update a user.
		/// </summary>
		/// <param name="id">User id.</param>
		/// <param name="userDto">User dto.</param>
		/// <response code="200">Information about user updated.</response>
		[HttpPut("{id}")]
		public ActionResult UpdateUser(Guid id, UpdateUserDto userDto)
		{
			var existingUser = repository.GetUser(id);

			if (existingUser is null)
			{
				return NotFound();
			}

			User updatedUser = new()
			{
				Id = id,
				Username = userDto.Username,
				Password = userDto.Password
			};

			repository.UpdateUser(updatedUser);

			return NoContent();
		}

		/// <summary>
		/// Delete a user.
		/// </summary>
		/// <param name="id">User id.</param>
		/// <response code="200">User Deleted.</response>
		[HttpDelete("{id}")]
		public ActionResult DeleteUser(Guid id)
		{
			var existingUser = repository.GetUser(id);

			if (existingUser is null)
			{
				return NotFound();
			}

			repository.DeleteUser(id);

			return NoContent();
		}
	}
}
