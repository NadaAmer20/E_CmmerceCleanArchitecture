using E_Commerce.Core.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data.Helpers;
using E_Commerce.Core.Features.Products.Queries.Results;
namespace E_Commerce.Core.Features.Products.Queries.Models
{
    public class GetProductPaginatedListQuery : IRequest<PaginatedResult<GetProductPaginatedListResponse>>
        {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ProductOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
