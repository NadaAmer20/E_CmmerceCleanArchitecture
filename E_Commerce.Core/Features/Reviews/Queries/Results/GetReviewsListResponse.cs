using E_Commerce.Data.Entites.Identity;
using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Reviews.Queries.Results
{
    public class GetReviewsListResponse
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public DateTime dateTime { get; set; } 

        public int UserId { get; set; }

        public int ProductId { get; set; }

    }
}
