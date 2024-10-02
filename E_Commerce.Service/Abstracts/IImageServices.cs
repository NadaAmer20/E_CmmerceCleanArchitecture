using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Abstracts
{
    public interface IImageServices
    {
        public Task<List<ProductImages>> GetProductImagesByProductIdAsync(int id);  
    }
}
