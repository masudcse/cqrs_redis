using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application.DTOs.Setup;
using Payroll.Application.InterfaceService.Setup;

namespace Payroll.API.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTOs request)
        {
            var response = await _authService.AuthenticateAsync(request);
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}
