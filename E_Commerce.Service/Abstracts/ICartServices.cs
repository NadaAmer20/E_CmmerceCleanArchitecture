using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Abstracts
{
    public interface ICartServices
    {
         Task<string> AddToCart(int userId, int productId, int quantity);
        Task<IEnumerable<UserCart>> GetCard(int userId);
        Task<decimal> TotalPayment(int userId);
        Task<string> RemoveFromCard(int productID, int userId, int quantity);
    }
}
