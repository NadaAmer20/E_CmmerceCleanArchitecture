using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Orders.Commands.Models;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Orders.Commands.Handlers
{
    public class OrderCommandHandler : ResponseHandler,
        IRequestHandler<DeleteOrderCommand, Response<string>>
    {
        #region Fields
        private readonly IOrderServices _orderServices;
        private readonly UserManager<User> _userManager; // UserManager to fetch user details
        #endregion

        #region Constructor
        public OrderCommandHandler(IOrderServices orderServices, UserManager<User> userManager)
        {
            _orderServices = orderServices;
            _userManager = userManager; // Initialize the UserManager
        }
        #endregion

        #region HandleFunction
        public async Task<Response<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderServices.CancelOrder(request.UserId, request.OrderNumber);
            if (result == "The order number is invalid.")
                return NotFound<string>(result);
            if (result == "Sorry, you cannot cancel the order after 3 days.")
                return BadRequest<string>(result);
            return Success<string>(result);
        }
        #endregion
    }
}
