using E_Commerce.Data.Entites;
using E_Commerce.Infrustructure.InfrustructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrustructure.Abstracts
{
    public interface IOrderRepository : IGenericRepositoryAsync<Order>
    {
    }
}
