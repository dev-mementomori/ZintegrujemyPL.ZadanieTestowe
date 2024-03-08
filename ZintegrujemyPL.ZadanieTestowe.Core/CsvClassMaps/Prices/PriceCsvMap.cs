using CsvHelper.Configuration;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Converters.Csv;

namespace ZintegrujemyPL.ZadanieTestowe.Core.CsvClassMaps.Prices
{
    public class PriceCsvMap : ClassMap<PriceCsvModel>
    {
        public PriceCsvMap()
        {
            Map(x => x.ProductSKU).Index(1);
            Map(x => x.NettProductPriceAfterDiscountForProductLogisticUnit).Index(5)
                .TypeConverter<DecimalConverter>();
        }
    }
}
