using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Infrustructure.InfrustructureBases;
using E_Commerce.Data.Entites;
namespace E_Commerce.Infrustructure.Abstracts
{
    public interface IProductRepository : IGenericRepositoryAsync<Product>
    {
    }
}
