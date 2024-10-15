using E_Commerce.Core.Features.Categories.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Categories.Queries.Models
{

    public class GetCategoryByIDQuery : IRequest<Bases.Response<GetSingleCategoryResponse>>
    {
        public int Id { get; set; }
        public GetCategoryByIDQuery(int id)
        {
            Id = id;
        }
    }
         
}
