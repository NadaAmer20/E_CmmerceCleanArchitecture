using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Commands.Models
{
    public class DeleteProductCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
