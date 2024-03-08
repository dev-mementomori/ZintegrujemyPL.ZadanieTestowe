using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvMappers;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvReaders;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.Csv;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvReaders
{
    public class InventoryCsvReaderService : CsvReaderService, IInventoryCsvReaderService
    {
        public InventoryCsvReaderService(IInventoryCsvConfigurationProvider csvConfigurationProvider, IInventoryCsvMapperService csvMapperService) : base(csvConfigurationProvider, csvMapperService) /*base(inventoryCsvConfigurationProvider, mappingService)*/
        {

        }
    }
}
