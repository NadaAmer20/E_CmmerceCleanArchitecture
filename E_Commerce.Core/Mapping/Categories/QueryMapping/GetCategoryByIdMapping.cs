using AutoMapper;
using E_Commerce.Core.Features.Categories.Queries.Models;
using E_Commerce.Core.Features.Categories.Queries.Results;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce.Core.Mapping.Categories
{
    public partial class CategoriesProfile : Profile
    {
        public void GetCategoryByIdMapping()
        {
         
            // Map from Category to GetSingleCategoryResponse
            CreateMap<Category, GetSingleCategoryResponse>()
                .ForMember(dest => dest.productResponse, opt => opt.MapFrom(src => src.Products)); // Adjust the property names if necessary

            // Map from Product to ProductResponse
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Item_Name, opt => opt.MapFrom(src => src.Item_Name))
                .ForMember(dest => dest.solditems, opt => opt.MapFrom(src => src.solditems))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.price))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.quantity));

            // Add additional mappings if needed

        }
    }
}
 
   
 