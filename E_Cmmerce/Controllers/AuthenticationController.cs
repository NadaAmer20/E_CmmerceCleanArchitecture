using E_Cmmerce.Base;
using E_Commerce.Core.Features.Authentication.Commands.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace E_Cmmerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
