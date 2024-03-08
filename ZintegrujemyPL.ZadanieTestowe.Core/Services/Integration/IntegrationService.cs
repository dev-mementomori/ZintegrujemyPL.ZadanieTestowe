using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvReaders;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Download;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Files;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Integrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Validators.Integrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Settings;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Services.Integrations
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IntegrationSettings _integrationSettings;
        private readonly IDownloadService _downloadService;
        private readonly IFileWriterService _fileWriterService;
        private readonly IInventoryCsvReaderService _inventoryCsvReaderService;
        private readonly IProductCsvReaderService _productCsvReaderService;
        private readonly IPriceCsvReaderService _priceCsvReaderService;
        private readonly IProductRepository _productRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        private readonly IIntegrationSettingsValidator _integrationSettingsValidator;

        public IntegrationService(IntegrationSettings integrationSettings, IDownloadService downloadService, IFileWriterService fileWriterService, IProductCsvReaderService productCsvReaderService,
                    IInventoryCsvReaderService inventoryCsvReaderService, IPriceCsvReaderService priceCsvReaderService, IProductRepository productRepository, IPriceRepository priceRepository,
                    IInventoryRepository inventoryRepository, IMapper mapper, IIntegrationSettingsValidator integrationSettingsValidator)
        {
            _integrationSettings = integrationSettings;
            _downloadService = downloadService;
            _fileWriterService = fileWriterService;
            _productCsvReaderService = productCsvReaderService;
            _inventoryCsvReaderService = inventoryCsvReaderService;
            _priceCsvReaderService = priceCsvReaderService;
            _productRepository = productRepository;
            _priceRepository = priceRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _integrationSettingsValidator = integrationSettingsValidator;
        }

        public async Task Integrate()
        {
            try
            {
                _integrationSettingsValidator.Validate(_integrationSettings);
                await DownloadAndStoreFiles();
                await ProcessData();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task DownloadAndStoreFiles()
        {
            await DownloadAndStoreFile(_integrationSettings.Products.DownloadUrl, _integrationSettings.Products.GetFullPath());
            await DownloadAndStoreFile(_integrationSettings.Inventory.DownloadUrl, _integrationSettings.Inventory.GetFullPath());
            await DownloadAndStoreFile(_integrationSettings.Prices.DownloadUrl, _integrationSettings.Prices.GetFullPath());
        }

        private async Task DownloadAndStoreFile(string downloadUrl, string fullPath)
        {
            var fileData = await _downloadService.DownloadText(downloadUrl);

            if (fileData == null)
            {
                throw new Exception($"Integracja została przerwana, ponieważ nie można było pobrać pliku. Url: {downloadUrl}");
            }

            await _fileWriterService.WriteDataToFile(fileData, fullPath);
        }

        private async Task ProcessData()
        {
            var inventoriesShippedWithin24h = await GetInventoriesShippedWithin24h();
            var productsShippedWithin24h = await GetProductsShippedWithin24h(inventoriesShippedWithin24h);
            var prices = await _priceCsvReaderService.ReadList<PriceCsvModel>(_integrationSettings.Prices.GetFullPath());

            await DeleteOldAllData();
            await InsertNewData(productsShippedWithin24h, inventoriesShippedWithin24h, prices);
        }

        private async Task DeleteOldAllData()
        {
            await _productRepository.DeleteAll();
            await _priceRepository.DeleteAll();
            await _inventoryRepository.DeleteAll();
        }

        private async Task<List<InventoryCsvModel>> GetInventoriesShippedWithin24h()
        {
            var inventories = await _inventoryCsvReaderService.ReadList<InventoryCsvModel>(_integrationSettings.Inventory.GetFullPath());
            var inventoriesShippedWithin24h = inventories.Where(prp => prp.ShippingTime.Contains(_integrationSettings.ShippingTime, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return inventoriesShippedWithin24h;
        }

        private async Task<List<ProductCsvModel>> GetProductsShippedWithin24h(List<InventoryCsvModel> inventoriesShippedWithin24h)
        {
            var availableSKUs = new HashSet<string>(inventoriesShippedWithin24h.Select(item => item.SKU));
            var products = await _productCsvReaderService.ReadList<ProductCsvModel>(_integrationSettings.Products.GetFullPath());
            var productsShippedWithin24h = products.Where(prp => !prp.IsWire && availableSKUs.Contains(prp.SKU))
                .ToList();

            return productsShippedWithin24h;
        }

        private async Task InsertNewData(List<ProductCsvModel> products, List<InventoryCsvModel> inventories, List<PriceCsvModel> prices)
        {
            var productsMapped = _mapper.Map<List<Product>>(products);
            var inventoriesMapped = _mapper.Map<List<Inventory>>(inventories);
            var pricesMapped = _mapper.Map<List<Price>>(prices);

            await _productRepository.InsertMany(productsMapped);
            await _inventoryRepository.InsertMany(inventoriesMapped);
            await _priceRepository.InsertMany(pricesMapped);
        }
    }
}
