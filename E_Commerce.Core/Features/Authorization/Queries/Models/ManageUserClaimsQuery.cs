using E_Commerce.Core.Bases;
using E_Commerce.Data.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResults>>
    {
        public int Id { get; set; }
        public ManageUserClaimsQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
