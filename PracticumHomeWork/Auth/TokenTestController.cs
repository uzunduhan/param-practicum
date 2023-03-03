using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticumHomeWork.Base.Types;
using System.Security.Claims;

namespace PracticumHomeWork.Auth
{
    [Route("param/api/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {
        public TokenTestController()
        {
        }


        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "No Token";
        }

        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "Authorize";
        }

        [HttpGet("Admin")]
        [Authorize(Roles = Role.Admin)]
        public string Admin()
        {
            return "Admin";
        }

        [HttpGet("Viewer")]
        [Authorize(Roles = Role.Viewer)]
        public string Viewer()
        {
            return "Viewer";
        }


        [HttpGet("AdminViewer")]
        [Authorize(Roles = $"{Role.Admin},{Role.Viewer}")]
        public string AdminViewer()
        {
            var userRole = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;

            return "AdminViewer";
        }
    }
}
