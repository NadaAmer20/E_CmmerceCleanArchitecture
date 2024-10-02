using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Carts.Queries.Models;
using E_Commerce.Core.Features.Carts.Queries.Results;
using E_Commerce.Core.Features.Categories.Queries.Results;
using E_Commerce.Service.Abstracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Queries.Handlers
{
    public class CartsQueryHandler : ResponseHandler,
        IRequestHandler<GetCartsByUserIdQuery, Response<GetCartsResponse>>,
         IRequestHandler<GetTotalPaymentQuery, Response<GetTotalPaymentResponse>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ICartServices _cartServices; // Injecting the CartServices

        #endregion

        #region Constructor
        public CartsQueryHandler(IMapper mapper, ICartServices cartServices)
        {
            _mapper = mapper;
            _cartServices = cartServices; // Initialize the CartServices
        }

        public async Task<Response<GetCartsResponse>> Handle(GetCartsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cartItems = await _cartServices.GetCard(request.UserId);
            var cartResponse = _mapper.Map<GetCartsResponse>(cartItems);
         //   return Response<GetCartsResponse>.Success(cartResponse);
            return Success<GetCartsResponse>(cartResponse);
        }
        public async Task<Response<GetTotalPaymentResponse>> Handle(GetTotalPaymentQuery request, CancellationToken cancellationToken)
        {
            // Get total payment for the user
            var totalPayment = await _cartServices.TotalPayment(request.UserId);
            var response = new GetTotalPaymentResponse(totalPayment);
          //  return Response<GetTotalPaymentResponse>.Success(response);
            return Success<GetTotalPaymentResponse>(response);

        }

        #endregion
    }
}
