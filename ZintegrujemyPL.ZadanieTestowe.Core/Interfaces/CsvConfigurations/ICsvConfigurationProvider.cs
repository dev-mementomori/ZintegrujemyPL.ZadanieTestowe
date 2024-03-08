using CsvHelper.Configuration;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations
{
    public interface ICsvConfigurationProvider
    {
        CsvConfiguration GetConfiguration();
    }
}
