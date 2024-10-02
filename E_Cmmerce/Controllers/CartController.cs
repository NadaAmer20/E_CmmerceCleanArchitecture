using E_Cmmerce.Base;
using E_Commerce.Core.Features.Carts.Commands.Models;
using E_Commerce.Core.Features.Carts.Queries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_Cmmerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : AppControllerBase
    {


        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddToCart([FromBody] AddCartCommand command)
        {
            if (command == null || command.ProductId == 0)
            {
                return BadRequest("Invalid product data.");
            }
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId)) 
            {
                return BadRequest("Invalid user ID.");
            }
            command.UserId = userId; 
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet("get-cart")]
        public async Task<IActionResult> GetCart()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            // Log the value of userIdClaim for debugging purposes

            if (!int.TryParse(userIdClaim, out int userId))
            {
                return BadRequest("Invalid user ID.");
            }

            // Pass the userId to the constructor
            var query = new GetCartsByUserIdQuery(userId);
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet("total-payment")]
        public async Task<IActionResult> GetTotalPayment()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
            {
                return BadRequest("Invalid user ID.");
            }
            var query = new GetTotalPaymentQuery(userId);
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpDelete("remove-from-cart")]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveCartCommand command)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
            {
                return BadRequest("Invalid user ID.");
            }
            command.UserId = userId;
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}