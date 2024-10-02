using System.ComponentModel.DataAnnotations.Schema;
using E_Commerce.Data.Entites.Identity;
namespace E_Commerce.Data.Entites
{
    public class UserCart
    {

        public int Id { get; set; }
        public Product Product { get; set; }
        public int? ProductId {get;set;}
        public int Qunatity { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public User user { get; set; }
    }
}
