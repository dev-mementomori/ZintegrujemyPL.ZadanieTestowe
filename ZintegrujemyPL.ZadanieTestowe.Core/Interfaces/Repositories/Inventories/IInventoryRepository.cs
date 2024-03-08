using System.Collections.Generic;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Inventories;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Inventories
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task InsertMany(List<Inventory> prices);
        Task DeleteAll();
    }
}
