using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Abstracts
{
    public interface IReviewServices
    {
        public Task<string> CreateReview(Review review);
        public Task<string> DeleteReviewAsync(Review review);
        public Task<string> EditAsyncReviewAsync(Review review);
        public Task<Review> GetByIdAsync(int id);
        public Task<List<Review>> GetAllReviewsAsync();
        public Task<List<Review>> GetAllReviewsForProductAsync(int productId);
    }
}
