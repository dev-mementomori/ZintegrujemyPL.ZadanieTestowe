using System.IO;
using System;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Settings
{
    public class IntegrationDesc
    {
        public string DownloadUrl { get; set; }
        public string DownloadPath { get; set; }
        public string FileName { get; set; }

        public string GetFullPath()
        {
            return Path.Combine(DownloadPath, FileName);
        }
    }
}
