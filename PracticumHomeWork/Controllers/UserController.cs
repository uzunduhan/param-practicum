using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.Validations;

namespace PracticumHomeWork.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }



        [HttpGet("api/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.getUserByEmail(email);

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            UserDtoValidator validator = new UserDtoValidator();
            validator.ValidateAndThrow(user);

            await _userService.InsertAsync(user);

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto updatedUser)
        {
            UserDtoValidator validator = new UserDtoValidator();
            validator.ValidateAndThrow(updatedUser);

            await _userService.UpdateAsync(id, updatedUser);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            await _userService.RemoveAsync(id);

            return NoContent();
        }

    }
}
