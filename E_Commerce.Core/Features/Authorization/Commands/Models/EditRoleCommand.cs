using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data.Requests;
namespace E_Commerce.Core.Features.Authorization.Commands.Models
{

    public class EditRoleCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
