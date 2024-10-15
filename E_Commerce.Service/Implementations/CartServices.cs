using E_Commerce.Data.Entites;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Infrustructure.Repositories;
using E_Commerce.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Implementations
{
    public class CartServices : ICartServices
    {


        #region Fields
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<User> _userManager;
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        #endregion
        #region Constructor
        public CartServices(ICartRepository cartRepository, 
            UserManager<User> userManager, IProductRepository productRepository
            , ApplicationDbContext applicationDbContext)
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
            _productRepository = productRepository;
            _applicationDbContext = applicationDbContext;
        }


        #endregion
        #region HandleFunctions

        public async Task<string> AddToCart(int userId, int productId, int quantity)
        {
            var product = await _productRepository.GetTableNoTracking()
                                                  .Where(x => x.Id == productId)
                                                  .FirstOrDefaultAsync();

            if (product == null)
            {
                return "Product not found.";
            }

            var existingCartItem = await _cartRepository.SingleOrDefaultAsync(c => c.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Qunatity += quantity;
                await _cartRepository.UpdateAsync(existingCartItem);
            }
            else
            {
                var userCart = new UserCart
                {
                    ProductId = productId,
                    UserId = userId,
                    Qunatity = quantity,
                    Date = DateTime.Now
                };

                await _cartRepository.AddAsync(userCart);
            }

            await _cartRepository.SaveChangesAsync();
            return "Product added to cart successfully.";
        }
        public async Task<IEnumerable<UserCart>> GetCard(int userId)
        { 
            var cartItems = await _applicationDbContext.UserCarts
                .Include(c => c.Product)   
                .Where(c => c.UserId == userId)
                .ToListAsync();
             
            return cartItems;
        }
        public async Task<decimal> TotalPayment(int userId)
        {
            var cartItems = await _applicationDbContext.UserCarts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
            if (cartItems == null || !cartItems.Any())
            {
                return 0; 
            }

            decimal totalPayment = cartItems.Sum(item => item.Product.price * item.Qunatity);
            return totalPayment ; // Format to 2 decimal places
        }
        public async Task<string> RemoveFromCard(int productId, int userId, int quantity)
        {
            var cartItem = await _applicationDbContext.UserCarts
                .Where(c => c.ProductId == productId && c.UserId == userId)
                .FirstOrDefaultAsync();

            if (cartItem == null)
                return "Product not found in cart.";
            if (cartItem.Qunatity <= quantity)
                _applicationDbContext.UserCarts.Remove(cartItem);
            else
            {
                cartItem.Qunatity -= quantity;
                _applicationDbContext.UserCarts.Update(cartItem);
                await _applicationDbContext.SaveChangesAsync();
            }

            return "Product removed from cart.";
        }

        #endregion
    }
}
