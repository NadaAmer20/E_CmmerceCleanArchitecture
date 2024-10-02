using E_Cmmerce.Base;
using E_Commerce.Core.Features.Categories.Commands.Models;
using E_Commerce.Core.Features.Categories.Queries.Models;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Core.Features.Products.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace E_Cmmerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]

    public class ProductController : AppControllerBase
    {

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
        {

            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("EditProduct")]
        public async Task<IActionResult> Edit([FromForm] UpdateProductCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteProductCommand(id));
            return NewResult(response);
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var response = await Mediator.Send(new GetProductListQuery());
            return NewResult(response);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var response = await Mediator.Send(new GetProductByIDQuery(id));
            return NewResult(response);
        }
        [HttpGet("GetByname")]
        public async Task<IActionResult> GetByname(string name)
        {
            var response = await Mediator.Send(new GetProductByNameQuery(name));
            return NewResult(response);
        }
        [HttpGet("ProductsPaginated")]
        public async Task<IActionResult> Paginated([FromQuery] GetProductPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("GetAllProductBySortReview")]
        public async Task<IActionResult> GetAllProductBySortReview()
        {
            var response = await Mediator.Send(new GetAllProductSortByReviewQuery());
            return NewResult(response);
        }
    }
}
