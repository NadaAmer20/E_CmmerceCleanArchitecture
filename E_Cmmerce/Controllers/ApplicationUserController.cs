using E_Cmmerce.Base;
using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Core.Features.ApplicationUser.Command.Models;
using Microsoft.AspNetCore.Components.Routing;
using E_Commerce.Core.Features.ApplicationUser.Query.Models;
namespace E_Cmmerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UpdateUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByID( int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }
    }
}
