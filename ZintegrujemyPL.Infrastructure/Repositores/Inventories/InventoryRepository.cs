using System.Collections.Generic;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.DataContexts;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Base;

namespace ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Inventories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(IAppDbContext appDbContext) : base(appDbContext)
        {

        }


        public async Task InsertMany(List<Inventory> inventories)
        {
            var query = @"
                    INSERT INTO dbo.Inventory 
                        (SKU, Quantity, Unit, ShippingCost, ShippingTime) 
                    VALUES 
                        (@SKU, @Quantity, @Unit, @ShippingCost, @ShippingTime);";

            await _appDbContext.Execute(query, inventories);
        }

        public async Task DeleteAll()
        {
            var query = "DELETE FROM dbo.Inventory;";
            await _appDbContext.Execute(query);
        }
    }
}
