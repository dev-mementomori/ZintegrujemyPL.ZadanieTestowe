using CsvHelper.Configuration;
using ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Converters.Csv;

namespace ZintegrujemyPL.ZadanieTestowe.Core.CsvClassMaps.Inventories
{
    public class InventoryCsvMap : ClassMap<InventoryCsvModel>
    {
        public InventoryCsvMap()
        {
            Map(x => x.SKU).Index(1);
            Map(x => x.Unit).Index(2);
            Map(x => x.Quantity).Index(3)
                .TypeConverter<DecimalConverter>();
            Map(x => x.ShippingTime).Index(6);
            Map(x => x.ShippingCost).Index(7)
                .TypeConverter<DecimalConverter>();
        }
    }
}
