using CsvHelper.Configuration;
using System.Globalization;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvConfigurations
{
    public class PriceCsvConfigurationProvider : IPriceCsvConfigurationProvider
    {
        public CsvConfiguration GetConfiguration()
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ",",
                TrimOptions = TrimOptions.Trim,
                IgnoreBlankLines = true
            };

            return csvConfiguration;
        }
    }
}
