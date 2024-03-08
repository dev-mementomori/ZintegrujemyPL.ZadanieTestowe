using System;
using System.IO;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Validators.Integrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Settings;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Validators.Integrations
{
    public class IntegrationDescValidator : IIntegrationDescValidator
    {
        public void Validate(IntegrationDesc integrationDesc, string name = "")
        {
            if (integrationDesc == null)
            {
                throw new ArgumentNullException(nameof(integrationDesc), name + " IntegrationDesc nie może być null.");
            }

            if (string.IsNullOrWhiteSpace(integrationDesc.DownloadPath))
            {
                throw new ArgumentException(name + " - DownloadPath nie może być pusty.", nameof(integrationDesc.DownloadPath));
            }

            if (string.IsNullOrWhiteSpace(integrationDesc.FileName))
            {
                throw new ArgumentException(name + " - FileName nie może być pusty.", nameof(integrationDesc.FileName));
            }

            if (!Path.IsPathRooted(integrationDesc.DownloadPath))
            {
                throw new ArgumentException(name +  " - Podana ścieżka nie jest ścieżką absolutną.", nameof(integrationDesc.DownloadPath));
            }

            if (!Directory.Exists(integrationDesc.DownloadPath))
            {
                throw new ArgumentException(name + " - Podana ścieżka nie istnieje.", nameof(integrationDesc.DownloadPath));
            }

            if (!integrationDesc.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(name + " - Nazwa pliku musi kończyć się na '.csv'.", nameof(integrationDesc.FileName));
            }

            Uri uriResult;
            if (!Uri.TryCreate(integrationDesc.DownloadUrl, UriKind.Absolute, out uriResult))
            {
                throw new ArgumentException(name + " - Nieprawidłowy URL.", nameof(integrationDesc.DownloadUrl));
            }

            if (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException(name + " - Nieprawidłowy schemat URL.", nameof(integrationDesc.DownloadUrl));
            }
        }
    }
}
