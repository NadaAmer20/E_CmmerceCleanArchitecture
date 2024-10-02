
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
    public class OrderRepository : GenericRepositoryAsync<Order>, IOrderRepository
    {
        #region Fields
        private readonly DbSet<Order> _orders;
        #endregion
        #region Constructor
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _orders = context.Set<Order>();
        }
        #endregion
        #region Handle Function
        #endregion
    }
}
