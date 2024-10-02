using AutoMapper;
using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Data.Entites;
using E_Commerce.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace E_Commerce.Core.Mapping.Categories
{
     public partial class CategoriesProfile : Profile
    {
        public void AddCategoryMapping()
        {
            CreateMap<CreateCategoryCommand, Category>();

        }
    }
}
