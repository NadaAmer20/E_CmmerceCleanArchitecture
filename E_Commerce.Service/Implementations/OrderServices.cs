using E_Commerce.Data.Entites;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Service.Implementations
{
    public class OrderServices : IOrderServices
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly ApplicationDbContext _context;  
        #endregion

        #region Constructor
        public OrderServices(UserManager<User> userManager, IOrderRepository orderRepository, ApplicationDbContext context)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
            _context = context;
        }
        #endregion

        #region HandleFunctions
        public async Task<string> CancelOrder(int userId, string orderN)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return "Invalid user.";
            }

            var orderDB = await _orderRepository.GetTableNoTracking()
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.OrderNumber == orderN && o.UserId == userId);

            if (orderDB == null)
                return "The order number is invalid.";

            if (DateTime.Now >= orderDB.Date.AddDays(3))
                return "Sorry, you cannot cancel the order after 3 days.";
            for (int index = 0; index < orderDB.Products.Count; index++)
            {
                var product = orderDB.Products[index];
                product.quantity += orderDB.Quantities[index];
            }
            _context.Orders.RemoveRange(orderDB);
            await _context.SaveChangesAsync();
            return "Order canceled successfully.";
        }
        #endregion
    }
}
