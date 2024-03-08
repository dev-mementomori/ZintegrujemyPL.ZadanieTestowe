using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Products;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<ProductInformation> GetProductInformation(string sku)
        {
            return await _productRepository.GetProductInformation(sku);
        }
    }
}
