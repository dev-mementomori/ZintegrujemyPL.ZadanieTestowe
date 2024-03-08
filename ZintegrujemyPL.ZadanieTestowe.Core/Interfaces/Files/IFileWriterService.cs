using System.Threading.Tasks;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Files
{
    public interface IFileWriterService
    {
        Task WriteDataToFile(string data, string filePath);
    }
}
