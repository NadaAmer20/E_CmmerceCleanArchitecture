using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Abstracts
{
    public interface ICategoryServices
    {
        public Task<string> CreateCategory(Category category);
        public Task<string> DeleteAsync(Category category);
        public Task<string> EditAsync(Category category);
        public Task<Category> GetByIdAsync(int id);   
        public Task<Category> GetByIdWithIncludeAsync(int id);
        public Task<List<Category>> GetCategorytListAsync();
        public Task<List<Category>> GetByNameAsunc(string name);


    }
}
