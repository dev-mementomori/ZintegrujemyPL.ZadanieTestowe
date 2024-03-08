using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Products;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Products
{
    public interface IProductService
    {
        Task<ProductInformation> GetProductInformation(string sku);
    }
}
