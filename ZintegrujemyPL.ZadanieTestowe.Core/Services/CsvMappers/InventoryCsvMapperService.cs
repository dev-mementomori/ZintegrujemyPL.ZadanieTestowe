using CsvHelper;
using ZintegrujemyPL.ZadanieTestowe.Core.CsvClassMaps.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvMappers;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvMappers
{
    public class InventoryCsvMapperService : IInventoryCsvMapperService
    {
        public void Configure(CsvContext csvContext)
        {
            csvContext.RegisterClassMap<InventoryCsvMap>();
        }
    }
}
