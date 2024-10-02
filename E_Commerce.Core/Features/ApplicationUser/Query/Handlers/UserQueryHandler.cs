using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.ApplicationUser.Query.Models;
using E_Commerce.Core.Features.ApplicationUser.Query.Results;
using E_Commerce.Core.Wrapper;
using E_Commerce.Data.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.ApplicationUser.Query.Handlers
{
    public class UserQueryHandler : ResponseHandler,
         IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserQueryHandler(  IMapper mapper,
                                  UserManager<User> userManager) 
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region Handle Functions       
        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<GetUserByIdResponse>("NotFound");
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }
        #endregion
    }
}