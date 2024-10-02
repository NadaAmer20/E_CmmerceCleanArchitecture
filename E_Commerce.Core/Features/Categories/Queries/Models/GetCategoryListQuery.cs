using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Categories.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Categories.Queries.Models
{        public class GetCategoryListQuery : IRequest<Response<List<GetCategoryListResponse>>>
    {
        // Add any query parameters if needed
    }


}
