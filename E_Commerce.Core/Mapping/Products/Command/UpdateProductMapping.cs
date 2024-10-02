using AutoMapper;
using E_Commerce.Core.Features.Categories.Commands.Validations;
using E_Commerce.Core.Features.Products.Commands.Models;
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
        public void UpdateProduct()
        {

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId)); // Adjust this line based on your actual mapping logic
        }
    }
}
 
 