using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvMappers;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvReaders;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.Csv;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvReaders
{
    public class ProductCsvReaderService : CsvReaderService, IProductCsvReaderService
    {
        public ProductCsvReaderService(IProductCsvConfigurationProvider csvConfigurationProvider, ICsvMapperService csvMapperService) : base(csvConfigurationProvider, csvMapperService) /*base(inventoryCsvConfigurationProvider, mappingService)*/
        {

        }
    }
}
