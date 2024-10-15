using E_Commerce.Data.Entites;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Repositories;
using E_Commerce.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Implementations
{
    public class ReviewServices : IReviewServices
    {
        #region Fields
        private readonly IReviewRepository _reviewRepository;
        #endregion


        #region Constructor
        public ReviewServices(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        #endregion
        #region HandleFunctions
        public async Task<string> CreateReview(Review review)
        {
            await _reviewRepository.AddAsync(review);
            return "Added SuccessFully";
        }

        public async Task<string> DeleteReviewAsync(Review review)
        {
              var Trans = _reviewRepository.BeginTransaction();
            try
            {
                await _reviewRepository.DeleteAsync(review);
                await Trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await Trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsyncReviewAsync(Review review)
        {
            var existingReview = await GetByIdAsync(review.Id);  
            if (existingReview == null)
                return "Review Does Not exist";

            await _reviewRepository.UpdateAsync(review);
            return "Success";
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetTableNoTracking()
                          .ToListAsync();
         //   List<Review> reviewss = await _reviewRepository.GetTableNoTracking()
           //     .Where(r => r.ServicId == rest.RestaurantId).ToList();


           // if (reviews.Any())
            //{
             //   int averageRate = (int)reviews.Average(r => r.Rating);
               // rest.averageRate = averageRate;
                if (!reviews.Any())
                return null;
            return reviews;
        }

        public async Task<List<Review>> GetAllReviewsForProductAsync(int productId)
        {
            var reviews = await _reviewRepository.GetTableNoTracking()
                          .Where(x => x.ProductId.Equals(productId)).ToListAsync();
            return reviews;
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            var review = await _reviewRepository.GetTableNoTracking()
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return review;
        }
        #endregion

    }
}
