using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Mapping.Reviews
{
    public partial class ReviewsProfile : Profile
    {
        public ReviewsProfile() 
        {
            AddReviewMapping();
            UpdateReviewMapping();
            GetReviewListMapping();
        }
    }
}
