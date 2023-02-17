using Microsoft.AspNetCore.Mvc;
using PracticumHomeWork.DTOs;
using PracticumHomeWork.Services;

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
            var users = await _userService.GetUsers();

            return Ok(users);
        }



        [HttpGet("api/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.getUserByEmail(email);

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserModel user)
        {
            await _userService.AddUser(user);

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserModel updatedUser)
        {

            await _userService.UpdateUser(id, updatedUser);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            await _userService.DeleteUser(id);

            return NoContent();
        }

    }
}
