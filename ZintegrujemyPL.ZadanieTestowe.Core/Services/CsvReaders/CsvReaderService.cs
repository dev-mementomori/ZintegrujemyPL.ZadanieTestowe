using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvMappers;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvReaders;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.Csv
{
    public class CsvReaderService : ICsvReaderService
    {
        private readonly ICsvConfigurationProvider _csvConfigurationProvider;
        private readonly ICsvMapperService _mapperService;

        public CsvReaderService(ICsvConfigurationProvider csvConfigurationProvider, ICsvMapperService mapperService)
        {
            _csvConfigurationProvider = csvConfigurationProvider;
            _mapperService = mapperService;
        }

        public async Task<List<T>> ReadList<T>(string filePath)
        {
            var csvConfiguration = _csvConfigurationProvider.GetConfiguration();

            using (TextReader textReader = new StreamReader(filePath))
            {
                using (var csvReader = new CsvReader(textReader, csvConfiguration))
                {
                    _mapperService.Configure(csvReader.Context);
                    var records = await csvReader.GetRecordsAsync<T>()
                        .ToListAsync();
                    return records;
                }
            }
        }
    }
}
