using AutoMapper;
using E_Commerce.Core.Features.Reviews.Commands.Models;
using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Mapping.Reviews
{
    public partial class ReviewsProfile : Profile
    {
        public void UpdateReviewMapping()
        {
            CreateMap<UpdateReviewCommand, Review>();
        }

    }
}
