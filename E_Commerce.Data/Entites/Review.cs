using System.ComponentModel.DataAnnotations.Schema;
using E_Commerce.Data.Entites.Identity;
namespace E_Commerce.Data.Entites
{
    public class Review
    {

        public int Id { get; set; } 
        public string Comment { get; set; }
        public int  Rate { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        
        public int UserId { get; set; }
        public User user { get; set; }

        public int ProductId {  get; set; }

        public Product Product { get; set; }

    }
}
