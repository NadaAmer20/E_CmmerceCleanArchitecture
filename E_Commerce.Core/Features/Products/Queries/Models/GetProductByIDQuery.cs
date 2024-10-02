using E_Commerce.Core.Features.Categories.Queries.Results;
using E_Commerce.Core.Features.Products.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Queries.Models
{
    public class GetProductByIDQuery : IRequest<Bases.Response<GetSingleProductResponse>>
    {
        public int Id { get; set; }
        public GetProductByIDQuery(int id)
        {
            Id = id;
        }
    }
}
