using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Products.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Queries.Models
{
    public class GetProductByNameQuery : IRequest<Response<List<GetProductListResponse>>>
    {
        public string Name { get; set; }
        public GetProductByNameQuery(string name)
        {
            Name = name;
        }
    }
}
