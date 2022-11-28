﻿using Microsoft.AspNetCore.Mvc;
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

		[ProducesResponseType(200)]
		[HttpGet]
		public IEnumerable<UserDto> GetUsers(int offset = 0, int limit = 20)
		{
			var users = repository.GetUsers().Select(user => user.AsDto());

			return users.Skip(offset).Take(limit);
		}

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