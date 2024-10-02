using E_Commerce.Data.Entites;
using E_Commerce.Data.Helpers;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Repositories;
using E_Commerce.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Implementations
{
    public class ProductServices : IProductServices
    { 
        #region Fields
        private readonly IProductRepository _productRepository;
        private readonly IReviewServices _reviewServices;

        #endregion
        #region Constructor
        public ProductServices(IProductRepository productRepository, IReviewServices reviewServices)/// , ImageRepository imageRepository)
        {
            _productRepository = productRepository;
            _reviewServices = reviewServices;
            // _imageRepository = imageRepository;
        }
        #endregion
        #region HandleFunctions
        public async Task<string> CreateProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            return "Added SuccessFully";
        }

        public async Task<string> DeleteAsync(Product product)
        {
            var Trans = _productRepository.BeginTransaction();
            try
            {
                await _productRepository.DeleteAsync(product);
                await Trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await Trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return "Success";
        }

     
        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetTableNoTracking().Include(x=>x.Images)
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetByName(string name)
        {
            var product = await _productRepository.GetTableNoTracking().Include(x => x.Images)
                          .Where(x => x.Item_Name.Equals(name)).ToListAsync();
            return product;
        }

        public async Task<List<Product>> GetProductListAsync()
        {
            var products = await _productRepository.GetTableNoTracking().Include(x => x.Images).ToListAsync();
            if (!products.Any())
                return null;
            return products;
        }
        public IQueryable<Product> FilterProductPaginatedQuerable(ProductOrderingEnum orderingEnum, string Search)
        {
            var querable = _productRepository.GetTableNoTracking().Include(x => x.Images).AsQueryable();
            if (Search != null)
                querable = querable.Where(x => x.Item_Name.Contains(Search));// || x.price.Contains(Search));
            switch (orderingEnum)
            {
                case ProductOrderingEnum.Id:
                    querable = querable.OrderBy(x => x.Id);
                    break;
                case ProductOrderingEnum.Item_Name:
                    querable = querable.OrderBy(x => x.Item_Name);
                    break;
                default:
                    querable = querable.OrderBy(x => x.price);
                    break;
            }
            return querable;
        }

        public  IQueryable<Product> GetAllProductsQueryable()
        {
            return  _productRepository.GetTableNoTracking().Include(x => x.Images).AsQueryable();
        }

        public async Task<List<Product>> GetAllBySortReviewAsync()
        {
            // Get all products including images and reviews
            var products = await _productRepository.GetTableNoTracking()
                                                   .Include(p => p.Images)
                                                   .Include(p => p.Reviews)
                                                   .ToListAsync();

            // Return empty list if no products are found
            if (!products.Any())
                return new List<Product>();

            // Calculate and assign average rates for each product
            foreach (var product in products)
            {
                if (product.Reviews.Any())
                    product.averageRate = (int)product.Reviews.Average(r => r.Rate);
                else
                    product.averageRate = 0; // If no reviews, set average rate to 0 or a default value
            }

            // Sort products by their average rate in descending order
            return products.OrderByDescending(p => p.averageRate).ToList();
        }


        #endregion

    }
}
