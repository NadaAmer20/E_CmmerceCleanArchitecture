using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Products.Queries.Models;
using E_Commerce.Core.Features.Products.Queries.Results;
using E_Commerce.Core.Features.Reviews.Queries.Models;
using E_Commerce.Core.Features.Reviews.Queries.Results;
using E_Commerce.Data.Entites;
using E_Commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Reviews.Queries.Handlers
{
    public class ReviewQueryHandler : ResponseHandler, IRequestHandler<GetReviewsListQuery, Response<List<GetReviewsListResponse>>>
    {
        #region  Feilds
        private readonly IReviewServices _reviewServices;
        private readonly IMapper _mapper;
        #endregion

        #region  Constructor
        public ReviewQueryHandler(IReviewServices reviewServices,IMapper mapper)
        {
            _reviewServices = reviewServices;
            _mapper = mapper;
        }
        #endregion
        #region  HandleFunction 
        public async Task<Response<List<GetReviewsListResponse>>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var Reviews = await _reviewServices.GetAllReviewsAsync();

            if (Reviews == null)
                return NotFound<List<GetReviewsListResponse>>("Reviews not found");
            var mappedResponse = _mapper.Map<List<GetReviewsListResponse>>(Reviews);
            return Success<List<GetReviewsListResponse>>(mappedResponse);
        }
        #endregion
       
    }
}
