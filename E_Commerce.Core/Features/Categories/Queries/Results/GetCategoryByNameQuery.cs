using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Products.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Categories.Queries.Results
{
    public class GetCategoryByNameQuery: IRequest<Response<List<GetCategoryListResponse>>>
    {
        public string Name { get; set; }
        public GetCategoryByNameQuery(string name)
        {
            Name = name;
        }
    }
}
