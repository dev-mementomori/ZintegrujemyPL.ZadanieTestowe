using CsvHelper.Configuration;
using System.Globalization;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvConfigurations
{
    public class InventoryCsvConfigurationProvider : IInventoryCsvConfigurationProvider
    {
        public CsvConfiguration GetConfiguration()
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                TrimOptions = TrimOptions.Trim,
                IgnoreBlankLines = true
            };

            return csvConfiguration;
        }
    }
}
