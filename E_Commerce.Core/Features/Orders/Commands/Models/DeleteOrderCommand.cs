using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Orders.Commands.Models
{
    public class DeleteOrderCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; } 
        public string OrderNumber { get; set; }
        public DeleteOrderCommand(int Userid, string name)
        {
            UserId = Userid;
            OrderNumber = name;
        }
    }
}
