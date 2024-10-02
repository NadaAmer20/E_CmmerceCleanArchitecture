using AutoMapper;
using E_Commerce.Core.Features.Products.Queries.Results;
using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce.Core.Mapping.Products
{
    public partial class ProductsProfile : Profile
    {
        public void GetAllProductBySortReviewMapping()
        {
            CreateMap<Product, GetAllProductSortByReviewResponse>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Item_Name, opt => opt.MapFrom(src => src.Item_Name))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.solditems, opt => opt.MapFrom(src => src.solditems))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.quantity))
               .ForMember(dest => dest.averageRate, opt => opt.MapFrom(src => src.averageRate))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images));

        }
    }
}
