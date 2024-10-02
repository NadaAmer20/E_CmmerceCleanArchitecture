using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Mapping.Categories
{
    public partial class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
               AddCategoryMapping();
               UpdateCategoryCommandMapping();
            GetCategoryByIdMapping();
            GetCategoryListMapping();
        }
    }
     
}
