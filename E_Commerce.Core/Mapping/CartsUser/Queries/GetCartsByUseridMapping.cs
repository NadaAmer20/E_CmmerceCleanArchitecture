using AutoMapper;
using E_Commerce.Core.Features.Carts.Queries.Results;
using E_Commerce.Data.Entites;

namespace E_Commerce.Core.Mapping.CartsUser
{
    public partial class CartsProfile : Profile
    {
        public void GetCartsByUseridMapping()
        {
            // Map from UserCart entity to CartItemResponse DTO
            CreateMap<UserCart, CartItemResponse>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Item_Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.price)); 
 
            CreateMap<IEnumerable<UserCart>, GetCartsResponse>()
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Sum(item => item.Product.price * item.Qunatity))) 
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => src.Max(item => item.Date))); 
        }
    }
}
