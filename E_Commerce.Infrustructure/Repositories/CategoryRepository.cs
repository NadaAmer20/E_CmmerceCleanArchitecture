using E_Commerce.Data.Entites;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Infrustructure.InfrustructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrustructure.Repositories
{
    public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
    {
        #region Fields
        private readonly DbSet<Category> _category;
        #endregion
        #region Constructor
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _category = context.Set<Category>();
        }
        #endregion
        #region Handle Function
        public async Task<List<Category>> GetCategoryListAsync()
        {
            return await _category.Include(x => x.Products).ToListAsync();

        }
        #endregion
    }
}
