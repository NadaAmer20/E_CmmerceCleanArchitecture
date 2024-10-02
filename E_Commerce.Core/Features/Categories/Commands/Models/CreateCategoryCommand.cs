using E_Commerce.Core.Bases;
using E_Commerce.Data.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Commands.Models
{
    public class CreateCategoryCommand : IRequest<Response<string>>
    {
        public IFormFile? File { get; set; }  // Add this line for file upload
        public bool IsDeleted { get; set; }
        public string   Name { get; set; }
        public string? Description { get; set; }
   //     public string? Picture { get; set; }
        public int? TotalProducts { get; set; }
    //    IFormFile file { get; set; }

    }
}
