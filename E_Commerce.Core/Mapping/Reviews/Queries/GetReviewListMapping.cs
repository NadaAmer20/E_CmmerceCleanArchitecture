using AutoMapper;
using E_Commerce.Core.Features.Products.Queries.Results;
using E_Commerce.Core.Features.Reviews.Commands.Models;
using E_Commerce.Core.Features.Reviews.Queries.Results;
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
        public void GetReviewListMapping()
        {
                 CreateMap<Review, GetReviewsListResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
            .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
             .ForMember(dest => dest.dateTime, opt => opt.MapFrom(src => src.dateTime))

            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));


        }

    }
}
 


 