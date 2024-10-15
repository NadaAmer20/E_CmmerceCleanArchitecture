using E_Cmmerce.Base;
using E_Commerce.Core.Features.Emails.Commands.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Cmmerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : AppControllerBase
    {
        [HttpPost("SendEmail")]
         public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
