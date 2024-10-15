using E_Commerce.Data.Entites;
using E_Commerce.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Abstracts
{
    public interface IProductServices
    {
        public Task<string> CreateProduct(Product product);
        public Task<string> DeleteAsync(Product product);
        public Task<string> EditAsync(Product product);
        public Task<Product> GetByIdAsync(int id);
        public Task<List<Product>> GetByName(string name);
        // public Task<Product> GetByIdWithIncludeAsync(int id);
        public Task<List<Product>> GetProductListAsync();
        //    public Task<List<ProductImages>> GetProductImagesByProductIdAsync(int productId);
        public IQueryable<Product> GetAllProductsQueryable();
        public IQueryable<Product> FilterProductPaginatedQuerable(ProductOrderingEnum orderingEnum, string Search);
        public Task<List<Product>> GetAllBySortReviewAsync();

    }
}
