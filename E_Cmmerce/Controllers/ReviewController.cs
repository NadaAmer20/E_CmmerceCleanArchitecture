using E_Cmmerce.Base;
using E_Commerce.Core.Features.Categories.Commands.Models;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Core.Features.Products.Queries.Models;
using E_Commerce.Core.Features.Reviews.Commands.Models;
using E_Commerce.Core.Features.Reviews.Queries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Cmmerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : AppControllerBase
    {

        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview([FromBody] CreateReviewCommands command)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int userId))
                return BadRequest("Invalid user ID.");

            command.UserId = userId;
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete("delete-review")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteReviewCommand(id));
            return NewResult(response);
        }
        [HttpPut("Edit-Review")]
        public async Task<IActionResult> Edit([FromForm] UpdateReviewCommand command)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
                return BadRequest("Invalid user ID.");
            command.UserId = userId;
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet("GetAllReview")]
        public async Task<IActionResult> GetAllReview()
        {
            var response = await Mediator.Send(new GetReviewsListQuery());
            return NewResult(response);
        }
    }
}
