using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Carts.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Queries.Models
{
    public class GetTotalPaymentQuery : IRequest<Response<GetTotalPaymentResponse>>
    {
        public int UserId { get; set; }

        public GetTotalPaymentQuery(int userId)
        {
            UserId = userId;
        }
    }
}
