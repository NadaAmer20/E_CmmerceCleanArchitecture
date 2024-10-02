﻿using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Commands.Models
{
    public class UpdateProductCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Item_Name { get; set; }
        public int price { get; set; }
        public string? Description { get; set; }
        public int? solditems { get; set; }
        public int? quantity { get; set; }
    }
}
