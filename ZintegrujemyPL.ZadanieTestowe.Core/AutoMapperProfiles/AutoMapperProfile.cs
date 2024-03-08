using AutoMapper;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Products;

namespace ZintegrujemyPL.ZadanieTestowe.Core.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductCsvModel, Product>();
            CreateMap<InventoryCsvModel, Inventory>();
            CreateMap<PriceCsvModel, Price>();
        }
    }
}
