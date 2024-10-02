using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Core.Features.Reviews.Commands.Models;
using E_Commerce.Data.Entites;
using E_Commerce.Service.Abstracts;
using E_Commerce.Service.Implementations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Reviews.Commands.Handlers
{
    public class ReviewCommandHandler : ResponseHandler, IRequestHandler<CreateReviewCommands, Response<string>>,
        IRequestHandler<DeleteReviewCommand, Response<string>>,
           IRequestHandler<UpdateReviewCommand, Response<string>>
    {
        #region Feilds
        private readonly IMapper _mapper;
        private readonly IReviewServices _reviewServices;
        #endregion

        #region Constructor
        public ReviewCommandHandler(IMapper mapper , IReviewServices reviewServices)
        {
            _mapper = mapper;
            _reviewServices = reviewServices;
        }
        #endregion

        #region HandleFunction
        public async Task<Response<string>> Handle(CreateReviewCommands request, CancellationToken cancellationToken)
        {

            var review = _mapper.Map<Review>(request);
            var result = await _reviewServices.CreateReview(review);
            if(result == "Added SuccessFully")
                return Success<string>(result);
            else
                return BadRequest<string>(result); 
        }
        public async Task<Response<string>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewServices.GetByIdAsync(request.Id);
            if (review == null)
                return NotFound<string>("review Not Exsists");
            await _reviewServices.DeleteReviewAsync(review);
            return Deleted<string>("Delete Success");
        }

        public async Task<Response<string>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var existingReview = await _reviewServices.GetByIdAsync(request.Id);

            if (existingReview == null)
                return NotFound<string>("Review Does Not exist");

            var updatedReview = _mapper.Map(request, existingReview);  
            var result = await _reviewServices.EditAsyncReviewAsync(updatedReview);

            return Success<string>(result);
        }

        #endregion

    }
}
