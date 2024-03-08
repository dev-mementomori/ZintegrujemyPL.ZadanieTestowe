using CsvHelper.Configuration;
using System.Globalization;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvConfigurations
{
    public class CsvConfigurationProvider : ICsvConfigurationProvider
    {
        public CsvConfiguration GetConfiguration()
        {
            return new CsvConfiguration(CultureInfo.CurrentCulture);
        }
    }
}
