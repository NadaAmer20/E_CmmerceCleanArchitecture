using E_Commerce.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Categories.Commands.Models
{
    public class UpdateCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; } 
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? TotalProducts { get; set; }
    }
}
