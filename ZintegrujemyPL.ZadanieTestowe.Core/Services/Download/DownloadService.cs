using System.Net.Http;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Download;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.Download
{
    public class DownloadService : IDownloadService
    {
        private readonly HttpClient _httpClient;
        public DownloadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> DownloadText(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
