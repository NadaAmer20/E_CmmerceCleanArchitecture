using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Carts.Queries.Results;
using E_Commerce.Core.Features.Categories.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Queries.Models
{
    public class GetCartsByUserIdQuery : IRequest<Response<GetCartsResponse>>
    {
        public int UserId { get; set; }
        public GetCartsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
