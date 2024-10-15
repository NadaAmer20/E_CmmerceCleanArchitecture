using E_Commerce.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Commands.Models
{
    public class CreateProductCommand : IRequest<Response<string>>
    {
        public int CategoryId{ get; set; }
        public string Item_Name { get; set; }
        public int price { get; set; }
        public string? Description { get; set; }
        public int? solditems { get; set; }
        public int? quantity { get; set; }
        public List<IFormFile>? File { get; set; }  // Add this line for file upload
    }
}
