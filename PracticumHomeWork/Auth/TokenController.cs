using Microsoft.AspNetCore.Mvc;
using PracticumHomeWork.Dto.Models;
using PracticumHomeWork.Service.Abstract;

namespace PracticumHomeWork.Auth
{
    [Route("param/api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;

        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost("token")]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequest request)
        {
            var userAgent = Request.Headers["User-Agent"].ToString();
            var result = await tokenManagementService.GenerateTokensAsync(request, DateTime.UtcNow, userAgent);

            if (result is not null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

    }
}
