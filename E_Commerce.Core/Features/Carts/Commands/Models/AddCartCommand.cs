using E_Commerce.Core.Bases;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Data.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Commands.Models
{
    public class AddCartCommand : IRequest<Response<string>>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; } // Added UserId to track who is adding the cart
        public int Quantity { get; set; } = 1; // Default quantity to 1
    }
}
