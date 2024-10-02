using AutoMapper;
using E_Commerce.Core.Features.Carts.Commands.Models;
using E_Commerce.Data.Entites;

namespace E_Commerce.Core.Mapping.CartsUser
{
    public partial class CartsProfile : Profile
    {
        public void AddCartMapping()
        {
            CreateMap<AddCartCommand, UserCart>()
                .ForMember(dest => dest.Qunatity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}
