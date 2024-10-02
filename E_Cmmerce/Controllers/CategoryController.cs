using E_Cmmerce.Base;
using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
using E_Commerce.Core.Features.Categories.Commands.Models;
using E_Commerce.Core.Features.Categories.Queries.Models;
using E_Commerce.Core.Features.Categories.Queries.Results;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Core.Features.Products.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Cmmerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : AppControllerBase
    {
        //private readonly IWebHostEnvironment _webHostEnvironment;
        //public CategoryController(IWebHostEnvironment webHostEnvironment )
        //{
        //    _webHostEnvironment = webHostEnvironment;
        //}

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Create([FromForm]  CreateCategoryCommand command)
        {
           
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UpdateCategoryCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteCategoryCommand(id));
            return NewResult(response);
        }
      
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            var response = await Mediator.Send(new GetCategoryByIDQuery(id));
            return NewResult(response);
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await Mediator.Send(new GetCategoryListQuery());
            return NewResult(response);
        }
        [HttpGet("GetByname")]
        public async Task<IActionResult> GetByname(string name)
        {
            var response = await Mediator.Send(new GetCategoryByNameQuery(name));
            return NewResult(response);
        }
    }
}
