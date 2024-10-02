using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Reviews.Commands.Models
{
    public class DeleteReviewCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteReviewCommand(int id)
        {
            Id = id;
        }
    }
}
