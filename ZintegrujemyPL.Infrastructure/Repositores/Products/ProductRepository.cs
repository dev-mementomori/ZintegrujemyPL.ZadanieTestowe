using System.Collections.Generic;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.DataContexts;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Products;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Base;

namespace ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Products
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IAppDbContext appDbContext) : base(appDbContext)
        {

        }


        public async Task InsertMany(List<Product> products)
        {
            var query = @"
                    INSERT INTO dbo.Products 
                        (SKU, Name, EAN, ProducerName, Category, DefaultImage, IsWire) 
                    VALUES 
                        (@SKU, @Name, @EAN, @ProducerName, @Category, @DefaultImage, @IsWire);";

            await _appDbContext.Execute(query, products);
        }

        public async Task DeleteAll()
        {
            var query = "DELETE FROM dbo.Products;";
            await _appDbContext.Execute(query);
        }

        public async Task<ProductInformation> GetProductInformation(string sku)
        {
            var query = @"
                SELECT 
                    Q.Name,
                    Q.EAN,
                    Q.ProducerName,
                    Q.Category,
                    Q.DefaultImage AS DefaultImageURL,
                    Q1.Quantity AS QuantityInStock,
                    Q1.Unit AS Unit,
                    Q2.NettProductPriceAfterDiscountForProductLogisticUnit,
                    Q1.ShippingCost
                FROM 
                    dbo.Products Q
                JOIN 
                    dbo.Inventory Q1 ON Q.SKU = Q1.SKU
                JOIN 
                    dbo.Prices Q2 ON Q.SKU = Q2.ProductSKU
                WHERE 
                    Q.SKU = @SKU;";

            return await _appDbContext.QueryFirstOrDefault<ProductInformation>(query, new { SKU = sku });
        }
    }
}
