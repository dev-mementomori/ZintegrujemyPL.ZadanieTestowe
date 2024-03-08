using System;
using System.IO;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Files;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.Files
{
    public class FileWriterService : IFileWriterService
    {
        public async Task WriteDataToFile(string data, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteLineAsync(data);
            }
        }
    }
}