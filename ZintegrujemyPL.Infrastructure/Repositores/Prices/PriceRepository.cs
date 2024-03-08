using System.Collections.Generic;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.DataContexts;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Prices;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Base;

namespace ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Prices
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {
        public PriceRepository(IAppDbContext appDbContext) : base(appDbContext)
        {

        }


        public async Task InsertMany(List<Price> prices)
        {
            var query = @"
                    INSERT INTO dbo.Prices 
                        (ProductSKU, NettProductPriceAfterDiscountForProductLogisticUnit) 
                    VALUES 
                        (@ProductSKU, @NettProductPriceAfterDiscountForProductLogisticUnit);";

            await _appDbContext.Execute(query, prices);
        }

        public async Task DeleteAll()
        {
            var query = "DELETE FROM dbo.Prices;";
            await _appDbContext.Execute(query);
        }
    }
}
