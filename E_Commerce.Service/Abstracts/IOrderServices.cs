using E_Commerce.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Abstracts
{
    public interface IOrderServices
    {
        //Task<string> CheckOut(int userId);
      //  Task<List<Order>> ViewOrders(int userId);
        Task<string> CancelOrder(int userId, string orderN);
      //  Task<string> TrackOrder(int userId, string orderN);
    }
}
