using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrustructure.InfrustructureBases
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();//no
        void Commit();//no
        void RollBack();//no
        IQueryable<T> GetTableNoTracking();//no
        IQueryable<T> GetTableAsTracking();//no
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);//no
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);//no
        Task DeleteAsync(T entity);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

    }
}