using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvReaders
{
    public interface ICsvReaderService
    {
        Task<List<T>> ReadList<T>(string filePath);
    }
}
