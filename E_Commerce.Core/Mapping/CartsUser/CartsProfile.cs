using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Mapping.CartsUser
{
    public partial class CartsProfile : Profile
    {
        public CartsProfile()
        {
            AddCartMapping();
            GetCartsByUseridMapping();
        }
    }
}
 


