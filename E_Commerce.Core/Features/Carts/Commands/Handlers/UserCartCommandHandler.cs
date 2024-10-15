using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Carts.Commands.Models;
using E_Commerce.Core.Features.Carts.Queries.Results;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Data.Entites;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Service.Abstracts;
using E_Commerce.Service.Implementations;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Commands.Handlers
{
    public class UserCartCommandHandler : ResponseHandler, 
        IRequestHandler<AddCartCommand, Response<string>>,
                IRequestHandler<RemoveCartCommand, Response<string>>


    {
        #region Feilds
        private readonly IMapper _mapper;
        private readonly ICartServices _cartServices;
        private readonly IProductServices _productServices;
        #endregion

        #region Constructor
        public UserCartCommandHandler(IMapper mapper, ICartServices cartServices, IProductServices productServices)
        {
            _mapper = mapper;
            _cartServices = cartServices;
            _productServices = productServices;
        }

        #endregion
        #region HandleFunction
        public async Task<Response<string>> Handle(AddCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartServices.AddToCart(request.UserId, request.ProductId, request.Quantity);

            if (result == "Product not found.")
            {
                return NotFound<string>(result);

            }
            return Success<string>(result);

        }

        public async Task<Response<string>> Handle(RemoveCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartServices.RemoveFromCard(request.ProductId, request.UserId, request.Quantity);

            if (result == "Product not found in cart.")
            {
                return NotFound<string>(result);
            }

            return Success<string>(result);
        }

        #endregion
    }
}
