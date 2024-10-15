using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  E_Commerce.Core.Features.Products.Queries.Results;

namespace E_Commerce.Core.Features.Products.Queries.Models
{
    public class GetProductListQuery : IRequest<Response<List<GetProductListResponse>>>
    {

    }
}
