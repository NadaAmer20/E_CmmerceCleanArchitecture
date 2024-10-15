using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Products.Queries.Results;
using E_Commerce.Core.Features.Reviews.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Reviews.Queries.Models
{
    public class GetReviewsListQuery : IRequest<Response<List<GetReviewsListResponse>>>
    {
    }
}
