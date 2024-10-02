using E_Commerce.Core.Bases;
using E_Commerce.Data.Entites.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Reviews.Commands.Models
{
    public class CreateReviewCommands : IRequest<Response<string>>
    {
        public string Comment { get; set; }
        public int Rate { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public int ProductId { get; set; }

    }
}
