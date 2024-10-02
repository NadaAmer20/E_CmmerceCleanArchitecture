using E_Commerce.Data.Entites;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Service.Implementations
{
    public class CategoryServices : ICategoryServices
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        #endregion
        #region Constructor
        public CategoryServices(ICategoryRepository  categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion
        #region HandleFunctions
        public async Task<string> CreateCategory(Category category)
        {
            // adding student 

            await _categoryRepository.AddAsync(category);
            return "Added SuccessFully";
        }
        public async Task<string> EditAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            return "Success";
        }
        public async Task<string> DeleteAsync(Category category)
        {
            // do groub of tranactiom or never do any of it
            var Trans = _categoryRepository.BeginTransaction();
            try
            {
               // if (category.Products == null)
             //       context.Categories.Remove(category);
              //  else
               // {
                //    foreach (var product in category.Products)
                //    {
                 //       context.products.Remove(product);
                 //   }
                 //   context.Categories.Remove(category);
                 //   context.SaveChanges();
               //}
                await _categoryRepository.DeleteAsync(category);

                await Trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await Trans.RollbackAsync();
                return "Failed";
            }
        }
        public async Task<List<Category>> GetCategorytListAsync()
        {
            return await _categoryRepository.GetCategoryListAsync();
        }
        public async Task<Category> GetByIdWithIncludeAsync(int id)
        {
            var category = await  _categoryRepository.GetTableNoTracking().Include(x => x.Products)
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return category;
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetTableNoTracking().Include(x=>x.Products)
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return category;
        }

        public async Task<List<Category>> GetByNameAsunc(string name)
        {
            var categories = await _categoryRepository.GetTableNoTracking().Include(x=>x.Products)
                .Where(x=>x.Name.Equals(name)).ToListAsync();
            return categories;
        }

        #endregion
    }
}
