using System.Collections.Generic;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Products;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task InsertMany(List<Product> products);
        Task DeleteAll();
        Task<ProductInformation> GetProductInformation(string sku);
    }
}
