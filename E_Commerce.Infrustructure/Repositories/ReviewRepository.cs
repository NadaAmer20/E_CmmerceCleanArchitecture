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
    public class ReviewRepository :   GenericRepositoryAsync<Review>, IReviewRepository
    {

        #region Fields
        private readonly DbSet<Review> _reviews;
        #endregion
        #region Constructor
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _reviews = context.Set<Review>();
        }
        #endregion
        #region Handle Function
         #endregion

    }
}
