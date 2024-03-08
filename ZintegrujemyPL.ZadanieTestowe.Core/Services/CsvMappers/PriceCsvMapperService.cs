using CsvHelper;
using ZintegrujemyPL.ZadanieTestowe.Core.CsvClassMaps.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvMappers;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvMappers
{
    public class PriceCsvMapperService : IPriceCsvMapperService
    {
        public void Configure(CsvContext csvContext)
        {
            csvContext.RegisterClassMap<PriceCsvMap>();
        }
    }
}
