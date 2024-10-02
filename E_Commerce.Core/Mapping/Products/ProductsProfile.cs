using AutoMapper;
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
        public ProductsProfile() 
        {
            AddProductMapping();
            UpdateProduct();
            GetProductListMapping();
            GetProductByIdMapping();
            GetAllProductBySortReviewMapping();
        }
    }
}
