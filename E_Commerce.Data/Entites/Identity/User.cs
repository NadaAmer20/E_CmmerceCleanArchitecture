using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Data.Entites.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName  { get; set; }
        public string LastName { get; set; }

        public string? ProfileImage { get; set; }
 
        public string? Address { get; set; }
        public string? Country { get; set; }


        public ICollection<UserCart>? MyCart { get; set; }
        public ICollection<Order>? MyOrders { get; set; } = new List<Order>();
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Product>? products  { get; set; }
        [InverseProperty("user")]
        public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }

    }
}
