using CsvHelper;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvMappers
{
    public interface ICsvMapperService
    {
        void Configure(CsvContext csvContext);
    }
}
