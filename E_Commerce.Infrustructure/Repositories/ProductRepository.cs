using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data.Entites;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Infrustructure.InfrustructureBases;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Infrustructure.Repositories
{
    public class ProductRepository: GenericRepositoryAsync<Product>, IProductRepository
    {
         
        #region Fields
        private readonly DbSet<Product> _Products;
        #endregion
        #region Constructor
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _Products = context.Set<Product>();
        }
        #endregion
        #region Handle Function
        //public async Task<List<Product>> GetCategoryListAsync()
        //{
        //    return await _Products.Include(x => x.Images).ToListAsync();

        //}
        #endregion

    }
}
