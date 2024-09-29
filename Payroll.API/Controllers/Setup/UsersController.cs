using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application.Users.Commands;
using Payroll.Application.Users.Query;

namespace Payroll.API.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public UsersController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpPost("users")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var userId = await _mediatR.Send(command);
            return Ok(userId);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUser()
        {
            var user =await _mediatR.Send(new GetUserListQuery());
            return Ok(user);
        }
    }
}
