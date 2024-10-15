using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;
using E_Commerce.Data.Entites.Identity;
namespace E_Commerce.Data.Entites
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("product")]
        public int ProductId { get; set; }
        public virtual Product product { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Item_Name { get; set; }
        public int price { get; set;}
        public string Description { get; set; }
        public int solditems { get; set;}
        public int quantity { get; set;}

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int? averageRate { get; set; }

        public virtual ICollection<UserCart>? usercarts { get; set; }

        public  ICollection<ProductImages>? Images { get; set; }
     
         public ICollection<Review>? Reviews { get; set; }
 

        public ICollection<Order>? Orders { get; set; }

        [ForeignKey("user")]
        public int? UserId { get; set; }
         public User? user { get; set; }
    }
}
