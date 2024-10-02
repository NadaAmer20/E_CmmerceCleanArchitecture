using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Commands.Models
{
    public class RemoveCartCommand : IRequest<Response<string>>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }    
        public int Quantity { get; set; } 
    }
}
