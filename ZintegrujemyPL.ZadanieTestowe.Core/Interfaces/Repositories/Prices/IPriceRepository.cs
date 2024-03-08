using System.Collections.Generic;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Prices;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Prices
{
    public interface IPriceRepository : IRepository<Price>
    {
        Task InsertMany(List<Price> prices);
        Task DeleteAll();
    }
}
