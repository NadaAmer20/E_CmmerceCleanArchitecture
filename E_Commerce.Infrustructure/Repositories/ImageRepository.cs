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
    public class ImageRepository : GenericRepositoryAsync<ProductImages>, IImageRepository
    {
        #region Fields
        private readonly DbSet<ProductImages> _productImages;
        #endregion
        #region Constructor
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
            _productImages = context.Set<ProductImages>();
        }
        #endregion
        #region Handle Function
       
        #endregion
    }
}
