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
    public class CartRepository: GenericRepositoryAsync<UserCart>, ICartRepository
    {
        #region Fields
        private readonly DbSet<UserCart> _userCarts;
        #endregion
        #region Constructor
        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _userCarts = context.Set<UserCart>();
        }
        #endregion
        #region Handle Function
        #endregion
    }
}
