using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data.Entites;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Repositories;
using E_Commerce.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Service.Implementations
{
    public class ImageServices :IImageServices
    {
        #region Fields
        private readonly IImageRepository _imageRepository;
        #endregion
        #region Constructor
        public ImageServices(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        #endregion
        #region HandleFunctions


        public async Task<List<ProductImages>> GetProductImagesByProductIdAsync(int productId)
        {
            // Retrieve images for the specified product from the database
            var images = await _imageRepository.GetTableNoTracking()
                .Where(img => img.ProductId == productId)
                .ToListAsync();
            return images;
        }

        #endregion
    }
}
