using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using E_Commerce.Data.Entites.Identity;

namespace E_Commerce.Data.Entites
{ 
    public class Order
    {
        
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        [NotMapped] 
        public List<int> Quantities { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
  
        [ForeignKey("user")]
        public int UserId { get; set; }
        public User user { get; set; }
        public double Price { get; set; }
        public string OrderNumber { get; set; }
        public bool IsDelivered => DateTime.Now >= Date.AddDays(9);
    }
}
