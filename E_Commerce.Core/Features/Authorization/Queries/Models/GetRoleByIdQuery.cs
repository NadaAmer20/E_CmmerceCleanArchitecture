using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Authorization.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public int Id { get; set; }
        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }

    }
}
