using System.Threading.Tasks;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Download
{
    public interface IDownloadService
    {
        Task<string> DownloadText(string url);
    }
}
