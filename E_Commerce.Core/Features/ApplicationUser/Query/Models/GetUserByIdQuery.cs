using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.ApplicationUser.Query.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.ApplicationUser.Query.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
