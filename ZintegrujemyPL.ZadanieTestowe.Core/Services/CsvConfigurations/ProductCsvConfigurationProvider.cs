using CsvHelper.Configuration;
using System.Globalization;
using System.Linq;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvConfigurations
{
    public class ProductCsvConfigurationProvider : IProductCsvConfigurationProvider
    {
        public CsvConfiguration GetConfiguration()
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
                TrimOptions = TrimOptions.Trim,
                IgnoreBlankLines = true,
                ShouldSkipRecord = args => args.Row.Parser.Record.All(prp => prp.Contains("__empty_line__"))
            };

            return csvConfiguration;
        }
    }
}
