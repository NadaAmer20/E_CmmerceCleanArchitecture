using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Data.Entites;


namespace E_Commerce.Core.Mapping.Products
{
    public partial class ProductsProfile : Profile  
    {
        public void AddProductMapping()
        {
          
                CreateMap<CreateProductCommand, Product>()
                    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId)); // Adjust this line based on your actual mapping logic
        }
    }
}
